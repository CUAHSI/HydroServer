
ThisScriptName="ChangeWebSitePath.vbs"

if WScript.Arguments.Count <> 0 then
    strWebStartPath = WScript.arguments(0)
    strWebSiteName = WScript.arguments(1)
    strNewHomePath = WScript.arguments(2)
    strLogFile = WScript.arguments(3)
else

    '*********************
    'Get current Directory
    '*********************
    Set fso = CreateObject("Scripting.FileSystemObject")
    Set file = fso.GetFile(ThisScriptName)
    for iCtr = Len(file.Path) to 1 step -1
        lPos = Instr(iCtr,file.path,"\")
        if lPos > 0 then
            strLogFile=left(file.Path,lPos) & "ChangeWebSitePath.log"
            Exit For
        End If
    Next
    
    'Log command lin error
    Call LogText(strLogFile,"One or more missing parameters on command line. " & WScript.ScriptFullName &  " started on " & formatdatetime(Date,0) & " " & formatdatetime(Time,3))
    WScript.Quit

end if

'Log start of script
Call LogText(strLogFile,"***** " & WScript.ScriptFullName &  " started on " & formatdatetime(Date,0) & " " & formatdatetime(Time,3) & " *****")
 

Set objIIsWebService = GetObject(strWebStartPath)

For Each objSITE In objIIsWebService
    If objSITE.class = "IIsWebServer" Then
	if UCase(objSITE.ServerComment) = UCase(strWebSiteName) then
    		strIndex = objSITE.Name
                Call LogText(strLogFile,"Found Website " & strWebSiteName & " with index of " & strIndex)
		Set objIIsWebSite = GetObject(strWebStartPath & "/" & strIndex & "/ROOT")
		objIIsWebSite.Path = strNewHomePath
		objIIsWebSite.SetInfo
                Call LogText(strLogFile,"Changed Website " & strWebSiteName & " home directory to " &  strNewHomePath)
		Exit For
	end if
    End If
Next
       

'Log end of script
Call LogText(strLogFile,"***** " & WScript.ScriptFullName & " completed on " & formatdatetime(Date,0) & " " & formatdatetime(Time,3) & " *****")

WScript.Quit

Sub LogText(strFileSpec,strLogLine)

dim fs, f1
Const FOR_READING=1
Const FOR_WRITING=2
Const FOR_APPENDING=8
Const TRISTATE_FALSE=0
Const TRISTATE_TRUE=-1
Const TRISTATE_USE_DEFAULT=-2

    Set fs=CreateObject("Scripting.FileSystemObject")

    Set f1 = fs.OpenTextFile(strFileSpec, FOR_APPENDING, True) 
    f1.WriteLine(strLogLine)
    f1.Close 
   
    Set f1=Nothing
    Set fs=Nothing
  
End Sub