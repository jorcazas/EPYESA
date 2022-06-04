# -*- coding: utf-8 -*-
"""
Created on Sat Jun 26 21:38:30 2021

@author: javi2
"""

import psycopg2
import pandas as pd
import sys
import json

def leer_proyecto(nombre,id_):
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
p.nombre as "Nombre del Proyecto",fecha as "Fecha", latitud as "Latitud", 
longitud as "Longitud", c.nombre as "Cliente", num_sondeos as "No. de Sondeos",
cantidad_pca as "Cantidad de PCA´s", prof_max_metros as "Profundidad Maxima (m)"
from proyecto p
join contacto c using (id_contacto) where p.nombre = %s or 
p."ID" = %s """
        
        cursor.execute(postgres_select_query, (nombre,id_))
    
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
    f = open("local\\maquina.json")
    maquina = json.load(f)
    f.close()
    root = maquina["root"]
    res = ""
    proyecto=leer_proyecto(sys.argv[1], sys.argv[1])
    
    df1 = pd.DataFrame(data=proyecto, columns=["ID","Nombre del Proyecto", 
                                            "Fecha (MM-DD-YYYY)", "Latitud", 
                                            "Longitud", "Cliente", "No. de Sondeos",
                                            "Cantidad de PCA´s", "Profundidad Máxima (m)"])
    
    try:
        df1.to_csv(root+"\\Proyectos\\ProyectoEsp.csv", 
                   encoding="utf -8", index=False)
        
    except(Exception) as error:
        res =  ("Por favor, revisa que el archivo ProyectoEsp.csv no esté abierto. Error: ", error)
        
    print(res)

if __name__ == "__main__":
    main()