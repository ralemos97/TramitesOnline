using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class Empleado : Usuario
    {

        private string _horaEntrada;

        private string _horaSalida;

        private List<HoraExtra> _horasExtrasGeneradas;

        [DataMember]
        public string HoraEntrada
        {
            get { return _horaEntrada; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Debe indicar hora de entrada para el empleado.");

                if(value.Length != 5)
                    throw new Exception("La hora de entrada debe tener 6 caracteres con el siguiente formato HH:mm");

                _horaEntrada = value;
            }
        }

        [DataMember]
        public string HoraSalida
        {
            get { return _horaSalida; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Debe indicar hora de salida para el empleado.");

                if (value.Length != 5)
                    throw new Exception("La hora de salida debe tener 6 caracteres con el siguiente formato HH:mm");

                _horaSalida = value;
            }
        }

        [DataMember]
        public List<HoraExtra> HorasExtrasGeneradas
        {
            get { return _horasExtrasGeneradas; }
            set
            {
                if (value == null)
                    throw new Exception("Debe indicar una lista de horas extras que puede estar vacia.");

                _horasExtrasGeneradas = value;
            }
        }

        public Empleado(string doc, string contrasena, string nombreCompleto, string horaEntrada, string horaSalida, List<HoraExtra> horasExtras) : base (doc, contrasena, nombreCompleto)
        {
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
            HorasExtrasGeneradas = horasExtras;
        }

        public Empleado() { }
    }
}
