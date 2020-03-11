using System;
using WSTramitesOnline;

public partial class MPSolicitantes : System.Web.UI.MasterPage
{
    Solicitante userLogin = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        try
        {
            Session["userLogin"] = null;
            Response.Redirect("~/Login.aspx", false);
        }
        catch (Exception ex)
        {
            Utilidades.MsgError(lblMsg, ex.Message);
        }
    }
}
