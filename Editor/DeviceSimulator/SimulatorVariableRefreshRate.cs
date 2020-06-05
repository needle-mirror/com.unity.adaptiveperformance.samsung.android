using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.AdaptivePerformance.Samsung.Android;

namespace UnityEditor.AdaptivePerformance.Simulator.Editor
{
    /// <summary>
    /// Describes the simulated Motion smoothness value in Android Display settings.
    /// </summary>
    public enum AndroidDisplayRefreshRate
    {
        /// <summary>
        /// Allow high speed refresh rates with a minimum of 60 Hz.
        /// </summary>
        HighSpeed,

        /// <summary>
        /// Only allow standard refresh rates. 60 Hz and below.
        /// </summary>
        Standard
    }

    /// <summary>
    /// Interface of the Samsung Variable Refresh Rate API for use with the Device Simulator
    /// </summary>
    public interface IVariableRefreshRateSimulator : IVariableRefreshRate
    {
        /// <summary>
        /// Sets the simulated display refresh mode.
        /// </summary>
        /// <param name="rate">The display mode to set.</param>
        void SetAndroidDisplayRefreshRate(AndroidDisplayRefreshRate rate);
    }

    internal class VRRManagerSimulator : IVariableRefreshRateSimulator
    {
        int[] m_SupportedRefreshRates = new int[0];
        int m_CurrentRefreshRate = -1;

        AndroidDisplayRefreshRate m_DisplayRefreshRateMode = AndroidDisplayRefreshRate.HighSpeed;
        readonly int[] m_StandardRefreshRates = { 60, 48 };
        readonly int[] m_HighResolutionRefreshRates = { 120, 96, 60 };

        private int[] GetSupportedRefreshRates()
        {
            switch (m_DisplayRefreshRateMode)
            {
                case AndroidDisplayRefreshRate.HighSpeed:
                    return m_HighResolutionRefreshRates;
                case AndroidDisplayRefreshRate.Standard:
                    return m_StandardRefreshRates;
            }

            return null;
        }

        private void UpdateRefreshRateInfo()
        {
            m_SupportedRefreshRates = GetSupportedRefreshRates();
        }

        public VRRManagerSimulator()
        {
            UpdateRefreshRateInfo();
        }

        public int[] SupportedRefreshRates { get { return m_SupportedRefreshRates; } }
        public int CurrentRefreshRate { get { return m_CurrentRefreshRate; } }

        public void SetAndroidDisplayRefreshRate(AndroidDisplayRefreshRate rate)
        {
            m_DisplayRefreshRateMode = rate;
            UpdateRefreshRateInfo();
            RefreshRateChanged.Invoke();
        }

        public bool SetRefreshRateByIndex(int index)
        {
            if (index < 0 && index >= SupportedRefreshRates.Length)
                return false;
            m_CurrentRefreshRate = SupportedRefreshRates[index];
            RefreshRateChanged.Invoke();
            return true;
        }

        public event VariableRefreshRateEventHandler RefreshRateChanged;
    }
}
