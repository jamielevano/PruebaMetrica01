using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanco.Models;
using System.Data.SqlClient;

namespace WebBanco.DAO
{
    public class OrdenPagoDao
    {
        private Conexion objConexion;
        private SqlCommand comando;

        public OrdenPagoDao()
        {
            objConexion = Conexion.saberEstado();
        }


        public List<OrdenPago> Listar()
        {
            List<OrdenPago> lista = new List<OrdenPago>();

            try
            {
                comando = new SqlCommand("SP_ORDENPAGO_LISTAR", objConexion.getCon());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    OrdenPago op = new OrdenPago();
                    op.IdOrdenPago = Convert.ToInt32(read[0].ToString());
                    op.IdBanco = Convert.ToInt32(read[1].ToString());
                    op.IdSucursal = Convert.ToInt32(read[2].ToString());
                    op.Monto = Convert.ToDouble(read[3].ToString());
                    op.Moneda = read[4].ToString();
                    op.Estado = Convert.ToInt32(read[5].ToString());
                    op.FechaPago = DateTime.Parse(read[6].ToString());
                    op.NombreBanco = read[7].ToString();
                    op.NombreSucursal = read[8].ToString();
                    lista.Add(op);
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
            return lista;
        }

        public OrdenPago Obtener(int id)
        {
            OrdenPago op = new OrdenPago();

            try
            {
                comando = new SqlCommand("SP_ORDENPAGO_OBTENER", objConexion.getCon());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                objConexion.getCon().Open();
                SqlDataReader read = comando.ExecuteReader();
                while (read.Read())
                {
                    op.IdOrdenPago = Convert.ToInt32(read[0].ToString());
                    op.IdBanco = Convert.ToInt32(read[1].ToString());
                    op.IdSucursal = Convert.ToInt32(read[2].ToString());
                    op.Monto = Convert.ToDouble(read[3].ToString());
                    op.Moneda = read[4].ToString();
                    op.Estado = Convert.ToInt32(read[5].ToString());
                    op.FechaPago = DateTime.Parse(read[6].ToString());
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
            return op;
        }

        public void insertar(OrdenPago op)
        {
            try
            {
                comando = new SqlCommand("SP_ORDENPAGO_INSERTAR", objConexion.getCon());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@idBanco", System.Data.SqlDbType.Int).Value = op.IdBanco;
                comando.Parameters.Add("@idSucursal", System.Data.SqlDbType.Int).Value = op.IdSucursal;
                comando.Parameters.Add("@monto", System.Data.SqlDbType.Decimal).Value = op.Monto;
                comando.Parameters.Add("@moneda", System.Data.SqlDbType.VarChar).Value = op.Moneda;
                comando.Parameters.Add("@estado", System.Data.SqlDbType.Int).Value = op.Estado;
                comando.Parameters.Add("@fechaPago", System.Data.SqlDbType.Date).Value = op.FechaPago;
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

        public void actualizar(OrdenPago op)
        {
            try
            {
                comando = new SqlCommand("SP_ORDENPAGO_ACTUALIZAR", objConexion.getCon());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = op.IdOrdenPago;
                comando.Parameters.Add("@idBanco", System.Data.SqlDbType.Int).Value = op.IdBanco;
                comando.Parameters.Add("@idSucursal", System.Data.SqlDbType.Int).Value = op.IdSucursal;
                comando.Parameters.Add("@monto", System.Data.SqlDbType.Decimal).Value = op.Monto;
                comando.Parameters.Add("@moneda", System.Data.SqlDbType.VarChar).Value = op.Moneda;
                comando.Parameters.Add("@estado", System.Data.SqlDbType.Int).Value = op.Estado;
                comando.Parameters.Add("@fechaPago", System.Data.SqlDbType.Date).Value = op.FechaPago;
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
                comando = new SqlCommand("SP_ORDENPAGO_ELIMINAR", objConexion.getCon());
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
