using UnityEngine;
using UnityEngine.AdaptivePerformance;

namespace UnityEngine.AdaptivePerformance.Samsung.Android
{
    /// <summary>
    /// Provider Settings for Samsung Android Provider which controls the runtime asset instance which stores the Settings.
    /// </summary>
    [System.Serializable]
    [AdaptivePerformanceConfigurationData("Samsung (Android)", SamsungAndroidProviderConstants.k_SettingsKey)]
    public class SamsungAndroidProviderSettings : IAdaptivePerformanceSettings
    {
        [SerializeField, Tooltip("Enable Logging in Devmode")]
        bool m_SamsungProviderLogging = false;

        /// <summary>
        ///  Control debug logging of the Samsung provider.
        ///  This setting only affects development builds. All logging is disabled in release builds.
        ///  The global logging setting can also be controlled after startup using <see cref="IDevelopmentSettings.Logging"/>.
        ///  Logging is disabled by default.
        /// </summary>
        /// <value>`true` to enable debug logging, `false` to disable it (default: `false`)</value>
        public bool samsungProviderLogging
        {
            get { return m_SamsungProviderLogging; }
            set { m_SamsungProviderLogging = value; }
        }

        /// <summary>Static instance that will hold the runtime asset instance we created in our build process.</summary>
        /// <see cref="SamsungAndroidProviderBuildProcess"/>
#if !UNITY_EDITOR
        public static SamsungAndroidProviderSettings s_RuntimeInstance = null;
#endif
        void Awake()
        {
#if !UNITY_EDITOR
            s_RuntimeInstance = this;
#endif
        }

        /// <summary>
        /// Returns Android Provider Settings which are used by Adaptive Performance to apply Provider Settings.
        /// </summary>
        /// <returns>Android Provider Settings</returns>
        public static SamsungAndroidProviderSettings GetSettings()
        {
            SamsungAndroidProviderSettings settings = null;
#if UNITY_EDITOR
            UnityEditor.EditorBuildSettings.TryGetConfigObject<SamsungAndroidProviderSettings>(SamsungAndroidProviderConstants.k_SettingsKey, out settings);
#else
            settings = s_RuntimeInstance;
#endif
            return settings;
        }
    }
}
