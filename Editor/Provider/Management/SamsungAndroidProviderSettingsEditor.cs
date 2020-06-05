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

        static GUIContent s_SamsungProviderLoggingLabel = EditorGUIUtility.TrTextContent("Samsung Provider Logging", "Only active in development mode.");

        SerializedProperty m_SamsungProviderLoggingProperty;

        /// <summary>
        /// Override of Editor callback to display custom settings.
        /// </summary>
        public override void OnInspectorGUI()
        {
            if (!DisplayBaseSettingsBegin())
                return;

            if (m_SamsungProviderLoggingProperty == null)
                m_SamsungProviderLoggingProperty = serializedObject.FindProperty(k_SamsungProviderLogging);

            BuildTargetGroup selectedBuildTargetGroup = EditorGUILayout.BeginBuildTargetSelectionGrouping();

            if (selectedBuildTargetGroup == BuildTargetGroup.Android)
            {
                EditorGUIUtility.labelWidth = 170; // some property labels are cut-off
                DisplayBaseRuntimeSettings();

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
                EditorGUILayout.HelpBox("Adaptive Performance Samsung Android settings not available on this platform.", MessageType.Info);
                EditorGUILayout.Space();
            }
            DisplayBaseSettingsEnd();
        }
    }
}
