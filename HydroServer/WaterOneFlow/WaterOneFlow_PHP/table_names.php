<?php
require_once('./configuration/app_config.php');
function get_table_name($uppercase_table_name) {
  if (LOWERCASE_TABLE_NAMES === TRUE) {
    return '`'.strtolower($uppercase_table_name).'`';
  }
  else {
    return '`'. $uppercase_table_name .'`';
  }
}