<?php
require_once('./configuration/app_config.php');
function get_table_name($uppercase_table_name) {
    return '`'. strtolower($uppercase_table_name) .'`';
}