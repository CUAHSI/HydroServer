<?php
  configureWSDL(‘stockserver’, ‘urn:stockquote’);
$server->register(“getStockQuote”,
array(‘symbol’ => ‘xsd:string’),
array(‘return’ => ‘xsd:decimal’),
‘urn:stockquote’,
‘urn:stockquote#getStockQuote’);
$HTTP_RAW_POST_DATA = isset($HTTP_RAW_POST_DATA)
? $HTTP_RAW_POST_DATA : ”;
$server->service($HTTP_RAW_POST_DATA);
?>