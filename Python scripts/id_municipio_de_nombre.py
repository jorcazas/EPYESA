# -*- coding: utf-8 -*-
"""
Created on Mon Jul  5 21:29:31 2021

@author: javi2
"""

import psycopg2
import pandas as pd
import sys
import json


def id_municipio_de_nombre(nombre_municipio, id_estado):
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
    
        postgres_select_query = """ select m.id_municipio 
        from municipio m join estado e using (id_estado) 
        where m.nombre = %s and e.id_estado = %s """
        
        cursor.execute(postgres_select_query, (nombre_municipio, id_estado))
    
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
    proyecto=id_municipio_de_nombre(sys.argv[1], sys.argv[2])
    df1 = pd.DataFrame(data=proyecto, columns=["id"])
    print(df1["id"][0])


    

if __name__ == "__main__":
    main()