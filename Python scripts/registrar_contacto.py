# -*- coding: utf-8 -*-
"""
Created on Sun Jul 25 19:02:34 2021

@author: javi2
"""

import psycopg2
import sys
import json

def registrar_contacto(contacto):
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
    
        postgres_insert_query = """ insert into contacto 
	(nombre, telefono, correo, id_empresa_cliente) 
	values (%s,%s, %s,(SELECT id_empresa_cliente from empresa_cliente
	where nombre = %s))"""
        
        record_to_insert = contacto
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
    contacto = []
    
    for arg in sys.argv[1:]:
        contacto.append(arg)  
            
    
    contacto = tuple(contacto)
    print(registrar_contacto(contacto))

if __name__ == "__main__":
    main()