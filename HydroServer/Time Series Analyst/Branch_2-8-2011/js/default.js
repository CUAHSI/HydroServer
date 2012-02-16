// Initialize
function init() {
	preloadImages();
}

// Form
function printVersion() {
	document.frmAnalyst.target = "_blank";
	__doPostBack("mnuFilePrintAction","");
	document.frmAnalyst.target = "_self";
}
function viewData() {
	document.frmAnalyst.target = "_blank";
	__doPostBack("mnuDataViewAction","");
	document.frmAnalyst.target = "_self";
}

// Menu
var menuOpened = '';
function openMenu(menu) {
	if (menuOpened != menu) {
		if (menuOpened != '') {
			closeMenu(menuOpened);
		}
		document.getElementById(menu).style.visibility = 'visible';
		document.getElementById(menu + "Cell").className = 'activeMenu';
		menuOpened = menu;
	}
}
function closeMenu(menu) {
	document.getElementById(menu).style.visibility = 'hidden';
	document.getElementById(menu + "Cell").className = 'menu';
	menuOpened = '';
}

// Clear control line
function clearControlLine() {
	document.getElementById('objPlotOptions_txtLabel').value = '';
	document.getElementById('objPlotOptions_txtValue').value = '';
	document.getElementById('objPlotOptions_cboColor').selectedIndex = 0;
}

// Preload images
function newImage(arg) {
	if (document.images) {
		rslt = new Image();
		rslt.src = arg;
		return rslt;
	}
}

function changeImages() {
	if (document.images && (preloadFlag == true)) {
		for (var i=0; i<changeImages.arguments.length; i+=2) {
			document[changeImages.arguments[i]].src = changeImages.arguments[i+1];
		}
	}
}

var preloadFlag = false;
function preloadImages() {
	if (document.images) {
		clear_over = newImage("images/clear-over.gif");
		preloadFlag = true;
	}
}

//Launch a new window with a particular size
function NewWindow(url) {
	var windowProperties

	if (screen.height <= 600) {
		windowProperties = 'width=400,height=150,left=0,top=0,resizable=yes,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no,status=no';			
	} else {
		windowProperties = 'width=400,height=150,left=0,top=0,resizable=no,scrollbars=no,toolbar=no,menubar=no,location=no,directories=no,status=no';
	}

	popupWindow = window.open(url,'popupWindow',windowProperties);
	if (window.focus) { popupWindow.focus() }
}