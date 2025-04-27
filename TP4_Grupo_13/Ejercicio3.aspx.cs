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
        //private const string cadenaConexion = "Data Source=GERSONGUTIERREZ\\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True;Encrypt=False"
        private const string cadenaConexion = "Data Source=DESKTOP-A61I0IB\\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True;Encrypt=False";
        string consultaSQL = "SELECT * FROM Temas";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(consultaSQL, connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    ddlTemas.DataSource = dr;
                    ddlTemas.DataTextField = "Tema";
                    ddlTemas.DataValueField = "IdTema";
                    ddlTemas.DataBind();
                    connection.Close();
                }
            }
        }

        protected void lbLibros_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ejercicio3B.aspx");
        }
    }








}