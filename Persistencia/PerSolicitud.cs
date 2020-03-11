using Entidades;
using Persistencia.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class PerSolicitud : IPerSolicitudes
    {
        private static PerSolicitud _instancia = null;
        private PerSolicitud() { }

        public static PerSolicitud ObtenerInstancia()
        {
            return _instancia ?? new PerSolicitud();
        }

        PerSolicitante perSolicitante = PerSolicitante.ObtenerInstancia();
        PerTipoTramite perTipoTramite = PerTipoTramite.ObtenerInstancia();

        public void AgregarSolicitud(Solicitud solicitud, Solicitante userLogin)
        {
            Conexion conexion = new Conexion(userLogin);
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                conexion.Conectar();

                SqlCommand cmdAgregarSolicitud = db.GenerarStoreProcedure("sp_AgregarSolicitud", conexion.GetSqlConnection());

                cmdAgregarSolicitud.Parameters.AddWithValue("@docSolicitante", solicitud.Emisor.Documento);
                cmdAgregarSolicitud.Parameters.AddWithValue("@fechaHora", solicitud.FechaHora);
                cmdAgregarSolicitud.Parameters.AddWithValue("@idTipoTramite", solicitud.Tipo.Codigo);

                db.GenerarValueReturn(cmdAgregarSolicitud);

                cmdAgregarSolicitud.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                        throw new Exception("Ya tiene una solicitud generada para esta fecha y hora.");
                    case -2:
                        throw new Exception("Existe una solicitud del mismo tipo de tramite sin finalizar.");
                    case -9:
                        throw new Exception("Error al generar nueva solicitud.");
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

        public void CambiarEstado(Solicitud solicitud, Empleado userLogin)
        {
            Conexion conexion = new Conexion(userLogin);
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                conexion.Conectar();

                SqlCommand cmdCambiarEstado = db.GenerarStoreProcedure("sp_CambiarEstadoSolicitud", conexion.GetSqlConnection());

                cmdCambiarEstado.Parameters.AddWithValue("@codigo", solicitud.Codigo);
                cmdCambiarEstado.Parameters.AddWithValue("@estado", solicitud.Estado);

                db.GenerarValueReturn(cmdCambiarEstado);

                cmdCambiarEstado.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                        throw new Exception("No se encontro solicitud con el codigo ingresado.");
                    case -9:
                        throw new Exception("Error al cambiar el estado de la solicitud.");
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

        public List<Solicitud> ListadoSolicitudes(Empleado userLogin)
        {
            Conexion conexion = new Conexion(userLogin);
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                List<Solicitud> solicitudes = new List<Solicitud>();
                conexion.Conectar();

                SqlCommand cmdSolicitudes = db.GenerarStoreProcedure("sp_ObtenerSolicitudes", conexion.GetSqlConnection());

                SqlDataReader rdSolicitudes = cmdSolicitudes.ExecuteReader();

                if (rdSolicitudes.HasRows)
                {
                    solicitudes = new List<Solicitud>();

                    while (rdSolicitudes.Read())
                    {
                        Solicitante emisor = perSolicitante.BuscarSolicitante(rdSolicitudes["NumDocumento"].ToString());
                        TipoTramite tipo = perTipoTramite.BuscarTramite(rdSolicitudes["IdTipoTramite"].ToString(), userLogin);
                        Solicitud solicitud = new Solicitud(Convert.ToInt64(rdSolicitudes["Codigo"].ToString()), Convert.ToDateTime(rdSolicitudes["FechaHora"].ToString()),
                                                        rdSolicitudes["Estado"].ToString(), tipo, emisor);

                        solicitudes.Add(solicitud);
                    }
                    rdSolicitudes.Close();
                }

                return solicitudes;
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