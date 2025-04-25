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

    public partial class Ejercicio2 : System.Web.UI.Page

    {
        //private const string cadenaConexion = @"Data Source=DESKTOP-IN37CD7\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;TrustServerCertificate=True";
        // private const string cadenaConexion = @"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=False";
        private const string cadenaConexion = "Data Source=GERSONGUTIERREZ\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=False";
        private string consultaSQL = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    SqlCommand cmdProductos = new SqlCommand(consultaSQL, connection);
                    SqlDataReader sqlDataReader = cmdProductos.ExecuteReader();

                    gvProductos.DataSource = sqlDataReader;
                    gvProductos.DataBind();
                }
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(txtProducto.Text) && string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                
                string operador = "="; 
                switch (ddlIdProducto.SelectedValue)
                {
                    case "1":
                        operador = ">";
                        break;
                    case "2":
                        operador = "<";
                        break;
                }

                string consultaFiltrada = $"SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE IdProducto {operador} @IdProducto";

                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(consultaFiltrada, connection);
                    cmd.Parameters.AddWithValue("@IdProducto", txtProducto.Text);

                    SqlDataReader reader = cmd.ExecuteReader();
                    gvProductos.DataSource = reader;
                    gvProductos.DataBind();
                }
            }
        }
    }
}
