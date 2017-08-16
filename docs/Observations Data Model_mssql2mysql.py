#!/usr/bin/python
from __future__ import unicode_literals
import pyodbc
import sys
import re

_srvr = r".\SQLEXPRESS"	#MSSQL SERVER NAME
_user = "sa"			#MSSQL USER NAME
_pass = "2c506bbe"		#MSSQL PASSWORD
_db   = "LittleBear_1_1_1"			#MSSQL DB

constraints=[]
f=open("ms2my.sql",'w')
def show_structure(table):
    s =""
    datatypes=[]
    q="exec sp_columns "+table
    un=""
    conn.execute(q)
    print "-----------+"+table+"+----------------"
    s+= "-- Drop table '" + table + "'\n"
    s+= "DROP TABLE IF EXISTS " + table.lower() + ";\n"
    s+= "--\n-- Table structure for table '"+table+"\n--\n"
    s+= "CREATE TABLE `" + table.lower() + "`(\n"
    while 1:
        row = conn.fetchone()
        if not row:
            break
        nullable = " NULL " if row.NULLABLE else " NOT NULL"
        #print nullable
        c_name = "`"+row.COLUMN_NAME+"`"
        d_type = row.TYPE_NAME
        length = row.LENGTH
        default = row.COLUMN_DEF
        #print d_type
        if len (d_type.partition(" ") ) ==3:
            d_type,sp,un = d_type.partition(" ")
            
        else:
            d_type = d_type.partition(" ")
            
        datatypes.insert( (row.ORDINAL_POSITION -1), d_type)
        #print c_name
        prec = row.PRECISION
        scale = row.SCALE
        if c_name == "smallmoney":
            prec=10
            scale=4
        if c_name == "money":
            prec=19
            scale=4

        if c_name == "show":
            c_name = "showTitle"
        
        if d_type == "int":
            s+=c_name+" INT "
            if un:
                s+= " AUTO_INCREMENT "
        elif d_type == "bit":
            s+=c_name+" TINYINT "
        elif d_type == "smallint":
            s+=c_name+" SMALLINT "
        elif d_type == "nvarchar" or d_type =="varchar":
            #s += c_name + " "
            if prec <= 255 :
                s += c_name +" VARCHAR (" + str(prec) +") "
            else:
                default =0
                s+=c_name+" TEXT "
        elif d_type == "char" :
            #s += c_name + " "
            if length <= 255 :
                s += "CHAR (" + prec +") "
            else:
                default =0
                s+=c_name+" TEXT "

        elif d_type == "ntext" or d_type =="text":
            #s += c_name + " "
            default =0
            s+=c_name+" TEXT "

        elif d_type == "uniqueidentifier":
            #s += c_name + " "
            s+=c_name+" CHAR(36) "

        elif d_type == "binary" or d_type =="varbinary" or d_type =="image":
            s += d_type;
            s+=c_name+" BLOB "

        elif d_type == "datetime" or d_type =="smalldatetime":
            s+=c_name+" DATETIME "

        elif d_type == "timestamp":
            s+=c_name+" TIMESTAMP  "

        elif d_type == "float":
            s+=c_name+" DOUBLE "

        elif d_type == "real" :
            s+=c_name+" FLOAT "

        elif d_type == "numeric" or d_type =="decimal" or d_type =="money" or d_type =="smallmoney":
            s+=c_name+" DECIMAL ("+ prec +"," + scale + ")"

        
        else:
            s += ""+ str(c_name) +" "+ str(d_type) + "( "+ str(prec) +")"

        s+=" " + nullable +" "
        
        if default:
            if "((" in default:
                s+=" DEFAULT " + default[2:-2] +" "
            elif "(" in default:
                s+=" DEFAULT " + default[1:-1] +" "
        s+=",\n"

    pk = get_pKeys(table)
    if len(pk) !=0:
        s += "PRIMARY KEY (`" + pk + "` ),\n"
   
    #print len(constraints)
    for cons in constraints:
        if cons.TableName == table:
            s+=" CONSTRAINT " + cons.ForeignKey +" FOREIGN KEY(`"+ cons.ColumnName +"` ) REFERENCES `" +cons.ReferenceTableName+ "` ( `"+cons.ReferenceColumnName+"`)"
            s+= " ON DELETE CASCADE " if cons.DeleteAction else " ON DELETE NO ACTION "
            s+= " ON UPDATE CASCADE " if cons.UpdateAction else " ON UPDATE NO ACTION "
            s+=",\n"

    
    s=s[:-2]
    s += ") DEFAULT CHARSET=utf8 collate utf8_unicode_ci  ENGINE=InnoDB; \n\r\n"
    insertCounter=0
    
    f.write(s)
    cols = get_columnNames(table)
    q = "SELECT " + cols + " FROM " + table
    #print q
    conn.execute(q)
    while 1:
        row = conn.fetchone()
        if not row:
            break
        #print row[2]

        s2=  writeout_insert(row,datatypes,table,cols)
        f.write(s2)
    #return s
    

def get_constraints():
    s=""
    q="select f.name as ForeignKey,f.update_referential_action as UpdateAction,f.delete_referential_action as DeleteAction ,OBJECT_NAME(f.parent_object_id) as TableName,COL_NAME (fc.parent_object_id,fc.parent_column_id) as ColumnName,OBJECT_NAME (f.referenced_object_id) as ReferenceTableName,COL_NAME(fc.referenced_object_id, fc.referenced_column_id) as ReferenceColumnName from sys.foreign_keys as f  INNER JOIN sys.foreign_key_columns as fc ON f.object_id = fc.constraint_object_id "
    conn.execute(q)
    while 1:
        row = conn.fetchone()
        if not row:
            break
        constraints.append(row)
    for c in constraints:
         if not c.ReferenceTableName in tables_ordered:
             tables_ordered.append(c.ReferenceTableName)
    for c in constraints:
         if not c.TableName in tables_ordered:
            tables_ordered.append(c.TableName)
            
    #print tables_ordered
        
def get_columnNames(table):
    s=""
    q="exec sp_columns "+table
    conn.execute(q)
    while 1:
        row = conn.fetchone()
        if not row:
            break
    #    if row[5] == "uniqueidentifier" :
    #        s = s + "CAST (" + row[3] + " AS nvarchar(255)) AS " + row[3] +","
    #    elif row[5] == "timestamp":
    #        s = s + "CAST (" + row[3] + " AS datetime) AS " + row[3] +","

    #    elif row[5] == "text" or row[5] == "ntext":
    #        s = s + "LEFT ( CAST (" + row[3] + " AS VARCHAR(100)) ,100) AS " + row[3] +","

     #   else:
      #  if row[5] == "image":
       #     s = s+ " CAST ( " + row[3] +" AS TEXT AS " + row[3] +","
       # else:
        s=s+ row[3] + " ,"
    
    s=s[:-1]
    #print s
    return s

#def to get the Primary Key of Table
def get_pKeys(table):
    s=""
    q="exec sp_pkeys "+table
    conn.execute(q)
    while 1:
        row = conn.fetchone()
        if not row:
            break
        s = row[3]#c_name

    return s


#def to get the dataType of Column
def get_datatype(table,columnName):
    s =""
    q="exec sp_columns @table_name = " + table +", @column_name = " +columnName
    conn.execute(q)
    while 1:
        row = conn.fetchone()
        if not row:
            break
        s=row[4]
    #print s

def writeout_insert(arr,datatypes,table,cols):
    s=" INSERT INTO " + table.lower() + " ( " + cols +" ) VALUES ("
    l  = len(arr)
    
      
    for i in range(l):
        c=""
         #if datatypes[i] == "datetime" :
         #   arr[i] = convert_date( arr[i] ) 

        if datatypes[i] == "int":
            c+= str(int (0 if arr[i] is None else arr[i]))
            #s += "0"
        elif type(arr[i]) == unicode :
                c += str(arr[i].encode('ascii','ignore'))
                
        else:
                #if "cast " in str(arr[i]):
                #print str(arr[i])
                #s+=re.sub(r'"','',str(arr[i]))
                #s+= re.escape (str(arr[i]))
                #print re.escape (str(arr[i]))
                c+= str(arr[i])


        c= c.replace('\"',"\\\"")
        
        if datatypes[i] !="int":
            s += "\""

        
 
        s = s+c
   
        if datatypes[i] != "int":
            s += "\""
        s += ","
        

    s=s[:-1]
    s+= ");\n"
    #print s
    return s


   
try:
    tables=[]
    tables_ordered=[]
    conn_str ='DRIVER={SQL Server};SERVER='+_srvr+';UID='+_user+' ;PWD='+_pass+';DATABASE='+_db
    print conn_str
    cn = pyodbc.connect (conn_str)
    conn = cn.cursor()
    q_gettables = "select TABLE_NAME from INFORMATION_SCHEMA.tables"
    #show_structure("isometadata")
    ##print get_pKeys("SpatialReferences")
    conn.execute(q_gettables)
    while 1:
        row = conn.fetchone()
        if not row:
            break
        tables.append(row[0])
        #Dump Table
    #print tables
    get_constraints()
    for t in tables:
         if not t in tables_ordered:
             if t != "sysdiagrams":
                tables_ordered.append(t)
    checks = " set foreign_key_checks = 0;\n"
    f.write ( checks)
    f.write("SET sql_mode='NO_AUTO_VALUE_ON_ZERO';\n")
    #print tables_ordered
    for table in tables_ordered:
        show_structure(table)
     #   #print "****TABLE ",table,"****\n"
        ##print "-------------------------\n\n"
    #q_table = "exec sp_help "+ tables[0]
    ##print q_table
    #conn.execute(q_table)
    #for row in conn:
     #       #print row
    #show_structure(tables[1])

except :
    #print e.text
    raise
finally:
    cn.close()
    f.close()

