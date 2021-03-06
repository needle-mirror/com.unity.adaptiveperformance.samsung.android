# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.1.10] - 2021-02-05

### Changed
- Fix issues where skin temperature was used on Game SDK 1.5 devices instead of PST to send initial temperature warning when devices are hot. 
- Updated GameSDK wrapper to latest version which enhances GPU frametime information.

## [1.1.9] - 2020-07-23

### Changed
- Exchanged GameSDK wrapper with updated version removing GameSDK 3.1 support.
- Thermal Mitigation Logic changes in GameSDK 3.2 and it was updated in SetFreqLevels() to react to the correct return values.
- Thermal Mitigation Logic sets Automatic Performance Control to System when not available and releases when it reaches norminal temperature levels.
- Automatic Performance Control does not lower CPU lower than 1 on GameSDK 3.2 workaround.
- Add workaround to send temperature warning when the device starts as warm already as currently no events are sent.

## [1.1.7] - 2020-05-07

### Changed
- Adaptive Performance needs to re-initialize GameSDK on resume application because some Android onForegroundchange() APIs do not detect the change (e.g. bixby) and cause Adaptive Performance to not get valid data anymore.

## [1.1.6] - 2020-04-29

### Changed
- GameSDK 3.2 uses a wider range of temperature levels and maximum temperature level is changed to level 10.
- GameSDK 3.2 has a different behaviour when setting frequency levels and warning level 2 (throttling) is reached and you are always in control of the CPU/GPU level.

## [1.1.4] - 2020-03-26

### Removed
- Game SDK 3.1 initialization due to issues in GameSDK 3.1. Any other GameSDK version is still supported.

## [1.1.3] - 2020-03-18

### Fixed
- Avoids that callbacks in GameSDK 3.1, such as Listener.onHighTempWarning(), are not called when onRefreshRateChanged() is not implemented. This is only present on devices supporting VRR

### Changed
-With GameSDK 3.1 it's not necessary to (un)register listeners during OnPause and OnResume as it's handled in the GameSDK

## [1.1.2] - 2020-03-13

### Added
- Updated GameSDK from 3.0 to 3.1

### Fixed
- Avoid onRefreshRateChanged() crash on S20 during Motion smoothness change (60Hz <-> 120Hz) while app is in background and resumed

### Improvement
- GameSDK 3.1 introduced setFrequLevel callback for temperature mitigation to avoid overheating when no additional scale factors are used. This replaces SetLevelWithScene in GameSDK 3.1

## [1.1.1] - 2020-02-13

### Changed
- Package name from AP Samsung Android to Adaptive Performance Samsung Android as the Unity Package Manager naming limit was raised to 50 characters

## [1.1.0] - 2020-01-30

### Fixed
- Compatibility with .net 3.5 in Unity 2018.4

## [1.0.1] - 2019-08-29

### Changed
- Compatibility with Subsystem API changes in Unity 2019.3

## [1.0.0] - 2019-08-19

### Added
- Support for Samsung GameSDK 3.0

## [0.2.0-preview.1] - 2019-06-19

### This is the first preview release of the *Adaptive Performance Samsung (Android)* package for *Adaptive Performance* which was integrated within Adaptive Performance previously.
