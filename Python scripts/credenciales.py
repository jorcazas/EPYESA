# -*- coding: utf-8 -*-
"""
Created on Tue Aug  3 10:44:02 2021

@author: javi2
"""

import psycopg2
import sys
import json

def usuario_contrasena(usuario):
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
    
        postgres_select_query = """select contrasena from "usuario-contrasena" 
        where usuario = %s"""
        
        cursor.execute(postgres_select_query, (usuario))
    
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
    usuario = sys.argv[1]
    res = ""
    contrasena=usuario_contrasena([usuario])
    res += (str(contrasena[0])) 
    print(res)

if __name__ == "__main__":
    main()