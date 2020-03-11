using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class Solicitante : Usuario
    {
        private string _telefono;

        [DataMember]
        public string Telefono
        {
            get { return _telefono;  }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Debe ingresar número de telefono del solicitante.");

                if(value.Length > 10)
                    throw new Exception("El número de telefono no puede superar los 10 caracteres.");

                _telefono = value;
            }
        }

        public Solicitante(string doc, string contrasena, string nombreCompleto, string telefono) : base (doc, contrasena, nombreCompleto)
        {
            Telefono = telefono;
        }

        public Solicitante() { }
    }
}
