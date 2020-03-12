;1. create a loop which will wait for file upload dialog box
;2. Bring the upload dialog in focus
;3. Supply the file along with its path in the upload dialog
;4. Click upload button

$count = 0

Sleep(3000)


While $count <> 10 Then
   $chrome = WinActivate("Open")
   $filefox = WinActivate("File Upload")


   if($chrome <> 0)
	  ControlFocus("Open", "", "Edit1")
	  Sleep(500)
	  ControlSetText("Open", "", "Edit1", $CmdLine[1])
	  Sleep(500)
	  ControlClick("Open", "", "Button1")
	  Exit
   EndIf

   if($chrome <> 0)
	  ControlFocus("File Upload", "", "Edit1")
	  Sleep(500)
	  ControlSetText("File Upload", "", "Edit1", $CmdLine[1])
	  Sleep(500)
	  ControlClick("File Upload", "", "Button1")
	  Exit
   EndIf

   Sleep(1000)
   $count = $count + 1

   WEnd