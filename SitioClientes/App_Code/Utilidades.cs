using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public class Utilidades
{
    public Utilidades(){}

    public static void MsgError(Label lbl, string msg)
    {
        lbl.ForeColor = System.Drawing.Color.DarkRed;
        lbl.Text = msg;
        lbl.Visible = true;
    }

    public static void MsgSuccess(Label lbl, string text)
    {
        lbl.ForeColor = System.Drawing.Color.Green;
        lbl.Text = text;
        lbl.Visible = true;
    }

    public static bool IsNumeric(string num)
    {
        int result = 0;
        bool isValid = int.TryParse(num, out result);

        return isValid;
    }
}