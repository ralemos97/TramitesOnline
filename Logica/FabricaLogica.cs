using Logica.interfaces;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaSolicitud GetLogicaSolicitud()
        {
            return LogicaSolicitud.GetInstancia();
        }

        public static ILogicaTipoTramite GetLogicaTipoTraimte()
        {
            return LogicaTipoTramite.GetInstancia();
        }

        public static ILogicaUsuario GetLogicaUsuario()
        {
            return LogicaUsuario.GetInstancia();
        }

        public static ILogicaDocumento GetLogicaDocumento()
        {
            return LogicaDocumento.GetInstancia();
        }
    }
}
