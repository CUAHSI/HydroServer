#!/usr/bin/python

import MySQLdb as mdb
import sys


tables=[]
_srvr = "localhost"
_user = "root"
_pass = "pakistan"
_db   = "mydb"
constraints=[]
f=open("my2ms.sql",'w')
reserved=['definition']
def show_structure(table):
        s =""
        datatypes=[]
        primary =""
        q="SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME =  '"+table+"'"
        conn.execute(q)
        print"---------------"+table+"-----------\n"
        s+="\n\nIF OBJECT_ID('"+table+"') IS NOT NULL\nBEGIN\nDROP TABLE "+table+"\nEND\n\n"
        s+= "--\n-- Table structure for table '"+table+"\n--\n"
        s+= "CREATE TABLE " + table.lower() + "(\n";
        while 1:
                row = conn.fetchone()
                if not row:
                        break
                nullable =" NULL " if row[6]=="YES" else " NOT NULL "
                #print nullable
                c_name  = row[3]
                default = row[5]
                d_type  = row[7]
                character_maxlen = row[8]
                prec    = row[9]
                scale   = row[10]
                col_key = row[14]
                primary =""
                #print row
                c_name = c_name+"1" if c_name.lower() in reserved else c_name
                
                datatypes.insert( (row[4] -1), d_type)
                if d_type.lower() == "int":
                        s+=c_name+" INT "
                elif d_type.lower() == "tinyint":
                        s+=c_name+" TINYINT "

                elif d_type.lower() == "smallint":
                        s+=c_name+" SMALLINT "
                elif d_type.lower() == "mediumint":
                        s+=c_name+" INT "

                elif d_type.lower() == "INTEGER":
                        s+=c_name+" INT"

                elif d_type.lower() == "bigint":
                        s+=c_name+" BIGINT "
                elif d_type.lower() == "float":
                        if prec <25:
                                s+=c_name+" FLOAT(0) "
                        else:
                                s+=c_name+" FLOAT(25) "

                elif d_type.lower() == "bigint":
                        s+=c_name+" BIGINT "
                
                elif d_type.lower() == "double":
                        s+=c_name+" FLOAT(25) "

                elif d_type.lower() == "double precision":
                        s+=c_name+" FLOAT(25) "

                elif d_type.lower() == "bigint":
                        s+=c_name+" BIGINT "

                elif d_type.lower() == "real":
                        s+=c_name+" REAL "

                elif d_type.lower() == "decimal":
                        s+=c_name+" DECIMAL "

                elif d_type.lower() == "numeric":
                        s+=c_name+" NUMERIC "

                elif d_type.lower() == "date":
                        s+=c_name+" SMALLDATETIME "

                elif d_type.lower() == "datetime":
                        s+=c_name+" DATETIME "  
              
                elif d_type.lower() == "timestamp":
                        s+=c_name+" TIMESTAMP "

                elif d_type.lower() == "time":
                        s+=c_name+" SMALLDATETIME "

                elif d_type.lower() == "year":
                        s+=c_name+" SMALLDATETIME "

                elif d_type.lower() == "char":
                        if character_maxlen <=255:
                                s+=c_name+" CHAR (" + str(character_maxlen) +")"
                        else:
                                s+=c_name +" TEXT "

                elif d_type.lower() == "varchar":
                        if character_maxlen <=255:
                                s+=c_name+" VARCHAR (" + str(character_maxlen) +")"
                        else:
                                s+=c_name +" TEXT "

                elif d_type.lower() == "tinyblob":
                        s+=c_name+" BINARY "

                elif d_type.lower() == "blob":
                        s+=c_name+" VARBINARY "

                elif d_type.lower() == "text":
                        s+=c_name+" TEXT "

                elif d_type.lower() == "mediumblob":
                        s+=c_name+" IMAGE "

                elif d_type.lower() == "mediumtext":
                        s+=c_name+" TEXT "

                elif d_type.lower() == "longblob":
                        s+=c_name+" IMAGE "

                elif d_type.lower() == "longtext":
                        s+=c_name+" TEXT " 
              
                else:
                        s += ""+ str(c_name) +" "+ str(d_type) + "( "+ str(prec) +")"

                s+=" "+ nullable  + " "

                if default:
                        if "((" in default:
                                s+= " DEFAULT '" + default[2:-2]+ "' "
                        elif "(" in default:
                                s+= " DEFAULT '" + default[1:-1]+ "' "
                        else:
                                s+=" DEFAULT '"+ default + "' "
                
                
                for constraint in constraints:
                        if constraint[0] == table and constraint[2].lower() == 'primary':
                                if c_name == constraint[1]:
                                        primary = constraint[1]
                #P_Id int NOT NULL PRIMARY KEY,
                if primary:
                        s+=" PRIMARY KEY "
                
                
                s+=",\n"
                
                #CONSTRAINT fk_PerOrders FOREIGN KEY (P_Id)REFERENCES Persons(P_Id)

        
        
        for cons in constraints:
                if cons[0] == table and constraint[2].lower() != 'primary':
                        s+="CONSTRAINT " + cons[2] +" FOREIGN KEY ("+ cons[1] +" ) REFERENCES " +cons[3]+ " ( "+cons[4]+"),\n"
        s=s[:-2]
        
        s += ")\n"
        f.write(s)
        #print s

        cols = get_columnNames(table)
        q = "SELECT " + cols + " FROM " + table
        #print q
        conn.execute(q)

        while 1:
                row = conn.fetchone()
                if not row:
                        break
                s2= writeout_insert(row,datatypes,table,cols)
                f.write(s2)
                

                

def writeout_insert(arr,datatypes,table,cols):
        columns = cols.split(',')
        print columns
        for index,col in enumerate(columns):
                if col.lower() in reserved:
                        columns[index] = col+"1"
        cols= ",".join(columns)
        print cols
        s="INSERT INTO " + table.lower() + " ( " + cols +" ) VALUES ("
        l  = len(arr)
        print l
    
      
        for i in range(l):
                c=""
         #if datatypes[i] == "datetime" :
         #   arr[i] = convert_date( arr[i] ) 

                if datatypes[i] == "int":
                        c+= str(int (0 if arr[i] is None else arr[i]))
            
                elif type(arr[i]) == unicode :
                        c += str(arr[i].encode('ascii','ignore'))
                
                else:
                        c+= str(arr[i])


                c= c.replace('\'',"\'\'")
        
                if datatypes[i] !="int":
                        s += "\'"
        
 
                s = s+c
   
                if datatypes[i] != "int":
                        s += "\'"
                s += ","
        

        s=s[:-1]
        s+= ");\n"
        #print s
        return s

        
def get_columnNames(table):
        s=""
        q="SHOW COLUMNS FROM "+_db+"."+table+";"
        conn.execute(q)
        while 1:
                row = conn.fetchone()
                if not row:
                        break
                s=s+ row[0] + ","

        s=s[:-1]

        #print s
        return s
        
	
def get_constraints():
	s=""
    	q="SELECT TABLE_NAME, COLUMN_NAME, CONSTRAINT_NAME, REFERENCED_TABLE_NAME, REFERENCED_COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE CONSTRAINT_SCHEMA='"+_db+"'"    
	conn.execute(q)
	while 1:
		row = conn.fetchone()
        	if not row:
            		break
		constraints.append(row)
#	print "contraints"
#	('censorcodecv', 'Term', 'PRIMARY', None, None)
        
                        


try:
	tables=[]
	con = mdb.connect(_srvr,_user,_pass,_db);
	q_gettables = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables where TABLE_SCHEMA='"+_db+"'"
   	conn = con.cursor()
   	get_constraints()
    	conn.execute(q_gettables)
    	checks = 'EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"'
    	f.write ( checks)
    	
	while 1:
		row = conn.fetchone()
		if not row:
        		break
		#print row[0]
		tables.append(row[0])
        for table in tables:
                show_structure(table)
	
	
	#print tables
	#show_structure('censorcodecv')
except mdb.Error, e:
  
    print "Error %d: %s" % (e.args[0],e.args[1])
    sys.exit(1)
    
finally:    
        
        if con:
                con.close()
        f.close()
