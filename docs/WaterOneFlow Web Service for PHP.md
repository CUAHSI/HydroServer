# Quick Documentation
See the quick installation manual: [WaterOneFlow_PHP_2.2_Installation.pdf](WaterOneFlow Web Service for PHP_WaterOneFlow_PHP_2.2_Installation.pdf)

# How to set up WaterOneFlow web service for PHP on shared webhosting
# Create a new account on the webhosting site. This example uses [http://www.000webhost.com](http://www.000webhost.com). To create a new account you need to create a user name and enter your email. After receiving a confirmation e-mail your account is created
# Log-in into your account and select CPanel. This is the main administration panel
# Select the MySQL menu
# Create a new MySQL database. Write down the database host name, database name, database user name and database password.
# From CPanel go to phpMyAdmin and select the new database
# In phpMyAdmin select Import and import the ODM Database Schema file. This will create all required tables in the database
# Add data to your database. You can use the sample script that will add two sites with two variables to your database. To add the sample data in phpMyAdmin select Import and select the [OdMforMySQL_MOSS.sql](WaterOneFlow Web Service for PHP_OdMforMySQL_MOSS.sql) ODM Sample Data file.
# Copy the WaterOneFlow PHP files. In CPanel go to FileManager. Select the archives (zip, tar, gz) option and upload the [ WaterOneFlow_PHP_2.3.zip ]( WaterOneFlow_PHP_2.3.zip ) file (you can get this file from the [Downloads](Downloads) page.
# Edit the database access configuration. In CPanel go to FileManager. Select the subfolder /services/application/config and edit the file database.php. Enter the correct values of database server (usually localhost), MySQL database name, database user and database password.
# Test your installation: Go to the {{services/ page}} and {{services/cuahsi_1_1.asmx page}} and test the web services. Also test accessing the web service in HydroDesktop and HydroExcel.

## Detailed Documentation
A detailed step-by-step tutorial is available:
[WaterOneFlow_PHP_2.2_Installation.pdf](WaterOneFlow Web Service for PHP_WaterOneFlow_PHP_2.2_Installation.pdf)
[WaterOneFlow_PHP_setup.pdf](WaterOneFlow Web Service for PHP_WaterOneFlow_PHP_setup.pdf)

## For Developers - XAMPP Setup Documentation

For local testing and exploring the code offline on Windows and Mac we recommend [XAMPP](http://www.apachefriends.org/en/xampp.html). This is a lighweight local Apache server with PHP and MySQL. For Linux we recommend the pre-installed Apache software with MySQL database.

## Sample Database for the WebServices
This sample database schema contains selected water quality observations samples from the Little Bear River experimental watershed. It can be used as an example for setting up the web services for an observatory with large number of field sensors.
[WOF_PHP_2.1_LittleBear_MySQL_Database.zip](WaterOneFlow Web Service for PHP_WOF_PHP_2.1_LittleBear_MySQL_Database.zip)

## Installing the Web Services on Local Linux Server
If you install the web services on a local Linux server (Apache) for example on Ubuntu Linux or Centos Linux, the {mod_rewrite} module must be enabled. This setting is usually found in the {/etc/conf.d/apache2.conf} or {/etc/httpd/conf.d/httpd.conf} file. If mod_rewrite is disabled, then the services will still work but the only on the URL: {http://your_server_URL/services/index.php/cuahsi_1_1.asmx}
