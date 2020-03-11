using Entidades;
using System.Collections.Generic;
using System.Xml;

namespace Logica.interfaces
{
    public interface ILogicaTipoTramite
    {
        void AgregarTramite(TipoTramite tramite, Empleado userLogin);
        void ModificarTramite(TipoTramite tramite, Empleado user);
        void EliminarTramite(TipoTramite tramite, Empleado user);
        List<TipoTramite> ObtenerTramites();
        XmlDocument ObtenerTipoTramites();
        TipoTramite BuscarTramiteActivo(string idTramite, Empleado user);
    }
}
