using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace TP4_Grupo_13
{

    public partial class Ejercicio3 : System.Web.UI.Page
    {
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                SqlConnection cn = new SqlConnection("Data Source=GERSONGUTIERREZ\\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True;Encrypt=False");
                cn .Open();

                SqlCommand cmd = new SqlCommand("Select * from Temas",cn);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlTemas.DataSource = dr;
                ddlTemas.DataTextField = "Tema";
                ddlTemas.DataValueField = "IdTema";
                ddlTemas.DataBind();
                cn.Close();

            }
        }





       










    }








}