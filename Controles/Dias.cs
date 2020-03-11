using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Controles
{
    public class Dias : DropDownList
    {   
        private List<int> dias;

        public Dias() : base()
        {
            dias = new List<int>();
            for (int i = 1; i <= 31; i++)            
                dias.Add(i);

            this.DataSource = dias;
            this.DataBind();       
        }


        public int SelectedDia{
            get { return SelectedIndex + 1; }
            set
            {
                if (value >= 1 && value <= 31)
                    this.SelectedIndex = value - 1;
                else
                    throw new Exception("El dia ingresado no es valido.");
                
            }

        }

    }
}
