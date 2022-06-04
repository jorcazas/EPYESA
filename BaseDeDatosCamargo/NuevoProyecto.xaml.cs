using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Lógica de interacción para NuevoProyecto.xaml
    /// </summary>
    public partial class NuevoProyecto : Window
    {
        private string id_proyecto_nuevo;
        private string carpeta_id;
        private string orden_compra;
        private string orden_compra_ruta;
        private string cotizacion;
        private string cotizacion_ruta;
        private string factura;
        private string factura_ruta;
        private string root;
        private string desktop;
        public MaquinaConexion mc;

        public NuevoProyecto(MaquinaConexion mc)
        {
            InitializeComponent();
            this.mc = mc;
            this.root = mc.root;
            this.desktop = mc.desktop;

        }

        private void bt_revisar_ubicacion_Click(object sender, RoutedEventArgs e)
        {
            ConexionBD con = new ConexionBD(mc);
            Proyecto p = new Proyecto();
            try
            {
                p.nombre = ('"' + tb_nombre.Text + '"').Replace(',', ' ');
                p.latitud = tb_latitud.Text;
                p.longitud = tb_longitud.Text;
                StringBuilder sb_fecha = new StringBuilder();
                sb_fecha.Append(cb_anio.SelectedItem.ToString() + "-"
                    + (cb_mes.SelectedIndex + 1).ToString() + "-"
                    + cb_dia.SelectedItem.ToString());
                p.fecha = sb_fecha.ToString();
                p.cliente = '"' + cb_cliente.SelectedItem.ToString() + '"';
                p.id = '"' + "ID por confirmar" + '"';

                if (Double.Parse(tb_latitud.Text) > 11.480 && Double.Parse(tb_latitud.Text) < 34.343
                && Double.Parse(tb_longitud.Text) > -123.662 && Double.Parse(tb_longitud.Text) < -79.014)
                {

                    string[] arg = { p.id, p.nombre, p.fecha, p.latitud, p.longitud, p.cliente };


                    String act_mapas = con.Run_actualizar_mapas(arg);

                    Console.Write(act_mapas);
                    if (act_mapas.Length < 3)
                    {
                        MessageBox.Show("A continuación, se abrirá el Escritorio, en donde \n" +
                        "se generaron los archivos ProyectosRegistrados.csv y ProyectosNuevos.csv. \n" +
                        "Estos archivos tienen la información de los proyectos registrados y del proyecto" +
                        "que está por ingresar a la base de datos.\n" +
                        "Están listos para ser exportado a un programa de geolocalización.");
                        con.OpenFolder(desktop);
                    }
                    else
                    {
                        MessageBox.Show("Cierra los archivos ProyectosNuevos.csv y/o " +
                        "ProyectosRegistrados.csv e inténtalo de nuevo");
                    }
                }
                else
                    MessageBox.Show("Las coordenadas no entran en el rango usual, por favor verifíquelas.");


            }
            catch
            {
                MessageBox.Show("Verifique que todos los campos se llenaron correctamente.");
            }
        }

        private void bt_registrar_proyecto_Click(object sender, RoutedEventArgs e)
        {

            ConexionBD con = new ConexionBD(mc);
            Proyecto p = new Proyecto();
            if (!idExiste(tb_id.Text)) {
                try
                {
                    p.id = tb_id.Text;
                    p.nombre = tb_nombre.Text.Replace(',', ' ');
                    p.latitud = tb_latitud.Text;
                    p.longitud = tb_longitud.Text;
                    StringBuilder sb_fecha = new StringBuilder();
                    sb_fecha.Append(cb_anio.SelectedItem.ToString() + "-"
                        + (cb_mes.SelectedIndex + 1).ToString() + "-"
                        + cb_dia.SelectedItem.ToString());
                    p.fecha = sb_fecha.ToString();
                    p.num_sondeos = tb_sondeo.Text;
                    p.cant_pca = tb_pca.Text;
                    p.responsable = cb_responsable.SelectedItem.ToString();
                    p.empresa = cb_empresa.SelectedItem.ToString();
                    p.cliente = cb_cliente.SelectedItem.ToString();
                    p.empresa_cliente = cb_cliente_empresa.SelectedItem.ToString();
                    p.subcontratacion = "";
                    p.factura_si_no = "";
                    p.municipio = "";
                    if (chb_subc.IsChecked == true)
                        p.subcontratacion = "TRUE";
                    else
                        p.subcontratacion = "FALSE";

                    if (chb_fact.IsChecked == true)
                        p.factura_si_no = "TRUE";
                    else
                        p.factura_si_no = "FALSE";

                    string[] municipio_args = { '"' + cb_municipio.SelectedItem.ToString()
                        +'"', (cb_estado.SelectedIndex +1 ).ToString() };
                    p.municipio = con.Run_id_municipio_de_nombre(municipio_args);

                }
                catch
                {
                    MessageBox.Show("Verifique que todos los campos se llenaron correctamente.");
                    return;
                }

                if (Double.Parse(tb_latitud.Text) > 11.480 && Double.Parse(tb_latitud.Text) < 34.343
                && Double.Parse(tb_longitud.Text) > -123.662 && Double.Parse(tb_longitud.Text) < -79.014)
                {

                    string[] arg = { '"' + p.id + '"', '"' + p.nombre + '"', p.fecha, p.latitud, p.longitud, p.num_sondeos, 
                        p.cant_pca, p.subcontratacion, '"'+  p.municipio+ '"', '"' + p.empresa + '"', '"'+ p.cliente+ '"',
                        '"' + p.empresa_cliente + '"', p.factura_si_no };
                    string status_act = con.Run_insertar_proyecto(arg);
                    if (status_act.Length < 3)
                    {

                        asignar_orden_compra(p);
                        asignar_cotizacion(p);
                        asignar_factura(p);
                        MessageBox.Show("Proyecto agregado con éxito a la base de datos.");


                        NuevoProyecto np = new NuevoProyecto(mc);
                        np.Show();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Por favor, revisa que todos los campos estén correctamente llenados.\n " +
                            "Recuerda que no puedes ingresar letras en los campos numéricos\n" +
                            " y recuerda que la fecha debe tener el formato AAAA/MM/DD");

                }
                else
                    MessageBox.Show("Las coordenadas no entran en el rango usual, por favor verifíquelas.");
            }
            else
            {
                try
                {

                    p.id = tb_id.Text;
                    p.nombre = tb_nombre.Text;
                    p.latitud = tb_latitud.Text;
                    p.longitud = tb_longitud.Text;
                    StringBuilder sb_fecha = new StringBuilder();
                    sb_fecha.Append(cb_anio.SelectedItem.ToString() + "-"
                        + (cb_mes.SelectedIndex + 1).ToString() + "-"
                        + cb_dia.SelectedItem.ToString());
                    p.fecha = sb_fecha.ToString();
                    p.num_sondeos = tb_sondeo.Text;
                    p.cant_pca = tb_pca.Text;
                    p.responsable = cb_responsable.SelectedItem.ToString();
                    p.empresa = cb_empresa.SelectedItem.ToString();
                    p.cliente = cb_cliente.SelectedItem.ToString();
                    p.empresa_cliente = cb_cliente_empresa.SelectedItem.ToString();
                    p.subcontratacion = "";
                    p.factura_si_no = "";
                    p.municipio = "";
                    if (chb_subc.IsChecked == true)
                        p.subcontratacion = "TRUE";
                    else
                        p.subcontratacion = "FALSE";

                    if (chb_fact.IsChecked == true)
                        p.factura_si_no = "TRUE";
                    else
                        p.factura_si_no = "FALSE";

                    string[] municipio_args = { '"' + cb_municipio.SelectedItem.ToString()
                        +'"', (cb_estado.SelectedIndex +1 ).ToString() };
                    p.municipio = con.Run_id_municipio_de_nombre(municipio_args);

                    id_proyecto_nuevo = con.Run_ultimo_proyecto().Replace('-', ' ');
                    p.carpeta_id = root + "\\DocumentosProyectos\\" + id_proyecto_nuevo.Substring(0, id_proyecto_nuevo.Length - 2);
                    p.orden_compra = orden_compra;
                    p.orden_compra_ruta= orden_compra_ruta;
                    p.factura= factura;
                    p.factura_ruta=factura_ruta;
                    p.cotizacion=cotizacion;
                    p.cotizacion_ruta=cotizacion_ruta;

                    IdExiste ide = new IdExiste(mc, p);
                    ide.Show();

                }
                catch
                {
                    MessageBox.Show("Verifique que todos los campos se llenaron correctamente.");
                    return;
                }

            }
        }

        private bool idExiste(string id)
        {
            ConexionBD con = new ConexionBD(mc);
            string[] arg = { id };
            string res;
            res = con.Run_id_existe(arg);
            if (res.Length < 3)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        private void bt_atras_Click(object sender, RoutedEventArgs e)
        {
            Administrador admin = new Administrador(mc);
            admin.Show();
            this.Close();
        }

        private void cb_anio_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime actual = DateTime.Now;
            int i = actual.Year;
            while (i >= 2013)
            {
                cb_anio.Items.Add(i);
                i = i - 1;
            }

        }

        private void cb_mes_Loaded(object sender, RoutedEventArgs e)
        {
            cb_mes.Items.Add("Enero");
            cb_mes.Items.Add("Febrero");
            cb_mes.Items.Add("Marzo");
            cb_mes.Items.Add("Abril");
            cb_mes.Items.Add("Mayo");
            cb_mes.Items.Add("Junio");
            cb_mes.Items.Add("Julio");
            cb_mes.Items.Add("Agosto");
            cb_mes.Items.Add("Septiembre");
            cb_mes.Items.Add("Octubre");
            cb_mes.Items.Add("Noviembre");
            cb_mes.Items.Add("Diciembre");
        }

        private void cb_dia_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < 32; i++)
            {
                cb_dia.Items.Add(i);
            }
        }


        private void cb_empresa_Loaded(object sender, RoutedEventArgs e)
        {
            ConexionBD con = new ConexionBD(mc);
            String status_act = con.Run_empresas();
            if (status_act.Length > 2)
            {
                
                for(int j = 0; j < status_act.Split(',').Length-1; j++)
                {
                    cb_empresa.Items.Add(status_act.Split(',')[j]);
                }
            }
            
        }

        private void cb_responsable_Loaded(object sender, RoutedEventArgs e)
        {
            ConexionBD con = new ConexionBD(mc);
            String status_act = con.Run_personal();
            if (status_act.Length > 2)
            {

                for (int j = 0; j < status_act.Split(',').Length - 1; j++)
                {
                    cb_responsable.Items.Add(status_act.Split(',')[j]);
                }
            }
        }

        private void bt_agregar_cliente_Click(object sender, RoutedEventArgs e)
        {
            NuevoCliente nc = new NuevoCliente(mc);
            nc.Show();
        }

        private void cb_estado_Loaded(object sender, RoutedEventArgs e)
        {
            ConexionBD con = new ConexionBD(mc);
            String status_act = con.Run_estados();
            if (status_act.Length > 2)
            {

                for (int j = 0; j < status_act.Split(',').Length - 1; j++)
                {
                    cb_estado.Items.Add(status_act.Split(',')[j]);
                }
            }
        }

        private void cb_estado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_municipio.Items.Clear();
            ConexionBD con = new ConexionBD(mc);
            string[] args = { (cb_estado.SelectedIndex+1).ToString() };
            String status_act = con.Run_municipios(args);
            if (status_act.Length > 2)
            {

                for (int j = 0; j < status_act.Split(',').Length - 1; j++)
                {
                    cb_municipio.Items.Add(status_act.Split(',')[j]);
                }
            }
        }

        


        private void bt_asignar_orden_compra_Click(object sender, RoutedEventArgs e)
        {
            string a,b;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Document|*.pdf";
            ofd.ShowDialog();
            a = ofd.SafeFileName;
            orden_compra = a;
            b = ofd.FileName;
            orden_compra_ruta = b;

            if (a != "")
            {
                lb_oc.Content = "Asignada: "+ orden_compra;
                bt_X_oc.Visibility = (Visibility)0;
            }

        }

        private void asignar_orden_compra(Proyecto p)
        {
            try
            {
                string carpeta_orden_compra, carpeta_proyecto;
                ConexionBD con = new ConexionBD(mc);
                id_proyecto_nuevo = con.Run_ultimo_proyecto().Replace('-', ' ');
                carpeta_id = root + "\\DocumentosProyectos\\" + id_proyecto_nuevo.Substring(0,id_proyecto_nuevo.Length - 2);
                carpeta_proyecto = carpeta_id + "\\" + p.nombre;

                bool exists = System.IO.Directory.Exists(carpeta_proyecto);

                if (!exists)
                    System.IO.Directory.CreateDirectory(carpeta_proyecto);

                //la cadena del id añade dos espacios al final
                carpeta_orden_compra = carpeta_proyecto + "\\OrdenCompra";

                exists = System.IO.Directory.Exists(carpeta_orden_compra);

                if (!exists)
                    System.IO.Directory.CreateDirectory(carpeta_orden_compra);

                string sourceFile = orden_compra_ruta;
                string destFile = carpeta_orden_compra
                    + "\\" + orden_compra;
                System.IO.File.Copy(sourceFile, destFile, true);


            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        private void bt_asignar_cotizacion_Click(object sender, RoutedEventArgs e)
        {
            string a, b;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Document|*.pdf";
            ofd.ShowDialog();
            a = ofd.SafeFileName;
            cotizacion = a;
            b = ofd.FileName;
            cotizacion_ruta = b;
            if (a != "")
            {
                lb_c.Content = "Asignada: " + cotizacion;
                bt_X_c.Visibility = (Visibility)0;
            }
        }

        private void asignar_cotizacion(Proyecto p)
        {
            try
            {
                string carpeta_cotizacion, carpeta_proyecto;
                ConexionBD con = new ConexionBD(mc);
                id_proyecto_nuevo = con.Run_ultimo_proyecto().Replace('-', ' ');
                carpeta_id = root + "\\DocumentosProyectos\\" + id_proyecto_nuevo.Substring(0, id_proyecto_nuevo.Length - 2);
                carpeta_proyecto = carpeta_id + "\\" + p.nombre;

                bool exists = System.IO.Directory.Exists(carpeta_proyecto);

                if (!exists)
                    System.IO.Directory.CreateDirectory(carpeta_proyecto);

                //la cadena del id añade dos espacios al final
                carpeta_cotizacion = carpeta_proyecto + "\\Cotizacion";

                exists = System.IO.Directory.Exists(carpeta_cotizacion);

                if (!exists)
                    System.IO.Directory.CreateDirectory(carpeta_cotizacion);

                string sourceFile = cotizacion_ruta;
                string destFile = carpeta_cotizacion
                    + "\\" + cotizacion;
                System.IO.File.Copy(sourceFile, destFile, true);


            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        private void bt_asignar_factura_Click(object sender, RoutedEventArgs e)
        {
            string a, b;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Document|*.pdf";
            ofd.ShowDialog();
            a = ofd.SafeFileName;
            factura = a;
            b = ofd.FileName;
            factura_ruta = b;
            if (a != "")
            {
                lb_f.Content = "Asignada: " + factura; 
                bt_X_f.Visibility = (Visibility)0;
            }
        }

        private void asignar_factura(Proyecto p)
        {
            try
            {
                string carpeta_factura, carpeta_proyecto;
                ConexionBD con = new ConexionBD(mc);
                id_proyecto_nuevo = con.Run_ultimo_proyecto().Replace('-', ' ');
                carpeta_id = root + "\\DocumentosProyectos\\" + id_proyecto_nuevo.Substring(0, id_proyecto_nuevo.Length - 2);
                carpeta_proyecto = carpeta_id + "\\" + p.nombre;

                bool exists = System.IO.Directory.Exists(carpeta_proyecto);

                if (!exists)
                    System.IO.Directory.CreateDirectory(carpeta_proyecto);

                //la cadena del id añade dos espacios al final
                carpeta_factura = carpeta_proyecto + "\\Facturas";

                exists = System.IO.Directory.Exists(carpeta_factura);

                if (!exists)
                    System.IO.Directory.CreateDirectory(carpeta_factura);

                string sourceFile = factura_ruta;
                string destFile = carpeta_factura
                    + "\\" + factura;
                System.IO.File.Copy(sourceFile, destFile, true);


            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        private void bt_verificar_coordenadas_Click(object sender, RoutedEventArgs e)
        {
            /*try
            {
                ConexionBD con = new ConexionBD(mc);
                if (Double.Parse(tb_latitud.Text) > 11.480 && Double.Parse(tb_latitud.Text) < 34.343
                    && Double.Parse(tb_longitud.Text) > -123.662 && Double.Parse(tb_longitud.Text) < -79.014)
                {
                    string[] args = { '"' + tb_longitud.Text + '"', '"' + tb_latitud.Text + '"' };
                    con.Run_generar_mapa_simple_proyecto_nuevo(args);

                    MapaNuevo mn = new MapaNuevo(mc);
                    mn.Show();
                }
                else
                    MessageBox.Show("Las coordenadas no entran en el rango usual, por favor verifíquelas.");
            }
            catch 
            { 
            }*/
        }

        private void bt_X_oc_Click(object sender, RoutedEventArgs e)
        {
            lb_oc.Content = "";
            bt_X_oc.Visibility = (Visibility)1;
            orden_compra = "";
            orden_compra_ruta = "";
        }

        private void bt_X_c_Click(object sender, RoutedEventArgs e)
        {
            lb_c.Content = "";
            bt_X_c.Visibility = (Visibility)1;
            cotizacion = "";
            cotizacion_ruta = "";
        }

        private void bt_X_f_Click(object sender, RoutedEventArgs e)
        {
            lb_f.Content = "";
            bt_X_f.Visibility = (Visibility)1;
            factura = "";
            factura_ruta = "";
        }

        private void cb_cliente_empresa_Loaded(object sender, RoutedEventArgs e)
        {
            ConexionBD con = new ConexionBD(mc);
            String status_act = con.Run_empresas_cliente();
            if (status_act.Length > 2)
            {
                for (int j = 0; j < status_act.Split(',').Length - 1; j++)
                {
                    cb_cliente_empresa.Items.Add(status_act.Split(',')[j]);
                }
            }
        }

        private void bt_refresh_Click(object sender, RoutedEventArgs e)
        {
            cb_cliente.Items.Clear();
            cb_cliente_empresa.Items.Clear();
            ConexionBD con = new ConexionBD(mc);
            String status_act = con.Run_empresas_cliente();
            if (status_act.Length > 2)
            {
                for (int j = 0; j < status_act.Split(',').Length - 1; j++)
                {
                    cb_cliente_empresa.Items.Add(status_act.Split(',')[j]);
                }
            }
        }

        private void cb_cliente_empresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_cliente.Items.Clear();
            ConexionBD con = new ConexionBD(mc);

            if (cb_cliente_empresa.SelectedItem != null)
            {
                string[] args = { '"' + cb_cliente_empresa.SelectedItem.ToString() + '"' };
                String status_act = con.Run_clientes(args);
                if (status_act.Length > 2)
                {
                    for (int j = 0; j < status_act.Split(',').Length - 1; j++)
                    {
                        cb_cliente.Items.Add(status_act.Split(',')[j]);
                    }
                }
            }
        }

       
    }
}