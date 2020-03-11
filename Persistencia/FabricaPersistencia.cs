using Persistencia.interfaces;

namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static IPerSolicitante GetPersistenciaSolicitante()
        {
            return PerSolicitante.ObtenerInstancia();
        }

        public static IPerEmpleado GetPersistenciaEmpleado()
        {
            return PerEmpleado.ObtenerInstancia();
        }

        public static IPerTipoTramite GetPersistenciaTipoTramite()
        {
            return PerTipoTramite.ObtenerInstancia();
        }

        public static IPerSolicitudes GetPersistenciaSolicitud()
        {
            return PerSolicitud.ObtenerInstancia();
        }

        public static IPerDocumento GetPersistenciaDocumento()
        {
            return PerDocumento.ObtenerInstancia();
        }
    }
}
