using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica.interfaces
{
    public interface ILogicaUsuario
    {
        Usuario Login(string usuario, string contrasena);        
        void Registro(Usuario userRegister, Usuario userLogin);
        void ModificarEmpleado(Empleado empleado, Empleado userLogin);
        void EliminarEmpleado(Empleado empleado, Empleado userLogin);
        void AgregarHoraExtra(Empleado empleado);
        Empleado BuscarEmpleado(string documento);
    }
}
