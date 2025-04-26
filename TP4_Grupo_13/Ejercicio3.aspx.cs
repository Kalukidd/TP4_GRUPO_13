using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace TP4_Grupo_13
{
    public partial class Ejercicio3 : System.Web.UI.Page
    {
        private const string cadenaConexion = "Data Source=DESKTOP-MMELJR5\\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True;Encrypt=False";
        private string consultaSQL = "SELECT * FROM Libros";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();
                    SqlCommand cmdLibros = new SqlCommand(consultaSQL, connection);
                    SqlDataReader sqlDataReader = cmdLibros.ExecuteReader(); 
                }
            }
        }
    }
}