using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para VerProyecto.xaml
    /// </summary>
    public partial class VerProyecto : Window
    {

        private string desktop;
        private string root;
        private string id;
        private string nombre;
        public MaquinaConexion mc;
        public VerProyecto(string id_proyecto, string nombre, MaquinaConexion mc)
        {
            InitializeComponent();
            this.id = id_proyecto;
            this.nombre = nombre;
            this.mc = mc;
            this.root = mc.root;
            this.desktop = mc.desktop;
            ConexionBD con = new ConexionBD(mc);
            string[] args = { id, '"'+nombre +'"'};
            con.Run_proyecto_esp_completo(args);
            using (var reader = new StreamReader(root + "\\Proyectos\\ProyectoEspCompleto.csv"))
            {
                List<string> listA = new List<string>();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    lb_id.Content = values[0];
                    lb_nombre.Content = values[1];
                    lb_fecha.Content = values[2];
                    lb_cliente.Content = values[3];
                    lb_latitud.Content = values[4];
                    lb_longitud.Content = values[5];
                    lb_estado.Content = values[6];
                    lb_municipio.Content = values[7];
                    lb_prof_max.Content = values[8];
                    if (values[9] == "True")
                    {
                        string selectedFileName = root + "\\BaseDeDatosCamargo\\verde.png";
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(selectedFileName);
                        bitmap.EndInit();
                        semaforo.Source = bitmap;
                        lb_terminado.Content = "Terminado";
                        lb_fecha_finalización.Content = values[10];
                    }
                }

            }
        }

        private void bt_atras_Click(object sender, RoutedEventArgs e)
        {
            ProyectosRegistradosVisitante pr = new ProyectosRegistradosVisitante(mc);
            pr.Show();
            this.Close();
        }

        private void bt_reporte_Click(object sender, RoutedEventArgs e)
        {
            if (lb_terminado.Content.ToString() == "NO TERMINADO")
            {
                MessageBox.Show("El proyecto no cuenta con un reporte final dado que no ha sido finalizado.");
            }
            else
            {
                try
                {
                    string carpeta_reporte;
                    string carpeta_id;
                    string id_proyecto = id;
                    string[] files;
                    bool exists;
                    string sourceFile, destFile;
                    ConexionBD con = new ConexionBD(mc);

                    carpeta_id = root + "\\DocumentosProyectos\\" + id_proyecto.Replace('-', ' ');


                    carpeta_reporte = carpeta_id + "\\Reporte";

                    exists = System.IO.Directory.Exists(carpeta_reporte);

                    if (!exists)
                        MessageBox.Show("Este Proyecto no cuenta con reporte final.");
                    else
                    {
                        exists = System.IO.Directory.Exists(desktop + "\\Reporte " + id);
                        if (!exists)
                            System.IO.Directory.CreateDirectory(desktop + "\\Reporte " + id);
                        files = System.IO.Directory.GetFiles(carpeta_reporte);
                        for (int i = 0; i < files.Length; ++i)
                        {
                            sourceFile = files[i];
                            destFile = desktop + "\\Reporte " + id+"\\Reporte-"+i+".pdf";
                            System.IO.File.Copy(sourceFile, destFile, true);
                        }
                        MessageBox.Show("En el escritorio encontrarás la " +
                            "carpeta 'Reporte " + id + "' con el reporte de este proyecto.");
                    }

                }
                catch
                {
                }
            }
        }
    }
}
