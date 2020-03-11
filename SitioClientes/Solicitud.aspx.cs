using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WSTramitesOnline;

public partial class Solicitud : System.Web.UI.Page
{
    Solicitante userLogin = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            userLogin = (Solicitante)Session["userLogin"];

            if (userLogin == null)
            {
                Desloguear();
            }            

            DefaultView(userLogin);
            if (!IsPostBack)
                CargarTramites();
        }
        catch (Exception ex)
        {
            Utilidades.MsgError(lblMessage, ex.Message);
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            Validaciones();

            WSTramitesOnline.Solicitud nuevaSolicitud = new WSTramitesOnline.Solicitud();

            nuevaSolicitud.Emisor = userLogin;
            nuevaSolicitud.Estado = "Alta";
            nuevaSolicitud.Tipo = ObtenerTipoTramiteSelect();
            nuevaSolicitud.FechaHora = new DateTime(calendarFechaTramite.Fecha.Year, calendarFechaTramite.Fecha.Month, calendarFechaTramite.Fecha.Day,
                                                    solHoraMinutos.Hora.Hour, solHoraMinutos.Hora.Minute, 0);

            new WSTramitesOnline.ServicioTramitesOnlineClient().AgregarSolicitud(nuevaSolicitud, userLogin);

            Utilidades.MsgSuccess(lblMessage, "Solicitud creada correctamente.");
        }
        catch (Exception ex)
        {
            Utilidades.MsgError(lblMessage, ex.Message);
        }
    }

    protected void ddlTipoTramite_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            TipoTramite tramiteSelect = ObtenerTipoTramiteSelect();

            lblDocRequeridos.Text = "Los documentos requeridos para el tramite son: " + string.Join(", ", tramiteSelect.DocumentosRequeridos.Select(d => d.Nombre));
        }
        catch (Exception ex)
        {
            Utilidades.MsgError(lblMessage, ex.Message);
        }
    }

    #region Metodos privados
    private void CargarTramites()
    {
        try
        {
            List<TipoTramite> tramites = (List<TipoTramite>)Session["lstTramites"];
            if (tramites == null)
            {
                tramites = new WSTramitesOnline.ServicioTramitesOnlineClient().ObtenerTramites().ToList();

                if (tramites.Count == 0)
                    throw new Exception("No se encontraron tipos de tramites.");

                Session["lstTramites"] = tramites;
            }

            ddlTipoTramite.DataSource = tramites;
            ddlTipoTramite.DataTextField = "Nombre";
            ddlTipoTramite.DataValueField = "Codigo";
            ddlTipoTramite.DataBind();

            lblDocRequeridos.Text = "Los documentos requeridos para el tramite son: " + string.Join(", ", tramites[0].DocumentosRequeridos.Select(d => d.Nombre));
        }
        catch (Exception ex)
        {
            Utilidades.MsgError(lblMessage, ex.Message);
        }
    }


    private void Desloguear()
    {
        HyperLink hlSolicitud = (HyperLink)Master.FindControl("hlSolicitud");
        hlSolicitud.Visible = false;

        HyperLink hlRegistro = (HyperLink)Master.FindControl("hlRegistro");
        hlRegistro.Visible = true;

        HyperLink hlLogin = (HyperLink)Master.FindControl("hlLogin");
        hlLogin.Visible = true;

        Session["userLogin"] = null;
        Response.Redirect("Login.aspx");
    }

    private void Validaciones()
    {
        try
        {
            if (calendarFechaTramite.Fecha <= DateTime.Now)
                throw new Exception("La fecha del tramite debe ser superior a hoy.");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DefaultView(Solicitante user)
    {
        HyperLink hlSolicitud = (HyperLink)Master.FindControl("hlSolicitud");
        hlSolicitud.Visible = true;

        HyperLink hlRegistro = (HyperLink)Master.FindControl("hlRegistro");
        hlRegistro.Visible = false;

        HyperLink hlLogin = (HyperLink)Master.FindControl("hlLogin");
        hlLogin.Visible = false;

        Label lblName = (Label)Master.FindControl("lblName");
        lblName.Text = user.NombreCompleto;

        HyperLink hlMiPerfil = (HyperLink)Master.FindControl("hlMiPerfil");
        hlMiPerfil.Visible = true;

        if (!IsPostBack)
        {
            calendarFechaTramite.Fecha = DateTime.Now.AddDays(1);
        }
    }

    private void LimpiarFormulario()
    {
        calendarFechaTramite.Fecha = DateTime.Now.AddDays(1);
        solHoraMinutos.Hora = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0);
        CargarTramites();
    }

    private TipoTramite ObtenerTipoTramiteSelect()
    {
        try
        {
            if (ddlTipoTramite.SelectedIndex == -1)
                throw new Exception("No se a seleccionado ningun tipo de tramite.");

            return ((List<TipoTramite>)Session["lstTramites"])[ddlTipoTramite.SelectedIndex];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
}