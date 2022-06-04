# -*- coding: utf-8 -*-
"""
Created on Sun Jun 27 20:39:41 2021

@author: javi2
"""

import psycopg2
import sys
import json


def registrar_prof_max(id_proyecto, prof_max):
    res=""
    record_to_insert = (id_proyecto, prof_max)
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
    
        postgres_insert_query = """ UPDATE proyecto SET prof_max_metros = cast(%s as int) 
WHERE id_proyecto = (select p.id_proyecto from proyecto p
where p."ID" = %s)
"""
        
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
    
    
    print(registrar_prof_max(sys.argv[1], sys.argv[2]))

if __name__ == "__main__":
    main()