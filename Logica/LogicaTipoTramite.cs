using Entidades;
using Logica.interfaces;
using Persistencia;
using Persistencia.interfaces;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Logica
{
    internal class LogicaTipoTramite : ILogicaTipoTramite
    {

        private static LogicaTipoTramite _instancia = null;
        private LogicaTipoTramite() { }
        public static LogicaTipoTramite GetInstancia()
        {
            return _instancia == null ? new LogicaTipoTramite() : _instancia;
        }

        IPerTipoTramite PerTipoTramite = FabricaPersistencia.GetPersistenciaTipoTramite();

        public void AgregarTramite(TipoTramite tramite, Empleado empleado)
        {
            try
            {
                PerTipoTramite.AgregarTramite(tramite, empleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarTramite(TipoTramite tramite, Empleado empleado)
        {
            try
            {
                PerTipoTramite.ModificarTramite(tramite, empleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTramite(TipoTramite tramite, Empleado empleado)
        {
            try
            {
                FabricaPersistencia.GetPersistenciaTipoTramite().EliminarTramite(tramite, empleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public TipoTramite BuscarTramiteActivo(string codigo, Empleado empleado)
        {
            try
            {
                return PerTipoTramite.BuscarTramiteActivo(codigo, empleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoTramite> ObtenerTramites()
        {
            try
            {
                return PerTipoTramite.ObtenerTramites();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public XmlDocument ObtenerTipoTramites()
        {
            try
            {
                List<TipoTramite> tramites = PerTipoTramite.ObtenerTramites();

                XmlDocument docTiposTramites = new XmlDocument();
                docTiposTramites.LoadXml("<?xml version='1.0' encoding='utf-8' ?> <TiposDeTramites> </TiposDeTramites>");
                XmlNode nodoPrincipal = docTiposTramites.DocumentElement;

                foreach (TipoTramite tramite in tramites)
                {
                    XmlElement nuevoTramite = docTiposTramites.CreateElement("TipoTramite");

                    XmlElement nombre = docTiposTramites.CreateElement("Nombre");
                    nombre.InnerText = tramite.Nombre;
                    nuevoTramite.AppendChild(nombre);

                    XmlElement codigo = docTiposTramites.CreateElement("Codigo");
                    codigo.InnerText = tramite.Codigo;
                    nuevoTramite.AppendChild(codigo);

                    XmlElement descripcion = docTiposTramites.CreateElement("Descripcion");
                    descripcion.InnerText = tramite.Descripcion;
                    nuevoTramite.AppendChild(descripcion);

                    XmlElement precio = docTiposTramites.CreateElement("Precio");
                    precio.InnerText = tramite.Precio.ToString();
                    nuevoTramite.AppendChild(precio);

                    XmlElement docsRequeridos = docTiposTramites.CreateElement("DocumentosRequeridos");
                    foreach (Documento doc in tramite.DocumentosRequeridos)
                    {
                        XmlElement docReq = docTiposTramites.CreateElement("Documento");

                        XmlElement idDoc = docTiposTramites.CreateElement("Id");
                        idDoc.InnerText = doc.Id.ToString();
                        docReq.AppendChild(idDoc);

                        XmlElement nombreDoc = docTiposTramites.CreateElement("Nombre");
                        nombreDoc.InnerText = doc.Nombre;
                        docReq.AppendChild(nombreDoc);

                        XmlElement lugarDoc = docTiposTramites.CreateElement("LugarSolicitud");
                        lugarDoc.InnerText = doc.LugarSolicitud;
                        docReq.AppendChild(lugarDoc);

                        docsRequeridos.AppendChild(docReq);
                    }
                    nuevoTramite.AppendChild(docsRequeridos);

                    nodoPrincipal.AppendChild(nuevoTramite);
                }

                return docTiposTramites;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
