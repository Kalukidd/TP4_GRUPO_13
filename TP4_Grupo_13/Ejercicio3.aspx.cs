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
        //private const string cadenaConexion = "Data Source=GERSONGUTIERREZ\\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True;Encrypt=False";
        // private const string cadenaConexion = "Data Source=DESKTOP-A61I0IB\\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True;Encrypt=False";
        //private const string cadenaConexion = "Data Source=KALU\\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True;Encrypt=False";
        //private const string cadenaConexion = "Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True;Encrypt=False";
        private const string cadenaConexion = @"Data Source=DESKTOP-IN37CD7\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True;TrustServerCertificate=True";

        string consultaSQL = "SELECT * FROM Temas";
        protected void Page_Load(object sender, EventArgs e)
        {
    

            if (!IsPostBack)
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    SqlDataAdapter da = new SqlDataAdapter(consultaSQL, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ddlTemas.DataSource = dt;
                    ddlTemas.DataTextField = "Tema";
                    ddlTemas.DataValueField = "IdTema";
                    ddlTemas.DataBind();

                    connection.Close();
                }
            }
        }




       

        protected void lbLibros_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Ejercicio3B.aspx?IdTema=" + ddlTemas.SelectedValue);
        }
    }








}