<?php
/**
 * Created by JetBrains PhpStorm.
 * User: Jiri
 * Date: 5/18/12
 * Time: 12:14 PM
 * To change this template use File | Settings | File Templates.
 */
/**
 * CSV file parser
 * Currently the string matching doesn't work
 * if the output encoding is not ASCII or UTF-8
 */
class CsvFileParser
{
    var $delimiter;         // Field delimiter
    var $enclosure;         // Field enclosure character
    var $inputEncoding;     // Input character encoding
    var $outputEncoding;    // Output character encoding
    var $data;              // CSV data as 2D array

    /**
     * Constructor
     */
    function CsvFileParser()
    {
        $this->delimiter = ",";
        $this->enclosure = '"';
        $this->inputEncoding = "ISO-8859-1";
        $this->outputEncoding = "ISO-8859-1";
        $this->data = array();
    }

    /**
     * Parse CSV from file
     * @param   content     The CSV filename
     * @param   hasBOM      Using BOM or not
     * @return Success or not
     */
    function ParseFromFile( $filename, $hasBOM = false )
    {
        if ( !is_readable($filename) )
        {
            return false;
        }
        return $this->ParseFromString( file_get_contents($filename), $hasBOM );
    }

    /**
     * Parse CSV from string
     * @param   content     The CSV string
     * @param   hasBOM      Using BOM or not
     * @return Success or not
     */
    function ParseFromString( $content, $hasBOM = false )
    {
        $content = iconv($this->inputEncoding, $this->outputEncoding, $content );
        $content = str_replace( "\r\n", "\n", $content );
        $content = str_replace( "\r", "\n", $content );
        if ( $hasBOM )                                // Remove the BOM (first 3 bytes)
        {
            $content = substr( $content, 3 );
        }
        if ( $content[strlen($content)-1] != "\n" )   // Make sure it always end with a newline
        {
            $content .= "\n";
        }

        // Parse the content character by character
        $row = array( "" );
        $idx = 0;
        $quoted = false;
        for ( $i = 0; $i < strlen($content); $i++ )
        {
            $ch = $content[$i];
            if ( $ch == $this->enclosure )
            {
                $quoted = !$quoted;
            }

            // End of line
            if ( $ch == "\n" && !$quoted )
            {
                // Remove enclosure delimiters
                for ( $k = 0; $k < count($row); $k++ )
                {
                    if ( $row[$k] != "" && $row[$k][0] == $this->enclosure )
                    {
                        $row[$k] = substr( $row[$k], 1, strlen($row[$k]) - 2 );
                    }
                    $row[$k] = str_replace( str_repeat($this->enclosure, 2), $this->enclosure, $row[$k] );
                }

                // Append row into table
                $this->data[] = $row;
                $row = array( "" );
                $idx = 0;
            }

            // End of field
            else if ( $ch == $this->delimiter && !$quoted )
            {
                $row[++$idx] = "";
            }

            // Inside the field
            else
            {
                $row[$idx] .= $ch;
            }
        }

        return true;
    }
}
