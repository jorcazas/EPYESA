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
    /// Lógica de interacción para Mapa.xaml
    /// </summary>
    public partial class Mapa : Window
    {
        private string desktop;
        public MaquinaConexion mc;
        public Mapa(MaquinaConexion mc)
        {
            InitializeComponent();
            this.mc = mc;
            this.desktop = mc.desktop;
        }
        private void mapa_Loaded(object sender, RoutedEventArgs e)
        {
            string selectedFileName = desktop + "\\mapa_simple.png";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(selectedFileName);
            bitmap.EndInit();
            mapa.Source = bitmap;

        }


        private void bt_cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
