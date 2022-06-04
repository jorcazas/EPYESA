# -*- coding: utf-8 -*-
"""
Created on Mon Jul 12 22:08:27 2021

@author: javi2
"""

import psycopg2
import pandas as pd
import matplotlib.pyplot as plt
import sys
import os
import json

def coord_long_2_mapa(long):
    long = float(long)
    long_max=-79.014
    long_min=-123.662
    pixeles = (1014, 571)
    res = long+123.662
    res = res*pixeles[0]/(long_max-long_min)
    return res

def coord_lat_2_mapa(lat):
    lat = float(lat)
    lat_max=34.343
    lat_min=11.480
    pixeles = (1014, 571)
    res = lat-11.480
    res = res*pixeles[1]/(lat_max-lat_min)
    return res

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
    
        postgres_select_query = """ select p.nombre as "Nombre del Proyecto",
        latitud as "Latitud", longitud as "Longitud" from proyecto p """
        
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
    lat_min=12
    long_max=-84
    long_min=-125
    pixeles = (16000, 9368)
    
    for value in df1["Longitud"]:
        longitud_mapa.append(value+125)
    
    for value in df1["Latitud"]:
        latitud_mapa.append(value-12)
    
    for value in longitud_mapa:
        longitud_mapa_ajustada.append(value*pixeles[0]/(long_max-long_min))
        
    for value in latitud_mapa:
        latitud_mapa_ajustada.append(value*pixeles[1]/(lat_max-lat_min))
            
    
    extent=(0,pixeles[0],0,pixeles[1])
    

    im = plt.imread(root+"//mapa.jpg")
    plt.imshow(im, extent=extent)
    plt.scatter(longitud_mapa_ajustada,latitud_mapa_ajustada, c='#CFB031', s=10)
    plt.scatter(coord_long_2_mapa(sys.argv[1]),coord_lat_2_mapa(sys.argv[2]),c='#1236D9', s=10)
    
    
    if os.path.exists(desktop + "\\mapa_simple_proyecto_nuevo.png"):
        os.remove(desktop + "\\mapa_simple_proyecto_nuevo.png")
    
    plt.savefig(desktop+"\\mapa_simple_proyecto_nuevo.png", dpi=500)
    

if __name__ == "__main__":
    main()