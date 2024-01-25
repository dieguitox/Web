using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaUsuario
    {
        public static void Agregar(Usuario pUsuario)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("AgregarUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@User", pUsuario.User);
            oComando.Parameters.AddWithValue("@nombre", pUsuario.Nombre);
            oComando.Parameters.AddWithValue("@cedula", pUsuario.Cedula);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("Ya existe un usuario con ese nombre");
                else if (resultado == -2)
                    throw new Exception("No se pudo agregar el nombre de usuario");
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

        public static void Modificar(Usuario pUsuario)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("ModificarUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@User", pUsuario.User);
            oComando.Parameters.AddWithValue("@nombre", pUsuario.Nombre);
            oComando.Parameters.AddWithValue("@cedula", pUsuario.Cedula);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("No existe un usuario con ese nombre");
                else if (resultado == -2)
                    throw new Exception("No se pudo modificar el nombre de usuario");

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

        public static void Eliminar(Usuario pUsuario)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("EliminarUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oUser = new SqlParameter("@User", pUsuario.User);
            oUser.Direction = ParameterDirection.Input;

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oUser);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("No existe un Usuario con ese nombre");
                else if (resultado == -2)
                    throw new Exception("Ya hay usuarios utilizados , no se puede eliminar");
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

        public static Usuario Buscar(string pUsuario) 
        {
            Usuario user = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("BuscarUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@User", pUsuario);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {

                        int cedula = (int)oReader["Cedula"];
                        string nombre = (string)oReader["NomCompleto"];

                        user = new Usuario(pUsuario, nombre, cedula);
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
            return user;
        }

        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> colUsuario = new List<Usuario>();

            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("ListadoDeUsuarios", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        string usuario = (string)oReader["Username"];
                        string nombre = (string)oReader["NomCompleto"];
                        int cedula = Convert.ToInt32(oReader["Cedula"]);

                        Usuario user = new Usuario(usuario, nombre, cedula);
                        colUsuario.Add(user);
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

            return colUsuario;
        }
    }
}

