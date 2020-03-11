using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class Documento
    {
        private int _id;

        private string _nombre;

        private string _lugarDeSolicitud;

        [DataMember]
        public int Id
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                    throw new Exception("El id del documento debe ser superior a 0.");

                _id = value;
            }
        }

        [DataMember]
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if(string.IsNullOrEmpty(value))
                    throw new Exception("Debe ingresar nombre para el documento.");

                if(value.Length > 40)
                    throw new Exception("El nombre del documento no puede superar los 40 caracteres.");

                _nombre = value;

            }
        }

        [DataMember]
        public string LugarSolicitud
        {
            get { return _lugarDeSolicitud; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Debe ingresar nombre de solicitud del documento.");

                if (value.Length > 150)
                    throw new Exception("El nombre del lugar de solicitud no puede superar los 150 caracteres.");

                _lugarDeSolicitud = value;
            }
        }

        public Documento(int id, string nombre, string lugar)
        {
            Id = id;
            Nombre = nombre;
            LugarSolicitud = lugar;
        }

        public Documento() { }
    }
}
