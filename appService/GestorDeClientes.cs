using appService.Infraestructura.Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appService.Infraestructura.Persistencia
{
    
    public class GestorDeClientes
    {
        private FabricaDeConexiones conexion = new FabricaDeConexiones();

        public List<Cliente> ListaClaro()
        {
            using (var cnn = conexion.ConexionPing())
            {
                var listaDeCustomers = cnn.Query<Cliente>(
                "Select * from dbo.Cliente",  // where id = @Id
                                           //new {id = 1},    clase anonima
                commandType: CommandType.Text
                ).ToList();
                return listaDeCustomers;
            }
        }

        public List<Parametro> ListaParametros()
        {
            using (var cnn = conexion.ConexionPing())
            {
                var listaDeParametros = cnn.Query<Parametro>(
                "Select * from dbo.Parametro",  // where id = @Id
                                              //new {id = 1},    clase anonima
                commandType: CommandType.Text
                ).ToList();
                return listaDeParametros;
            }
        }
    }
}
