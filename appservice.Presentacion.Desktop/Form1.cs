using appService.Infraestructura.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appservice.Presentacion.Desktop
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            try
            {
                GestorDeClientes lista = new GestorDeClientes();
                lista.ListaClaro().ForEach(x => {
                    this.dgvIps.Rows.Add(0, x.Ip, x.Usuario, x.Servicio);
                    //txtIps.Text = ($" Lista dirección {  x.D_DNI} Lista ciudades {x.D_NOMBRE } ");
                });

                txtRespuesta.Text = "...";
                txtRespuesta.Enabled = false;

                AddHeaderCheckBox();
                HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            }
            catch (Exception)
            {

              //  throw;
            }
            
        }
        
        CheckBox HeaderCheckBox = null;
        bool isHeaderCheckBoxClicked = false;
        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox();
            HeaderCheckBox.Size = new Size(45, 25);
            this.dgvIps.Controls.Add(HeaderCheckBox);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            isHeaderCheckBoxClicked = true;
            foreach(DataGridViewRow Row in dgvIps.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["chk"]).Value = HCheckBox.Checked;
                dgvIps.RefreshEdit();
                isHeaderCheckBoxClicked = false;
            }
        }
        
        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            string respuesta = "\r\n";
            int Ips = 0;
            try
            {
                for (int i = 0; i <= dgvIps.RowCount - 1; i++)
                {
                    if (Convert.ToBoolean(dgvIps.Rows[i].Cells["chk"].Value) == true)
                    {
                        string ip = dgvIps.Rows[i].Cells[1].Value.ToString();
                        ip = ip.Replace("\r", string.Empty).Replace("\n", string.Empty); // txtIps.Text.Replace(@"\r\n\", ""); ;
                        ip = ip.Replace(" ", "");
                        ip = ip.Replace(Environment.NewLine, "");

                        string resultadoPing = "";
                        Ping HacerPing = new Ping();
                        int iTiempoEspera = 5000;
                        PingReply RespuestaPing;
                       
                        RespuestaPing = HacerPing.Send(ip, iTiempoEspera);
                        if (RespuestaPing.Status == IPStatus.Success)
                        {
                            resultadoPing = ("Ping a " + ip.ToString() + " [" + RespuestaPing.Address.ToString() + "]" + " Correcto" + " Tiempo de respuesta = " +
                           RespuestaPing.RoundtripTime.ToString() + " ms" + "\r\n");
                        }
                        else
                        {
                            resultadoPing = ("Error: Ping a " + ip.ToString() + "\r\n");
                        }
                        respuesta = respuesta + resultadoPing;
                        Ips = Ips + 1;
                    }
                    txtRespuesta.Text = "Cantidad de Ips consultadas " + Ips + ": \r\n\r\n" + "RESULTADO" + "\r\n" + respuesta;
                    txtRespuesta.Enabled = false;
                }
            }
            catch (Exception)
            {
                txtRespuesta.Text = "Ocurrio un error en la consulta, en caso de registrar varias Ips concatenar con comas" + "\r\n\r\n" + respuesta;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //AddHeaderCheckBox();
            //HeaderCheckbox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
        }

        private void DgvIps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnDescarga_Click(object sender, EventArgs e)
        {
            string fecha = "";
            DateTime dt = DateTime.Now;
            String[] format = { "s" };
            String date;

            for (int i = 0; i < format.Length; i++)
            {
                date = dt.ToString(format[i], DateTimeFormatInfo.InvariantInfo);
                fecha = String.Concat(format[i], " ", date);
            }

            fecha = fecha.Replace("/", "").Replace(":", "");

            try
            {
                FolderBrowserDialog file = new FolderBrowserDialog();
                file.Description = "Donde desea descargar el archivo";
                file.RootFolder = Environment.SpecialFolder.Desktop;

                if (file.ShowDialog() == DialogResult.OK)
                {
                    
                    for (int n=0; n < 10; n++)
                    {
                        for (int i = 0; i <= dgvIps.RowCount - 1; i++)
                        {
                            if (Convert.ToBoolean(dgvIps.Rows[i].Cells["chk"].Value) == true)
                            {
                                string respuesta = "\r\n";
                                int Ips = 0;

                                string ip = dgvIps.Rows[i].Cells[1].Value.ToString();
                                ip = ip.Replace("\r", string.Empty).Replace("\n", string.Empty); // txtIps.Text.Replace(@"\r\n\", ""); ;
                                ip = ip.Replace(" ", "");
                                ip = ip.Replace(Environment.NewLine, "");

                                string resultadoPing = "";
                                Ping HacerPing = new Ping();
                                int iTiempoEspera = 5000;
                                PingReply RespuestaPing;

                                RespuestaPing = HacerPing.Send(ip, iTiempoEspera);
                                if (RespuestaPing.Status == IPStatus.Success)
                                {
                                    resultadoPing = (fecha + " Ping a " + ip.ToString() + " [" + RespuestaPing.Address.ToString() + "]" + " Correcto" + " TR = " +
                                   RespuestaPing.RoundtripTime.ToString() + " ms");
                                }
                                else
                                {
                                    resultadoPing = (fecha + " Ping a " + ip.ToString() + " [" + RespuestaPing.Address.ToString() + "]" + " Error:");
                                }
                                respuesta = respuesta + resultadoPing;
                                Ips = Ips + 1;


                                using (Stream fs = new FileStream(file.SelectedPath + "\\Log_" + ip + ".txt", mode: FileMode.Append, FileAccess.Write))
                                {
                                    using (StreamWriter sw = new StreamWriter(fs))
                                    {
                                        sw.WriteLine(resultadoPing);
                                        sw.Close();
                                    }


                                    //fs.Close();
                                }
                                txtRespuesta.Text = "Cantidad de Ips consultadas " + Ips + ": \r\n\r\n" + "RESULTADO" + "\r\n" + respuesta;
                                txtRespuesta.Enabled = false;

                                //using (StreamWriter writer = new StreamWriter(file.SelectedPath + "\\Log_" + ip + ".txt"))
                                //{
                                //    writer.Write(txtRespuesta.Text);
                                //    writer.Close();
                                //}
                            }

                        }

                        Thread.Sleep(60);
                    }

                    
                }

                // Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtRespuesta.Text = "Esperando ...";
        }

       
    }
}
