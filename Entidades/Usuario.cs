using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Entidades
{
    [DataContract]
    [KnownType(typeof(Empleado))]
    [KnownType(typeof(Solicitante))]
    public abstract class Usuario
    {
        private string _documento;

        private string _contrasena;

        private string _nombreCompleto { get; set; }

        [DataMember]
        public string Documento
        {
            get { return _documento;  }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Se requiere documento para el usuario.");

                if(value.Length > 8)
                    throw new Exception("El número de documento no puede superar los 8 caracteres.");

                _documento = value;
            }
        }

        [DataMember]
        public  string Contrasena
        {
            get { return _contrasena; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("La contraseña no puede ser vacia.");

                if(!Regex.Match(value, "^[a-zA-Z]{3}[0-9]{2}[^a-zA-Z0-9]$").Success)
                    throw new Exception("La contraseña debe tener 3 letras, 2 numéros y un simbolo.");

                _contrasena = value;
            }
        }

        [DataMember]
        public string NombreCompleto
        {
            get { return _nombreCompleto; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Debe ingresar nombre completo del usuario.");

                if (value.Length > 50)
                    throw new Exception("El nombre completo no puede superar los 50 caracteres.");

                _nombreCompleto = value;
            }
        }

        public Usuario(string doc, string contrasena, string nombreCompleto)
        {
            NombreCompleto = nombreCompleto;
            Documento = doc;
            Contrasena = contrasena;
        }

        public Usuario() { }
    }
}
