using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Controles
{
    public class Anio : DropDownList
    {
        private List<int> anio;      

        public Anio() : base() {
            int minYear = DateTime.Now.AddYears(-30).Year;
            int maxYear = DateTime.Now.AddYears(30).Year;
            anio = new List<int>();
            for (int i = minYear; i <= maxYear; i++)
                anio.Add(i);

            this.DataSource = anio;
            this.DataBind();
        }

        public int SelectedAnio
        {
            get {               
                return anio[this.SelectedIndex];
            }
            set
            {
                int minYear = DateTime.Now.AddYears(-30).Year;
                int maxYear = DateTime.Now.AddYears(30).Year;
                if (value >= minYear && value <= maxYear)
                    this.SelectedIndex = anio.IndexOf(value);                
                else
                    throw new Exception("El año seleccionado no es incorrecto.");
            }
        }

    }
}
