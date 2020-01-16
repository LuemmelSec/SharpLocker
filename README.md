# SharpLocker

SharpLocker helps get current user credentials by popping a fake Windows lock screen, ~~all output is sent to Console which works perfect for Cobalt Strike.~~

This for transforms the legacy SharpLocker Application into a NET ClassLibrary (dll), which exports the method:

```
String SharpLockerLib.Runner.Run()
```

The returned `String` represents the input to the password field.

The purpose is to allow integration of the pre-compiled NET binary into PowerShell payloads.

## Works
* Single/Multiple Monitors
* Windows 10
* Main monitor needs to be 1080p otherwise the location of the elements are wrong

## In Progress
* Backwards compatability for Win 7
* All resolution support


![Working SharpLocker](https://github.com/mame82/SharpLocker/blob/master/sharplocker.png?raw=true)
