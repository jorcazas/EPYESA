# -*- coding: utf-8 -*-
"""
Created on Tue Jun 15 16:04:42 2021

@author: javi2
"""
import psycopg2
import pandas as pd
import sys
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
p.nombre as "Nombre del Proyecto",fecha as "Fecha", latitud as "Latitud", longitud as "Longitud", c.nombre as "Cliente"
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
            
def generar_capas(proyectosRegistrados, nuevo):
    f = open("local\\maquina.json")
    maquina = json.load(f)
    f.close()
    desktop = maquina["desktop"]
    res = ()
    df1 = pd.DataFrame(data=proyectosRegistrados, columns=["ID","Nombre del Proyecto", 
                                            "Fecha (YYYY-MM-DD)", "Latitud", 
                                            "Longitud", "Cliente"])

    try:
        df1.to_csv(desktop+"\\ProyectosRegistrados.csv", 
                   encoding="utf -8", index=False)
        
    except(Exception) as error:
        res =  ("Por favor, revisa que el archivo ProyectosRegistrados.csv no esté abierto. Error: ", error)
    
    
    df2 = pd.DataFrame(data=nuevo, columns=["ID","Nombre del Proyecto", 
                                            "Fecha (YYYY-MM-DD)", "Latitud", 
                                            "Longitud", "Cliente"])
    
    try:
        df2.to_csv(desktop+"\\ProyectosNuevos.csv", encoding="utf -8", index=False)
    except(Exception) as error:
        res = ("Por favor, revisa que el archivo ProyectosNuevos.csv no esté abierto. Error: ", error)

    return res    
    
    


            
def main():
    proyectosR = leer_proyectos()
    
    nuevo = []
    for arg in sys.argv[1:]:
        nuevo.append(arg)
            
    nuevo = [tuple(nuevo)]
    
    
    res = str(generar_capas(proyectosR, nuevo))
    
    if (res[1:len(res)-1]) == '':
        print("")
    else:
        print(res[1:len(res)-1])
        
if __name__ == "__main__":
    main()