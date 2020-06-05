**_Adaptive Performance VRR Guide_**

# Variable Refresh Rate
The Variable Refresh Rate API allows you to change the current display refresh rate. The API provides `IVariableRefreshRate.SupportedRefreshRates`, an array of display refresh rates that are supported by the device. You can change the current refresh rate by calling `IVariableRefreshRate.SetRefreshRateByIndex` with a valid index for the array of supported refresh rates. Please note that the supported refresh rates depend on the model of the phone, Android Display Settings and application specific settings made in Samsung Game Launcher.

The Variable Refresh Rate API is supported on all devices where `UnityEngine.AdaptivePerformance.Samsung.Android.VariableRefreshRate.Instance` is not `null`.

In case the current refresh rate or the list of supported refresh rate changes because of an external event the `IVariableRefreshRate.RefreshRateChanged` event is triggered. This can happen when a user is making changes to the Display Settings.

The Unity core API `Screent.currentResolution.refreshRate` is automatically updated once a new refresh rate is realized. This may happen with a delay, so it is not recommended to cache the value of `Screent.currentResolution.refreshRate` in your application.

# Technical details

## Unity Support

This version of VRR is compatible with Unity Editor versions 2019 LTS and later.

* Unity 2020.2.0a7+
* Unity 2020.1.0b5+
* Unity 2019.3.11f1+

## Device Support

Variable Refresh Rate is currently only supported on following devices:

- Galaxy S20 with GameSDK 3.2 (April 2020 update).
