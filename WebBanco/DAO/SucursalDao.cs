using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanco.Models;
using System.Data.SqlClient;

namespace WebBanco.DAO
{
    public class SucursalDao
    {
        private Conexion objConexion;
        private SqlCommand comando;

        public SucursalDao()
        {
            objConexion = Conexion.saberEstado();
        }
        public List<Sucursal> Listar()
        {
            List<Sucursal> lisSucursal = new List<Sucursal>();
            
            try
            {
                comando = new SqlCommand("SP_SUCURSAL_LISTAR", objConexion.getCon());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    Sucursal suc = new Sucursal();
                    suc.IdSucursal = Convert.ToInt32(read[0].ToString());
                    suc.Nombre = read[1].ToString();
                    suc.Direccion = read[2].ToString();
                    suc.FechaRegistro = DateTime.Parse(read[3].ToString());
                    suc.IdBanco = Convert.ToInt32(read[4].ToString());
                    suc.NombreBanco = read[5].ToString();

                    lisSucursal.Add(suc);
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
            return lisSucursal;
        }

        public Sucursal Obtener(int id)
        {
            Sucursal suc = new Sucursal();

            try
            {
                comando = new SqlCommand("SP_SUCURSAL_OBTENER", objConexion.getCon());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    suc.IdSucursal = Convert.ToInt32(read[0].ToString());
                    suc.IdBanco = Convert.ToInt32(read[1].ToString());
                    suc.Nombre = read[2].ToString();
                    suc.Direccion = read[3].ToString();
                    suc.FechaRegistro = DateTime.Parse(read[4].ToString());
                    suc.NombreBanco = "";
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
            return suc;
        }

        public void insertar(Sucursal suc)
        {
            try
            {
                comando = new SqlCommand("SP_SUCURSAL_INSERTAR", objConexion.getCon());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@idBanco", System.Data.SqlDbType.Int).Value = suc.IdBanco;
                comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = suc.Nombre;
                comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = suc.Direccion;
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

        public void actualizar(Sucursal suc)
        {
            try
            {
                comando = new SqlCommand("SP_SUCURSAL_ACTUALIZAR", objConexion.getCon());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = suc.IdSucursal;
                comando.Parameters.Add("@idBanco", System.Data.SqlDbType.Int).Value = suc.IdBanco;
                comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = suc.Nombre;
                comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = suc.Direccion;
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
                comando = new SqlCommand("SP_SUCURSAL_ELIMINAR", objConexion.getCon());
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
