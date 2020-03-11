using Entidades;
using Logica.interfaces;
using Persistencia;
using Persistencia.interfaces;
using System;
using System.Collections.Generic;

namespace Logica
{
    internal class LogicaSolicitud : ILogicaSolicitud
    {
        private static LogicaSolicitud _instancia = null;
        private LogicaSolicitud() { }
        public static LogicaSolicitud GetInstancia()
        {
            return _instancia == null ? new LogicaSolicitud() : _instancia;
        }

        IPerSolicitudes PerSolicitudes = FabricaPersistencia.GetPersistenciaSolicitud();

        public void AgregarSolicitud(Solicitud solicitud, Solicitante userLogin)
        {
            try
            {
                PerSolicitudes.AgregarSolicitud(solicitud, userLogin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CambiarEstado(Solicitud solicitud, Empleado empleado)
        {
            try
            {
                PerSolicitudes.CambiarEstado(solicitud, empleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Solicitud> ListadoSolicitudes(Empleado empleado)
        {
            try
            {
                return PerSolicitudes.ListadoSolicitudes(empleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
