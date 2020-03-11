using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia.interfaces
{
    public interface IPerEmpleado
    {
        void AgregarEmpleado(Empleado empleado, Empleado userLogin);
        void ModificarEmpleado(Empleado empleado, Empleado userLogin);
        void EliminarEmpleado(Empleado empleado, Empleado userLogin);
        void AgregarHorasExtras(Empleado empleado);
        Empleado BuscarEmpleado(string documento);
    }
}
