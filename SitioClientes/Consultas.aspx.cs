using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WSTramitesOnline;

public partial class Consultas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Solicitante userLogin = (Solicitante)Session["userLogin"];

            if (!IsPostBack)
            {
                string xmlTiposTramites = new WSTramitesOnline.ServicioTramitesOnlineClient().ObtenerTipoTramites();

                XElement docTiposTramites = XElement.Parse(xmlTiposTramites);
                Session["docTipo"] = docTiposTramites;

                LoadTipoTramites();
            }

            if (userLogin != null)
            {
                DefaultView(userLogin);
            }
        }
        catch (Exception ex)
        {
            Utilidades.MsgError(lblMessage, ex.Message);
        }
    }

    protected void rptTiposTramite_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "VerTipoTramite")
            {
                XElement docTiposTramites = (XElement)Session["docTipo"];

                var tramite = (from tipo in docTiposTramites.Elements("TipoTramite")
                               where tipo.Element("Codigo").Value.ToString() == e.CommandArgument.ToString()
                               select tipo).FirstOrDefault();

                xmlTipoDoc.DocumentContent = tramite.ToString();
            }
        }
        catch (Exception ex)
        {
            Utilidades.MsgError(lblMessage, ex.Message);
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Utilidades.MsgSuccess(lblMessage, "");

            if (!string.IsNullOrEmpty(txtPrecioDesde.Text) && !Utilidades.IsNumeric(txtPrecioDesde.Text))
                throw new Exception("El precio desde debe ser un número");

            if (!string.IsNullOrEmpty(txtPrecioHasta.Text) && !Utilidades.IsNumeric(txtPrecioHasta.Text))
                throw new Exception("El precio hasta debe ser un número");

            decimal precionMin = string.IsNullOrEmpty(txtPrecioDesde.Text) ? decimal.MinValue : Convert.ToDecimal(txtPrecioDesde.Text);
            decimal precionMax = string.IsNullOrEmpty(txtPrecioHasta.Text) ? decimal.MaxValue : Convert.ToDecimal(txtPrecioHasta.Text);

            XElement docTiposTramites = (XElement)Session["docTipo"];
                        
            var tramites = (from t in docTiposTramites.Elements("TipoTramite")
                            where Convert.ToDecimal(t.Element("Precio").Value.ToString()) >= precionMin &&
                                  Convert.ToDecimal(t.Element("Precio").Value.ToString()) <= precionMax                                   
                            select t).ToList();

            if(Utilidades.IsNumeric(ddlAnio.SelectedValue) && ddlAnio.SelectedValue != "Todos")
            {
                tramites = (from t in tramites
                            where t.Element("Codigo").Value.Contains(ddlAnio.SelectedValue)
                            select t).ToList();
            }

            CargarRepeater(tramites);
        }
        catch (Exception ex)
        {
            Utilidades.MsgError(lblMessage, ex.Message);
        }
    }

    private void LoadTipoTramites()
    {
        try
        {
            XElement docTiposTramites = (XElement)Session["docTipo"];

            if (docTiposTramites == null)
                throw new Exception("No se encontraron tipos de tramites.");
            
            CargarAnios();

            var tramitesInit = (from tipo in docTiposTramites.Elements("TipoTramite") select tipo).ToList();
            CargarRepeater(tramitesInit);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarRepeater(List<XElement> tipoTramites)
    {
        try
        {
            var dataRpt = tipoTramites.Select(t => new
            {
                Nombre = t.Element("Nombre").Value.ToString(),
                Codigo = t.Element("Codigo").Value.ToString()
            }).ToList();

            rptTiposTramite.DataSource = dataRpt;
            rptTiposTramite.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarAnios()
    {
        try
        {
            XElement docTiposTramites = (XElement)Session["docTipo"];

            List<int> aniosDocument = docTiposTramites.Elements("TipoTramite")
                                .Select(s => s.Element("Codigo").Value.ToString().Substring(0, 4))
                                .GroupBy(a => a).Select(g => Convert.ToInt32(g.Key)).ToList();

            int minAnio = aniosDocument.Min(), maxAnio = aniosDocument.Max();

            List<string> aniosDdl = new List<string>();

            aniosDdl.Add("Todos");

            for (int i = maxAnio; i >= minAnio; i--)
            {
                aniosDdl.Add(i.ToString());
            }

            ddlAnio.DataSource = aniosDdl;
            ddlAnio.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DefaultView(Solicitante user)
    {
        HyperLink hlSolicitud = (HyperLink)Master.FindControl("hlSolicitud");
        hlSolicitud.Visible = true;

        HyperLink hlRegistro = (HyperLink)Master.FindControl("hlRegistro");
        hlRegistro.Visible = false;

        HyperLink hlLogin = (HyperLink)Master.FindControl("hlLogin");
        hlLogin.Visible = false;

        Label lblName = (Label)Master.FindControl("lblName");
        lblName.Text = user.NombreCompleto;

        HyperLink hlMiPerfil = (HyperLink)Master.FindControl("hlMiPerfil");
        hlMiPerfil.Visible = true;
    }

}