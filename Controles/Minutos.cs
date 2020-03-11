using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Controles
{
    public class Minutos : DropDownList
    {

        private List<int> minutos;

        public Minutos() : base()
        {
            int minHora = 00;
            int maxYear = 59;
            minutos = new List<int>();
            for (int i = minHora; i <= maxYear; i++)
                minutos.Add(i);

            this.DataSource = minutos;
            this.DataBind();
        }

        public int SelectedMinuto
        {
            get
            {
                return minutos[this.SelectedIndex];
            }
            set
            {
                int minYear = 00;
                int maxYear = 60;
                if (value >= minYear && value <= maxYear)
                    this.SelectedIndex = minutos.IndexOf(value);
                else
                    throw new Exception("El minuto seleccionado no es incorrecto.");
            }
        }

    }
}
