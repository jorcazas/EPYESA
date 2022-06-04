# -*- coding: utf-8 -*-
"""
Created on Sun Jun 27 21:08:32 2021

@author: javi2
"""

import psycopg2
import pandas as pd
import sys
import json

def leer_proyecto_completo(nombre,id_):
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
p.prof_max_metros as "Prof_max", p.terminado as "Terminado", p.fecha_finalizacion as "Fecha Finalizacion"
from proyecto p
join municipio m using (id_municipio)
join estado e using (id_estado)
join contacto c using (id_contacto) where p.nombre = %s and 
p."ID" = %s; """
        
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
    proyecto=leer_proyecto_completo(sys.argv[2], sys.argv[1])
    df1 = pd.DataFrame(data=proyecto, columns=["ID","Nombre del Proyecto", "Fecha", 
                                            "Cliente", "Latitud", 
                                            "Longitud", "Estado", "Municipio",
                                            "Prof_max", "Terminado", "Fecha Finalizacion"])
    

    try:
        df1.to_csv(root + "\\Proyectos\\ProyectoEspCompleto.csv", 
                   encoding="utf -8", index=False)
        
    except(Exception) as error:
        res =  ("Por favor, revisa que el archivo ProyectoEspCompleto.csv no esté abierto. Error: ", error)
        
    print(res)

if __name__ == "__main__":
    main()