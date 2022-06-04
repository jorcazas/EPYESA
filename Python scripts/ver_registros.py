# -*- coding: utf-8 -*-
"""
Created on Sun Jun 20 19:30:51 2021

@author: javi2
"""
import psycopg2
import pandas as pd
import json

def leer_proyectos():
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
p.nombre as "Nombre del Proyecto", fecha as "Fecha", latitud as "Latitud", 
longitud as "Longitud", c.nombre as "Cliente", p.num_sondeos as "No. de Sondeos",
cantidad_pca as "Cantidad de PCA´s", prof_max_metros as "Profundidad Máxima (m)"
from proyecto p
join contacto c using (id_contacto) order by p."ID" """
        
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
    f = open("local\\maquina.json")
    maquina = json.load(f)
    f.close()
    desktop = maquina["desktop"]
    res = ""
    proyectosRegistrados=leer_proyectos()
    df1 = pd.DataFrame(data=proyectosRegistrados, columns=["ID","Nombre del Proyecto", 
                                            "Fecha (MM-DD-YYYY)", "Latitud", 
                                            "Longitud", "Cliente", "No. de Sondeos",
                                            "Cantidad de PCA´s", "Profundidad Maxima (m)"])
    
    
    try:
        df1.to_csv(desktop+"\\ProyectosRegistrados.csv", 
                   encoding="utf -8", index=False)
        
    except(Exception) as error:
        res =  ("Por favor, revisa que el archivo ProyectosRegistrados.csv no esté abierto. Error: ", error)
        
    return res

if __name__ == "__main__":
    main()