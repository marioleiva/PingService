using appService.Infraestructura.Persistencia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Timers;

namespace appService.Presentacion.Consola
{
    public class HeartBeat
    {
        private readonly Timer _timer;
        string path = "";  //string path = @"c:\temp";  //\LogSheets.txt
        int timer = 30000;
        int tiempoEspera = 10000000;
        int horaInicio = 6;
        int horaFin = 21;
        List<String> Ips = new List<String>();

        public HeartBeat()
        {
            try
            {
                path = @"C:\PingService";
                timer = 10000;
                tiempoEspera = 500;
                horaInicio = 6;
                horaFin = 21;

                Ips.Add("vpn.sellbytel.es");
                Ips.Add("190.81.44.227");
                Ips.Add("200.48.98.6");
                Ips.Add("190.12.66.27");
                Ips.Add("190.119.243.178");

                //GestorDeClientes parametros = new GestorDeClientes();
                //parametros.ListaParametros().ForEach(a =>
                //{
                //    path = a.Carpeta;
                //    timer = a.Timer;
                //    tiempoEspera = a.TiempoEspera;
                //    horaInicio = a.horaInicio;
                //    horaFin = a.horaFin;
                //});

                //GestorDeClientes lista = new GestorDeClientes();
                //lista.ListaClaro().ForEach(x =>
                //{
                //    Ips.Add(x.Ip);
                //});
            }
            catch (Exception)
            {

            }

            _timer = new Timer(timer); // { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                //string hora = $"{DateTime.Now.ToString("HH:mm:ss")}/";
                DateTime horario = DateTime.Now;
                int hora = horario.Hour;

                if (hora >= horaInicio && hora < horaFin)
                {
                    string fecha = $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}/\\";
                    string dia = $"{DateTime.Now.ToString("dd/MM/yyyy")}/";
                    dia = dia.Replace("/", "");
                    foreach (var ip in Ips)
                    {
                        string resultadoPing = "";
                        Ping HacerPing = new Ping();
                        int iTiempoEspera = tiempoEspera;
                        PingReply RespuestaPing;
                        string carpeta = "";
                        try
                        {
                            RespuestaPing = HacerPing.Send(ip, iTiempoEspera);
                            if (RespuestaPing.Status == IPStatus.Success)
                            {
                                resultadoPing = fecha + " Respuesta desde " + RespuestaPing.Address.ToString() + ": tiempo =" + RespuestaPing.RoundtripTime.ToString() + " ms";
                            }
                            else
                            {
                                resultadoPing = fecha + " Tiempo de espera agotado para esta solicitud " + ip.ToString() + ": tiempo >" + tiempoEspera.ToString()+" ms";
                            }
                        }
                        catch (Exception)
                        {
                            resultadoPing = fecha + " Respuesta desde " + ip.ToString() + ": Host de destino inaccesible";
                        }

                        carpeta = path + "\\" + dia + "\\";
                        Directory.CreateDirectory(Path.GetDirectoryName(carpeta));

                        using (Stream fs = new FileStream(carpeta + ip + "_" + dia + ".txt", mode: FileMode.Append, FileAccess.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                sw.WriteLine(resultadoPing);
                                sw.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }

    }
}
