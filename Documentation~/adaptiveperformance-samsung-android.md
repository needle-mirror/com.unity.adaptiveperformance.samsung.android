**_Adaptive Performance Samsung (Android) Guide_**

# About the Adaptive Performance Samsung (Android) package

The Adaptive Performance Samsung (Android) Provider is a subsystem for the [Adaptive Performance](https://docs.unity3d.com/Packages/com.unity.adaptiveperformance@latest/index.html) package, to extend Adaptive Performance to Samsung Android devices. It transmits device-specific information to the Adaptive Performance package, and enables you to receive data about the thermal state of a Samsung Android device.

This package also provides access to a Variable Refresh Rate API that is supported by newer Samsung devices with high refresh rate displays.

# Installing the Adaptive Performance Samsung (Android) package

Use the [Unity Package Manager](https://docs.unity3d.com/Packages/com.unity.package-manager-ui@latest/index.html) to install the **Adaptive Performance Samsung (Android)** package, which includes the Samsung (Android) subsystem for Adaptive Performance.  

Unity automatically installs the Adaptive Performance package as a dependency of the Adaptive Performance Samsung (Android) package. You can use Adaptive Performance as soon as installation through the Package Manager completes. 

## Quick Setup Guide

* Install **Android Support** for Unity. Unity needs Android Support to build to your Samsung device.
* **Switch Platform** to Android in the **Build Settings** window.
* Use the Unity Package Manager and install the **Adaptive Performance Samsung (Android)** package which includes the subsystem. The Unity Package Manager then automatically installs the Adaptive Performance package as a dependency for you as well.
* When you build and deploy the app to your device, Adaptive Performance will be active by default. 

**Note:** To enable Adaptive Performance log messages in development builds, change `UnityEngine.AdaptivePerformance.StartupSettings.Logging` to `true`. Adaptive Performance then starts printing status information to the console. 

# Using the Adaptive Performance Samsung (Android) subsystem

This subsystem is only a data provider for Adaptive Performance, and has no user-facing APIs. The Adaptive Performance package includes all functionality. For details, see the [Adaptive Performance](https://docs.unity3d.com/Packages/com.unity.adaptiveperformance@latest/index.html) documentation.

# Variable Refresh Rate
The Variable Refresh Rate API allows you to change the current display refresh rate.
The API provides `IVariableRefreshRate.SupportedRefreshRates`, an array of display refresh rates that are supported by the device.
You can change the current refresh rate by calling `IVariableRefreshRate.SetRefreshRateByIndex` with a valid index for the array of supported refresh rates.
Please note that the supported refresh rates depend on the model of the phone, Android Display Settings and application specific settings made in Samsung Game Launcher.

The Variable Refresh Rate API is supported  on all devices where `UnityEngine.AdaptivePerformance.Samsung.Android.VariableRefreshRate.Instance` is not `null`.

In case the current refresh rate or the list of supported refresh rate changes because of an external event the `IVariableRefreshRate.RefreshRateChanged` event is triggered. This can happen when a user is making changes to the Display Settings.

The Unity core API `Screent.currentResolution.refreshRate` is automatically updated once a new refresh rate is realized. This may happen with a delay, so it is not recommended to cache the value of `Screent.currentResolution.refreshRate` in your application.

# Technical details
## Device Support

This version of the Adaptive Performance Samsung (Android) package is compatible with Unity Editor versions 2018 LTS and later (2019 LTS and later recommended).

Adaptive Performance Samsung (Android) currently supports the following Samsung devices running Android Pie:

* Galaxy S10
* Note 10
* Galaxy Tab S6
* Galaxy Fold

It supports those devices with Samsung GameSDK 1.5 and 1.6.

Adaptive Performance Samsung (Android) currently supports the following Samsung devices running Android 10:

* All old and new Samsung Galaxy models

It supports those devices with Samsung GameSDK 3.0+.

Variable Refresh Rate is currently only supported on Galaxy S20.

## Samsung GameSDK

Adaptive Performance prints the version of the Samsung GameSDK used in the Adaptive Performance Samsung (Android) subsystem to the console during startup when you enable logging:

```
Adaptive Performance: Subsystem version=1.6
```

## Document revision history
This section includes the revision history of the document. The revision history tracks when a document is created, edited, and updated. If you create or update a document, you must add a new row describing the revision. The Documentation Team also uses this table to track when a document is edited and its editing level.
 
|Date|Reason|
|---|---|
|January 22, 2020|Device Support section updated.|
|July 04, 2019|Chief Technical Editor reviewed.|
|June 21, 2019|Technical Writer reviewed.|
|June 19, 2019|Document created. Work in progress for initial release.|
