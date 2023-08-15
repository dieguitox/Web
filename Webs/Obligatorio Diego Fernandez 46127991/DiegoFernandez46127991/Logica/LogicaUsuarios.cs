using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuarios
    {
        public static void Agregar(Usuario pUsuario)
        {
            PersistenciaUsuario.Agregar(pUsuario);
        }

        public static void Modificar(Usuario pUsuario)
        {
            PersistenciaUsuario.Modificar(pUsuario);
        }

        public static void Eliminar(Usuario pUsuario)
        {
            PersistenciaUsuario.Eliminar(pUsuario);
        }

        public static Usuario Buscar(string pUsuario)
        {
            Usuario user = PersistenciaUsuario.Buscar(pUsuario);

            return user;
        }

        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> colUsuarios = new List<Usuario>();

            colUsuarios.AddRange(PersistenciaUsuario.ListarUsuarios());

            return colUsuarios;
        }
    }
}
