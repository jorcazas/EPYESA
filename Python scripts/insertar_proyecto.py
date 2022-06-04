# -*- coding: utf-8 -*-
"""
Created on Fri Jun 18 21:03:48 2021

@author: javi2
"""
import psycopg2
import sys
import json


def registrar_proyecto(proyecto):
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
    
        postgres_insert_query = """ insert into proyecto 
        ("ID", nombre, fecha, latitud, longitud, 
       	num_sondeos, cantidad_pca, subcontratacion, 
       	id_municipio,id_empresa, id_contacto, factura, terminado) 
       	values (%s, %s,CAST(%s AS DATE),
       	CAST( %s AS REAL),CAST( %s AS REAL),
       	CAST( %s AS INT), CAST(%s AS INT),
       	CAST(%s AS BOOL),CAST(%s AS INT), 
       	(SELECT id_empresa from empresa
       	where nombre = %s), (SELECT id_contacto
       	from contacto where nombre = %s 
       	and id_empresa_cliente = (select id_empresa_cliente
       	from empresa_cliente where nombre = %s)), 
        CAST(%s AS BOOL), false)"""
        
        record_to_insert = proyecto
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
    proyecto = []
    
    for arg in sys.argv[1:]:
        proyecto.append(arg)
            
    
    proyecto = tuple(proyecto)
    print(registrar_proyecto(proyecto))

if __name__ == "__main__":
    main()