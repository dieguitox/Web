using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Comunes : Mensaje
    {
        //Asociacion
        private TiposDeMensaje code;

        public TiposDeMensaje Codigo
        {
            get { return code; }
            set
            {
                if (value == null)
                    throw new Exception("El codigo no puede estar vacio");

                code = value;
            }
        }

        //Constructor
        public Comunes(int pNumero, DateTime pFecha, string pAsunto, string pTexto, Usuario pEnvia, Usuario pDestinatario, TiposDeMensaje pCode)
            : base(pNumero, pFecha, pAsunto, pTexto, pEnvia, pDestinatario)
        {
            Codigo = pCode;
        }


    }
}