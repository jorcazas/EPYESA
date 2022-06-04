# -*- coding: utf-8 -*-
"""
Created on Fri Oct 29 11:12:24 2021

@author: javi2
"""

import psycopg2
import pandas as pd
import sys
import json


def leer_proyecto(id_):
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
p.nombre as "Nombre del Proyecto",fecha as "Fecha"
from proyecto p
where p."ID" = %s """
        
        cursor.execute(postgres_select_query, (id_,))
    
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
    proyecto=leer_proyecto(sys.argv[1])
    
    df1 = pd.DataFrame(data=proyecto, columns=["ID","Nombre del Proyecto", 
                                            "Fecha (MM-DD-YYYY)"])
    if not df1.empty:
        res = "id exists"
    
    try:
        df1.to_csv(root+"\\Proyectos\\ProyectoIDExiste.csv", 
                   encoding="utf -8", index=False)
        
    except(Exception) as error:
        res =  ("Por favor, revisa que el archivo ProyectoIDExiste.csv no esté abierto. Error: ", error)
        
    print(res)

if __name__ == "__main__":
    main()