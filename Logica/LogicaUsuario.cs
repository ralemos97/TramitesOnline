using Entidades;
using Logica.interfaces;
using Persistencia;
using System;
using System.Linq;

namespace Logica
{
    internal class LogicaUsuario : ILogicaUsuario
    {
        private static LogicaUsuario _instancia = null;
        private LogicaUsuario() { }

        public static LogicaUsuario GetInstancia()
        {
            return _instancia == null ? new LogicaUsuario() : _instancia;
        }

        public Usuario Login(string usuario, string contrasena)
        {
            try
            {
                Usuario user = null;

                user = FabricaPersistencia.GetPersistenciaSolicitante().BuscarSolicitante(usuario);

                if (user == null)
                    user = FabricaPersistencia.GetPersistenciaEmpleado().BuscarEmpleado(usuario);

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Registro(Usuario userRegister, Usuario userLogin = null)
        {
            try
            {
                if (userRegister is Empleado && userLogin != null)
                {
                    FabricaPersistencia.GetPersistenciaEmpleado().AgregarEmpleado((Empleado)userRegister, (Empleado)userLogin);
                }
                else if (userRegister is Solicitante)
                {
                    FabricaPersistencia.GetPersistenciaSolicitante().AgregarSolicitante((Solicitante)userRegister);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarEmpleado(Empleado empleado, Empleado userLogin)
        {
            try
            {
                FabricaPersistencia.GetPersistenciaEmpleado().ModificarEmpleado(empleado, userLogin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEmpleado(Empleado empleado, Empleado userLogin)
        {
            try
            {
                FabricaPersistencia.GetPersistenciaEmpleado().EliminarEmpleado(empleado, userLogin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarHoraExtra(Empleado empleado)
        {
            try
            {
                if (!empleado.HorasExtrasGeneradas.Any(e => e.Fecha.Date == DateTime.Today))
                    throw new Exception("No existen horas extras para agregar a la fecha actual.");

                FabricaPersistencia.GetPersistenciaEmpleado().AgregarHorasExtras(empleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Empleado BuscarEmpleado(string documento)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaEmpleado().BuscarEmpleado(documento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
