using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaTipoDeMensaje
    {
        public static void Agregar(TiposDeMensaje pTiposDeMensaje)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("AgregarTipo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cod", pTiposDeMensaje.Codigo);
            oComando.Parameters.AddWithValue("@nom", pTiposDeMensaje.Nombre);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("No existe una publicacion con ese ISBN");
                else if (resultado == -2)
                    throw new Exception("Hay prestamos Asociados - No se Elimina");
                else if (resultado == -3)
                    throw new Exception("Ocurrio un error ineesperado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void Modificar(TiposDeMensaje pTiposDeMensaje)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("ModificarTipo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cod", pTiposDeMensaje.Codigo);
            oComando.Parameters.AddWithValue("@nom", pTiposDeMensaje.Nombre);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("No existe un codigo con ese nombre");
                else if (resultado == -2)
                    throw new Exception("No se pudo modificar el codigo");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void Eliminar(TiposDeMensaje pTiposDeMensaje)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("EliminarTipo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCodigo = new SqlParameter("@cod", pTiposDeMensaje.Codigo);
            oCodigo.Direction = ParameterDirection.Input;

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCodigo);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("No existe un codigo con ese nombre.");
                else if (resultado == -2)
                    throw new Exception("Ya hay codigo utilizados.No se puede eliminar");
                else if (resultado == -3)
                    throw new Exception("Ocurrio un error inesperado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

        }

        public static TiposDeMensaje Buscar(string pCodigo)
        {
            TiposDeMensaje cod = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("BuscarTipo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cod", pCodigo);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        string nombre = (string)oReader["Nombre"];

                        cod = new TiposDeMensaje(pCodigo, nombre);
                    }
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return cod;
        }

        public static List<TiposDeMensaje> ListadoDeTipos()
        {
            List<TiposDeMensaje> colTipos = new List<TiposDeMensaje>();

            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("ListadoDeTipo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        string codigo = oReader["Codigo"].ToString();
                        string nombre = oReader["Nombre"].ToString();

                        TiposDeMensaje tipo = new TiposDeMensaje(codigo, nombre);
                        colTipos.Add(tipo);
                    }
                }
                oReader.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

            return colTipos;
        }
    }
}
