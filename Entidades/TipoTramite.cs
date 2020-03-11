using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Entidades
{
    [DataContract]
    public class TipoTramite
    {
        private string _nombre;

        private string _codigo;

        private string _descripcion;

        private decimal _precio;

        private List<Documento> _documentosRequeridos;

        [DataMember]
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Debe ingresar nombre para el tipo de tramite.");

                if(value.Length > 100)
                    throw new Exception("El nombre del tramite no puede superar los 100 caracteres.");

                _nombre = value;
            }
        }

        [DataMember]
        public string Codigo
        {
            get { return _codigo; }
            set
            {
                if(string.IsNullOrEmpty(value))
                    throw new Exception("Debe ingresar codigo para el tipo de tramite.");

                if(value.Length > 9)
                    throw new Exception("El codigo del tipo de tramite no puede superar los 9 caracteres.");

                
                if(!Regex.Match(value, "^[2][0][0-9][0-9][a-zA-Z]{5}$").Success)
                    throw new Exception("El codigo debe tener 4 numero y 5 letras.");

                _codigo = value;
            }
        }

        [DataMember]
        public string Descripcion {
            get { return _descripcion; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Debe ingresar descripción para el tipo de tramite.");

                if (value.Length > 200)
                    throw new Exception("La descripción no puede superar los 200 caracteres.");

                _descripcion = value;
            }
        }

        [DataMember]
        public decimal Precio
        {
            get { return _precio; }
            set
            {
                if (value < 0)
                    throw new Exception("El precio no puede ser menor a 0.");

                _precio = value;
            }
        }

        [DataMember]
        public List<Documento> DocumentosRequeridos
        {
            get { return _documentosRequeridos; }
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar una lista de documentos requeridos.");

                if(value.Count == 0)
                    throw new Exception("Se necesita como minimo un documento.");

                _documentosRequeridos = value;
            }
        }

        public TipoTramite(string codigo, string nombre, string descripcion, decimal precio, List<Documento> docsRequeridos) {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            DocumentosRequeridos = docsRequeridos;
        }

        public TipoTramite() { }
    }
}
