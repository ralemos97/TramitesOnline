using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controles
{
    public class CustomCalendar : WebControl, INamingContainer
    {
        private Dias ctrDias;
        private Meses ctrMeses;
        private Anio ctrAnios;
        private Panel panel;


        public DateTime Fecha
        {
            get
            {
                try
                {
                    return new DateTime(ctrAnios.SelectedAnio, ctrMeses.SeleccionMes, ctrDias.SelectedDia);
                }
                catch (Exception)
                {
                    throw new Exception("Fecha invalida");
                }
            }
            set
            {
                try
                {
                    this.EnsureChildControls();
                    ctrDias.SelectedDia = value.Day;
                    ctrMeses.SeleccionMes = value.Month;
                    ctrAnios.SelectedAnio = value.Year;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            panel = new Panel();

            ctrDias = new Dias();
            panel.Controls.Add(ctrDias);


            ctrMeses = new Meses();
            panel.Controls.Add(ctrMeses);

            ctrAnios = new Anio();
            panel.Controls.Add(ctrAnios);

            Controls.Add(panel);
        }

    }
}