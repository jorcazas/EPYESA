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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaseDeDatosCamargo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string root = "C:\\Users\\javi2\\Documents\\BaseDeDatosCamargo";
        public string desktop = "C:\\Users\\javi2\\Desktop";
        public string python = "C:\\Users\\javi2\\AppData\\Local\\Microsoft\\WindowsApps\\python.exe";
        public MaquinaConexion mc;

        public MainWindow()
        {
            InitializeComponent();
            tb_contrasena.PasswordChar = '*';
            this.mc = new MaquinaConexion(root, desktop, python);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConexionBD con = new ConexionBD(mc);
                string usuario = tb_usuario.Text;
                string[] args = { usuario };
                string contrasena = con.Run_credenciales(args).Split(',')[0];
                contrasena = contrasena.Substring(2, contrasena.Length - 3);
                if (usuario == "administrador" && tb_contrasena.Password == contrasena)
                {
                    Administrador admin = new Administrador(mc);
                    admin.Show();
                    this.Close();
                }
                else if (usuario == "visitante" && tb_contrasena.Password == contrasena)
                {
                    Visitante visit = new Visitante(mc);
                    visit.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Credenciales no válidas.");
                }
            }
            catch
            {
                MessageBox.Show("Credenciales no válidas.");
            }


        }
    }
}
