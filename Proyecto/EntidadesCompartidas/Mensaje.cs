using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Mensaje
    {
        //atributos
        private int numero;
        private DateTime fecha;
        private string asunto;
        private string texto;

        //Asociacion
        Usuario envia;
        Usuario destinatario;
        TiposDeMensaje tipo;

        //propiedades

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                if (value.Date > DateTime.Now)
                    throw new Exception("La fecha no puedes ser menor que la actual");

                fecha = value;
            }
        }

        public string Asunto
        {
            get { return asunto; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("El asunto no puede estar vacío.");
                else if (value.Trim().Length > 50)
                    throw new Exception("El asunto no puede tener más de 50 caracteres");

                asunto = value;
            }
        }

        public string Texto
        {
            get { return texto; }
            set
            {
                if (value.Length > 200 && value.Length < 0)
                    throw new Exception("El mensaje no puede superar los 200 caracteres.");

                texto = value;
            }
        }

        public Usuario CargoUsuario
        {
            get { return envia; }
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar un usuario");

                envia = value;
            }
        }

        public Usuario CargoDest
        {
            get { return destinatario; }
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar un usuario");

                destinatario = value;
            }
        }

        public TiposDeMensaje Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public Mensaje(int pNumero, DateTime pFecha, string pAsunto, string pTexto, Usuario pEnvia, Usuario pDestinatario)
        {
            Numero = pNumero;
            fecha = pFecha;
            Asunto = pAsunto;
            Texto = pTexto;
            CargoUsuario = pEnvia;
            CargoDest = pDestinatario;
        }
    }
}
