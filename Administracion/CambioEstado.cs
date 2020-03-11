using Administracion.Enums;
using Administracion.WSTramitesOnline;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static Utilidades;

namespace Administracion
{
    public partial class CambioEstado : Form
    {
        Empleado user = null;
        CustomStripMethods utilStrip = null;
        List<Solicitud> solicitudes = new List<Solicitud>();

        public CambioEstado(Usuario userLogin)
        {
            InitializeComponent();
            user = (Empleado)userLogin;
        }

        private void CambioEstado_Load(object sender, EventArgs e)
        {
            utilStrip = new CustomStripMethods(lblStatus);

            ObtenerSolicitudes();
            CargarSolicitudes();
        }

        private void txtFindText_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFindText.Text))
                {
                    CargarSolicitudes();
                }
                else
                {
                    string textFind = txtFindText.Text.Trim();
                    List<Solicitud> filterSoli = (from s in solicitudes
                                                  where s.Codigo.ToString() == textFind ||
                                                        s.Tipo.Nombre.Contains(textFind) ||
                                                        s.Emisor.NombreCompleto.Contains(textFind) ||
                                                        s.Emisor.Documento == textFind
                                                  select s).ToList();

                    CargarSolicitudes(filterSoli);
                }
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void ObtenerSolicitudes()
        {
            solicitudes = new ServicioTramitesOnlineClient().ListadoSolicitudes(user).ToList();

            solicitudes = (from s in solicitudes
                           where s.Estado == Enumerados.Estados.Alta.ToString()
                           select s).ToList();
        }

        private void CargarSolicitudes(List<Solicitud> solicitudesLoad = null)
        {
            dgvCambioEstado.AutoGenerateColumns = false;

            if (solicitudesLoad == null)
            {
                solicitudesLoad = solicitudes;
            }

            var lstSolicitudes = (from solicitud in solicitudesLoad
                                  select new
                                  {
                                      Id = solicitud.Codigo,
                                      Tipo = solicitud.Tipo.Nombre,
                                      Nombre = solicitud.Emisor.NombreCompleto,
                                      Documento = solicitud.Emisor.Documento
                                  }).ToList();

            dgvCambioEstado.DataSource = lstSolicitudes;
        }

        private void dgvCambioEstado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4 && e.ColumnIndex != 5)
            {
                return;
            }


            long idSolicitud = Convert.ToInt64(dgvCambioEstado.Rows[e.RowIndex].Cells[0].Value.ToString());
            Solicitud solicitud = solicitudes.Find(s => s.Codigo == idSolicitud);

            if (e.ColumnIndex == 4)
            {
                solicitud.Estado = Enumerados.Estados.Anulada.ToString();
            }
            else if (e.ColumnIndex == 5)
            {
                solicitud.Estado = Enumerados.Estados.Ejecutada.ToString();
            }

            new WSTramitesOnline.ServicioTramitesOnlineClient().CambiarEstado(solicitud, user);

            if (MessageBox.Show("El estado de la solicitud " + solicitud.Codigo + " se cambio correctamente.", "Cambio estado.", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                ObtenerSolicitudes();
                CargarSolicitudes();
            }
        }
    }
}
