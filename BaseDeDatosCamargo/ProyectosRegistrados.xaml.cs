using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    /// Lógica de interacción para ProyectosRegistrados.xaml
    /// </summary>
    public partial class ProyectosRegistrados : Window
    {
        private string desktop;
        public MaquinaConexion mc;
        public ProyectosRegistrados(MaquinaConexion mc)
        {
            InitializeComponent();
            this.mc = mc;
            this.desktop = mc.desktop;
            try
            { 
                ConexionBD con = new ConexionBD(mc);
                con.Run_ver_registros();
                dg.ItemsSource = con.CreateDataSource("ProyectosRegistrados");
            }
            catch
            {
                MessageBox.Show("Por favor, cierra el documento ProyectosRegistrados.csv");
            }

        }

        private void bt_atras_Click(object sender, RoutedEventArgs e)
        {
            Administrador admin = new Administrador(mc);
            admin.Show();
            this.Close();
        }

        private void bt_buscar_Click(object sender, RoutedEventArgs e)
        {
            ConexionBD con = new ConexionBD(mc);
            if (tb_busqueda_proyecto.Text != "")
            {
                string[] arg = { tb_busqueda_proyecto.Text };
                con.Run_proyecto_esp(arg);
                dg.ItemsSource = con.CreateDataSourceEsp("ProyectoEsp");
            }


        }

        private void bt_volver_Click(object sender, RoutedEventArgs e)
        {
            ConexionBD con = new ConexionBD(mc);
            con.Run_ver_registros();
            dg.ItemsSource = con.CreateDataSource("ProyectosRegistrados");
        }

        private void dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {


            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;
            string id_proyecto = row_selected["ID"].ToString();
            string nombre = row_selected["Proyecto"].ToString();

            ModificarProyecto mp = new ModificarProyecto(id_proyecto,nombre, mc);
            mp.Show();
            this.Close();


        }

        private void bt_mapa_Click(object sender, RoutedEventArgs e)
        {
            
            ConexionBD con = new ConexionBD(mc);
            con.Run_generar_mapa_simple();
            /*
            Mapa m = new Mapa(mc);
            m.Show();
            */
            String act_mapas = con.Run_ver_registros();
            if (act_mapas.Length < 3)
            {
                Console.Write(act_mapas);
                MessageBox.Show("A continuación, en el Escritorio podrá consultar \n" +
                "el archivo ProyectosRegistrados.csv, el cual contiene la información \n" +
                "de todos los proyectos y está listo para ser exportado a un programa de geolocalización.");
                con.OpenFolder(desktop);
            }
            else
            {
                MessageBox.Show("Cierre el archivo ProyectosRegistrados.csv e inténtalo de nuevo");
            }
            
            
            

        }

        private void bt_reporte_economico_Click(object sender, RoutedEventArgs e)
        {
            ReporteEconomico re = new ReporteEconomico(mc);
            re.Show();
        }
    }
}
