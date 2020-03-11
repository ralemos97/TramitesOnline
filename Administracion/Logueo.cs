using Administracion.WSTramitesOnline;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace Administracion
{
    public partial class Logueo : Form
    {
        public Logueo()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnLogueo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtUsuario.Text))
                {
                    MessageBox.Show("Debe ingresar usuario y contraseña.", "Error login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Usuario usuLogueado = new WSTramitesOnline.ServicioTramitesOnlineClient().Login(txtUsuario.Text, txtContrasenia.Text);

                if (usuLogueado is Solicitante)
                {
                    MessageBox.Show("El usuario ingresado no es valido.", "Error login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (usuLogueado == null || usuLogueado.Contrasena != txtContrasenia.Text)
                {
                    MessageBox.Show("Usuario o contraseña incorrrecto.", "Error login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                GenerateXmlLogin(usuLogueado);
                this.Hide();
                MenuPrincipal frmMenu = new MenuPrincipal(usuLogueado);
                frmMenu.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateXmlLogin(Usuario usuLogueado)
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string fileNameApplication = Path.GetFileName(assembly.Location);
                string path = Path.Combine(assembly.Location.Replace(fileNameApplication, string.Empty), "Info");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string pathFile = Path.Combine(path, Properties.Settings.Default.FileNameXML);

                if (File.Exists(pathFile))
                {
                    File.Delete(pathFile);
                }

                XmlDocument xmlUserData = new XmlDocument();

                xmlUserData.LoadXml("<?xml version='1.0' encoding='utf-8' ?> <UserInfo> </UserInfo>");
                XmlNode nodoPrincipal = xmlUserData.DocumentElement;

                XmlElement userLogueado = xmlUserData.CreateElement("UserDoc");
                userLogueado.InnerText = usuLogueado.Documento;
                nodoPrincipal.AppendChild(userLogueado);

                XmlElement horaInicio = xmlUserData.CreateElement("HoraEntrada");
                horaInicio.InnerText = ((Empleado)usuLogueado).HoraEntrada;
                nodoPrincipal.AppendChild(horaInicio);

                XmlElement horaSalida = xmlUserData.CreateElement("HoraSalida");
                horaSalida.InnerText = ((Empleado)usuLogueado).HoraSalida;
                nodoPrincipal.AppendChild(horaSalida);

                xmlUserData.Save(pathFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
