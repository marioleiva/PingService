using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appService.Infraestructura.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Usuario { get; set; }
        public string Servicio { get; set; }
        public DateTime Fecha { get; set; }
    }
}
