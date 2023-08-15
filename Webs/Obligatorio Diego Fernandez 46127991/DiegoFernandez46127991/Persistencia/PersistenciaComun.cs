using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaComun
    {
        public static void Agregar(Comunes pComunes)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("AgregarMensajeComun", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@user", pComunes.CargoUsuario.User);
            oComando.Parameters.AddWithValue("@dest", pComunes.CargoDest.User);
            oComando.Parameters.AddWithValue("@asunto", pComunes.Asunto);
            oComando.Parameters.AddWithValue("@texto", pComunes.Texto);
            oComando.Parameters.AddWithValue("@cod", pComunes.Codigo.Codigo);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("No existe el Usuario");
                else if (resultado == -2)
                    throw new Exception("No existe el Destinatario");
                else if (resultado == -3)
                    throw new Exception("No existe el codigo");
                else if (resultado == -4)
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

        public static List<Comunes> ListarComunes()
        {
            List<Comunes> colMensajes = new List<Comunes>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("MensajesComunes", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int numero = Convert.ToInt16(oReader["NumInterno"]);
                        DateTime fecha = (DateTime)oReader["FechaHora"];
                        string asunto = oReader["Asunto"].ToString();
                        string texto = oReader["Texto"].ToString();
                        string destinatario = oReader["Destinatario"].ToString();
                        string usuario = oReader["Username"].ToString();
                        string codigo = oReader["Codigo"].ToString();

                        Usuario dest = PersistenciaUsuario.Buscar(destinatario);
                        Usuario user = PersistenciaUsuario.Buscar(usuario);
                        TiposDeMensaje cod = PersistenciaTipoDeMensaje.Buscar(codigo);

                        Comunes comun = new Comunes(numero, fecha, asunto, texto, user, dest, cod);
                        colMensajes.Add(comun);
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

            return colMensajes;
        }

        public static List<Comunes> ListarMensajesComunes(Usuario pUser, TiposDeMensaje pCod, int ddl)
        {

            List<Comunes> colMensajes = new List<Comunes>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("ListadoMsjComun", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@user", pUser.User);
            oComando.Parameters.AddWithValue("@cod", pCod.Codigo);
            oComando.Parameters.AddWithValue("@ddl", ddl);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        if (ddl == 1)
                        {
                            int numero = Convert.ToInt32(oReader["NumInterno"]);
                            string destinatario = oReader["Destinatario"].ToString();
                            DateTime fecha = Convert.ToDateTime(oReader["FechaHora"]);
                            string asunto = oReader["Asunto"].ToString();
                            string texto = oReader["Texto"].ToString();

                            Usuario dest = PersistenciaUsuario.Buscar(destinatario);

                            Comunes comun = new Comunes(numero, fecha, asunto, texto, pUser, dest, pCod);
                            colMensajes.Add(comun);
                        }
                        else if (ddl == 2)
                        {
                            int numero = Convert.ToInt32(oReader["NumInterno"]);
                            string usuario = oReader["Username"].ToString();
                            DateTime fecha = Convert.ToDateTime(oReader["FechaHora"]);
                            string asunto = oReader["Asunto"].ToString();
                            string texto = oReader["Texto"].ToString();

                            Usuario user = PersistenciaUsuario.Buscar(usuario);

                            Comunes comun = new Comunes(numero, fecha, asunto, texto, user, pUser, pCod);
                            colMensajes.Add(comun);
                        }
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

            return colMensajes;
        }
    }
}
