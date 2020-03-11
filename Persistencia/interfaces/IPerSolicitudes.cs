using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia.interfaces
{
    public interface IPerSolicitudes
    {
        void AgregarSolicitud(Solicitud solicitud, Solicitante userLogin);
        void CambiarEstado(Solicitud solicitud, Empleado userLogin);
        List<Solicitud> ListadoSolicitudes(Empleado userLogin);
    }
}
