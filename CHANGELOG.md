# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.1.3] - 2020-03-18

### Bugfix - which avoids that callbacks in GameSDK 3.1, such as Listener.onHighTempWarning(), are not called when onRefreshRateChanged() is not implemented. This is only present on devices supporting VRR
### Improvement - with GameSDK 3.1 it's not necessary to (un)register listeners during OnPause and OnResume as it's handled in the GameSDK

## [1.1.2] - 2020-03-13

### Update - to GameSDK 3.1 
### Bugfix - which avoid onRefreshRateChanged() crash on S20 during Motion smoothness change (60Hz <-> 120Hz) while app is in background and resumed
### Improvement - with GameSDK 3.1 SetFrequLevel callback for temperature mitigation to avoid overheating when no additional scale factors are used. This replaces SetLevelWithScene in GameSDK 3.1   

## [1.1.1] - 2020-02-13

### Update package name from AP to Adaptive Performance as the Unity Package Manager naming limit was raised to 50 characters

## [1.1.0] - 2020-01-30

### Fix compatibility with .net 3.5 in Unity 2018.4

## [1.0.1] - 2019-08-29

### Compatibility with Subsystem API changes in Unity 2019.3

## [1.0.0] - 2019-08-19

### Add support for Samsung GameSDK 3.0

## [0.2.0-preview.1] - 2019-06-19

### This is the first preview release of the *Adaptive Performance Samsung (Android)* package for *Adaptive Performance* which was integrated within Adaptive Performance previously.
