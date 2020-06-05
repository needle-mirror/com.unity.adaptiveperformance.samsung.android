// device simulator is in core unity with Unity 2020.2, before that it's supported via packages.
#if DEVICE_SIMULATOR_ENABLED //|| UNITY_2020_2_OR_NEWER - not landed in trunk yet, do not enable
using System;
using System.Collections.Generic;
#if DEVICE_SIMULATOR_ENABLED
using Unity.DeviceSimulator;
#else
using UnityEditor.DeviceSimulator;
#endif
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEditor.AdaptivePerformance.Simulator.Editor;
using UnityEngine.AdaptivePerformance.Samsung.Android;

namespace UnityEditor.AdaptivePerformance.Samsung.Android.Editor
{
    public class AdaptivePerformanceVRRUIExtension :
        #if DEVICE_SIMULATOR_ENABLED
        IDeviceSimulatorExtension
        #else
        DeviceSimulatorExtension
        #endif
        , ISerializationCallbackReceiver
    {
#if !DEVICE_SIMULATOR_ENABLED
        override
#endif
        public string extensionTitle { get { return "Adaptive Performance Samsung"; } }

        VisualElement m_ExtensionFoldout;
        Foldout m_VrrFoldout;
        PopupField<string> m_DisplaySetting;
        PopupField<string> m_SupportedModes;
        SimulatorAdaptivePerformanceSubsystem m_Subsystem;
        List<string> m_HighModes = new List<string> { "120", "96", "60" };
        List<string> m_StandardModes = new List<string> { "60", "48" };
        VRRManagerSimulator m_vrrManager = new VRRManagerSimulator();

        [SerializeField, HideInInspector]
        AdaptivePerformanceStates m_SerializationStates;

#if DEVICE_SIMULATOR_ENABLED
        public void OnExtendDeviceSimulator(VisualElement visualElement)
        {
            m_ExtensionFoldout = visualElement;
#else
        override public VisualElement OnCreateExtensionUI()
        {
            m_ExtensionFoldout = new VisualElement();
#endif
            VariableRefreshRate.Instance = m_vrrManager;

            var tree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Packages/com.unity.adaptiveperformance.samsung.android/Editor/DeviceSimulator/AdaptivePerformanceExtension.uxml");
            m_ExtensionFoldout.Add(tree.CloneTree());

            m_VrrFoldout = m_ExtensionFoldout.Q<Foldout>("vrr");
            m_VrrFoldout.value = m_SerializationStates.vrrFoldout;

            var choices = new List<string> {"120", "60"};
            m_DisplaySetting = new PopupField<string>("Display Setting", choices, 0);
            m_VrrFoldout.Add(m_DisplaySetting);

            AddSupportedModesPopup(m_DisplaySetting.index);

            m_DisplaySetting.RegisterCallback<ChangeEvent<string>>(evt =>
            {
                if (m_vrrManager == null)
                    return;

                m_VrrFoldout.Remove(m_SupportedModes);

                AddSupportedModesPopup(m_DisplaySetting.index);

                m_vrrManager.SetAndroidDisplayRefreshRate((AndroidDisplayRefreshRate)m_DisplaySetting.index);
            });

#if !DEVICE_SIMULATOR_ENABLED
            return m_ExtensionFoldout;
#endif
        }

        void AddSupportedModesPopup(int displaySettingIndex)
        {
            switch (m_DisplaySetting.index)
            {
                case 0:
                    m_SupportedModes = new PopupField<string>("Supported Modes", m_HighModes, 0);
                    break;
                case 1:
                    m_SupportedModes = new PopupField<string>("Supported Modes", m_StandardModes, 0);
                    break;
            }
            m_VrrFoldout.Add(m_SupportedModes);

            m_SupportedModes.RegisterCallback<ChangeEvent<string>>(evt =>
            {
                if (VariableRefreshRate.Instance == null)
                    return;

                VariableRefreshRate.Instance.SetRefreshRateByIndex(m_SupportedModes.index);
            });
        }

        [System.Serializable]
        internal struct AdaptivePerformanceStates
        {
            public bool vrrFoldout;
        };

        public void OnBeforeSerialize()
        {
            m_SerializationStates.vrrFoldout = m_VrrFoldout.value;
        }

        public void OnAfterDeserialize() {}
    }
}
#endif
