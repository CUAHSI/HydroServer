/*!
 * Site Code Creation script by Rohit Khattar and Rex Burch
 */

var str = "$sname";	//McCall Outdoor Science School
var matches = str.match(/\b(\w)/g);	// ['M','O','S','S']
var newsource = matches.join('');	// MOSS

//Take the first letter from each word in name provided, and abbrev. it

function FindName() {
var info_provided = document.all("SiteName").value; //Boulder Creek at Jug Mountain Ranch

	//if string contains " at "
	if(info_provided.indexOf(" at ")){

		//Split the string where "at" is used
		var newpieces = info_provided.split(" at ");
		var first_hlf = newpieces[0];
		var second_hlf = newpieces[1];

		//process each new string
		var match1 = first_hlf.match(/\b(\w)/g);	// ['B','C']
		var acronym1 = match1.join('');	// BC

		var match2 = second_hlf.match(/\b(\w)/g);	// ['J','M','R']
		var acronym2 = match2.join('');	// JMR

		var newString = (newsource + '-' + acronym1 + '-' + acronym2);

		document.all("SiteCode").value = newString;
		}
	else {

		//process string they type in
		var match1 = info_provided.match(/\b(\w)/g);	// ['B','C']
		var acronym1 = match1.join('');	// BC

		var newString = (newsource + '-' + acronym1);

		document.all("SiteCode").value = newString;
	}
}