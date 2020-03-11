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
    public partial class ListadoSolicitudes : Form
    {
        Empleado user = null;
        CustomStripMethods utilStrip = null;
        List<Solicitud> solicitudes = new List<Solicitud>();        

        public ListadoSolicitudes(Usuario userLogin)
        {
            InitializeComponent();
            user = (Empleado)userLogin;
        }

        private void ListadoSolicitudes_Load(object sender, EventArgs e)
        {
            try
            {
                utilStrip = new CustomStripMethods(lblStatus);
                dgvListado.AutoGenerateColumns = true;
                CargarSolicitudes();
                CargarGrilla(Enumerados.FiltroSolicitudes.Default);
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void btnResTipoTramite_Click(object sender, EventArgs e)
        {
            try
            {
                DeshabilitarFiltrosFecha();
                CargarGrilla(Enumerados.FiltroSolicitudes.ResumenTipoTramite);
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void btnResDocumentacion_Click(object sender, EventArgs e)
        {
            try
            {
                DeshabilitarFiltrosFecha();
                CargarGrilla(Enumerados.FiltroSolicitudes.ResumenUsoDocumentacion);
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void btnResMes_Click(object sender, EventArgs e)
        {
            try
            {
                DeshabilitarFiltrosFecha();
                CargarGrilla(Enumerados.FiltroSolicitudes.ResumenMensual);
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void btnFiltroFecha_Click(object sender, EventArgs e)
        {
            try
            {
                dtpFiltroFecha.Enabled = true;
                btnBuscar.Enabled = true;
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void btnAnual_Click(object sender, EventArgs e)
        {
            try
            {
                DeshabilitarFiltrosFecha();
                CargarGrilla(Enumerados.FiltroSolicitudes.Default);
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarGrilla(Enumerados.FiltroSolicitudes.FiltroFecha);
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }
      
        private void CargarSolicitudes()
        {
            try
            {
                solicitudes = new WSTramitesOnline.ServicioTramitesOnlineClient().ListadoSolicitudes(user).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGrilla(Enumerados.FiltroSolicitudes tipoCarga)
        {
            switch (tipoCarga)
            {
                case Enumerados.FiltroSolicitudes.Default:
                    CargaPorDefecto();
                    break;
                case Enumerados.FiltroSolicitudes.ResumenTipoTramite:
                    CargarResumenTT();
                    break;
                case Enumerados.FiltroSolicitudes.ResumenMensual:
                    CargarResumenMeses();
                    break;
                case Enumerados.FiltroSolicitudes.ResumenUsoDocumentacion:
                    CargarResumenDocs();
                    break;
                case Enumerados.FiltroSolicitudes.FiltroFecha:
                    CargarFiltroFecha();
                    break;
                default:
                    break;
            }

            lblCantidad.Text = dgvListado.Rows.Count.ToString();
        }

        private void CargaPorDefecto()
        {
            try
            {
                var lstSolicitudes = (from s in solicitudes
                                      where s.FechaHora.Year == DateTime.Now.Year
                                      select new
                                      {
                                          Id = s.Codigo,
                                          Fecha = s.FechaHora.ToString("yyyy-MM-dd HH:mm"),
                                          Tipo = s.Tipo.Nombre,
                                          Nombre = s.Emisor.NombreCompleto,
                                          Documento = s.Emisor.Documento,
                                          Estado = s.Estado
                                      }).ToList();

                dgvListado.DataSource = lstSolicitudes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarResumenTT()
        {
            try
            {
                var result = (from s in solicitudes
                              group s by new { s.Tipo.Codigo, s.Tipo.Nombre }
                              into g
                              orderby g.Key.Nombre
                              select new
                              {
                                  Nombre = g.Key.Nombre,
                                  Cantidad = g.Count()
                              }).ToList();

                dgvListado.DataSource = result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarResumenDocs()
        {
            try
            {
                var result = (from s in solicitudes
                              from d in s.Tipo.DocumentosRequeridos
                              group d by new { d.Id, d.Nombre } into grpDocs
                              orderby grpDocs.Key.Nombre
                              select new
                              {
                                  Documento = grpDocs.Key.Nombre,
                                  Cantidad = grpDocs.Count()
                              }).ToList();

                dgvListado.DataSource = result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarResumenMeses()
        {
            try
            {
                var result = (from s in solicitudes
                              where s.FechaHora.Year == DateTime.Now.Year
                              group s by new { s.FechaHora.Month }
                              into g
                              orderby g.Key.Month
                              select new
                              {
                                  Mes = ((Enumerados.Meses)g.Key.Month).ToString(),
                                  Cantidad = g.Count()
                              }).ToList();

                dgvListado.DataSource = result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarFiltroFecha()
        {
            try
            {
                var result = (from s in solicitudes
                              where s.FechaHora.Date == dtpFiltroFecha.Value.Date
                              orderby s.FechaHora.Hour, s.FechaHora.Minute
                              select new
                              {
                                  Id = s.Codigo,
                                  Hora = s.FechaHora.ToString("HH:mm"),
                                  Tipo = s.Tipo.Nombre,
                                  Nombre = s.Emisor.NombreCompleto,
                                  Documento = s.Emisor.Documento,
                                  Estado = s.Estado
                              }).ToList();

                dgvListado.DataSource = result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeshabilitarFiltrosFecha()
        {
            dtpFiltroFecha.Enabled = false;
            btnBuscar.Enabled = false;
        }

    }
}
