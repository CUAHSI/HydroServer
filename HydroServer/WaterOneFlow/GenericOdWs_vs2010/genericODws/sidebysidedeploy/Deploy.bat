
SET BUILD_NUMBER=1000
SET YOUR_REMOTE_SERVER=YourRemoteServerName
SET YOUR_REMOTE_USER=YourRemoteUserName
SET YOUR_REMOTE_PASSWORD=YourRemotePassword

IF NOT EXIST \\%YOUR_REMOTE_SERVER%\Packages\AutoWeb\1.0.0.%BUILD_NUMBER% MD \\%YOUR_REMOTE_SERVER%\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%

REM Create the deployment batch files
echo C:\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%\ChangeWebSitePath.vbs "IIS://localhost/W3SVC" "AutoWeb" "C:\InetPub\wwwRoot\AutoWeb" "C:\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%\ResetWebPath.log" >ResetWebPath.bat"
echo msiexec.exe /i C:\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%\AutoWebSetup.msi TARGETPORT=8000 /qn /L* C:\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%\AutoWeb_Install.log >Install.bat
echo C:\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%\ChangeWebSitePath.vbs "IIS://localhost/W3SVC" "AutoWeb" "C:\InetPub\wwwRoot\AutoWeb\AutoWebSetup%BUILD_NUMBER%" "C:\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%\SetNewWebPath.log" >SetNewWebPath.bat

REM copy the files to the remote server
xcopy /Y "ChangeWebSitePath.vbs" \\%YOUR_REMOTE_SERVER%\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%
xcopy /Y "Install.bat" \\%YOUR_REMOTE_SERVER%\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%
xcopy /Y "ResetWebPath.bat" \\%YOUR_REMOTE_SERVER%\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%
xcopy /Y "SetNewWebPath.bat" \\%YOUR_REMOTE_SERVER%\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%
xcopy /Y "C:\Inetpub\wwwroot\AutoWeb\AutoWebSetup\Debug\AutoWebSetup.msi" \\%YOUR_REMOTE_SERVER%\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%

REM run the Deployment
cmd /c psexec.exe \\%YOUR_REMOTE_SERVER% -u %YOUR_REMOTE_USER% -p %YOUR_REMOTE_PASSWORD% "C:\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%\ResetWebPath.bat"
cmd /c psexec.exe \\%YOUR_REMOTE_SERVER% -u %YOUR_REMOTE_USER% -p %YOUR_REMOTE_PASSWORD% "C:\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%\Install.bat"
cmd /c psexec.exe \\%YOUR_REMOTE_SERVER% -u %YOUR_REMOTE_USER% -p %YOUR_REMOTE_PASSWORD% "C:\Packages\AutoWeb\1.0.0.%BUILD_NUMBER%\SetNewWebPath.bat"

