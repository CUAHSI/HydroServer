Dim strVersion, strDeployScriptDir

strDeployScriptDir="C:\Inetpub\wwwroot\AutoWeb\AutoWebSetup\AutoWebSetup.vdproj"
strVersion="1000"

'stamp the new product name into the deployment project file
StampProductName strDeployScriptDir, strVersion


Sub StampProductName(FileSpec,strVersion)

Const FOR_READING=1
Const FOR_WRITING=2
Const TRISTATE_FALSE=0
Const TRISTATE_TRUE=-1
Const TRISTATE_USE_DEFAULT=-2

  'open the file
  Set fs=CreateObject("Scripting.FileSystemObject")
  Set f1=fs.GetFile(FileSpec)
  Set textstream= f1.OpenAsTextStream(FOR_READING,TRISTATE_FALSE)

  ' loop thru line by line and locate/replace the ProductName line
    Do While textstream.AtEndOfStream = False
    strLine = textstream.readline
    If instr(strLine,"ProductName") >0 Then
            iStart = instr(strLine,"8:")
            If iStart Then
              strLine=mid(strLine,iStart + 2)
              iStart=1
              iFinish = instr(strLine,Chr(34))
              If iFinish Then
                strProductName = mid(strLine,(iStart), iFinish - (iStart))
                strNewLine = "        " & Chr(34) & "ProductName"  & Chr(34)
                strNewLine=strNewLine & " = " & Chr(34) & "8:" & strProductName
                strNewLine=strNewLine & " " & strVersion & Chr(34)
    	        strBuffer = strBuffer & strNewLine & vbcrlf
    	      End If
    	    End If    
    Else
     strBuffer = strBuffer & strLine & vbcrlf
    End If
  Loop
  textstream.Close
  
  'now overwrite the file
  Set f2=fs.GetFile(FileSpec)
  Set textstream=f2.OpenAsTextStream(FOR_WRITING,TRISTATE_FALSE)
  textstream.Write strBuffer
  textstream.Close
    
  Set f1=Nothing
  Set f2=Nothing
  Set fs=Nothing
  
End Sub
