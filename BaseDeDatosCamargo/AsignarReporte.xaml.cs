using Microsoft.Win32;
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
    /// Lógica de interacción para AsignarReporte.xaml
    /// </summary>
    public partial class AsignarReporte : Window
    {
        private string id="";
        private string nombre = "";
        private string reporte="";
        private string reporte_ruta="";
        private string root;
        public MaquinaConexion mc;
        public AsignarReporte(string id_proyecto,string nombre, MaquinaConexion mc)
        {
            InitializeComponent();
            this.id = id_proyecto;
            this.nombre = nombre;
            this.mc = mc;
            this.root = mc.root;
        }

        private void cb_anio_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime actual = DateTime.Now;
            int i = actual.Year;
            while (i >= 2013)
            {
                cb_anio.Items.Add(i);
                i = i - 1;
            }

        }

        private void cb_mes_Loaded(object sender, RoutedEventArgs e)
        {
            cb_mes.Items.Add("Enero");
            cb_mes.Items.Add("Febrero");
            cb_mes.Items.Add("Marzo");
            cb_mes.Items.Add("Abril");
            cb_mes.Items.Add("Mayo");
            cb_mes.Items.Add("Junio");
            cb_mes.Items.Add("Julio");
            cb_mes.Items.Add("Agosto");
            cb_mes.Items.Add("Septiembre");
            cb_mes.Items.Add("Octubre");
            cb_mes.Items.Add("Noviembre");
            cb_mes.Items.Add("Diciembre");
        }

        private void cb_dia_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < 32; i++)
            {
                cb_dia.Items.Add(i);
            }
        }

        

        private void bt_asignar_reporte_Click(object sender, RoutedEventArgs e)
        {
            string a, b;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Document|*.pdf";
            ofd.ShowDialog();
            a = ofd.SafeFileName;
            reporte = a;
            b = ofd.FileName;
            reporte_ruta = b;
            if (a != "")
            {
                lb_r.Content = "Asignado: " + reporte;
                bt_X_r.Visibility = (Visibility)0;
            }
        }

        private string asignar_reporte()
        {
            try
            {
                string carpeta_reporte, carpeta_id, carpeta_proyecto;
                string id_proyecto = id;
                bool exists;
                ConexionBD con = new ConexionBD(mc);
                carpeta_id = root + "\\DocumentosProyectos\\" + id_proyecto.Replace('-', ' ');
                carpeta_proyecto = carpeta_id + "\\" + nombre;

                carpeta_reporte = carpeta_proyecto + "\\Reporte";

                exists = System.IO.Directory.Exists(carpeta_reporte);

                if (!exists)
                    System.IO.Directory.CreateDirectory(carpeta_reporte);

                string sourceFile = reporte_ruta;
                string destFile = carpeta_reporte
                    + "\\" + reporte;
                System.IO.File.Copy(sourceFile, destFile, true);

                StringBuilder sb_fecha = new StringBuilder();
                sb_fecha.Append(cb_anio.SelectedItem.ToString() + "-"
                    + (cb_mes.SelectedIndex + 1).ToString() + "-"
                    + cb_dia.SelectedItem.ToString());
                string[] args = { sb_fecha.ToString(), id, nombre };
                
                con.Run_asignar_fecha_finalizacion(args);
                return "";

            }
            catch
            {
                return "Error";
            }
        }


        private void bt_X_r_Click(object sender, RoutedEventArgs e)
        {
            lb_r.Content = "";
            bt_X_r.Visibility = (Visibility)1;
            reporte = "";
            reporte_ruta = "";
        }

        private void bt_agregar_Click(object sender, RoutedEventArgs e)
        {
            if (asignar_reporte() != "")
                MessageBox.Show("Selecciona un archivo de reporte y una fecha de finalización válidos, por favor.");
            else
            {
                MessageBox.Show("El proyecto ahora está finalizado.");
                ModificarProyecto mp = new ModificarProyecto(id,nombre, mc);
                mp.Show();
                this.Close();
            }

        }

        private void bt_atras_Click(object sender, RoutedEventArgs e)
        {
            ModificarProyecto mp = new ModificarProyecto(id,nombre, mc);
            mp.Show();
            this.Close();
        }
    }
}
