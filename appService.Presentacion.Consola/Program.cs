using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace appService.Presentacion.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(p =>
            {
                p.Service<HeartBeat>(s =>
                {
                    s.ConstructUsing(heartbeat => new HeartBeat());
                    s.WhenStarted(heartbeat => heartbeat.Start());
                    s.WhenStopped(heartbeat => heartbeat.Stop());
                });
                p.RunAsLocalSystem();
                p.SetServiceName("PingServiceDynamicall");
                p.SetDisplayName("PingServiceDynamicall");
                p.SetDescription("Se encarga de registrar un log(txt) de latencia entre el PC -> IPs");
            });
        }
    }
}
