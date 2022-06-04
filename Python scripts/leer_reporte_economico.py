# -*- coding: utf-8 -*-
"""
Created on Mon Aug  2 00:20:53 2021

@author: javi2
"""

import psycopg2
import pandas as pd
import json

def leer_reporte_economico():
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
    
        postgres_select_query = """ select * from reporte_facturas order by "Proyecto" """
        
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
    reporte_economico=leer_reporte_economico()
    df1 = pd.DataFrame(data=reporte_economico, columns=["ID","Proyecto", 
                                            "Empresa", "Factura", 
                                            "Monto", "Monto con IVA"])

    try:
        df1.to_csv(desktop+"\\ReporteEconomico.csv", 
                   encoding="utf -8", index=False)
        
    except(Exception) as error:
        res =  ("Por favor, revisa que el archivo ProyectosRegistrados.csv no esté abierto. Error: ", error)
        
    return res

if __name__ == "__main__":
    main()