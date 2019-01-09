using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebBanco.DAO
{
    public class Conexion
    {
        private static Conexion objConexion = null;
        private SqlConnection con;

 
        private Conexion()
        {
            
            con = new SqlConnection("Data Source=JAMIE-MSI\\MSSQLSERVER_2012;Initial Catalog=banco;User id=sa;Password=sql");
        }

        public static Conexion saberEstado()
        {
            if (objConexion == null)
            {
                objConexion = new Conexion();
            }
            return objConexion;
        }

        public SqlConnection getCon()
        {
            return con;
        }

        public void cerrarConexion()
        {
            objConexion = null;
        }
    }
}
