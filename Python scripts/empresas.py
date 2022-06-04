# -*- coding: utf-8 -*-
"""
Created on Thu Jun 24 22:51:36 2021

@author: javi2
"""

import psycopg2
import json


def leer_empresas():
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
    
        postgres_select_query = """ select nombre from empresa order by nombre"""
        
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
    empresas=leer_empresas()
    for empresa in empresas:
        res += (str(empresa[0])) 
        res += ","
    print(res)

if __name__ == "__main__":
    main()