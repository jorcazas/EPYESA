# -*- coding: utf-8 -*-
"""
Created on Sat Jun 26 18:46:26 2021

@author: javi2
"""

import psycopg2
import sys
import json

def leer_municipios(id_estado):
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
    
        postgres_select_query = """ select nombre from municipio where id_estado = %s"""
        
        cursor.execute(postgres_select_query, id_estado)
    
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
    id_estado = sys.argv[1]
    res = ""
    municipios=leer_municipios([id_estado])
    for municipio in municipios:
        res += (str(municipio[0])) 
        res += ","
    print(res)

if __name__ == "__main__":
    main()