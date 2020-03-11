using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using static Utilidades;
using Administracion.WSTramitesOnline;

namespace Administracion
{
    public partial class MenuPrincipal : Form
    {
        Usuario userLogin;
        CustomStripMethods utilStrip;

        public MenuPrincipal(Usuario usuLogueado)
        {
            InitializeComponent();
            utilStrip = new CustomStripMethods(lblStatus);
            utilStrip.SetMessage("Bienvenido " + usuLogueado.NombreCompleto);
            userLogin = usuLogueado;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblHora.Text = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void menuEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                ABMEmpleado unForm = new ABMEmpleado(userLogin);
                unForm.ShowDialog();
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void menuDoc_Click(object sender, EventArgs e)
        {
            try
            {
                ABMDocumentacion unForm = new ABMDocumentacion(userLogin);
                unForm.ShowDialog();
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void menuTramite_Click(object sender, EventArgs e)
        {
            try
            {
                ABMTipoTramite unForm = new ABMTipoTramite(userLogin);
                unForm.ShowDialog();
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void menuCambioEstado_Click(object sender, EventArgs e)
        {
            try
            {
                CambioEstado unForm = new CambioEstado(userLogin);
                unForm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void listadoDeSolicitudesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ListadoSolicitudes unForm = new ListadoSolicitudes(userLogin);
                unForm.ShowDialog();
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Confirma salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    string fileNameApplication = Path.GetFileName(assembly.Location);
                    string path = Path.Combine(assembly.Location.Replace(fileNameApplication, string.Empty), "Info");                    

                    File.Delete(Path.Combine(path, Properties.Settings.Default.FileNameXML));
                }   
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }
    }
}
