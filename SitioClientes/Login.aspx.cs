using System;
using System.Web.UI.WebControls;
using WSTramitesOnline;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario userLogin = new WSTramitesOnline.ServicioTramitesOnlineClient().Login(txtUsuario.Text, txtContrasena.Text);

            if (!(userLogin is Solicitante))
                throw new Exception("No es posible acceder con el usuario indicado.");

            Session["userLogin"] = userLogin;

            Response.Redirect("~/Solicitud.aspx", false);

            HyperLink hlSolicitud = (HyperLink)Master.FindControl("hlSolicitud");
            hlSolicitud.Visible = true;

            HyperLink hlRegistro = (HyperLink)Master.FindControl("hlRegistro");
            hlRegistro.Visible = false;

            HyperLink hlLogin = (HyperLink)Master.FindControl("hlLogin");
            hlLogin.Visible = false;

            Label lblName = (Label)Master.FindControl("lblName");
            lblName.Text = userLogin.NombreCompleto;

            HyperLink hlMiPerfil = (HyperLink)Master.FindControl("hlMiPerfil");
            hlMiPerfil.Visible = true;
        }
        catch (Exception ex)
        {
            Utilidades.MsgError(lblMessage, ex.Message);
        }
    }
}