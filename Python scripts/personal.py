# -*- coding: utf-8 -*-
"""
Created on Fri Jun 25 22:48:07 2021

@author: javi2
"""

import psycopg2
import json

def leer_personal():
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
    
        postgres_select_query = """ select nombre from personal order by nombre"""
        
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
    personas=leer_personal()
    for persona in personas:
        res += (str(persona[0])) 
        res += ","
    print(res)

if __name__ == "__main__":
    main()