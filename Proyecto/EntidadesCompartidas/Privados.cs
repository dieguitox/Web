using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Privados : Mensaje
    {
        //atributo
        private DateTime vencimiento;

        //propiedad
        public DateTime Vencimiento
        {
            get { return vencimiento; }
            set { vencimiento = value; }
        }

        //Constructor
        public Privados(DateTime pVencimiento, int pNumero, DateTime pFecha, string pAsunto, string pTexto, Usuario pEnvia, Usuario pDestinatario)
            : base(pNumero, pFecha, pAsunto, pTexto, pEnvia, pDestinatario)
        {
            Vencimiento = pVencimiento;
        }
    }
}
