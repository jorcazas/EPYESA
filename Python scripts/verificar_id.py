# -*- coding: utf-8 -*-
"""
Created on Tue Aug 17 23:52:41 2021

@author: javi2
"""

import psycopg2
import sys
import json

def verificar_id(id_):
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
    
        postgres_select_query = """ select count(*) from proyecto p where 
        p."ID"=%s """
        
        cursor.execute(postgres_select_query, (id_))
    
        connection.commit()
        
        return cursor.fetchall()
    
    except (Exception, psycopg2.Error) as error:
        return ('Error:', error)
    
    finally:
        # closing database connection.
        if connection:
            cursor.close()
            connection.close()
            #print("PostgreSQL connection is closed")
            
def main():
    res = ""
    
    res=verificar_id([sys.argv[1]])

    print(res[0][0])

if __name__ == "__main__":
    main()