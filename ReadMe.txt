------------------------------------------------------------
 B5L Sample code for get temperature.  (for C#)
------------------------------------------------------------

(1) Contents
  This code provides B5L(3D TOF Sensor Module) C# sample code for get temperature.

  "Get LED Temperature command" and "Get imager Temperature command" can be executed during measurement only.
  Device error(F7h) occurred and measurement will not be able to start, if these commands are executed
  before execution of "Start measurement command."
  (It is necessary to power on the B5L again or reboot B5L by "Software reset command" in such kind of error situation.)

  This sample code is an example of getting temperature during measurement.
  The outline of processing flow is as follows.
  (Refer to source code about detail information.)

    (a) Execute "Start measurement command."
    (b) Execute "Get imager temperature command" and "Get LED temperature command" alternately.
    (c) If the imager temperature is more than "Stop Temperature(imager)" or LED temperature is more than "Stop Temperature(LED)",
        execute "Stop measurement command" (cooling down the B5L)
    (d) After waiting a time specified as "Time Interval", execute "Start measurement command", and then execute "Get imager temperature command",
        "Get LED temperature command."
        If the imager temperature is less than "Start Temperature(imager)" and LED temperature is less than "Start Temperature(LED)", go back to (b).
        Otherwise, execute "Stop measurement command" and then repeat (d).

     * "Stop Temperature(imager)", "Stop Temperature(LED)", "Start Temperature(LED)", "Start Temperature(LED)"
       and "Time Interval" are arbitrary value set in sample code.

(2) File description
  The following files exist in the TOFSensorSampleGetTemperature/ folder.

    bin/                                    Output directory for building
    Properties/                             Data storage directory of project settings
    FormMain.cs                             Sample code main
    FormMain.Designer.cs                    Form screen design definition file
    FormMain.resx                           Form screen XML resource file
    Program.cs                              The main entry point for the application.
    TOFCommand.cs                           Command class
    TOFSensorSampleGetTemperature.csproj    Project file.
    TOFSerialPort.cs                        Serial Port connect/disconnect/send/receive class

(3) Building method for sample code
  1. The sample code is built to be operated on Windows 10.
     It can be compiled and linked with Visual Studio 2015(C#.NET).
  2. The exe file is generated under TOFSensorSampleGetTemperature/bin after compilation.
     .NET Framework 4.5 or later is required in execution.
     (Refer to "ExecutableFileDescription.pdf" for detail ifromation about exe file)


[NOTES ON USAGE]
* This sample code and documentation are copyrighted property of OMRON Corporation
* This sample code does not guarantee proper operation
* This sample code is distributed in the Apache License 2.0.

----
OMRON Corporation 
Copyright 2020 OMRON Corporation, All Rights Reserved.