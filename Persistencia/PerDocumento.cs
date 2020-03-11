using Entidades;
using Persistencia.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class PerDocumento : IPerDocumento
    {
        private static PerDocumento _instancia = null;
        private PerDocumento() { }

        public static PerDocumento ObtenerInstancia()
        {
            return _instancia ?? new PerDocumento();
        }

        public void AgregarDocumento(Documento nuevoDoc, Empleado userLogin)
        {
            Conexion conexion = new Conexion(userLogin);
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                conexion.Conectar();

                SqlCommand cmdAgregarDoc = db.GenerarStoreProcedure("sp_AgregarDocumento", conexion.GetSqlConnection());
                                
                cmdAgregarDoc.Parameters.AddWithValue("@codigo", nuevoDoc.Id);
                cmdAgregarDoc.Parameters.AddWithValue("@nombre", nuevoDoc.Nombre);
                cmdAgregarDoc.Parameters.AddWithValue("@lugarSolicitud", nuevoDoc.LugarSolicitud);
                db.GenerarValueReturn(cmdAgregarDoc);

                cmdAgregarDoc.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                        throw new Exception("Ya existe un documento con nombre y lugar ingresado.");
                    case -9:
                        throw new Exception("Error al agregar documento.");
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

        public void ModificarDocumento(Documento doc, Empleado userLogin)
        {
            Conexion conexion = new Conexion(userLogin);
            UtilidadesDB db = new UtilidadesDB();
            try

            {
                conexion.Conectar();

                SqlCommand cmdModificarDoc = db.GenerarStoreProcedure("sp_ModificarDocumento", conexion.GetSqlConnection());

                cmdModificarDoc.Parameters.AddWithValue("@id", doc.Id);
                cmdModificarDoc.Parameters.AddWithValue("@nombre", doc.Nombre);
                cmdModificarDoc.Parameters.AddWithValue("@lugarSolicitud", doc.LugarSolicitud);
                db.GenerarValueReturn(cmdModificarDoc);

                cmdModificarDoc.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                        throw new Exception("No existe un documento con los datos ingresados.");
                    case -9:
                        throw new Exception("Error al modificar documento.");
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

        public void EliminarDocumento(int id, Empleado userLogin)
        {
            Conexion conexion = new Conexion(userLogin);
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                conexion.Conectar();

                SqlCommand cmdEliminarDoc = db.GenerarStoreProcedure("sp_EliminarDocumento", conexion.GetSqlConnection());
                cmdEliminarDoc.Parameters.AddWithValue("@id", id);

                db.GenerarValueReturn(cmdEliminarDoc);

                cmdEliminarDoc.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                        throw new Exception("No existe un documento con los datos ingresados.");
                    case -9:
                        throw new Exception("Error al modificar documento.");
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

        public List<Documento> ObtenerDocumentos(Empleado userLogin)
        {
            Conexion conexion = new Conexion(userLogin);
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                List<Documento> docs = new List<Documento>();
                conexion.Conectar();

                SqlCommand cmdObtenerDocs = db.GenerarStoreProcedure("sp_ObtenerDocumentos", conexion.GetSqlConnection());

                SqlDataReader rdDocs = cmdObtenerDocs.ExecuteReader();

                if (rdDocs.HasRows)
                {
                    while (rdDocs.Read())
                    {
                        docs.Add(new Documento(Convert.ToInt32(rdDocs["Id"].ToString()), rdDocs["Nombre"].ToString(), rdDocs["LugarSolicitud"].ToString()));
                    }
                    rdDocs.Close();
                }

                return docs;
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

        public Documento BuscarDocumentoActivo(int id, Usuario userLogin)
        {
            Conexion conexion = new Conexion(userLogin);
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                Documento doc = null;
                conexion.Conectar();

                SqlCommand cmdBuscarDoc = db.GenerarStoreProcedure("sp_BuscarDocumentoActivo", conexion.GetSqlConnection());
                cmdBuscarDoc.Parameters.AddWithValue("@id", id);

                db.GenerarValueReturn(cmdBuscarDoc);

                SqlDataReader rdDocumento = cmdBuscarDoc.ExecuteReader();

                if (rdDocumento.HasRows)
                {
                    rdDocumento.Read();
                    doc = new Documento(Convert.ToInt32(rdDocumento["Id"].ToString()), rdDocumento["Nombre"].ToString(), rdDocumento["LugarSolicitud"].ToString());
                    rdDocumento.Close();
                }

                return doc;
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

        internal Documento BuscarDocumento(int id)
        {
            Conexion conexion = new Conexion();
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                Documento doc = null;
                conexion.Conectar();

                SqlCommand cmdBuscarDoc = db.GenerarStoreProcedure("sp_BuscarDocumento", conexion.GetSqlConnection());
                cmdBuscarDoc.Parameters.AddWithValue("@id", id);

                db.GenerarValueReturn(cmdBuscarDoc);

                SqlDataReader rdDocumento = cmdBuscarDoc.ExecuteReader();

                if (rdDocumento.HasRows)
                {
                    rdDocumento.Read();
                    doc = new Documento(Convert.ToInt32(rdDocumento["Id"].ToString()), rdDocumento["Nombre"].ToString(), rdDocumento["LugarSolicitud"].ToString());
                    rdDocumento.Close();
                }

                return doc;
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
