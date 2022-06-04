# -*- coding: utf-8 -*-
"""
Created on Mon Jul 12 22:07:46 2021

@author: javi2
"""

import psycopg2
import pandas as pd
import matplotlib.pyplot as plt
import os
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
    
        postgres_select_query = """ select p.nombre as "Nombre del Proyecto", latitud as "Latitud", longitud as "Longitud" from proyecto  p where 
latitud is not null and longitud is not null"""
        
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
    root = maquina["root"]
    desktop = maquina["desktop"]
    
    proyectosRegistrados=leer_proyectos()
    df1 = pd.DataFrame(data=proyectosRegistrados, columns=["Nombre del Proyecto",
                                                           "Latitud",
                                                           "Longitud"])

    latitud_mapa=[]
    longitud_mapa= []
    latitud_mapa_ajustada = []
    longitud_mapa_ajustada = []
    lat_max=36
    lat_min=10
    long_max=-83.5
    long_min=-123
    pixeles = (9750, 6431)
    
    for value in df1["Latitud"]:
        latitud_mapa.append(value-lat_min)
    
    for value in df1["Longitud"]:
        longitud_mapa.append(value-long_min)
        
    for value in latitud_mapa:
        latitud_mapa_ajustada.append(value*pixeles[1]/(lat_max-lat_min))
        
    for value in longitud_mapa:
        longitud_mapa_ajustada.append(value*pixeles[0]/(long_max-long_min))
        
    print(latitud_mapa_ajustada, longitud_mapa_ajustada)
    
    extent=(0,pixeles[0],0,pixeles[1])

    
    im = plt.imread(root+"\\mapa.jpg")
    plt.imshow(im, extent=extent)
    plt.scatter(longitud_mapa_ajustada,latitud_mapa_ajustada, c='#1236D9', s=0.1, marker = '.') 
    
    if os.path.exists(desktop + "\\mapa_simple.png"):
        os.remove(desktop + "\\mapa_simple.png")
    

    plt.savefig(desktop + "\\mapa_simple.png", dpi=2000)
    

if __name__ == "__main__":
    main()