# -*- coding: utf-8 -*-
"""
Created on Fri Jun 25 22:42:03 2021

@author: javi2
"""


import psycopg2
import sys
import json

def leer_contactos(nombre_empresa_cliente):
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
    
        postgres_select_query = """ select nombre from contacto 
        where id_empresa_cliente = (select id_empresa_cliente 
                                    from empresa_cliente where 
                                    nombre = %s) order by nombre"""
        
        cursor.execute(postgres_select_query, nombre_empresa_cliente)
    
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
    nombre_empresa_cliente = sys.argv[1]
    res = ""
    contactos=leer_contactos([nombre_empresa_cliente])
    for contacto in contactos:
        res += (str(contacto[0])) 
        res += ","
    print(res)

if __name__ == "__main__":
    main()