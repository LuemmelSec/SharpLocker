# SharpLocker

SharpLocker helps get current user credentials by popping a fake Windows lock screen, ~~all output is sent to Console which works perfect for Cobalt Strike.~~

This for transforms the legacy SharpLocker Application into a NET ClassLibrary (dll), which exports the method:

```
String SharpLockerLib.Runner.Run()
```

The returned `String` represents the input to the password field.

Additionally the method could be invoked with the path of the current user's LockScreen background image (the profile image is determined automatically).
The path to the background image could be requested utilizing the UWP namespace `Windows.System.Userprofile` like this from PowerShell:

```
[Windows.System.UserProfile.LockScreen,Windows.System.UserProfile,ContentType=WindowsRuntime] | Out-Null
[SharpLockerLib.Runner]::Run([Windows.System.UserProfile.LockScreen]::OriginalImageFile.AbsolutePath)
```


The purpose is to allow integration of the pre-compiled NET binary into PowerShell payloads.

## Works
* Single/Multiple Monitors
* Windows 10
* Main monitor needs to be 1080p otherwise the location of the elements are wrong

## In Progress
* ~~Backwards compatability for Win 7~~ 
* ~~All resolution support~~

Reworked look (15KB NET Assembly):

![Working SharpLocker](https://raw.githubusercontent.com/mame82/SharpLocker/netassembly/sharplocker_reworked.png)


Old look:

![Working SharpLocker](https://github.com/mame82/SharpLocker/blob/master/sharplocker.png?raw=true)
