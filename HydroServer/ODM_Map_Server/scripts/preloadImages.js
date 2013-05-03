function preloadImages() {
	if (document.images) {
		if (!document.pics) {
			document.pics = new Array();
		}
	
		var i;
		var j = document.pics.length;
		var args = preloadImages.arguments;
		for (i = 0; i < args.length; i++) {
			if (args[i].indexOf("#") != 0) {
				document.pics[j] = new Image;
				document.pics[j++].src = args[i];
			}
		}
	}
}