using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class Solicitud
    {
        private long _codigo;

        private DateTime _fechaHora;

        private string _estado;

        private TipoTramite _tipo;

        private Solicitante _emisor;

        [DataMember]
        public long Codigo
        {
            get { return _codigo; }
            set
            {
                if (value < 0)
                    throw new Exception("El codigo del la solicitud debe ser superior a 0.");

                _codigo = value;
            }
        }

        [DataMember]
        public DateTime FechaHora
        {
            get { return _fechaHora; }
            set { _fechaHora = value; }
        }

        [DataMember]
        public string Estado
        {
            get { return _estado; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Debe ingresar un estado.");

                if (value != "Alta" && value != "Ejecutada" && value != "Anulada")
                    throw new Exception("El nombre del estado no es correcto.");

                _estado = value;
            }
        }

        [DataMember]
        public TipoTramite Tipo
        {
            get { return _tipo; }
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar tipo de solicitud.");

                _tipo = value;
            }
        }

        [DataMember]
        public Solicitante Emisor
        {
            get { return _emisor; }
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar un solicitante.");

                _emisor = value;
            }
        }

        public Solicitud(long codigo, DateTime fechaHora, string estado, TipoTramite tipo, Solicitante emisor)
        {
            Codigo = codigo;
            FechaHora = fechaHora;
            Estado = estado;
            Tipo = tipo;
            Emisor = emisor;
        }

        public Solicitud() { }
    }
}
