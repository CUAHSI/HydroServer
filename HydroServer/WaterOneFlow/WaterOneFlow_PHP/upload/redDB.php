<?php
/**
All code is Copyright 2009 by Ashwin Surajbali (http://www.redinkdesign.net).

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation.

This program is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License
for more details.

You can view a copy of the GNU General Public Licsense at

http://www.gnu.org/licenses/old-licenses/gpl-2.0.txt.

 **/

/**
 * Create's an object representing a table in a database
 * This class requires a database handle to be passed in
 *
 * @version 1.0
 *
 * @example
 *  $db = new redDB('host', 'username', 'password', 'database_name');
 *  $user = $db->init('user_table');
 *  $user->get("user_id = 4343");
 *  $user->name = 'BumbleBee';
 *  $user->save();
 *
 * @example
 *  $db = new redDB('host', 'username', 'password', 'database_name');
 *  $user = $db->init('user_table');
 *  $user->name = 'BumbleBee';
 *  $user->age = 24;
 *  $user->save();
 *
 * @example
 *  $db = new redDB('host', 'username', 'password', 'database_name');
 *  $user = $db->init('user_table');
 *  $user->get("user_id = 1233");
 *  $user->name = '
 *  $user->sex = 'F';
 *  $user->update("sex != 'F' && user_id = 1233");
 *
 * @example
 *  $db = new redDB('host', 'username', 'password', 'database_name');
 *  $user = $db->init('user_table');
 *  $ar_users = $user->get_data("first_name = 'john'");
 *  foreach ($ar_users as $user){
 *      echo $user->id;
 *  }
 *
 * @example
 *  $db = new redDB('host', 'username', 'password', 'database_name');
 *  $user = $db->init('user_table');
 *  $ar_all_users = $user->get_data();
 *  foreach ($ar_all_users as $user){
 *      echo $user->age . '<br />';
 *  }
 *
 * @example
 *  $db = new redDB('host', 'username', 'password', 'database_name');
 *  $first_name = $db->get_query_value("select first_name from user_table where id = 12333");
 *
 * @example
 *  $db = new redDB('host', 'username', 'password', 'database_name');
 *  $ar_data = $db->get_query_data("select * from user_table where age > 21");
 *  foreach ($ar_data as $data){
 *      echo $data->first_name . '<br />';
 *  }
 *
 */

class redDB {

    private $__db_host;
    private $__db_username;
    private $__db_password;
    private $__db_name;
    private $__db_port;
    private $__db_handle;

    private $__sql;
    private $__table_name;
    private $__primary_key = '';
    private $__result;
    private $__ar_field_types = array(
        0 => "DECIMAL",
        1 => "TINYINT",
        2 => "SMALLINT",
        3 => "INTEGER",
        4 => "FLOAT",
        5 => "DOUBLE",
        7 => "TIMESTAMP",
        8 => "BIGINT",
        9 => "MEDIUMINT",
        10 => "DATE",
        11 => "TIME",
        12 => "DATETIME",
        13 => "YEAR",
        14 => "DATE",
        16 => "BIT",
        246 => "DECIMAL",
        247 => "ENUM",
        248 => "SET",
        249 => "TINYBLOB",
        250 => "MEDIUMBLOB",
        251 => "LONGBLOB",
        252 => "BLOB",
        253 => "VARCHAR",
        254 => "CHAR",
        255 => "GEOMETRY"
    );

    function __construct($host, $username, $password, $db_name, $port = '3306'){

        $this->__db_host = $host;
        $this->__db_username = $username;
        $this->__db_password = $password;
        $this->__db_name = $db_name;
        $this->__db_port = $port;
        $this->connect();
    }

    /**
     * Initialize our table object
     *
     * @example $this->init('users_table');
     *
     * @param string $table
     * @return object
     */
    public function init($table = ''){
        if(empty($table)){
            $this->throw_error(__METHOD__, __LINE__, 'No table name specified.');
        }

        $this->__table_name = $table;

        $ar_fields = $this->get_table_fields();

        if (!is_array($ar_fields)) {
            $this->throw_error(__METHOD__, __LINE__, "ERROR: Table '{$this->__table_name}' has no fields.");
        }

        foreach ($ar_fields as $field){

            switch ($field->type){
                case "INTEGER":
                case "TINYINT":
                case "SMALLINT":
                case "MEDIUMINT":
                    $this->{$field->name} = 0;
                    break;
                case "DOUBLE":
                case "FLOAT":
                case "DECIMAL":
                    $this->{$field->name} = 0.00;
                    break;
                case "DATE":
                    $this->{$field->name} = '0000-00-00';
                    break;
                case "TIME":
                    $this->{$field->name} = '00:00:00';
                    break;
                case "DATETIME":
                    $this->{$field->name} = '0000-00-00 00:00:00';
                    break;
                case "YEAR":
                    $this->{$field->name} = '0000';
                    break;
                default:
                    $this->{$field->name} = '';
                    break;
            }

            if (!empty($field->def)) {
                $this->{$field->name} = $field->def;
            }

        }

        return $this;
    }

    /**
     * Alias for @link init
     *
     * @param string $table
     * @return object
     */
    public function init_table($table){
        return $this->init($table);
    }

    /**
     * Returns a single record as a table object depending on
     * constraint passed in
     *
     * @example $this->get_single_record("id = 22");
     *
     * @param string $constraint
     * @return object
     */
    public function get_single_record($constraint = ''){
        if (empty($this->__table_name)){
            $this->throw_error(__METHOD__, __LINE__,  "You must initialize a table before retrieving a record.");
        }

        if (empty($constraint)){
            $this->throw_error(__METHOD__, __LINE__,  "No constraint entered.");
        }

        $this->__sql = "select * from {$this->__table_name} where {$constraint} limit 1";
        return $this->get_single_result();

    }

    /**
     * Alias for @link get_single_record
     *
     * @param string $constraint
     * @return object
     */
    public function get($constraint){
        return $this->get_single_record($constraint);
    }

    /**
     * Inserts a new record or updates if it already exists
     * Use this for quick updates/inserts
     *
     * For custom updates, use @link update
     *
     * @return boolean
     */
    public function save(){

        $duplicate_sql = '';
        $this->__sql = "insert into {$this->__table_name} values (";
        foreach ($this as $key => $val){
            if (substr($key, 0, 2) == '__'){
                continue;
            }
            $this->__sql .= "'{$this->escape($val)}'" . ',';
            $duplicate_sql .= "{$key} = '{$this->escape($val)}'" . ',';
        }
        $this->__sql = trim($this->__sql, ',');
        $this->__sql .= ")";
        $this->__sql .= ' on duplicate key update ';
        $this->__sql .= trim($duplicate_sql, ',');

        return $this->execute_query($this->__sql);
    }

    /**
     * Updates an existing record depending on custom constraints
     * Use this for complex updates instead of @link save
     *
     * @param string $where_constraint
     * @return boolean
     */
    public function update($where_constraint = ''){
        if (empty($where_constraint)){
            $this->throw_error(__METHOD__, __LINE__, 'Missing WHERE constraint. eg. ID = 222');
        }

        $this->__sql = "update {$this->__table_name} set ";
        foreach ($this as $key => $val){
            if (substr($key, 0, 2) == '__'){
                continue;
            }
            $this->__sql .= "{$key} = '{$this->escape($val)}'" . ',';
        }
        $this->__sql = trim($this->__sql, ',');
        $this->__sql .= ' ' . $where_constraint;

        return $this->execute_query($this->__sql);
    }

    /**
     * Executes a query
     *
     * @param string $query
     * @return boolean
     */
    public function execute_query($query){
        $this->__sql = $query;
        if(!$this->__db_handle->query($this->__sql)){
            $this->throw_error(__METHOD__, __LINE__);
        }
    }

    /**
     * Send out a query and return the first field of the first result row
     * eg. select count(*) as count from blah; only the value of count will be returned
     *
     * @param string $query
     * @return string return value of query
     */
    public function get_query_value($query){
        if (empty($query)) $this->throw_error(__METHOD__, __LINE__, 'Query missing.');

        $this->__sql = $query;
        $this->__result = $this->__db_handle->query($this->__sql);
        if (!$this->__result){
            $this->throw_error(__METHOD__, __LINE__);
        }

        $ar_result = $this->__result->fetch_array();
        if (!empty($ar_result[0])){
            return $ar_result[0];
        }else{
            return false;
        }
    }

    /**
     * Get data from the initialized table depending on constraint, limit and order
     * Returns results in an array of objects
     *
     * @param string $constraint - optional
     * @param string $limit - optional
     * @param string $order_by - optional
     * @return array of objects
     */
    public function get_data($constraint = '', $limit = '', $order_by = ''){
        if (empty($this->__table_name)) $this->throw_error(__METHOD__, __LINE__, 'Table missing.');

        $this->__sql = "select * from {$this->__table_name}" . (!empty($constraint)? " where {$constraint}" : '') .
            (!empty($order_by)? " order by {$this->escape($order_by)}" : '') .
            (!empty($limit)? " limit {$this->escape($limit)}" : '');
        $this->__result = $this->__db_handle->query($this->__sql);
        if (!$this->__result){
            $this->throw_error(__METHOD__, __LINE__);
        }

        $ar_results = array();
        while($obj = $this->__result->fetch_object()){
            $ar_results[] = $obj;
        }

        if (is_array($ar_results)){
            return $ar_results;
        }else{
            return false;
        }
    }

    /**
     * Runs a query and returns results in an array of objects
     *
     * @param string $query
     * @return array
     */
    public function get_query_data($query){
        if (empty($query)) $this->throw_error(__METHOD__, __LINE__, "Query missing.");

        $this->__sql = $query;
        $this->__result = $this->__db_handle->query($this->__sql);
        if(!$this->__result){
            $this->throw_error(__METHOD__, __LINE__);
        }

        $ar_results = array();
        while ($obj = $this->__result->fetch_object()){
            $ar_results[] = $obj;
        }

        if (is_array($ar_results)){
            return $ar_results;
        }else{
            return false;
        }
    }

    /**
     * Escapes special characters in a string for use in a SQL statement
     *
     * @param string $string
     * @return string
     */
    public function escape($string){
        return $this->__db_handle->real_escape_string($string);
    }

    /**
     * Alias of function escape
     *
     * @param mixed $mixed_var
     * @return string
     */
    public function escape_str($mixed_var){
        return $this->escape($mixed_var);
    }

    /**
     * Hanldes integers properly for db insertion
     * Helps prevent injections by converting the mixed var to an int and then attempt to escape it (sanity check)
     *
     * @param mixed $mixed_var
     * @return mixed
     */
    public function escape_int($mixed_var){
        return $this->__db_handle->real_escape_string(intval($mixed_var));
    }

    /**
     * Gets the sql statement that was executed
     *
     * @return string
     */
    public function get_sql(){
        return $this->__sql;
    }

    /**
     * Returns the auto generated id used in the last query
     *
     * @return int
     */
    public function get_inserted_id(){
        return mysqli_insert_id($this->__db_handle);
    }

    /**
     * Gets the number of rows in a result
     *
     * @return int
     */
    public function get_num_rows(){
        return $this->__result->num_rows();
    }

    /**
     * Gets the number of affected rows in a previous MySQL operation
     * Returns an integer greater than zero which indicated the number of rows affected or retrieved.
     * Zero indicates that no records where updated for an UPDATE statement,
     * no rows matched the WHERE clause in the query or that no query has yet been executed.
     * -1 indicates that the query returned an error.
     *
     * @return int
     */
    public function get_affected_rows(){
        return $this->__db_handle->affected_rows;
    }

    /**
     * Returns a string providing information about the last query executed.
     * ex. Records:100 Duplicates:0 Warnings:0 etc.
     *
     * @return string
     */
    public function get_query_info(){
        return $this->__db_handle->info;
    }

    private function connect(){
        $this->__db_handle = new mysqli($this->__db_host, $this->__db_username, $this->__db_password, $this->__db_name);
        if (mysqli_connect_errno()){
            $this->throw_error(__METHOD__, __LINE__, mysqli_connect_error);
        }
    }

    private function get_single_result(){
        $this->__result = $this->__db_handle->query($this->__sql);
        if (!$this->__result){
            $this->throw_error(__METHOD__, __LINE__);
        }

        $ob_record = $this->__result->fetch_object();
        if (is_object($ob_record)){
            foreach($ob_record as $key => $value){
                $this->{$key} = $value;
            }
            return $this;
        }else{
            return false;
        }
    }

    private function get_table_fields(){
        $this->__sql = "select * from {$this->escape($this->__table_name)} limit 1";

        $this->__result = $this->__db_handle->query($this->__sql);
        if (!$this->__result){
            $this->throw_error(__METHOD__, __LINE__,'Could not fetch table fields.');
        }

        $ar_field_info = $this->__result->fetch_fields();
        $ar_fields = array();
        if (is_array($ar_field_info)){
            foreach ($ar_field_info as $val){
                $ar_fields[$val->name]->name = $val->name;
                $ar_fields[$val->name]->orgname = $val->orgname;
                $ar_fields[$val->name]->table = $val->table;
                $ar_fields[$val->name]->orgtable = $val->orgtable;
                $ar_fields[$val->name]->def = $val->def;
                $ar_fields[$val->name]->max_length = $val->max_length;
                $ar_fields[$val->name]->length = $val->length;
                $ar_fields[$val->name]->charsetnr = $val->charsetnr;
                $ar_fields[$val->name]->flags = $val->flags;
                $ar_fields[$val->name]->type = $this->__ar_field_types[$val->type];
                $ar_fields[$val->name]->decimals = $val->decimals;
            }
            return $ar_fields;
            print_r($ar_fields);
        }else{
            $this->throw_error(__METHOD__, __LINE__, "No columns found for table {$this->__table_name}.");
        }
    }

    private function throw_error($function_name, $line_number, $error_msg = ''){
        die('<font style="color: red; font-weight: bold;">-- Error --</font><br />' . $function_name . ' at line ' .
            $line_number . '<br />MySQLi Error: ' . $this->__db_handle->error .
            (!empty($error_msg)? "<br />Message: $error_msg" : ""));
    }

}
?>
