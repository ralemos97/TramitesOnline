using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Controles
{
    public class Meses : DropDownList
    {
        private List<string> meses;

        public Meses() : base()
        {
            meses = new List<string>();
            meses.Add("Enero");
            meses.Add("Febrero");
            meses.Add("Marzo");
            meses.Add("Abril");
            meses.Add("Mayo");
            meses.Add("Junio");
            meses.Add("Julio");
            meses.Add("Agosto");
            meses.Add("Setiembre");
            meses.Add("Octubre");
            meses.Add("Noviembre");
            meses.Add("Diciembre");

            this.DataSource = meses;
            this.DataBind();
        }

        public string SelectedMes
        {
            get { return meses[this.SelectedIndex]; }
            set
            {
                //var mes = meses.Find(a => a.ToLower() == value.ToLower());
                //if (mes == null)
                //    throw new Exception("El texto asignado no corresponde con ningun mes.");

                //this.SelectedIndex = meses.FindIndex(a => a == mes);


                switch (value.ToLower())
                {
                    case "enero":
                        this.SelectedIndex = 0;
                        break;
                    case "febrero":
                        this.SelectedIndex = 1;
                        break;
                    case "marzo":
                        this.SelectedIndex = 2;
                        break;
                    case "abril":
                        this.SelectedIndex = 3;
                        break;
                    case "mayo":
                        this.SelectedIndex = 4;
                        break;
                    case "junio":
                        this.SelectedIndex = 5;
                        break;
                    case "julio":
                        this.SelectedIndex = 6;
                        break;
                    case "agosto":
                        this.SelectedIndex = 7;
                        break;
                    case "setiembre":
                        this.SelectedIndex = 8;
                        break;
                    case "octubre":
                        this.SelectedIndex = 9;
                        break;
                    case "noviebre":
                        this.SelectedIndex = 10;
                        break;
                    case "diciembre":
                        this.SelectedIndex = 11;
                        break;
                    default:
                        throw new Exception("El texto asignado no corresponde con ningun mes.");
                }
            }
        }
        
        public int SeleccionMes
        {
            get { return this.SelectedIndex + 1; }
            set
            {
                if (value >= 1 && value <= 12)
                    this.SelectedIndex = value - 1;
                else
                    throw new InvalidCastException("El número asignado no corresponde a ningun mes.");
            }
        }
    }
}
