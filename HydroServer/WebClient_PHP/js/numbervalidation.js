/*!
 * Number validation script by Jagadish Chaterjee found on www.devarticles.com
 * Email: jag_chat@yahoo.com
 */

function validateNum() {
var v = document.all("value").value;
var Value = isValidNumber(v);
return Value;
}

function isValidNumber(val){
      if(val==null || val.length==0){
  		  alert("Please enter a number in the Value box");
		  return false;
		  }

      var DecimalFound = false
      for (var i = 0; i < val.length; i++) {
            var ch = val.charAt(i)
            if (i == 0 && ch == "-") {
                  continue
            }
            if (ch == "." && !DecimalFound) {
                  DecimalFound = true
                  continue
            }
            if (ch < "0" || ch > "9") {
       		    alert("Please enter a valid number in the Value box");
			    return false;
            	}
      }
	  return true;
}
