# -*- coding: utf-8 -*-
"""
Created on Sun Jul 25 20:29:07 2021

@author: javi2
"""

import psycopg2
import sys
import json

def registrar_empresa_cliente(empresa_cliente):
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
    
        postgres_insert_query = """insert into empresa_cliente 
        (nombre) values (%s)"""
        
        record_to_insert = empresa_cliente
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
    empresa_cliente = [sys.argv[1]]
    
    empresa_cliente = tuple(empresa_cliente)
    print(registrar_empresa_cliente(empresa_cliente))

if __name__ == "__main__":
    main()