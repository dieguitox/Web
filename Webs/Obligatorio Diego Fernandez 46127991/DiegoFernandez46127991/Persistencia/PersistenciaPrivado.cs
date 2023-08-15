using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaPrivado
    {
        public static void Agregar(Privados pPrivados)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("AgregarMensajePrivado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@user", pPrivados.CargoUsuario.User);
            oComando.Parameters.AddWithValue("@dest", pPrivados.CargoDest.User);
            oComando.Parameters.AddWithValue("@asunto", pPrivados.Asunto);
            oComando.Parameters.AddWithValue("@texto", pPrivados.Texto);
            oComando.Parameters.AddWithValue("@venc", pPrivados.Vencimiento);

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

        public static List<Privados> ListarPrivados()
        {
            List<Privados> colMensajes = new List<Privados>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("MensajesPrivados", oConexion);
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
                        DateTime vencimiento = Convert.ToDateTime(oReader["FechaVencimiento"]);

                        Usuario dest = PersistenciaUsuario.Buscar(destinatario);
                        Usuario user = PersistenciaUsuario.Buscar(usuario);


                        Privados privado = new Privados(vencimiento, numero, fecha, asunto, texto, user, dest);
                        colMensajes.Add(privado);
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

        public static List<Privados> ListarMensajesPrivados(Usuario pUser, int ddl)
        {
            List<Privados> colMensajes = new List<Privados>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.DTA);
            SqlCommand oComando = new SqlCommand("ListadoMsjPrivado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@user", pUser.User);
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
                            int numero = Convert.ToInt16(oReader["NumInterno"]);
                            DateTime fecha = (DateTime)oReader["FechaHora"];
                            string asunto = oReader["Asunto"].ToString();
                            string texto = oReader["Texto"].ToString();
                            string destinatario = oReader["Destinatario"].ToString();
                            DateTime vencimiento = Convert.ToDateTime(oReader["FechaVencimiento"]);

                            Usuario dest = PersistenciaUsuario.Buscar(destinatario);

                            Privados privado = new Privados(vencimiento, numero, fecha, asunto, texto, pUser, dest);
                            colMensajes.Add(privado);

                        }
                        else if (ddl == 2)
                        {
                            int numero = Convert.ToInt16(oReader["NumInterno"]);
                            DateTime fecha = (DateTime)oReader["FechaHora"];
                            string asunto = oReader["Asunto"].ToString();
                            string texto = oReader["Texto"].ToString();
                            string usuario = oReader["Username"].ToString();
                            DateTime vencimiento = Convert.ToDateTime(oReader["FechaVencimiento"]);

                            Usuario user = PersistenciaUsuario.Buscar(usuario);

                            Privados privado = new Privados(vencimiento, numero, fecha, asunto, texto, user, pUser);
                            colMensajes.Add(privado);
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
