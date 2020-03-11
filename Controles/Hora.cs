using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Controles
{
    public class Hora : DropDownList
    {
        private List<int> horas;

        public Hora() : base()
        {
            int minHora = 09;
            int maxHora = 18;
            horas = new List<int>();
            for (int i = minHora; i <= maxHora; i++)
                horas.Add(i);

            this.DataSource = horas;
            this.DataBind();
        }

        public int SelectedHora
        {
            get
            {
                return horas[this.SelectedIndex];
            }
            set
            {
                int minYear = 00;
                int maxYear = 23;
                if (value >= minYear && value <= maxYear)
                    this.SelectedIndex = horas.IndexOf(value);
                else
                    throw new Exception("La hora seleccionada es incorrecta.");
            }
        }
    }
}
