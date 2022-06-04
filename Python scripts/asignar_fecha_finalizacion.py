# -*- coding: utf-8 -*-
"""
Created on Sun Aug  1 21:37:01 2021

@author: javi2
"""
import psycopg2
import sys
import json


def asignar_fecha_finalizacion(fecha, id_proyecto, nombre):
    res=""
    try:
        f = open("os.getcwd()+"\\"local\\BDcreds.json")
        creds = json.load(f)
        f.close()
        connection = psycopg2.connect(user = creds["user"],
                                      password = creds["password"],
                                      host = creds["host"],
                                      port = creds["port"],
                                      database = creds["database"])
        cursor = connection.cursor()
    
        postgres_insert_query = """update proyecto 
        set fecha_finalizacion = cast(%s as date), terminado = true
        where id_proyecto = (select id_proyecto from proyecto p
					where p."ID" = %s and nombre = %s) """
        
        record_to_insert = (fecha,id_proyecto, nombre)
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
    print(asignar_fecha_finalizacion(sys.argv[1], sys.argv[2], sys.argv[3]))

if __name__ == "__main__":
    main()