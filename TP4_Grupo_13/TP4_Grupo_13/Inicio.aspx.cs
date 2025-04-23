using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo_13
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_ejercicio1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio1.aspx");    
        }

        protected void btn_ejercicio2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio2.aspx");
        }

        protected void btn_ejercicio3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio3.aspx");
        }
    }
}