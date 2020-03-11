using Administracion.WSTramitesOnline;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Utilidades;

namespace Administracion
{
    public partial class ABMEmpleado : Form
    {
        Empleado empleadoLogueado;
        private static bool showPassword = false;
        CustomStripMethods utilStrip = null;
        Empleado empleado = null;

        public ABMEmpleado(Usuario usuLogueado)
        {
            InitializeComponent();
            utilStrip = new CustomStripMethods(lblStatus);
            empleadoLogueado = (Empleado)usuLogueado;
        }

        private void txtCI_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    if (!Utilidades.IsNumeric(txtCI.Text))
                    {                        
                        throw new Exception("La C.I debe ser un número.");                        
                    }

                    e.Handled = true;
                    empleado = new ServicioTramitesOnlineClient().BuscarEmpleado(txtCI.Text.Trim());

                    if (empleado != null)
                    {
                        btnAgregar.Enabled = false;
                        btnModificar.Enabled = true;
                        btnEliminar.Enabled = true;
                        txtCI.Enabled = false;

                        if (empleadoLogueado.Documento == empleado.Documento)
                        {
                            txtContrasenia.Enabled = true;
                            pbVerContrasena.Visible = true;
                        }
                        else
                        {
                            txtContrasenia.Enabled = false;
                            pbVerContrasena.Visible = false;
                        }

                        txtFinTareas.Enabled = true;
                        txtIniTareas.Enabled = true;
                        txtNombre.Enabled = true;

                        txtContrasenia.Text = empleado.Contrasena.ToString();
                        txtFinTareas.Text = empleado.HoraSalida.ToString();
                        txtIniTareas.Text = empleado.HoraEntrada.ToString();
                        txtNombre.Text = empleado.NombreCompleto.ToString();
                    }
                    else
                    {
                        lblStatus.Text = "Usuario no encontrado";

                        btnAgregar.Enabled = true;
                        btnModificar.Enabled = false;
                        btnEliminar.Enabled = false;
                        txtCI.Enabled = false;
                        txtContrasenia.Enabled = true;
                        txtFinTareas.Enabled = true;
                        txtIniTareas.Enabled = true;
                        txtNombre.Enabled = true;
                        pbVerContrasena.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void pbVerContrasena_Click(object sender, EventArgs e)
        {
            if (!showPassword)
            {
                pbVerContrasena.Image = Properties.Resources.disable_show_Pass;
                txtContrasenia.UseSystemPasswordChar = false;
                showPassword = true;
            }
            else
            {
                pbVerContrasena.Image = Properties.Resources.enable_show_Pass;
                txtContrasenia.UseSystemPasswordChar = true;
                showPassword = false;
            }
        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtCI.Text = string.Empty;
            txtCI.Enabled = true;

            txtNombre.Text = string.Empty;
            txtNombre.Enabled = false;

            txtContrasenia.Text = string.Empty;
            txtContrasenia.Enabled = false;

            txtIniTareas.Text = "00:00";
            txtIniTareas.Enabled = false;

            txtFinTareas.Text = "00:00";
            txtFinTareas.Enabled = false;

            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            empleado = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarDatosEmpleado();

                new ServicioTramitesOnlineClient().Registro(empleado, empleadoLogueado);

                utilStrip.SetMessage("Usuario creado correctamente");
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void CargarDatosEmpleado()
        {
            empleado = empleado ?? new Empleado();
            empleado.Documento = txtCI.Text;
            empleado.Contrasena = txtContrasenia.Text;
            empleado.NombreCompleto = txtNombre.Text;
            empleado.HoraEntrada = txtIniTareas.Text.Trim();
            empleado.HoraSalida = txtFinTareas.Text.Trim();
            empleado.HorasExtrasGeneradas = new List<HoraExtra>().ToArray();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarDatosEmpleado();

                new ServicioTramitesOnlineClient().ModificarEmpleado(empleado, empleadoLogueado);

                utilStrip.SetMessage("Usuario modificado correctamente");
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
                CargarDatosEmpleado();

                new ServicioTramitesOnlineClient().EliminarEmpleado(empleado, empleadoLogueado);

                if (empleado.Documento == empleadoLogueado.Documento)
                {
                    Application.Exit();
                }
                else
                {
                    LimpiarFormulario();
                    utilStrip.SetMessage("Usuario eliminado correctamente");
                }
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}
