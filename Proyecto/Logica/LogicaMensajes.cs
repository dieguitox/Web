using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaMensajes
    {
        public static void Agregar(Mensaje pMensaje)
        {
            if (pMensaje is Comunes)
                PersistenciaComun.Agregar((Comunes)pMensaje);
            else
            {
                if (pMensaje.Fecha < DateTime.Now.Date)
                    throw new Exception("La fecha de vencimiento debe ser posterior al dia de hoy");

                PersistenciaPrivado.Agregar((Privados)pMensaje);
            }
        }

        public static void Agregar(TiposDeMensaje pTipo)
        {
            PersistenciaTipoDeMensaje.Agregar(pTipo);
        }

        public static void Modificar(TiposDeMensaje pTipo)
        {
            PersistenciaTipoDeMensaje.Modificar(pTipo);
        }

        public static void Eliminar(TiposDeMensaje pTipo)
        {
            PersistenciaTipoDeMensaje.Eliminar(pTipo);
        }

        public static TiposDeMensaje Buscar(string pCodigo)
        {
            TiposDeMensaje codigo = PersistenciaTipoDeMensaje.Buscar(pCodigo);

            return codigo;
        }

        public static List<TiposDeMensaje> ListarTipos()
        {
            return PersistenciaTipoDeMensaje.ListadoDeTipos();
        }

        public static List<Mensaje> ListarMensajes()
        {
            List<Mensaje> colAuxiliar = new List<Mensaje>();

            colAuxiliar.AddRange(PersistenciaComun.ListarComunes());
            colAuxiliar.AddRange(PersistenciaPrivado.ListarPrivados());

            return colAuxiliar;
        }

        public static List<Mensaje> ListarPorUsuario(Usuario pUser, TiposDeMensaje pCod, int ddl)
        {
            List<Mensaje> colAuxiliar = new List<Mensaje>();

            colAuxiliar.AddRange(PersistenciaComun.ListarMensajesComunes(pUser, pCod, ddl));

            return colAuxiliar;
        }

        public static List<Mensaje> ListarPorUsuarioPrivado(Usuario pUser, int ddl)
        {
            List<Mensaje> colAuxiliar = new List<Mensaje>();

            colAuxiliar.AddRange(PersistenciaPrivado.ListarMensajesPrivados(pUser, ddl));

            return colAuxiliar;
        }
    }
}
