using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Runspaces;
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
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class Administrador : Window
    {
        public MaquinaConexion mc;
        public Administrador(MaquinaConexion mc)
        {
            InitializeComponent();
            this.mc = mc;
        }

        private void bt_nuevo_proyecto_Click(object sender, RoutedEventArgs e)
        {
            NuevoProyecto np = new NuevoProyecto(mc);
            np.Show();
            this.Close();
        }

        private void bt_proyectos_r_Click(object sender, RoutedEventArgs e)
        {
            ProyectosRegistrados pr = new ProyectosRegistrados(mc);
            pr.Show();
            this.Close();
        }

        private void bt_salir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void bt_respaldo_Click(object sender, RoutedEventArgs e)
        {
            /*
            RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();

            Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
            runspace.Open();

            Pipeline pipeline = runspace.CreatePipeline();

            //Here's how you add a new script with arguments
            Command myCommand = new Command(scriptfile);
            CommandParameter testParam = new CommandParameter("key", "value");
            myCommand.Parameters.Add(testParam);

            pipeline.Commands.Add(myCommand);

            // Execute PowerShell script
            results = pipeline.Invoke();
            */
        }
    }
}
