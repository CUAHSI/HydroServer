<?php
$string_to_search = "   Dr. Smith and Mr. Smith and <variables><variable>VOLE:IDCS-1</variable></variables> are here";
$tag = "variable";
$regex = "/<\s*[ws:]*" . $tag . "\s*>(.*?)<\/\s*[ws:]*" . $tag . "\s*>/";
$num_matches = preg_match($regex, $string_to_search, $matches);
  if ($num_matches > 0) {
  echo "Found a match! num matches:" . $num_matches;
  
  //print_r ($matches);
  
  echo " match0: " . $matches[0];
  echo " match1: " . $matches[1];
  
  $replace = preg_replace($regex, "KOVAR", $string_to_search);
  //echo $replace;
  } else {
    echo "No match. Sorry.";
  }
?>