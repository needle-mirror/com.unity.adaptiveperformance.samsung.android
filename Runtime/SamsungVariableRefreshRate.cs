namespace UnityEngine.AdaptivePerformance.Samsung.Android
{
    /// <summary>
    /// Event handler declaration.
    /// </summary>
    public delegate void VariableRefreshRateEventHandler();

    /// <summary>
    /// Interface of the Samsung Variable Refresh Rate API
    /// </summary>
    public interface IVariableRefreshRate
    {
        /// <summary>
        /// List of supported display refresh rates.
        /// </summary>
        int[] SupportedRefreshRates { get; }

        /// <summary>
        /// The current display refresh rate.
        /// </summary>
        int CurrentRefreshRate { get; }

        /// <summary>
        /// Change the current display refresh rate to the value references by the given index into the list of supported refresh rates.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>`true` if the display refresh rate was updated successfully, false otherwise. Returns false if the requested refresh rate is larger as the Application.targetFrameRate. Please note the the actual change of the refresh rate and the value of `Screen.currentResolution.refreshRate` is updated with a delay.</returns>
        bool SetRefreshRateByIndex(int index);

        /// <summary>
        /// Event that is called if the current display refresh rate or the list of supported refresh rate is changed externally, e.g. by changing display settings.
        /// </summary>
        event VariableRefreshRateEventHandler RefreshRateChanged;
    }

    /// <summary>
    /// Holds the global instance to the Variable Refresh Rate API
    /// </summary>
    public static class VariableRefreshRate
    {
        /// <summary>
        /// Global instance to access the variable refresh API.
        /// May be null if variable refresh rate is not supported.
        /// </summary>
        static public IVariableRefreshRate Instance { get; set; }
    }
}
