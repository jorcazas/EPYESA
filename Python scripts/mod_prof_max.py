# -*- coding: utf-8 -*-
"""
Created on Wed Jul  7 23:49:09 2021

@author: javi2
"""

import psycopg2
import sys
import json

def mod_prof_max(prof_max, id_, nombre):
    res=""
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
    
        postgres_insert_query = """ with aux as (select p.id_proyecto, p."ID", p.nombre
from proyecto p) 
update proyecto set prof_max_metros = %s 
where id_proyecto = (select id_proyecto from aux where aux."ID" = %s and nombre = %s) ;"""
        
        record_to_insert = (prof_max, id_, nombre)
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
    
    print(mod_prof_max(sys.argv[1], sys.argv[2], sys.argv[3]))
    
    
    
if __name__ == "__main__":
    main()