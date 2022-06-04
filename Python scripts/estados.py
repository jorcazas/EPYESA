# -*- coding: utf-8 -*-
"""
Created on Sat Jun 26 18:22:14 2021

@author: javi2
"""


import psycopg2
import json

def leer_estados():
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
    
        postgres_select_query = """ select nombre from estado"""
        
        cursor.execute(postgres_select_query)
    
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
    estados=leer_estados()
    for estado in estados:
        res += (str(estado[0])) 
        res += ","
    print(res)

if __name__ == "__main__":
    main()