/*!
 * Number validation script by Ed Nutting found on www.codeproject.com
 */

function validateDate() {
var value2 = document.all("datepicker").value;

//Removing all space
value = value2.replace(" ",""); 

//minimum length is 10. example 2012-05-31
alert(value.length);
if(value.length != 10){
	
	alert("Invalid date length. Date format should be 2012-05-31");
	return false;
	}
if (isDate(value) == false){
	alert("Incorrect date. You cannot enter 00.");
	return false;
	}
}

//Check the length of each segment to ensure it is correct. The order is yyyy-mm-dd by default.
function isDate(value) {
    try {
        
        var YearIndex = 0;
        var MonthIndex = 1;
        var DayIndex = 2;
 
        value = value.replace("/","-").replace(".","-"); 
        var SplitValue = value.split("-");
        var OK = true;
		//Check the length of the year
        
		if (OK && SplitValue[YearIndex].length != 4){
			alert("Please enter the correct length for the YEAR.");
            OK = false;
        }
		
		//Check the length of the month
        if (OK && SplitValue[MonthIndex].length != 2){
			alert("Please enter the correct length for the MONTH.");
            OK = false;
        }
		
		//Check the length of the day
        if (SplitValue[DayIndex].length != 2){
			alert("Please enter the correct length for the DAY.");
            OK = false;
        }
		
        if (OK) {
            var Year = parseInt(SplitValue[YearIndex], 10);
            var Month = parseInt(SplitValue[MonthIndex], 10);
            var Day = parseInt(SplitValue[DayIndex], 10);
 
            if (OK = ((Year > 1900) && (Year <= new Date().getFullYear()))) {
				
                if (OK = (Month <= 12 && Month > 0)) {
                    var LeapYear = (((Year % 4) == 0) && ((Year % 100) != 0) || ((Year % 400) == 0));
 
                    if (Month == 2) {
						
                        OK = LeapYear ? Day <= 29 : Day <= 28;
                    }
                    else {
                        if ((Month == 4) || (Month == 6) || (Month == 9) || (Month == 11)) {
                            OK = (Day > 0 && Day <= 30);
                        }
                        else {
                      
							OK = (Day > 0 && Day <= 31);
							
                        }
                    }
                }
            }
        }
        return OK;
    }
    catch (e) {
        return false;
    }
}