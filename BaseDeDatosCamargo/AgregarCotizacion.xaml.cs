﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BaseDeDatosCamargo
{
    /// <summary>
    /// Lógica de interacción para AsignarCotizacion.xaml
    /// </summary>
    public partial class AgregarCotizacion : Window
    {
        private string id = "";
        private string cotizacion = "";
        private string cotizacion_ruta = "";
        public MaquinaConexion mc;
        private string root;
        private string nombre;
        public AgregarCotizacion(string id_proyecto, MaquinaConexion mc, string nombre)
        {
            InitializeComponent();
            this.id = id_proyecto;
            this.mc = mc;
            this.root = mc.root;
            this.nombre = nombre;
        }

        private void bt_asignar_cotizacion_Click(object sender, RoutedEventArgs e)
        {
            string a, b;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Document|*.pdf";
            ofd.ShowDialog();
            a = ofd.SafeFileName;
            cotizacion = a;
            b = ofd.FileName;
            cotizacion_ruta = b;
            if (a != "")
            {
                lb_r.Content = "Asignado: " + cotizacion;
                bt_X_r.Visibility = (Visibility)0;
            }
        }

        private string agregar_cotizacion()
        {
            try
            {
                string carpeta_cotizacion, carpeta_id, carpeta_proyecto;
                string id_proyecto = id;
                bool exists;
                ConexionBD con = new ConexionBD(mc);
                carpeta_id = root + "\\DocumentosProyectos\\" + id_proyecto.Replace('-', ' ');
                carpeta_proyecto = carpeta_id + "\\" + nombre;

                carpeta_cotizacion = carpeta_proyecto + "\\Cotizacion";

                exists = System.IO.Directory.Exists(carpeta_cotizacion);

                if (!exists)
                    System.IO.Directory.CreateDirectory(carpeta_cotizacion);

                string sourceFile = cotizacion_ruta;
                string destFile = carpeta_cotizacion
                    + "\\" + cotizacion;
                System.IO.File.Copy(sourceFile, destFile, true);
                return "";


            }
            catch
            {
                return ("Error");
            }
        }

        private void bt_agregar_Click(object sender, RoutedEventArgs e)
        {
            if (agregar_cotizacion() != "")
                MessageBox.Show("Selecciona un archivo válido, por favor.");
            else
            {
                MessageBox.Show("Documento agregado con éxito.");
                this.Close();
            }

        }

        private void bt_atras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_X_r_Click(object sender, RoutedEventArgs e)
        {
            lb_r.Content = "";
            bt_X_r.Visibility = (Visibility)1;
            cotizacion = "";
            cotizacion_ruta = "";
        }


    }
}
