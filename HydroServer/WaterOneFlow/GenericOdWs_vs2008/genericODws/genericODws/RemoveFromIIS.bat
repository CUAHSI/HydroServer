@echo off
call "%PROGRAMFILES%\Microsoft Visual Studio 8\VC\vcvarsall.bat" x86

set /p ConfigName= Name of Your Configuration (less the .config) 

@echo on

"%systemroot%\Microsoft.NET\Framework\v3.5\msbuild.exe" Installer.targets /v:quiet /t:Undeploy /p:Environment=%ConfigName%

set /p return= HIT RETURN TO EXIT