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
    /// Lógica de interacción para Visitante.xaml
    /// </summary>
    public partial class Visitante : Window
    {
        public MaquinaConexion mc;
        public Visitante(MaquinaConexion mc)
        {
            InitializeComponent();
            this.mc = mc;
        }

        private void bt_proyectos_r_Click(object sender, RoutedEventArgs e)
        {
            ProyectosRegistradosVisitante pr = new ProyectosRegistradosVisitante(mc);
            pr.Show();
            this.Close();
        }

        private void bt_salir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
