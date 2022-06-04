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
    /// Lógica de interacción para ReporteEconomico.xaml
    /// </summary>
    public partial class ReporteEconomico : Window
    {
        public MaquinaConexion mc;

        public ReporteEconomico(MaquinaConexion mc)
        {

            InitializeComponent();
            this.mc = mc;
            try
            {
                ConexionBD con = new ConexionBD(mc);
                con.Run_leer_reporte_economico();
                dg.ItemsSource = con.CreateDataSourceRepEco("ReporteEconomico");
            }
            catch
            {
                MessageBox.Show("Por favor, cierra el documento ReporteEconomico.csv");
            }
        }

        private void bt_atras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
