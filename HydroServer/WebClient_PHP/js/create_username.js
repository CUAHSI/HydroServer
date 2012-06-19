// JavaScript created by Rex Burch 


//Take the first letter from the first name provided

function GetFirstLetter(){ 

	var newLtr="";

	newLtr = document.newuser.firstname.value.substr(0,1); // "R" from Rex
	
	var newFirst = newLtr.toLowerCase(); // becomes "r"

	document.newuser.username.value = newFirst; //output current result, which is "r"
}


//Take the first letter from the last name provided and add it to the first initial

function GetLastName(){

	var FirstPiece="";
	
	var lastN="";

	FirstPiece = document.newuser.username.value;

	lastN = document.newuser.lastname.value; // "Burch"
	
	var newLast = lastN.toLowerCase(); // becomes "burch"

	document.newuser.username.value = (FirstPiece + newLast); //output combined results, which would be "rburch"
}
