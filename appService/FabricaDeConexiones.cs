using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appService
{
    public class FabricaDeConexiones
    {
        //private string Cadena = "SERVER=192.168.1.78;DataBase=BD_APP_HFC; USER ID=sa; PASSWORD=S0p0rt3%";
        private string Cadena = "SERVER=192.168.150.7;DataBase=BD_CRM; USER ID=appScripting; PASSWORD=%scripting%";
        public IDbConnection ConexionPing()
        {
            return new SqlConnection(this.Cadena);
        }
    }
}
