using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica.interfaces
{
    public interface ILogicaDocumento
    {
        void AgregarDocumento(Documento nuevoDoc, Empleado userLogin);
        void ModificarDocumento(Documento doc, Empleado userLogin);
        void EliminarDocumento(int id, Empleado userLogin);
        Documento BuscarDocumento(int id, Usuario userLogin);
        List<Documento> ObtenerDocumentos(Empleado userLogin);
    }
}
