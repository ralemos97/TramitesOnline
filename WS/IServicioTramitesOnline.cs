using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;

namespace WS
{
    
    [ServiceContract]
    public interface IServicioTramitesOnline
    {
        #region Usuario
        [OperationContract]
        void Registro(Usuario usuario, Empleado empleadoLogin = null);

        [OperationContract]
        Usuario Login(string usuarioLogin, string contrasena);
        #endregion

        #region Documentos
        [OperationContract]
        void AgregarDocumento(Documento nuevoDoc, Empleado userLogin);

        [OperationContract]
        void ModificarDocumento(Documento doc, Empleado userLogin);

        [OperationContract]
        void EliminarDocumento(int id, Empleado userLogin);

        [OperationContract]
        Documento BuscarDocumento(int id, Usuario userLogin);

        [OperationContract]
        List<Documento> ObtenerDocumentos(Empleado userLogin);
        #endregion

        #region Empleados
        [OperationContract]
        void AgregarEmpleado(Empleado empleado, Empleado userLogin);

        [OperationContract]
        void ModificarEmpleado(Empleado empleado, Empleado userLogin);

        [OperationContract]
        void EliminarEmpleado(Empleado empleado, Empleado userLogin);

        [OperationContract]
        Empleado BuscarEmpleado(string documento);

        [OperationContract]
        void AgregarHoraExtra(Empleado empleado);
        #endregion

        #region Solicitud
        [OperationContract]
        void AgregarSolicitud(Solicitud solicitud, Solicitante userLogin);

        [OperationContract]
        void CambiarEstado(Solicitud solicitud, Empleado userLogin);

        [OperationContract]
        List<Solicitud> ListadoSolicitudes(Empleado userLogin);
        #endregion

        #region TipoTramite
        [OperationContract]
        void AgregarTramite(TipoTramite tramite, Empleado userLogin);

        [OperationContract]
        void ModificarTramite(TipoTramite tramite, Empleado user);

        [OperationContract]
        void EliminarTramite(TipoTramite tramite, Empleado user);

        [OperationContract]
        List<TipoTramite> ObtenerTramites();

        [OperationContract]
        string ObtenerTipoTramites();

        [OperationContract]
        TipoTramite BuscarTramite(string idTramite, Empleado user);
        #endregion
    }
}