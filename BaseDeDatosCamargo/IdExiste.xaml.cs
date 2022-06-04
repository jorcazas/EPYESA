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
    /// Lógica de interacción para IdExiste.xaml
    /// </summary>
    public partial class IdExiste : Window
    {
        private Proyecto p;
        public MaquinaConexion mc;
        public IdExiste(MaquinaConexion mc, Proyecto p)
        {
            InitializeComponent();
            this.mc = mc;
            this.lb_id.Content = p.id;
            this.p = p;


            try
            {
                ConexionBD con = new ConexionBD(mc);
                string[] arg = { p.id };
                con.Run_id_existe(arg);
                dg.ItemsSource = con.CreateDataSourceIdExiste("ProyectoIDExiste");
            }
            catch
            {
                MessageBox.Show("Por favor, cierra el documento ProyectoIDExiste.csv");
            }
        }

        private void bt_agregar_Click(object sender, RoutedEventArgs e)
        {
            ConexionBD con = new ConexionBD(mc);
            if (Double.Parse(p.latitud) > 11.480 && Double.Parse(p.latitud) < 34.343
                && Double.Parse(p.longitud) > -123.662 && Double.Parse(p.longitud) < -79.014)
            {

                string[] arg = { '"' + p.id + '"', '"' + p.nombre + '"', p.fecha, p.latitud, p.longitud, p.num_sondeos, 
                        p.cant_pca, p.subcontratacion, '"'+  p.municipio+ '"', '"' + p.empresa + '"', '"'+ p.cliente+ '"',
                        '"' + p.empresa_cliente + '"', p.factura_si_no };

                string status_act = con.Run_insertar_proyecto(arg);
                Console.WriteLine(status_act);
                if (status_act.Length < 3)
                {

                    asignar_orden_compra();
                    asignar_cotizacion();
                    asignar_factura();
                    MessageBox.Show("Proyecto agregado con éxito a la base de datos.");


                    NuevoProyecto np = new NuevoProyecto(mc);
                    np.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Por favor, revisa que todos los campos estén correctamente llenados.\n " +
                        "Recuerda que no puedes ingresar letras en los campos numéricos\n" +
                        " y recuerda que la fecha debe tener el formato AAAA/MM/DD");
                /*
            }
            else
            {
                VerificarID vi = new VerificarID(id, arg, mc);
                vi.Show();
                return;
            }
                */

            }
            else
                MessageBox.Show("Las coordenadas no entran en el rango usual, por favor verifíquelas.");


        }

        private void bt_atras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void asignar_orden_compra()
        {
            try
            {
                string carpeta_orden_compra, carpeta_proyecto, carpeta_id;
                ConexionBD con = new ConexionBD(mc);
                carpeta_id = p.carpeta_id;
                carpeta_proyecto = carpeta_id + "\\" + p.nombre;

                bool exists = System.IO.Directory.Exists(carpeta_proyecto);
                if (!exists)
                    System.IO.Directory.CreateDirectory(carpeta_proyecto);

                carpeta_orden_compra = carpeta_proyecto + "\\OrdenCompra";

                exists = System.IO.Directory.Exists(carpeta_orden_compra);

                if (!exists)
                    System.IO.Directory.CreateDirectory(carpeta_orden_compra);

                string sourceFile = p.orden_compra_ruta;
                string destFile = carpeta_orden_compra
                    + "\\" + p.orden_compra;
                System.IO.File.Copy(sourceFile, destFile, true);


            }
            catch
            {
            }
        }
        private void asignar_cotizacion()
        {
            try
            {
                string carpeta_cotizacion, carpeta_proyecto, carpeta_id;
                ConexionBD con = new ConexionBD(mc);
                carpeta_id = p.carpeta_id;
                carpeta_proyecto = carpeta_id + "\\" + p.nombre;

                bool exists = System.IO.Directory.Exists(carpeta_proyecto);

                if (!exists)
                    System.IO.Directory.CreateDirectory(carpeta_proyecto);

                carpeta_cotizacion = carpeta_proyecto + "\\Cotizacion";

                exists = System.IO.Directory.Exists(carpeta_cotizacion);

                if (!exists)
                    System.IO.Directory.CreateDirectory(carpeta_cotizacion);

                string sourceFile = p.cotizacion_ruta;
                string destFile = carpeta_cotizacion
                    + "\\" + p.cotizacion;
                System.IO.File.Copy(sourceFile, destFile, true);


            }
            catch
            {
            }
        }


        private void asignar_factura()
        {
            try
            {
                string carpeta_factura, carpeta_proyecto, carpeta_id;
                ConexionBD con = new ConexionBD(mc);
                carpeta_id = p.carpeta_id;
                carpeta_proyecto = carpeta_id + "\\" + p.nombre;

                bool exists = System.IO.Directory.Exists(carpeta_proyecto);

                if (!exists)
                    System.IO.Directory.CreateDirectory(carpeta_proyecto);

                carpeta_factura = carpeta_proyecto + "\\Facturas";

                exists = System.IO.Directory.Exists(carpeta_factura);

                if (!exists)
                    System.IO.Directory.CreateDirectory(carpeta_factura);

                string sourceFile = p.factura_ruta;
                string destFile = carpeta_factura
                    + "\\" + p.factura;
                System.IO.File.Copy(sourceFile, destFile, true);


            }
            catch
            {
            }
        }
    }
}
