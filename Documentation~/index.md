# About the Adaptive Performance Samsung (Android) package

The Adaptive Performance Samsung (Android) provider is a subsystem for [Adaptive Performance](https://docs.unity3d.com/Packages/com.unity.adaptiveperformance@latest/index.html) to extend Adaptive Performance to Samsung Android devices. It transmits device-specific information to the Adaptive Performance system and enables you to receive data about the thermal state of a Samsung Android device.

This package also provides access to a [Variable Refresh Rate](vrr.md) API that is supported by newer Samsung devices with high refresh rate displays.
## Installation

Use the [Unity Package Manager](https://docs.unity3d.com/Packages/com.unity.package-manager-ui@latest/index.html) to install the **Adaptive Performance Samsung (Android)** package. Unity automatically installs the Adaptive Performance 2.0.0-preview package as a dependency of the Adaptive Performance Samsung (Android) package.

To use the Adaptive Performance Samsung (Android) provider you need to install the Adaptive Performance package and activate the provider in the Adaptive Performance section of the **Project Settings** window. For more information, see [Adaptive Performance package documentation](https://docs.unity3d.com/Packages/com.unity.adaptiveperformance@latest/index.html).

For information on what's new in the latest version of Adaptive Performance Samsung (Android), see the [Changelog](../changelog/CHANGELOG.html).

## Device support

This version of the Adaptive Performance Samsung (Android package) is compatible with Unity Editor versions 2019 LTS and later (2020.2 and later recommended).

Adaptive Performance Samsung (Android) currently supports the following Samsung devices running Android 9:

* Galaxy S10
* Note 10
* Galaxy Tab S6
* Galaxy Fold

It supports those devices with Samsung GameSDK 1.5 and 1.6.

Adaptive Performance Samsung (Android) currently supports the following Samsung devices running Android 10:

* All old and new Samsung Galaxy models

It supports those devices with Samsung GameSDK 3.2+.

[Variable Refresh Rate](vrr.md) is currently only supported on Galaxy S20.

## Samsung GameSDK

When you enable logging, Adaptive Performance prints the version of the Samsung GameSDK used in the Adaptive Performance Samsung Android subsystem to the console during startup. For example:

```
Adaptive Performance: Subsystem version=3.2
```
