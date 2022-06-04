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
    /// Lógica de interacción para ModificarProyecto.xaml
    /// </summary>
    public partial class ModificarProyecto : Window
    {
        private string nombre;
        private string id;
        private string root;
        public MaquinaConexion mc;
        public ModificarProyecto(string id_proyecto,string nombre, MaquinaConexion mc)
        {
            InitializeComponent();
            this.id = id_proyecto;
            this.nombre = nombre;
            this.mc = mc;
            this.root = mc.root;
            ConexionBD con = new ConexionBD(mc);
            string[] args = { id, '"'+nombre+'"' };
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

                    if(values[9] == "True")
                    {
                        string selectedFileName = root+"\\BaseDeDatosCamargo\\verde.png";
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

       


        private void bt_mod_prof_max_Click(object sender, RoutedEventArgs e)
        {
            Asignar_Profundidad ap = new Asignar_Profundidad(id, nombre, mc);
            ap.Show();
            this.Close();

            
        }

        private void bt_atras_Click(object sender, RoutedEventArgs e)
        {
            ProyectosRegistrados pr = new ProyectosRegistrados(mc);
            pr.Show();
            this.Close();
        }


        private void bt_ver_documentos_Click(object sender, RoutedEventArgs e)
        {
            ConexionBD con = new ConexionBD(mc);
            string id_proyecto = lb_id.Content.ToString().Replace('-', ' ');
            string ruta = root+"\\DocumentosProyectos\\" + id_proyecto;

            bool exists = System.IO.Directory.Exists(ruta);

            if (!exists)
                System.IO.Directory.CreateDirectory(ruta);
            con.OpenFolder(ruta);
        }

        private void bt_as_reporte_Click(object sender, RoutedEventArgs e)
        {
            AsignarReporte ar = new AsignarReporte(lb_id.Content.ToString(),nombre, mc);
            ar.Show();
            this.Close();
        }

        private void bt_agregar_factura_Click(object sender, RoutedEventArgs e)
        {
            AgregarFactura af = new AgregarFactura(lb_id.Content.ToString(), mc, lb_nombre.Content.ToString());
            af.Show();
        }

        private void bt_agregar_orden_compra_Click(object sender, RoutedEventArgs e)
        {
            AgregarOrdenCompra aoc = new AgregarOrdenCompra(lb_id.Content.ToString(), mc, lb_nombre.Content.ToString());
            aoc.Show();
        }

        private void bt_agregar_cotizacion_Click(object sender, RoutedEventArgs e)
        {
            AgregarCotizacion ac = new AgregarCotizacion(lb_id.Content.ToString(), mc, lb_nombre.Content.ToString());
            ac.Show();
        }

    }
}
