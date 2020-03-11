using Entidades;
using Persistencia.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class PerTipoTramite : IPerTipoTramite
    {
        private static PerTipoTramite _instancia = null;
        private PerTipoTramite() { }

        public static PerTipoTramite ObtenerInstancia()
        {
            return _instancia ?? new PerTipoTramite();
        }

        PerDocumento perDocumento = PerDocumento.ObtenerInstancia();

        public void AgregarTramite(TipoTramite tramite, Empleado user)
        {
            Conexion conexion = new Conexion(user);
            UtilidadesDB db = new UtilidadesDB();
            conexion.Conectar();
            SqlCommand cmdAgregarTramite = db.GenerarStoreProcedure("sp_AgregarTipoTramite", conexion.GetSqlConnection());
            try
            {
                cmdAgregarTramite.Parameters.AddWithValue("@codigo", tramite.Codigo);
                cmdAgregarTramite.Parameters.AddWithValue("@nombre", tramite.Nombre);
                cmdAgregarTramite.Parameters.AddWithValue("@descripcion", tramite.Descripcion);
                cmdAgregarTramite.Parameters.AddWithValue("@precio", tramite.Precio);
                db.GenerarValueReturn(cmdAgregarTramite);

                cmdAgregarTramite.Transaction = conexion.GetSqlConnection().BeginTransaction();

                cmdAgregarTramite.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                        throw new Exception("Ya existe un tramite con los datos ingresados.");
                    case -9:
                        throw new Exception("Error al crear tipo de tramite.");
                }

                foreach (Documento doc in tramite.DocumentosRequeridos)
                {
                    AsociarDocumentoTramite(doc, tramite.Codigo, cmdAgregarTramite.Transaction);
                }

                cmdAgregarTramite.Transaction.Commit();
            }
            catch (Exception ex)
            {
                cmdAgregarTramite.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        public void ModificarTramite(TipoTramite tramite, Empleado user)
        {
            Conexion conexion = new Conexion(user);
            UtilidadesDB db = new UtilidadesDB();
            conexion.Conectar();
            SqlCommand cmdModificarTramite = db.GenerarStoreProcedure("sp_ModificarTipoTramite", conexion.GetSqlConnection());
            try
            {
                cmdModificarTramite.Parameters.AddWithValue("@codigo", tramite.Codigo);
                cmdModificarTramite.Parameters.AddWithValue("@nombre", tramite.Nombre);
                cmdModificarTramite.Parameters.AddWithValue("@descripcion", tramite.Descripcion);
                cmdModificarTramite.Parameters.AddWithValue("@precio", tramite.Precio);
                db.GenerarValueReturn(cmdModificarTramite);

                cmdModificarTramite.Transaction = conexion.GetSqlConnection().BeginTransaction();

                cmdModificarTramite.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                        throw new Exception("No existe el tipo de tramite indicado.");
                    case -9:
                        throw new Exception("Error al modificar tramite.");
                }

                EliminarDocumentosTramite(tramite.Codigo, cmdModificarTramite.Transaction);

                foreach (Documento doc in tramite.DocumentosRequeridos)
                {
                    AsociarDocumentoTramite(doc, tramite.Codigo, cmdModificarTramite.Transaction);
                }

                cmdModificarTramite.Transaction.Commit();
            }
            catch (Exception ex)
            {
                cmdModificarTramite.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        public void EliminarTramite(TipoTramite tramite, Empleado user)
        {
            Conexion conexion = new Conexion(user);
            UtilidadesDB db = new UtilidadesDB();
            conexion.Conectar();

            SqlCommand cmdEliminarTramite = db.GenerarStoreProcedure("sp_EliminarTipoTramite", conexion.GetSqlConnection());

            try
            {

                cmdEliminarTramite.Transaction = conexion.GetSqlConnection().BeginTransaction();

                cmdEliminarTramite.Parameters.AddWithValue("@codigo", tramite.Codigo);
                db.GenerarValueReturn(cmdEliminarTramite);

                EliminarDocumentosTramite(tramite.Codigo, cmdEliminarTramite.Transaction);

                cmdEliminarTramite.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                        throw new Exception("No se encontro tramite para eliminar.");
                    case -9:
                        throw new Exception("Error al eliminar tramite.");
                }
                cmdEliminarTramite.Transaction.Commit();
            }
            catch (Exception ex)
            {
                cmdEliminarTramite.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                conexion.Desconectar();
            }
        }

        public TipoTramite BuscarTramiteActivo(string idTramite, Empleado user)
        {
            Conexion conexion = new Conexion(user);
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                conexion.Conectar();
                TipoTramite tramite = null;
                SqlCommand cmdBuscarTramite = db.GenerarStoreProcedure("sp_BuscarTramiteActivo", conexion.GetSqlConnection());
                cmdBuscarTramite.Parameters.AddWithValue("@codigoTramite", idTramite);

                SqlDataReader rdTramite = cmdBuscarTramite.ExecuteReader();

                if (rdTramite.HasRows)
                {
                    rdTramite.Read();
                    List<Documento> docsTramite = BuscarDocumentosTramite(rdTramite["Codigo"].ToString());
                    tramite = new TipoTramite(rdTramite["Codigo"].ToString(), rdTramite["Nombre"].ToString(), rdTramite["Descripcion"].ToString(),
                                              Convert.ToDecimal(rdTramite["Precio"].ToString()), docsTramite);
                    rdTramite.Close();
                }

                return tramite;
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

        public List<TipoTramite> ObtenerTramites()
        {
            Conexion conexion = new Conexion();
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                List<TipoTramite> tramites = new List<TipoTramite>();

                conexion.Conectar();
                SqlCommand cmdTramites = db.GenerarStoreProcedure("sp_ObtenerTramites", conexion.GetSqlConnection());

                SqlDataReader rdTramites = cmdTramites.ExecuteReader();

                if (rdTramites.HasRows)
                {
                    tramites = new List<TipoTramite>();

                    while (rdTramites.Read())
                    {
                        List<Documento> docsTramite = BuscarDocumentosTramite(rdTramites["Codigo"].ToString());

                        TipoTramite tramite = new TipoTramite(rdTramites["Codigo"].ToString(), rdTramites["Nombre"].ToString(), rdTramites["Descripcion"].ToString(),
                                                              Convert.ToDecimal(rdTramites["Precio"].ToString()), docsTramite);

                        tramites.Add(tramite);
                    }

                    rdTramites.Close();
                }

                return tramites;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal TipoTramite BuscarTramite(string idTramite, Empleado user)
        {
            Conexion conexion = new Conexion(user);
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                conexion.Conectar();
                TipoTramite tramite = null;
                SqlCommand cmdBuscarTramite = db.GenerarStoreProcedure("sp_BuscarTramite", conexion.GetSqlConnection());
                cmdBuscarTramite.Parameters.AddWithValue("@codigoTramite", idTramite);

                SqlDataReader rdTramite = cmdBuscarTramite.ExecuteReader();

                if (rdTramite.HasRows)
                {
                    rdTramite.Read();
                    List<Documento> docsTramite = BuscarDocumentosTramite(rdTramite["Codigo"].ToString());
                    tramite = new TipoTramite(rdTramite["Codigo"].ToString(), rdTramite["Nombre"].ToString(), rdTramite["Descripcion"].ToString(),
                                              Convert.ToDecimal(rdTramite["Precio"].ToString()), docsTramite);
                    rdTramite.Close();
                }

                return tramite;
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

        internal List<Documento> BuscarDocumentosTramite(string idTramite)
        {
            Conexion conexion = new Conexion();
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                conexion.Conectar();
                List<Documento> documentos = null;
                SqlCommand cmdTramitesDoc = db.GenerarStoreProcedure("sp_BuscarDocumentosTramite", conexion.GetSqlConnection());
                cmdTramitesDoc.Parameters.AddWithValue("@codigoTramite", idTramite);

                SqlDataReader rdTramitesDoc = cmdTramitesDoc.ExecuteReader();

                if (rdTramitesDoc.HasRows)
                {
                    documentos = new List<Documento>();

                    while (rdTramitesDoc.Read())
                    {
                        Documento doc = perDocumento.BuscarDocumento(Convert.ToInt32(rdTramitesDoc["IdDocumento"].ToString()));
                        documentos.Add(doc);
                    }

                    rdTramitesDoc.Close();
                }

                return documentos;
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

        internal void EliminarDocumentosTramite(string idTramite, SqlTransaction tran)
        {
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                SqlCommand cmdEliminarDocs = db.GenerarStoreProcedure("sp_EliminarDocumentosTramite", tran.Connection);
                cmdEliminarDocs.Parameters.AddWithValue("@codigo", idTramite);
                cmdEliminarDocs.Transaction = tran;
                db.GenerarValueReturn(cmdEliminarDocs);

                cmdEliminarDocs.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                        throw new Exception("No se encontro el tramite indicado.");
                    case -9:
                        throw new Exception("Error al eliminar documentos tramite.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
        internal void AsociarDocumentoTramite(Documento doc, string idTramite, SqlTransaction tran)
        {
            UtilidadesDB db = new UtilidadesDB();
            try
            {
                SqlCommand cmdAsociarDoc = db.GenerarStoreProcedure("sp_AgregarDocumentoTramite", tran.Connection);
                cmdAsociarDoc.Parameters.AddWithValue("@codigoTramite", idTramite);
                cmdAsociarDoc.Parameters.AddWithValue("@idDocumento", doc.Id);
                cmdAsociarDoc.Transaction = tran;
                db.GenerarValueReturn(cmdAsociarDoc);

                cmdAsociarDoc.ExecuteNonQuery();

                switch (db.GetValuerReturn())
                {
                    case -1:
                        throw new Exception("Ya existe el documento asociado al tramite.");
                    case -9:
                        throw new Exception("Error al asociar documento al tramite.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
