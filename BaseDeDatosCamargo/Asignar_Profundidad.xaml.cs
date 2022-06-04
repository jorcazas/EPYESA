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
    /// Lógica de interacción para Asignar_Profundidad.xaml
    /// </summary>
    public partial class Asignar_Profundidad : Window
    {
        private string id_proyecto;
        private string nombre;
        public MaquinaConexion mc;
        public Asignar_Profundidad(string id,string nombre, MaquinaConexion mc)
        {
            InitializeComponent();
            id_proyecto = id;
            this.nombre = nombre;
            this.mc = mc;
        }

        private void bt_agregar_Click(object sender, RoutedEventArgs e)
        {
            ConexionBD con = new ConexionBD(mc);
            string prof = tb_prof.Text;
            string[] args = { prof, id_proyecto, '"'+nombre+'"' };
            con.Run_mod_prof_max(args);
            if(tb_prof.Text != null)
            {
                lb_prof_mod.Content = "La profunidad máxima del proyecto " +nombre + "\n"+ 
                    "se estableció como: " + tb_prof.Text + " metros" ;
            }
        }

        private void bt_atras_Click(object sender, RoutedEventArgs e)
        {
            ModificarProyecto mp = new ModificarProyecto(id_proyecto,nombre, mc);
            mp.Show();
            this.Close();
        }
    }
}
