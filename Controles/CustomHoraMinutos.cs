using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controles
{
    public class CustomHoraMinutos : WebControl, INamingContainer
    {
        private Hora ctrHora;
        private Minutos ctrMinuto;
        private Panel panel;

        public DateTime Hora
        {
            get
            {
                try
                {
                    return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, ctrHora.SelectedHora, ctrMinuto.SelectedMinuto, 0);
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
                    ctrMinuto.SelectedMinuto = value.Minute;
                    ctrHora.SelectedHora = value.Hour;
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

            ctrHora = new Hora();
            panel.Controls.Add(ctrHora);


            ctrMinuto = new Minutos();
            panel.Controls.Add(ctrMinuto);

            Controls.Add(panel);
        }
    }
}
