using System;
using WSTramitesOnline;


public partial class Registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegistro_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = string.Empty;

            if (txtContrasena.Text != txtContrasenaValid.Text)
                throw new Exception("Las contraseñas no coinciden");

            Solicitante nuevoSolicitante = new Solicitante();
            nuevoSolicitante.Documento = txtDocumento.Text;
            nuevoSolicitante.Contrasena = txtContrasena.Text;
            nuevoSolicitante.NombreCompleto = txtNombre.Text;
            nuevoSolicitante.Telefono = txtTelefono.Text;

            new WSTramitesOnline.ServicioTramitesOnlineClient().Registro(nuevoSolicitante, null);

            LimpiarFormulario();
            Utilidades.MsgSuccess(lblMsg, "Usuario registrado correctamente");        
        }
        catch (Exception ex)
        {
            Utilidades.MsgError(lblMsg, ex.Message);            
        }
    }

    private void LimpiarFormulario()
    {
        txtDocumento.Text = string.Empty;
        txtContrasena.Text = string.Empty;
        txtContrasenaValid.Text = string.Empty;
        txtNombre.Text = string.Empty;
        txtTelefono.Text = string.Empty;        
    }        
}