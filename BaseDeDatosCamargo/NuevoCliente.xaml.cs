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
    /// Lógica de interacción para NuevoCliente.xaml
    /// </summary>
    public partial class NuevoCliente : Window
    {
        public MaquinaConexion mc;
        public NuevoCliente(MaquinaConexion mc)
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
                string telefono = '"' + tb_tel.Text + '"'; 
                string correo = '"' + tb_correo.Text + '"';
                string empresa = '"' + cb_empresa_cliente.SelectedItem.ToString() + '"';
                string[] arg = { nombre,telefono, correo, empresa };
                string status_act = con.Run_registrar_contacto(arg);
                if (status_act.Length < 3)
                {
                    MessageBox.Show("Contacto de cliente agregado con éxito a la base de datos.");
                    this.Close();
                }
                else
                    MessageBox.Show("Por favor, revisa que todos los campos estén correctamente llenados.");
            }
            catch
            {
                MessageBox.Show("Verifique que todos los campos se llenaron correctamente. \n" +
                    "Si desea dejar un dato en blanco, escriba un guión (-)");
            }
        }

        private void cb_empresa_cliente_Loaded(object sender, RoutedEventArgs e)
        {
            ConexionBD con = new ConexionBD(mc);
            String status_act = con.Run_empresas_cliente();
            if (status_act.Length > 2)
            {
                for (int j = 0; j < status_act.Split(',').Length - 1; j++)
                {
                    cb_empresa_cliente.Items.Add(status_act.Split(',')[j]);
                }
            }
        }
        private void bt_refresh_Click(object sender, RoutedEventArgs e)
        {
            cb_empresa_cliente.Items.Clear();
            ConexionBD con = new ConexionBD(mc);
            String status_act = con.Run_empresas_cliente();
            if (status_act.Length > 2)
            {
                for (int j = 0; j < status_act.Split(',').Length - 1; j++)
                {
                    cb_empresa_cliente.Items.Add(status_act.Split(',')[j]);
                }
            }
        }

        private void bt_nueva_Click(object sender, RoutedEventArgs e)
        {
            NuevaEmpresaCliente nec = new NuevaEmpresaCliente(mc);
            nec.Show();
        }

        
    }
}
