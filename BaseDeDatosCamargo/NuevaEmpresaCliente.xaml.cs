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
    /// Lógica de interacción para NuevaEmpresaCliente.xaml
    /// </summary>
    public partial class NuevaEmpresaCliente : Window
    {
        public MaquinaConexion mc;
        public NuevaEmpresaCliente(MaquinaConexion mc)
        {
            InitializeComponent();
            this.mc = mc;
        }

        private void bt_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_agregar_Click(object sender, RoutedEventArgs e)
        {
            ConexionBD con = new ConexionBD(mc);
            try
            {
                string nombre = '"' + tb_nombre.Text + '"';
                string[] arg = { nombre };

                string status_act = con.Run_registrar_empresa_cliente(arg);
                if (status_act.Length < 3)
                {
                    MessageBox.Show("Empresa Cliente agregado con éxito a la base de datos.");
                    this.Close();
                }
                else
                    MessageBox.Show("Por favor, revisa que todos los campos estén correctamente llenados.");
            }
            catch
            {
                MessageBox.Show("Verifique que todos los campos se llenaron correctamente.");
            }
        }
    }
}
