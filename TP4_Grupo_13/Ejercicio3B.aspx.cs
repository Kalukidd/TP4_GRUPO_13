using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo_13
{

    public partial class Ejercicio3B : System.Web.UI.Page
    {
        private const string cadenaConexion = "Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True;Encrypt=False";
        protected void Page_Load(object sender, EventArgs e)

        {


            string id;
            id = Request.QueryString["IdTema"];
        string consulta = "SELECT * FROM Libros WHERE IdTema =";


            if (!string.IsNullOrEmpty(id))
            {
                consulta += id;
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    SqlDataAdapter cmdLibros = new SqlDataAdapter(consulta, connection);
                    DataSet ds = new DataSet();
                    cmdLibros.Fill(ds, "Libros");

                    gvLibros.DataSource = ds.Tables["Libros"];
                    gvLibros.DataBind();


                    connection.Close();
                }
            }
}

        

        protected void lbOtroTema_Click(object sender, EventArgs e)
        {
            Server.Transfer("Ejercicio3.aspx");
        }
    }
}