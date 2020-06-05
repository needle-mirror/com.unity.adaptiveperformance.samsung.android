using UnityEngine;
using UnityEditor.AdaptivePerformance.Editor;

using UnityEngine.AdaptivePerformance.Samsung.Android;

namespace UnityEditor.AdaptivePerformance.Samsung.Android.Editor
{
    /// <summary>
    /// This is custom Editor for Samsung Android Provider Settings.
    /// </summary>
    [CustomEditor(typeof(SamsungAndroidProviderSettings))]
    public class SamsungAndroidProviderSettingsEditor : ProviderSettingsEditor
    {
        const string k_SamsungProviderLogging = "m_SamsungProviderLogging";
        const string k_AutomaticVRR = "m_AutomaticVRR";
        const string k_HighSpeedVRR = "m_HighSpeedVRR";

        static GUIContent s_SamsungProviderLoggingLabel = EditorGUIUtility.TrTextContent(L10n.Tr("Samsung Provider Logging"), L10n.Tr("Only active in development mode."));
        static GUIContent s_AutomaticVRRLabel = EditorGUIUtility.TrTextContent(L10n.Tr("Automatic VRR"), L10n.Tr("Enable Automatic Variable Refresh Rate. Only enabled if VRR is supported on the target device."));
        static GUIContent s_HighSpeedVRRLabel = EditorGUIUtility.TrTextContent(L10n.Tr("High-Speed VRR"), L10n.Tr("Allow High-Speed Variable Refresh Rate. It is required if you want to use variable refresh rates higher than 60hz. Can increase device temperature when activated."));

        static string s_UnsupportedInfo = L10n.Tr("Adaptive Performance Samsung Android settings not available on this platform.");
        static string s_HighSpeedVRRInfo = L10n.Tr("High-Speed VRR can increase device temperature.");
        static string s_AutoVRRInfo = L10n.Tr("Auto VRR only works with V-Sync disabled which is currently enalbed. See QualitySettings.vSyncCount in the Quality Settings window for more information.");

        SerializedProperty m_SamsungProviderLoggingProperty;
        SerializedProperty m_AutomaticVRRProperty;
        SerializedProperty m_HighSpeedVRRProperty;

        /// <summary>
        /// Override of Editor callback to display custom settings.
        /// </summary>
        public override void OnInspectorGUI()
        {
            if (!DisplayBaseSettingsBegin())
                return;

            if (m_SamsungProviderLoggingProperty == null)
                m_SamsungProviderLoggingProperty = serializedObject.FindProperty(k_SamsungProviderLogging);
            if (m_AutomaticVRRProperty == null)
                m_AutomaticVRRProperty = serializedObject.FindProperty(k_AutomaticVRR);
            if (m_HighSpeedVRRProperty == null)
                m_HighSpeedVRRProperty = serializedObject.FindProperty(k_HighSpeedVRR);

            BuildTargetGroup selectedBuildTargetGroup = EditorGUILayout.BeginBuildTargetSelectionGrouping();

            if (selectedBuildTargetGroup == BuildTargetGroup.Android)
            {
                EditorGUIUtility.labelWidth = 180; // some property labels are cut-off
                DisplayBaseRuntimeSettings();
                if (m_ShowRuntimeSettings)
                {
                    EditorGUI.indentLevel++;
                    if (m_HighSpeedVRRProperty.boolValue)
                    {
                        EditorGUILayout.HelpBox(s_HighSpeedVRRInfo, MessageType.Warning);
                    }
                    EditorGUILayout.PropertyField(m_HighSpeedVRRProperty, s_HighSpeedVRRLabel);
                    if (QualitySettings.vSyncCount > 0)
                    {
                        EditorGUILayout.HelpBox(s_AutoVRRInfo, MessageType.Info);
                        GUI.enabled = false;
                    }
                    EditorGUILayout.PropertyField(m_AutomaticVRRProperty, s_AutomaticVRRLabel);
                    GUI.enabled = true;
                    EditorGUI.indentLevel--;
                }

                EditorGUILayout.Space();

                DisplayBaseDeveloperSettings();
                if (m_ShowDevelopmentSettings)
                {
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(m_SamsungProviderLoggingProperty, s_SamsungProviderLoggingLabel);
                    EditorGUI.indentLevel--;
                }
            }
            else
            {
                EditorGUILayout.HelpBox(s_UnsupportedInfo, MessageType.Info);
                EditorGUILayout.Space();
            }
            DisplayBaseSettingsEnd();
        }
    }
}