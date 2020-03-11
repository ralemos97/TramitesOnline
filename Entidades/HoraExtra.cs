using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class HoraExtra
    {
        private DateTime _fecha;

        private int _minutos;

        [DataMember]
        public DateTime Fecha
        {
            get { return _fecha; }
            set
            {
                if (value.Date > DateTime.Today)
                    throw new Exception("No se pueden generar horas extras con fechas futuras.");

                _fecha = value;
            }
        }

        [DataMember]
        public int Minutos
        {
            get { return _minutos; }
            set
            {
                if(value <= 0)
                    throw new Exception("No se pueden generar horas extras sin minutos.");

                _minutos = value;
            }
        }

        public HoraExtra(DateTime fecha, int minutos)
        {
            Fecha = fecha;
            Minutos = minutos;
        }

        public HoraExtra() { }
    }        
}
