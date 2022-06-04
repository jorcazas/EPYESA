# -*- coding: utf-8 -*-
"""
Created on Mon Jul  5 19:01:10 2021

@author: javi2
"""
import psycopg2
import pandas as pd
import json

def leer_ultimo():
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
    
        postgres_select_query = """ select p."ID",
p.nombre as "Nombre del Proyecto", fecha as "Fecha",c.nombre as "Cliente",
latitud as "Latitud", longitud as "Longitud", e.nombre as "Estado", m.nombre as "Municipio",
p.prof_max_metros as "Prof_max"
from proyecto p
join municipio m using (id_municipio)
join estado e using (id_estado)
join contacto c using (id_contacto) order by p."DateCreated" desc limit 1 """
        
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
    proyecto=leer_ultimo()
    df1 = pd.DataFrame(data=proyecto, columns=["ID","Nombre del Proyecto", "Fecha", 
                                            "Cliente", "Latitud", 
                                            "Longitud", "Estado", "Municipio",
                                            "Prof_max"])
    print(df1["ID"][0])

    

if __name__ == "__main__":
    main()