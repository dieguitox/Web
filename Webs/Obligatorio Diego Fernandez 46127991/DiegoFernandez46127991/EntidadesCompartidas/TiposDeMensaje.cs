using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class TiposDeMensaje
    {
        //atributos
        private string codigo;
        private string nombre;

        //propiedades
        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("El nombre no puede estar vacio.");
                else if (value.Trim().Length > 3)
                    throw new Exception("El codigo no puede tener mas o menos de 3 caracteres");

                codigo = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("El nombre no puede estar vacio.");
                else if (value.Trim().Length > 20)
                    throw new Exception("El nombre no puede exceder los 20 caracteres.");

                nombre = value;

            }
        }

        //constructor
        public TiposDeMensaje(string pCode, string pNombre)
        {
            Codigo = pCode;
            Nombre = pNombre;
        }
    }
}