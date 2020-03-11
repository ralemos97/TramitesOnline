using System;
using System.Windows.Forms;
using static Utilidades;
using Administracion.WSTramitesOnline;

namespace Administracion
{
    public partial class ABMDocumentacion : Form
    {

        CustomStripMethods utilStrip;
        Empleado user = null;
        Documento doc = null;

        public ABMDocumentacion(Usuario userLogueado)
        {
            InitializeComponent();
            utilStrip = new CustomStripMethods(lblStatus);
            user = (Empleado)userLogueado;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                doc = ObtenerDoc();
                new WSTramitesOnline.ServicioTramitesOnlineClient().AgregarDocumento(doc, user);

                LimpiarFormulario();
                utilStrip.SetMessage("Documento creado correctamente.");
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                doc = ObtenerDoc();
                new WSTramitesOnline.ServicioTramitesOnlineClient().ModificarDocumento(doc, user);

                LimpiarFormulario();
                utilStrip.SetMessage("Documento modificado correctamente.");
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                doc = ObtenerDoc();
                new WSTramitesOnline.ServicioTramitesOnlineClient().EliminarDocumento(doc.Id, user);

                LimpiarFormulario();
                utilStrip.SetMessage("Documento eliminado correctamente.");
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    doc = new WSTramitesOnline.ServicioTramitesOnlineClient().BuscarDocumento(Convert.ToInt32(txtCodigo.Text), user);

                    HabilitarControles(doc != null);
                    txtNombre.Text = doc.Nombre;
                    txtLugarDeSolicitud.Text = doc.LugarSolicitud;
                }
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void HabilitarControles(bool existe)
        {
            try
            {
                btnAgregar.Enabled = !existe;
                btnEliminar.Enabled = existe;
                btnModificar.Enabled = existe;

                txtCodigo.Enabled = false;
                txtNombre.Enabled = true;
                txtLugarDeSolicitud.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LimpiarFormulario()
        {
            try
            {
                doc = null;
                btnAgregar.Enabled = false;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;

                txtCodigo.Enabled = true;
                txtCodigo.Text = string.Empty;

                txtNombre.Enabled = false;
                txtNombre.Text = string.Empty;

                txtLugarDeSolicitud.Enabled = false;
                txtLugarDeSolicitud.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Documento ObtenerDoc()
        {
            return new Documento()
            {
                Id = Convert.ToInt32(txtCodigo.Text),
                Nombre = txtNombre.Text,
                LugarSolicitud = txtLugarDeSolicitud.Text
            };
        }
    }
}
