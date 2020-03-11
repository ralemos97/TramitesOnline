using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;

namespace WS
{    
    public class ServicioTramitesOnline : IServicioTramitesOnline
    {
        #region Usuario

        void IServicioTramitesOnline.Registro(Usuario usuario, Empleado empleadoLogin)
        {
            FabricaLogica.GetLogicaUsuario().Registro(usuario, empleadoLogin);
        }

        Usuario IServicioTramitesOnline.Login(string usuarioLogin, string contrasena)
        {
            return FabricaLogica.GetLogicaUsuario().Login(usuarioLogin, contrasena);
        }

        #endregion
        
        #region Documentos
        void IServicioTramitesOnline.AgregarDocumento(Documento nuevoDoc, Empleado userLogin)
        {
            FabricaLogica.GetLogicaDocumento().AgregarDocumento(nuevoDoc, userLogin);
        }

        void IServicioTramitesOnline.ModificarDocumento(Documento doc, Empleado userLogin)
        {
            FabricaLogica.GetLogicaDocumento().ModificarDocumento(doc, userLogin);
        }

        void IServicioTramitesOnline.EliminarDocumento(int id, Empleado userLogin)
        {
            FabricaLogica.GetLogicaDocumento().EliminarDocumento(id, userLogin);
        }

        Documento IServicioTramitesOnline.BuscarDocumento(int id, Usuario userLogin)
        {
            return FabricaLogica.GetLogicaDocumento().BuscarDocumento(id, userLogin);
        }

        List<Documento> IServicioTramitesOnline.ObtenerDocumentos(Empleado userLogin)
        {
            return FabricaLogica.GetLogicaDocumento().ObtenerDocumentos(userLogin);
        }
        #endregion

        #region Empleados
        void IServicioTramitesOnline.AgregarEmpleado(Empleado empleado, Empleado userLogin)
        {
            FabricaLogica.GetLogicaUsuario().Registro(empleado, userLogin);
        }

        void IServicioTramitesOnline.ModificarEmpleado(Empleado empleado, Empleado userLogin)
        {
            FabricaLogica.GetLogicaUsuario().ModificarEmpleado(empleado, userLogin);
        }

        void IServicioTramitesOnline.EliminarEmpleado(Empleado empleado, Empleado userLogin)
        {
            FabricaLogica.GetLogicaUsuario().EliminarEmpleado(empleado, userLogin);
        }

        void IServicioTramitesOnline.AgregarHoraExtra(Empleado empleado)
        {
            FabricaLogica.GetLogicaUsuario().AgregarHoraExtra(empleado);
        }

        Empleado IServicioTramitesOnline.BuscarEmpleado(string documento)
        {
            return FabricaLogica.GetLogicaUsuario().BuscarEmpleado(documento);
        }

        #endregion

        #region Solicitud
        void IServicioTramitesOnline.AgregarSolicitud(Solicitud solicitud, Solicitante userLogin)
        {
            FabricaLogica.GetLogicaSolicitud().AgregarSolicitud(solicitud, userLogin);
        }

        void IServicioTramitesOnline.CambiarEstado(Solicitud solicitud, Empleado userLogin)
        {
            FabricaLogica.GetLogicaSolicitud().CambiarEstado(solicitud, userLogin);
        }

        List<Solicitud> IServicioTramitesOnline.ListadoSolicitudes(Empleado userLogin)
        {
            return FabricaLogica.GetLogicaSolicitud().ListadoSolicitudes(userLogin);
        }
        #endregion

        #region TipoTramite
        void IServicioTramitesOnline.AgregarTramite(TipoTramite tramite, Empleado userLogin)
        {
            FabricaLogica.GetLogicaTipoTraimte().AgregarTramite(tramite, userLogin);
        }

        void IServicioTramitesOnline.ModificarTramite(TipoTramite tramite, Empleado user)
        {
            FabricaLogica.GetLogicaTipoTraimte().ModificarTramite(tramite, user);
        }

        void IServicioTramitesOnline.EliminarTramite(TipoTramite tramite, Empleado user)
        {
            FabricaLogica.GetLogicaTipoTraimte().EliminarTramite(tramite, user);
        }

        List<TipoTramite> IServicioTramitesOnline.ObtenerTramites()
        {
            return FabricaLogica.GetLogicaTipoTraimte().ObtenerTramites();
        }

        string IServicioTramitesOnline.ObtenerTipoTramites()
        {
            return FabricaLogica.GetLogicaTipoTraimte().ObtenerTipoTramites().OuterXml;
        }

        TipoTramite IServicioTramitesOnline.BuscarTramite(string idTramite, Empleado user)
        {
            return FabricaLogica.GetLogicaTipoTraimte().BuscarTramiteActivo(idTramite, user);
        }
        #endregion
    }
}
