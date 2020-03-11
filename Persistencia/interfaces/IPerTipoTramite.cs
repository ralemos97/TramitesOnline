using Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Persistencia.interfaces
{
    public interface IPerTipoTramite
    {
        void AgregarTramite(TipoTramite tramite, Empleado user);
        void ModificarTramite(TipoTramite tramite, Empleado user);
        void EliminarTramite(TipoTramite tramite, Empleado user);
        List<TipoTramite> ObtenerTramites();
        TipoTramite BuscarTramiteActivo(string idTramite, Empleado user);
    }
}
