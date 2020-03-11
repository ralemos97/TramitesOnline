using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public class Utilidades
{
    public Utilidades(){}

    internal static bool IsNumeric(string num)
    {
        int result = 0;
        bool isValid = int.TryParse(num, out result);

        return isValid;
    }

    internal class CustomStripMethods
    {
        private static ToolStripStatusLabel strip;

        public static ToolStripStatusLabel Strip
        {
            get
            {
                return strip;
            }

            set
            {
                strip = value;
            }
        }

        public CustomStripMethods(ToolStripStatusLabel _strip)
        {
            Strip = _strip;
        }
        /// <summary>
        /// Es utilizado para mostrar errores de una excepcion en strip.
        /// </summary>
        /// <param name="ex"></param>
        public void ShowErrorStatus(Exception ex)
        {

            Strip.Text = ex.Source == "System.Web.Services" ? ((SoapException)ex).Detail.InnerText : ex.Message;
            Strip.ForeColor = System.Drawing.Color.Red;
        }

        public void ShowErrorStatus(SoapException ex)
        {
            Strip.Text = ex.Detail.InnerText;
            Strip.ForeColor = System.Drawing.Color.Red;
        }

        /// <summary>
        /// Permite dejar el strip con el texto por defecto que es LISTO
        /// </summary>
        public void ClearStripText()
        {
            Strip.Text = "Listo";
            Strip.ForeColor = System.Drawing.Color.Black;
        }

        /// <summary>
        /// Permite setear mensaje y color
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public void SetMessage(string text, System.Drawing.Color color)
        {
            Strip.Text = text;
            Strip.ForeColor = color;
        }

        /// <summary>
        /// Permite setear mensaje
        /// </summary>
        /// <param name="text"></param>
        public void SetMessage(string text)
        {
            Strip.Text = text;
            Strip.ForeColor = System.Drawing.Color.Black;
        }
    }
}