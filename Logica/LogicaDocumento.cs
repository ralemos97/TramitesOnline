using Entidades;
using Logica.interfaces;
using Persistencia;
using Persistencia.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    internal class LogicaDocumento : ILogicaDocumento
    {

        private static LogicaDocumento _instancia = null;
        private LogicaDocumento() { }
        public static LogicaDocumento GetInstancia()
        {
            return _instancia == null ? new LogicaDocumento() : _instancia;
        }

        IPerDocumento PerDocumento = FabricaPersistencia.GetPersistenciaDocumento();

        public void AgregarDocumento(Documento nuevoDoc, Empleado userLogin)
        {
            try
            {
                PerDocumento.AgregarDocumento(nuevoDoc, userLogin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarDocumento(Documento doc, Empleado userLogin)
        {
            try
            {
                PerDocumento.ModificarDocumento(doc, userLogin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarDocumento(int id, Empleado userLogin)
        {
            try
            {
                PerDocumento.EliminarDocumento(id, userLogin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Documento BuscarDocumento(int id, Usuario userLogin)
        {
            try
            {
                return PerDocumento.BuscarDocumentoActivo(id, userLogin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Documento> ObtenerDocumentos(Empleado userLogin)
        {
            try
            {
                return PerDocumento.ObtenerDocumentos(userLogin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
