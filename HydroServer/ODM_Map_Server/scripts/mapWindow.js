function MapWindow(url) {
	popupWindow = window.open(url,'popupWindow','width=500,height=400,left=25,top=25,resizable=no,scrollbars=no,toolbar=no,menubar=no,location=no,directories=no,status=no');
	if (window.focus) { popupWindow.focus() }
}