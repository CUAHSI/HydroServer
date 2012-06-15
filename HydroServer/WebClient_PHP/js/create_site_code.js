// JavaScript created by 

//Take the first letter from each word in Source name and abbrev. it


var newsource="";
var newString="-1";
function GetSourceName(){
	 //McCall Outdoor Science School

newsource="";
var str = $("#SourceID option:selected").text();

var matches = str.match(/\b(\w)/g);	// ['M','O','S','S']
newsource = matches.join('');	// MOSS
if (newString=="-1")
{
$("#SiteCode").val(newsource + '-');	
}
else
{
$("#SiteCode").val(newsource + '-' + newString);	
}

 //output current results
}

//Take the first letter from each word in Name provided and abbrev. it

function GetSiteName(){
	newstring="";
var info_provided = $("#SiteName").val(); //Boulder Creek at Jug Mountain Ranch
	//if string contains " at "
	
	if(info_provided.indexOf(" at ")!=-1){

		//Split the string where "at" is used
		var newpieces = info_provided.split(" at ");
		var first_hlf = newpieces[0];
		var second_hlf = newpieces[1];

		//process each new string
		var match1 = first_hlf.match(/\b(\w)/g);	// ['B','C']
		var acronym1 = match1.join('');	// BC

		var match2 = second_hlf.match(/\b(\w)/g);	// ['J','M','R']
		var acronym2 = match2.join('');	// JMR

		newString = (acronym1 + '-' + acronym2);

		$("#SiteCode").val(newsource + '-' + newString);
		}
	else {
		//process string they type in
		var match1 = info_provided.match(/\b(\w)/g);	// ['B','C']
		var acronym1 = match1.join('');	// BC
		newString = (acronym1);

	$("#SiteCode").val(newsource + '-' + newString);
	}
}
