using Entidades;
using Persistencia.interfaces;
using System;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class PerSolicitante : IPerSolicitante
    {        
        private static PerSolicitante _instancia = null;
        private PerSolicitante() { }

        public static PerSolicitante ObtenerInstancia()
        {
            return _instancia ?? new PerSolicitante();
        }

        public void AgregarSolicitante(Solicitante solicitante)
        {
            Conexion conexion = new Conexion();
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                conexion.Conectar();
                SqlCommand cmdAgregarSolicitante = db.GenerarStoreProcedure("sp_NuevoSolicitante", conexion.GetSqlConnection());

                cmdAgregarSolicitante.Parameters.AddWithValue("@doc", solicitante.Documento);
                cmdAgregarSolicitante.Parameters.AddWithValue("@contrasena", solicitante.Contrasena);
                cmdAgregarSolicitante.Parameters.AddWithValue("@nombre", solicitante.NombreCompleto);
                cmdAgregarSolicitante.Parameters.AddWithValue("@telefono", solicitante.Telefono);

                db.GenerarValueReturn(cmdAgregarSolicitante);

                cmdAgregarSolicitante.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                    case -2:
                        throw new Exception("No se pudo crear el usuario correctamente.");
                    case -3:
                        throw new Exception("Ya existe usuario con los datos ingresados.");
                    case -9:
                        throw new Exception("Error al crear el usuario.");
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

        public Solicitante BuscarSolicitante(string documento)
        {
            Conexion conexion = new Conexion();
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                Solicitante solicitante = null;
                conexion.Conectar();

                SqlCommand cmdSolicitante = db.GenerarStoreProcedure("sp_BuscarSolicitante", conexion.GetSqlConnection());
                cmdSolicitante.Parameters.AddWithValue("@doc", documento);

                SqlDataReader rdSolicitante = cmdSolicitante.ExecuteReader();

                if (rdSolicitante.HasRows)
                {
                    rdSolicitante.Read();

                    solicitante = new Solicitante(rdSolicitante["NumeroDocumento"].ToString(),
                                                  rdSolicitante["Contrasena"].ToString(),
                                                  rdSolicitante["NombreCompleto"].ToString(),
                                                  rdSolicitante["Telefono"].ToString());
                    rdSolicitante.Close();
                }

                return solicitante;
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
