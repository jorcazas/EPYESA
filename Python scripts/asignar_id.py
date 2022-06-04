# -*- coding: utf-8 -*-
"""
Spyder Editor

This is a temporary script file.
"""


import psycopg2
import sys
import json

def asignar_id(id_):
    res=""
    record_to_insert = (id_)
    try:
        f = open("local\\BDcreds.json")
        creds = json.load(f)
        f.close()
        connection = psycopg2.connect(user = creds["user"],
                                      password = creds["password"],
                                      host = creds["host"],
                                      port = creds["port"],
                                      database = creds["database"])
        cursor = connection.cursor()
    
        postgres_insert_query = """ UPDATE proyecto SET "ID" = %s
        WHERE id_proyecto = (select p.id_proyecto from proyecto p
                             order by p."DateCreated" desc limit 1)"""
        
        cursor.execute(postgres_insert_query, record_to_insert)
    
        connection.commit()
        res = ""
        #count = cursor.rowcount
        #print(count, "Record inserted successfully into mobile table")
        
        

    except (Exception, psycopg2.Error) as error:
        res = ("Error", error)
    
    finally:
        # closing database connection.
        if connection:
            cursor.close()
            connection.close()
            #print("PostgreSQL connection is closed")
            
    return res
    
def main():
    
    print(asignar_id(sys.argv[1]))
    
if __name__ == "__main__":
    main()