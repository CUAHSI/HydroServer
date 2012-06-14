/*!
 * Time validation script by Rashutosh Paul found on www.codeproject.com
 */

function  validateTime(){
var strval = document.all("timepicker").value;

//Minimum and maximum length is 5, for example, 01:20
	if(strval.length < 5 || strval.length > 5){
		alert("Invalid time. Time format should be five characters long and formatted HH:MM");
	return false;
	}

	//Removing all space
	strval = trimAllSpace(strval);
	document.all("timepicker").value = strval;

	//Split the string
	var newval = strval.split(":");
	var horval = newval[0]
	var minval = newval[1];

	//Checking hours

	//minimum length for hours is two digits, for example, 12
	if(horval.length != 2){
		alert("Invalid time. Hours format should be two digits long.");
		return false;
		}
	if(horval < 0){
		alert("Invalid time. Hours cannot be less than 00.");
		return false;
		}
	else if(horval > 23){
		alert("Invalid time. Hours cannot be greater than 23.");
		return false;
		}

	//Checking minutes

 	//minimum length for minutes is 2, for example, 59
	if(minval.length != 2){
		alert("Invalid time. Minutes format should be two digits long.");
	return false;
	} 
	if(minval < 0){
		alert("Invalid time. Minutes cannot be less than 00.");
		return false;
		}   
	else if(minval > 59){
		alert("Invalid time. Minutes cannot be greater than 59.");
		return false;
		}
	strval = IsNumeric(strval);
	document.all("timepicker").value = strval;
}

//The trimAllSpace() function will remove any extra spaces
function trimAllSpace(str) 
{ 
    var str1 = ''; 
    var i = 0; 
    while(i != str.length) 
    { 
        if(str.charAt(i) != ' ') 
            str1 = str1 + str.charAt(i); i ++; 
    } 
    return str1; 
}

//The trimString() function will remove 
function trimString(str) 
{ 
     var str1 = ''; 
     var i = 0; 
     while ( i != str.length) 
     { 
         if(str.charAt(i) != ' ') str1 = str1 + str.charAt(i); i++; 
     }
     var retval = IsNumeric(str1); 
     if(retval == false) 
         return -100; 
     else 
         return str1; 
}

//The IsNumeric() function will check whether the user has entered a numeric value or not.
function IsNumeric(strString){ 
    var strValidChars = "0123456789:"; 
    var blnResult = true; 

    //test strString consists of valid characters listed above
    for (i = 0; i < strString.length && blnResult == true; i++) 
    { 
        var strChar = strString.charAt(i); 
        if (strValidChars.indexOf(strChar) == -1) 
        {
			alert ("Invalid character. You may only use numbers.");
			strString = strString.replace(strString[i],"");
            blnResult = false;
        } 
     }
	return strString;
}