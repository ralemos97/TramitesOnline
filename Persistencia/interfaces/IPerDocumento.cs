using Entidades;
using System.Collections.Generic;

namespace Persistencia.interfaces
{
    public interface IPerDocumento
    {
        void AgregarDocumento(Documento nuevoDoc, Empleado userLogin);
        void ModificarDocumento(Documento doc, Empleado userLogin);
        void EliminarDocumento(int id, Empleado userLogin);
        Documento BuscarDocumentoActivo(int id, Usuario userLogin);
        List<Documento> ObtenerDocumentos(Empleado userLogin);
    }
}
