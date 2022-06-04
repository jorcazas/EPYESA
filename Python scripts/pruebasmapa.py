# -*- coding: utf-8 -*-
"""
Created on Tue Jul  6 09:36:06 2021

@author: javi2
"""

import psycopg2
import pandas as pd
import matplotlib.pyplot as plt
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
    proyectosRegistrados=leer_proyectos()
    df1 = pd.DataFrame(data=proyectosRegistrados, columns=["Nombre del Proyecto",
                                                           "Latitud",
                                                           "Longitud"])

    latitud_mapa=[]
    longitud_mapa= []
    latitud_mapa_ajustada = []
    longitud_mapa_ajustada = []
    lat_max=34.343
    lat_min=11.480
    long_max=-79.014
    long_min=-123.662
    pixeles = (1014, 571)
    
    for value in df1["Latitud"]:
        latitud_mapa.append(value-11.480)
    
    for value in df1["Longitud"]:
        longitud_mapa.append(value+123.662)
        
    for value in latitud_mapa:
        latitud_mapa_ajustada.append(value*pixeles[1]/(lat_max-lat_min))
        
    for value in longitud_mapa:
        longitud_mapa_ajustada.append(value*pixeles[0]/(long_max-long_min))
        
    print(latitud_mapa_ajustada, longitud_mapa_ajustada)
    
    extent=(0,pixeles[0],0,pixeles[1])
    
     

    
    
    im = plt.imread("mapa.png")
    plt.imshow(im, extent=extent)
    plt.scatter(longitud_mapa_ajustada,latitud_mapa_ajustada, c='#CFB031', s=1)
    plt.scatter(554,200,c='#16A914', s=1)
    plt.savefig("mapa_simple.png", dpi=500)
    

if __name__ == "__main__":
    main()