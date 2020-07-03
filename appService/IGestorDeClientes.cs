using appService.Infraestructura.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appService
{
    internal interface IGestorDeClientes
    {
        bool InsertCliente(Cliente cliente);
    }
}
