function invoke_web_service(service_url) {
	$("form").submit(function(e){
	  e.preventDefault();
	  var str = $("form").serialize();
	  $.ajax({
		  type:"POST",
		  url:service_url,
		  data: str,
		  dataType: "text",
		  success: function(resp) {
			  $("#status").text("status:" + "200 (OK)");
			  $("#test_response").text(resp);  
			  alert(resp);
		  },
		  error: function(xhr, status, error) {
			  $("#test_response").text(xhr.responseText);
			  $("#status").text("status:" + xhr.status);
			  alert();
		  }
	  })
	  
	}); 
}