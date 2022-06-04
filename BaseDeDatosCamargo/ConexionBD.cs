using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows;

namespace BaseDeDatosCamargo
{
    class ConexionBD
    {
        private string python;
        private string root;
        private string desktop;
    
        public ConexionBD(MaquinaConexion mc)
        {
            this.python = mc.python;
            this.root = mc.root;
            this.desktop = mc.desktop;
        }

        public string Run_credenciales(string[] args_)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string res;
            string args = root + "\\credenciales.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string Run_verificar_id(string[] args_)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string res;
            string args = root + "\\verificar_id.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string Run_asignar_id(string[] args_)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string res;
            string args = root + "\\asignar_id.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }
        public string Run_actualizar_mapas(string[] args_)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string res;
            string args = root+"\\actualizacion_mapas.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string Run_ver_registros()
        {
            StringBuilder sb = new StringBuilder();
            

            string res;
            string args = root+"\\ver_registros.py ";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }


            return res;
        }
        public string Run_leer_reporte_economico()
        {
            StringBuilder sb = new StringBuilder();


            string res;
            string args = root + "\\leer_reporte_economico.py ";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }


            return res;
        }

        public string Run_id_existe(string[] args_)
        {
            string res;


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string args = root + "\\id_existe.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string Run_ultimo_proyecto()
        {
            StringBuilder sb = new StringBuilder();


            string res;
            string args = root+"\\ultimo_proyecto.py ";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }


            return res;
        }

        public string Run_proyecto_esp(string[] args_)
        {
            string res;


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string args = root+"\\proyecto_esp.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string Run_id_municipio_de_nombre(string[] args_)
        {
            string res;


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string args = root+"\\id_municipio_de_nombre.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string Run_proyecto_esp_completo(string[] args_)
        {
            string res;


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string args = root+"\\proyecto_esp_completo.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string Run_empresas()
        {
            StringBuilder sb = new StringBuilder();


            string res;
            string args = root+"\\empresas.py ";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string Run_empresas_cliente()
        {
            StringBuilder sb = new StringBuilder();


            string res;
            string args = root + "\\empresas_cliente.py ";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }
        public string Run_clientes(string[] args_)
        {
            string res;


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string args = root + "\\clientes.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string Run_personal()
        {
            StringBuilder sb = new StringBuilder();


            string res;
            string args = root+"\\personal.py ";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        
        public string Run_estados()
        {
            StringBuilder sb = new StringBuilder();


            string res;
            string args = root + "\\estados.py ";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string Run_municipios(string[] args_)
        {
            string res;
            

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string args = root + "\\municipios.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }
        public string Run_insertar_proyecto(string[] args_)
        {
            string res;
            

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string args = root + "\\insertar_proyecto.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }
        public string Run_registrar_contacto(string[] args_)
        {
            string res;


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string args = root + "\\registrar_contacto.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string Run_registrar_empresa_cliente(string[] args_)
        {
            string res;


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string args = root + "\\registrar_empresa_cliente.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }
        public string Run_asignar_fecha_finalizacion(string[] args_)
        {
            string res;


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string args = root + "\\asignar_fecha_finalizacion.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string Run_mod_prof_max(string[] args_)
        {
            string res;
            

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string args = root + "\\mod_prof_max.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string Run_generar_mapa_simple()
        {
            StringBuilder sb = new StringBuilder();


            string res;
            string args = root + "\\generar_mapa_simple.py ";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string Run_generar_mapa_simple_proyecto_nuevo(string[] args_)
        {
            string res;


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args_.Length; i++)
            {
                sb.Append(args_[i] + " ");
            }

            string args = root + "\\generar_mapa_simple_proyecto_nuevo.py " + sb.ToString();
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = python;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    res = result;
                }
            }

            return res;
        }

        public string OpenFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(folderPath, "explorer.exe");
                Process.Start(startInfo);
                return "";
            }
            else
                return (string.Format("{0} Directory does not exist!", folderPath));

        }


        //Create Collection for DataGrid Source
        public ICollection CreateDataSource(string file)
        {
            //Create new DataTables and Rows
            DataTable dt = new DataTable();
            DataRow dr;

            //Create Column Headers
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("Proyecto", typeof(string)));
            dt.Columns.Add(new DataColumn("Fecha", typeof(string)));
            dt.Columns.Add(new DataColumn("Latitud", typeof(string)));
            dt.Columns.Add(new DataColumn("Longitud", typeof(string)));
            dt.Columns.Add(new DataColumn("Cliente", typeof(string)));
            dt.Columns.Add(new DataColumn("No de Sondeos", typeof(string)));
            dt.Columns.Add(new DataColumn("Cantidad de PCA´s", typeof(string)));
            dt.Columns.Add(new DataColumn("Profundidad Maxima (m)", typeof(string)));
            List<string> asList = File.ReadLines(desktop + "\\"+ file+".csv").ToList();


            //For each line in the File
            for (int i = 1; i < asList.Count; i++)
            {
                dr = dt.NewRow();

                dr[0] = asList[i].Split(',').ElementAt(0);
               
                dr[1] = asList[i].Split(',').ElementAt(1);

                dr[2] = asList[i].Split(',').ElementAt(2);

                dr[3] = asList[i].Split(',').ElementAt(3);

                dr[4] = asList[i].Split(',').ElementAt(4);

                dr[5] = asList[i].Split(',').ElementAt(5);

                dr[6] = asList[i].Split(',').ElementAt(6);

                dr[7] = asList[i].Split(',').ElementAt(7);

                dr[8] = asList[i].Split(',').ElementAt(8);



                //Add the row we created
                dt.Rows.Add(dr);
            }

            //Return Dataview 
            DataView dv = new DataView(dt);
            return dv;
        }

        public ICollection CreateDataSourceEsp(string file)
        {
            //Create new DataTables and Rows
            DataTable dt = new DataTable();
            DataRow dr;

            //Create Column Headers
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("Proyecto", typeof(string)));
            dt.Columns.Add(new DataColumn("Fecha", typeof(string)));
            dt.Columns.Add(new DataColumn("Latitud", typeof(string)));
            dt.Columns.Add(new DataColumn("Longitud", typeof(string)));
            dt.Columns.Add(new DataColumn("Cliente", typeof(string)));
            dt.Columns.Add(new DataColumn("No de Sondeos", typeof(string)));
            dt.Columns.Add(new DataColumn("Cantidad de PCA´s", typeof(string)));
            dt.Columns.Add(new DataColumn("Profundidad Maxima (m)", typeof(string)));
            List<string> asList = File.ReadLines(root + "\\Proyectos\\" + file + ".csv").ToList();


            //For each line in the File
            for (int i = 1; i < asList.Count; i++)
            {
                dr = dt.NewRow();

                dr[0] = asList[i].Split(',').ElementAt(0);

                dr[1] = asList[i].Split(',').ElementAt(1);

                dr[2] = asList[i].Split(',').ElementAt(2);

                dr[3] = asList[i].Split(',').ElementAt(3);

                dr[4] = asList[i].Split(',').ElementAt(4);

                dr[5] = asList[i].Split(',').ElementAt(5);

                dr[6] = asList[i].Split(',').ElementAt(6);

                dr[7] = asList[i].Split(',').ElementAt(7);

                dr[8] = asList[i].Split(',').ElementAt(8);


                //Add the row we created
                dt.Rows.Add(dr);
            }

            //Return Dataview 
            DataView dv = new DataView(dt);
            return dv;
        }

        public ICollection CreateDataSourceRepEco(string file)
        {
            //Create new DataTables and Rows
            DataTable dt = new DataTable();
            DataRow dr;

            //Create Column Headers
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("Proyecto", typeof(string)));
            dt.Columns.Add(new DataColumn("Empresa", typeof(string)));
            dt.Columns.Add(new DataColumn("Factura", typeof(string)));
            dt.Columns.Add(new DataColumn("Monto", typeof(string)));
            dt.Columns.Add(new DataColumn("Monto con IVA", typeof(string)));
            List<string> asList = File.ReadLines(desktop + "\\" + file + ".csv").ToList();


            //For each line in the File
            for (int i = 1; i < asList.Count; i++)
            {
                dr = dt.NewRow();

                dr[0] = asList[i].Split(',').ElementAt(0);

                dr[1] = asList[i].Split(',').ElementAt(1);

                dr[2] = asList[i].Split(',').ElementAt(2);

                dr[3] = asList[i].Split(',').ElementAt(3);

                dr[4] = asList[i].Split(',').ElementAt(4);

                dr[5] = asList[i].Split(',').ElementAt(5);

                //Add the row we created
                dt.Rows.Add(dr);
            }

            //Return Dataview 
            DataView dv = new DataView(dt);
            return dv;
        }

        public ICollection CreateDataSourceIdExiste(string file)
        {
            //Create new DataTables and Rows
            DataTable dt = new DataTable();
            DataRow dr;

            //Create Column Headers
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("Proyecto", typeof(string)));
            dt.Columns.Add(new DataColumn("Fecha", typeof(string)));
            List<string> asList = File.ReadLines(root + "\\Proyectos\\" + file + ".csv").ToList();


            //For each line in the File
            for (int i = 1; i < asList.Count; i++)
            {
                dr = dt.NewRow();

                dr[0] = asList[i].Split(',').ElementAt(0);

                dr[1] = asList[i].Split(',').ElementAt(1);

                dr[2] = asList[i].Split(',').ElementAt(2);

                //Add the row we created
                dt.Rows.Add(dr);
            }

            //Return Dataview 
            DataView dv = new DataView(dt);
            return dv;
        }

    }
}
