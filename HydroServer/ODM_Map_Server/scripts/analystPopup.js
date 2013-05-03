function NewWindow(url) {
	var windowProperties

	if (screen.height <= 600) {
		windowProperties = 'width=780,height=564,left=0,top=0,resizable=yes,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no,status=no';			
	} else {
		windowProperties = 'width=780,height=564,left=0,top=0,resizable=no,scrollbars=no,toolbar=no,menubar=no,location=no,directories=no,status=no';
	}

	popupWindow = window.open(url,'popupWindow',windowProperties);
	if (window.focus) { popupWindow.focus() }
}