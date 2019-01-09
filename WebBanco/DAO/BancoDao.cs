using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebBanco.Models;

namespace WebBanco.DAO
{
    public class BancoDao
    {
        private Conexion objConexion;
        private SqlCommand comando;

        public BancoDao()
        {
            objConexion = Conexion.saberEstado();
        }
        public List<Banco> Listar()
        {
            List<Banco> listaAlumnos = new List<Banco>();

            string findAll = "select*from banco";
            try
            {
                comando = new SqlCommand(findAll, objConexion.getCon());
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    Banco banco = new Banco();
                    banco.Id = Convert.ToInt32(read[0].ToString());
                    banco.Nombre = read[1].ToString();
                    banco.Direccion = read[2].ToString();
                    banco.FechaRegistro = DateTime.Parse(read[3].ToString());
                    listaAlumnos.Add(banco);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
            return listaAlumnos;
        }

        public Banco Obtener(int id)
        {
            Banco banco = new Banco();

            try
            {
                comando = new SqlCommand("SP_BANCO_OBTENER", objConexion.getCon());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    banco.Id = Convert.ToInt32(read[0].ToString());
                    banco.Nombre = read[1].ToString();
                    banco.Direccion = read[2].ToString();
                    banco.FechaRegistro = DateTime.Parse(read[3].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
            return banco;
        }

        public void insertar(Banco banco)
        {
            try
            {
                comando = new SqlCommand("SP_BANCO_INSERTAR", objConexion.getCon());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = banco.Nombre;
                comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = banco.Direccion;
                objConexion.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
        }

        public void actualizar(Banco banco)
        {
            try
            {
                comando = new SqlCommand("SP_BANCO_ACTUALIZAR", objConexion.getCon());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = banco.Id;
                comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = banco.Nombre;
                comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = banco.Direccion;
                objConexion.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                comando = new SqlCommand("SP_BANCO_ELIMINAR", objConexion.getCon());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                objConexion.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexion.getCon().Close();
                objConexion.cerrarConexion();
            }
        }





    }
}
