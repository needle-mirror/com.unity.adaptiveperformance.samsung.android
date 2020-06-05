using System;
using UnityEngine.AdaptivePerformance.Samsung.Android;

namespace UnityEngine.AdaptivePerformance
{
    /// <summary>
    /// A scaler used by <see cref="AdaptivePerformanceIndexer"/> to adjust the rendering rate using Variable Refresh Rate <see cref="VariableRefreshRate"/>.
    /// </summary>
    public class VariableRefreshRateScaler : AdaptiveFramerate
    {
        IVariableRefreshRate m_VRR;
        int m_CurrentRefreshRateIndex;

        /// <summary>
        /// Override for Awake in the base class to set up for Variable Refresh Rate.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            m_VRR = VariableRefreshRate.Instance;
            m_VRR.RefreshRateChanged += RefreshRateChanged;
            m_CurrentRefreshRateIndex = Array.IndexOf(m_VRR.SupportedRefreshRates, m_VRR.CurrentRefreshRate);
        }

        void OnDestroy()
        {
            m_VRR.RefreshRateChanged -= RefreshRateChanged;
        }

        void RefreshRateChanged()
        {
            m_CurrentRefreshRateIndex = Array.IndexOf(m_VRR.SupportedRefreshRates, m_VRR.CurrentRefreshRate);
        }

        /// <summary>
        /// Callback for when the performance level is increased.
        /// </summary>
        protected override void OnLevelIncrease()
        {
            if (m_CurrentRefreshRateIndex > 0)
            {
                var rateIndex = m_CurrentRefreshRateIndex - 1;
                var fps = m_VRR.SupportedRefreshRates[rateIndex];

                if (fps < minimumFPS || fps > maximumFPS)
                    return;
                if (m_VRR.SetRefreshRateByIndex(rateIndex))
                    m_CurrentRefreshRateIndex = rateIndex;
            }
        }

        /// <summary>
        /// Callback for when the performance level is decreased.
        /// </summary>
        protected override void OnLevelDecrease()
        {
            if (m_CurrentRefreshRateIndex < m_VRR.SupportedRefreshRates.Length - 1)
            {
                var rateIndex = m_CurrentRefreshRateIndex + 1;
                var fps = m_VRR.SupportedRefreshRates[rateIndex];

                if (fps < minimumFPS || fps > maximumFPS)
                    return;
                if (m_VRR.SetRefreshRateByIndex(rateIndex))
                    m_CurrentRefreshRateIndex = rateIndex;
            }
        }
    }
}
