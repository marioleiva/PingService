using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appService.Infraestructura.Entidades
{
    public class Parametro
    {
        public int Id { get; set; }
        public string Carpeta { get; set; }
        public int Timer { get; set; }
        public int TiempoEspera { get; set; }
        public string Respuesta { get; set; }
        public int horaInicio { get; set; }
        public int horaFin { get; set; }
    }
}
