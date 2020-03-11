using Entidades;
using Persistencia.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Persistencia
{
    internal class PerEmpleado : IPerEmpleado
    {
        private static PerEmpleado _instancia = null;
        private PerEmpleado() { }

        public static PerEmpleado ObtenerInstancia()
        {
            return _instancia ?? new PerEmpleado();
        }

        public void AgregarEmpleado(Empleado empleado, Empleado userLogin)
        {
            Conexion conexion = new Conexion(userLogin);
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                conexion.Conectar();
                SqlCommand cmdAgregarEmp = db.GenerarStoreProcedure("sp_NuevoEmpleado", conexion.GetSqlConnection());

                cmdAgregarEmp.Parameters.AddWithValue("doc", empleado.Documento);
                cmdAgregarEmp.Parameters.AddWithValue("contrasena", empleado.Contrasena);
                cmdAgregarEmp.Parameters.AddWithValue("nombre", empleado.NombreCompleto);
                cmdAgregarEmp.Parameters.AddWithValue("horaEntrada", empleado.HoraEntrada);
                cmdAgregarEmp.Parameters.AddWithValue("horaSalida", empleado.HoraSalida);
                db.GenerarValueReturn(cmdAgregarEmp);

                cmdAgregarEmp.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                        throw new Exception("No se pudo crear el login empleado.");
                    case -2:
                        throw new Exception("Error al crear nuevo empleado.");
                    case -3:
                        throw new Exception("Ya existe un usuario con los datos ingresados.");
                    case -9:
                        throw new Exception("Error al agregar empleado.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        public void ModificarEmpleado(Empleado empleado, Empleado userLogin)
        {
            Conexion conexion = new Conexion(userLogin);
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                conexion.Conectar();
                SqlCommand cmdModificarEmp = db.GenerarStoreProcedure("sp_ModificarEmpleado", conexion.GetSqlConnection());

                cmdModificarEmp.Parameters.AddWithValue("doc", empleado.Documento);
                cmdModificarEmp.Parameters.AddWithValue("contrasena", empleado.Contrasena);                
                cmdModificarEmp.Parameters.AddWithValue("oldContrasena", userLogin.Contrasena);                
                cmdModificarEmp.Parameters.AddWithValue("nombre", empleado.NombreCompleto);
                cmdModificarEmp.Parameters.AddWithValue("horaEntrada", empleado.HoraEntrada);
                cmdModificarEmp.Parameters.AddWithValue("horaSalida", empleado.HoraSalida);
                cmdModificarEmp.Parameters.AddWithValue("modificarContrasena", Convert.ToInt16(empleado.Documento == userLogin.Documento));

                db.GenerarValueReturn(cmdModificarEmp);

                cmdModificarEmp.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                        throw new Exception("No se encontro empleado para modificar.");
                    case -9:
                        throw new Exception("Error al modificar empleado.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        public void EliminarEmpleado(Empleado empleado, Empleado userLogin)
        {
            Conexion conexion = new Conexion(userLogin);
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                conexion.Conectar();
                SqlCommand cmdEliminarEmp = db.GenerarStoreProcedure("sp_EliminarEmpleado", conexion.GetSqlConnection());

                cmdEliminarEmp.Parameters.AddWithValue("doc", empleado.Documento);

                db.GenerarValueReturn(cmdEliminarEmp);

                cmdEliminarEmp.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                        throw new Exception("No se encontro empleado para eliminar.");
                    case -9:
                        throw new Exception("Error al eliminar empleado.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        public void AgregarHorasExtras(Empleado empleado)
        {
            Conexion conexion = new Conexion(empleado);
            UtilidadesDB db = new UtilidadesDB();
            try
            {                
                conexion.Conectar();
                SqlCommand cmdAgregarExtras = db.GenerarStoreProcedure("sp_AgregarExtras", conexion.GetSqlConnection());


                HoraExtra horaExtraActual = empleado.HorasExtrasGeneradas.FirstOrDefault(f => f.Fecha.Date == DateTime.Now);

                cmdAgregarExtras.Parameters.AddWithValue("doc", empleado.Documento);
                cmdAgregarExtras.Parameters.AddWithValue("fecha", horaExtraActual.Fecha);
                cmdAgregarExtras.Parameters.AddWithValue("minutos", horaExtraActual.Minutos);

                db.GenerarValueReturn(cmdAgregarExtras);

                cmdAgregarExtras.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                        throw new Exception("No se encontro empleado.");
                    case -9:
                        throw new Exception("Error al agregar extras empleado.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        public Empleado BuscarEmpleado(string documento)
        {
            Conexion conexion = new Conexion();
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                Empleado empleado = null;
                conexion.Conectar();

                SqlCommand cmdBuscarEmpleado = db.GenerarStoreProcedure("sp_BuscarEmpleado", conexion.GetSqlConnection());
                cmdBuscarEmpleado.Parameters.AddWithValue("doc", documento);

                SqlDataReader rdEmpleado = cmdBuscarEmpleado.ExecuteReader();

                if (rdEmpleado.HasRows)
                {                    
                    rdEmpleado.Read();

                    string horaEntrada = rdEmpleado["HoraEntrada"].ToString();
                    string horaSalida = rdEmpleado["HoraSalida"].ToString();

                    List<HoraExtra> horasExtras = ObtenerHorasExtras(documento);
                    empleado = new Empleado(rdEmpleado["NumeroDocumento"].ToString(), rdEmpleado["Contrasena"].ToString(), rdEmpleado["NombreCompleto"].ToString(),
                                            horaEntrada.Substring(0, horaEntrada.Length - 3), horaSalida.Substring(0, horaSalida.Length -3), horasExtras);
                    rdEmpleado.Close();
                }

                return empleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        private List<HoraExtra> ObtenerHorasExtras(string documento)
        {
            Conexion conexion = new Conexion();
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                List<HoraExtra> horasExtras = new List<HoraExtra>();
                conexion.Conectar();

                SqlCommand cmdObtenerExtras = db.GenerarStoreProcedure("sp_ObtenerExtras", conexion.GetSqlConnection());
                cmdObtenerExtras.Parameters.AddWithValue("doc", documento);

                SqlDataReader rdExtras = cmdObtenerExtras.ExecuteReader();

                if (rdExtras.HasRows)
                {
                    horasExtras = new List<HoraExtra>();
                    while (rdExtras.Read())
                    {
                        horasExtras.Add(new HoraExtra(Convert.ToDateTime(rdExtras["Fecha"].ToString()), Convert.ToInt32(rdExtras["CantidadMinutos"].ToString())));
                    }
                    rdExtras.Close();
                }

                return horasExtras;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Desconectar();
            }
        }

    }
}
