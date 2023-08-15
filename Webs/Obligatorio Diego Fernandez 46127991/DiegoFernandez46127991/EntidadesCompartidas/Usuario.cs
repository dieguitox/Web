using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuario
    {
        //atributos
        private int cedula;
        private string nombre;
        private string usuario;

        //Propiedades
        public int Cedula
        {
            get { return cedula; }
            set
            {
                if (value.ToString().Length != 8)
                    throw new Exception("La cédula debe tener 8 caracteres.");

                cedula = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("El nombre no puede estar vacío.");

                else if (value.Trim().Length > 20)
                    throw new Exception("El nombre no puede exceder los 20 caracteres.");

                nombre = value;
            }
        }

        public string User
        {
            get { return usuario; }
            set
            {
                if (value.Trim().ToLower() == "")
                    throw new Exception("El nombre de usuario no puede estar vacío.");
                else if (value.Length > 10)
                    throw new Exception("El nombre de usuario no puede exeder los 10 caracteres.");

                usuario = value;
            }
        }

        //constructor
        public Usuario(string pUser, string pNombre, int pCedula)
        {
            Cedula = pCedula;
            Nombre = pNombre;
            User = pUser;
        }
    }
}
