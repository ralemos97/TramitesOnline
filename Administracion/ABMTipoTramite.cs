using Administracion.WSTramitesOnline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Utilidades;

namespace Administracion
{
    public partial class ABMTipoTramite : Form
    {
        Empleado user = null;
        List<Documento> documentos = null;
        List<Documento> docsSeleccionados = new List<Documento>();
        CustomStripMethods utilStrip = null;
        TipoTramite tramite = null;

        public ABMTipoTramite(Usuario usuarioLogueado)
        {
            InitializeComponent();
            user = (Empleado)usuarioLogueado;
            utilStrip = new CustomStripMethods(lblStatus);
        }

        private void ABMTipoTramite_Load(object sender, EventArgs e)
        {
            try
            {
                documentos = new ServicioTramitesOnlineClient().ObtenerDocumentos(user).ToList();
                CargarDocs(documentos);
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarPropiedadesTramite();

                new ServicioTramitesOnlineClient().AgregarTramite(tramite, user);
                utilStrip.SetMessage("Se ha agregado el documento.");
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
                CargarPropiedadesTramite();

                new ServicioTramitesOnlineClient().ModificarTramite(tramite, user);
                utilStrip.SetMessage("Se ha modificado el documento.");
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
                CargarPropiedadesTramite();
                new ServicioTramitesOnlineClient().EliminarTramite(tramite, user);
                LimpiarFormulario();

                utilStrip.SetMessage("Se ha eliminado el documento.");
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
                if (Convert.ToChar(Keys.Enter) == e.KeyChar)
                {
                    if (txtCodigo.Text.Length != 9)
                        throw new Exception("El codigo debe estar compuesto por año y 5 letras");

                    tramite = new WSTramitesOnline.ServicioTramitesOnlineClient().BuscarTramite(txtCodigo.Text, user);

                    HabilitarControles(tramite != null);
                    CargarDatos(tramite);
                }
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void txtFindDoc_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFindDoc.Text))
                {
                    List<Documento> docsEncontrados = documentos.FindAll(d => d.Nombre.ToLower().Contains(txtFindDoc.Text.ToLower()));
                    CargarDocs(docsEncontrados);
                }
                else
                {
                    CargarDocs(documentos);
                }
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private void CargarDocs(List<Documento> docs)
        {
            try
            {
                var documentoForList = docs.Select(d => new ItemCheckList() { Id = d.Id, Name = d.Nombre });

                chkLstDocs.Items.Clear();

                foreach (var doc in documentoForList)
                {
                    bool active = false;

                    if (docsSeleccionados != null && docsSeleccionados.Any(d => d.Id == doc.Id))
                    {
                        active = true;
                    }

                    chkLstDocs.Items.Add(doc, active);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void HabilitarControles(bool existe)
        {
            try
            {
                btnAgregar.Enabled = !existe;
                btnModificar.Enabled = existe;
                btnEliminar.Enabled = existe;

                txtCodigo.Enabled = false;

                txtNombre.Enabled = true;
                txtDesc.Enabled = true;
                txtPrecio.Enabled = true;
                txtFindDoc.Enabled = true;
                chkLstDocs.Enabled = true;
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
                tramite = null;
                docsSeleccionados = new List<Documento>();

                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtDesc.Text = "";
                txtPrecio.Text = "";
                txtFindDoc.Text = "";
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnLimpiar.Enabled = true;
                txtDesc.Enabled = false;
                txtCodigo.Enabled = true;
                txtNombre.Enabled = false;
                txtPrecio.Enabled = false;
                chkLstDocs.Enabled = false;
                txtFindDoc.Enabled = false;
                CargarDocs(documentos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatos(TipoTramite tramiteCarga)
        {
            try
            {
                bool existe = tramite != null;

                if (existe)
                {
                    txtNombre.Text = tramiteCarga.Nombre;
                    txtDesc.Text = tramiteCarga.Descripcion;
                    txtPrecio.Text = tramiteCarga.Precio.ToString();
                    docsSeleccionados = tramiteCarga.DocumentosRequeridos.ToList();

                    CargarDocs(documentos);
                }
                else
                {
                    txtNombre.Text = string.Empty;
                    txtDesc.Text = string.Empty;
                    txtPrecio.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarPropiedadesTramite()
        {
            try
            {
                tramite = tramite ?? new TipoTramite();
                tramite.Codigo = txtCodigo.Text;
                tramite.Nombre = txtNombre.Text;
                tramite.Descripcion = txtDesc.Text;
                tramite.Precio = Convert.ToDecimal(txtPrecio.Text);
                tramite.DocumentosRequeridos = ObtenerDocumentosChecked().ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Documento> ObtenerDocumentosChecked()
        {
            try
            {
                List<Documento> listaD = new List<Documento>();
                for (int i = 0; i < chkLstDocs.CheckedItems.Count; i++)
                {
                    int indexEnDocs = documentos.FindIndex(d => d.Nombre == chkLstDocs.CheckedItems[i].ToString());

                    listaD.Add(documentos[indexEnDocs]);
                }
                return listaD;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chkLstDocs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                ItemCheckList itemSelected = (ItemCheckList)chkLstDocs.Items[e.Index];
                Documento docSelected = documentos.Find(d => d.Id == itemSelected.Id);

                if (e.NewValue == CheckState.Checked)
                {
                    if (!docsSeleccionados.Any(d => d.Id == docSelected.Id))
                    {
                        docsSeleccionados.Add(docSelected);
                    }
                }
                else
                {
                    docsSeleccionados.Remove(docSelected);
                }
            }
            catch (Exception ex)
            {
                utilStrip.ShowErrorStatus(ex);
            }
        }

        private class ItemCheckList
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return this.Name;
            }
        }

    }
}
