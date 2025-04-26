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
        private const string cadenaConexion = @"Data Source=DESKTOP-IN37CD7\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;TrustServerCertificate=True";
        // private const string cadenaConexion = @"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=False";
        // private const string cadenaConexion = "Data Source=GERSONGUTIERREZ\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=False";
        // private const string cadenaConexion = "Data Source=DESKTOP-A61I0IB\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=False";
        //private const string cadenaConexion = "Data Source=KALU\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=False";
        //private const string cadenaConexion = "Data Source=DESKTOP-MMELJR5\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=False";
        

        private string consultaSQL = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos";

        protected void Page_Load(object sender, EventArgs e)
        {

            ScriptResourceDefinition jQueryDef = new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-3.7.1.min.js",
                DebugPath = "~/Scripts/jquery-3.7.1.js",
                LoadSuccessExpression = "window.jQuery"
            };

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQueryDef);


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

            string idProducto = txtProducto.Text;
            string filtrodeProducto = ddlIdProducto.SelectedValue;
            string idCategoria = txtCategoria.Text;
            string filtrodeCategoria = ddlIdCategoria.SelectedValue;

           
            string consulta = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE 1=1";

           
            if (!string.IsNullOrEmpty(idProducto))
            {
                switch (filtrodeProducto)
                {
                    case "1":  // Igual a
                        consulta += " AND IdProducto = @IdProducto";
                        break;
                    case "2":  // Mayor a
                        consulta += " AND IdProducto > @IdProducto";
                        break;
                    case "3":  // Menor a
                        consulta += " AND IdProducto < @IdProducto";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(idCategoria))
            {
                if (!consulta.Contains("WHERE"))
                {
                    consulta += " WHERE 1=1";
                }

                switch (filtrodeCategoria)
                {
                    case "1":  // Igual a
                        consulta += " AND IdCategoría = @IdCategoría";
                        break;
                    case "2":  // Mayor a
                        consulta += " AND IdCategoría > @IdCategoría";
                        break;
                    case "3":  // Menor a
                        consulta += " AND IdCategoría < @IdCategoría";
                        break;
                }
            }

            /* if (!string.IsNullOrWhiteSpace(txtProducto.Text) && string.IsNullOrWhiteSpace(txtCategoria.Text))
             {
                 string consultaFiltrada  = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM *" ;
                 string operadorProducto = "="; 
                 string operadorCategoria = "=";
                 switch (ddlIdProducto.SelectedValue)
                     {
                         case "1":
                             operadorProducto = ">";
                             break;
                         case "2":
                             operadorProducto = "<";
                             break;
                     }
                     switch (ddlIdCategoria.SelectedValue)
                     {
                         case "1":
                             operadorCategoria = ">";
                             break;
                         case "2":
                             operadorCategoria = "<";
                             break;
                     }
                 int caso = 0;
                 if (txtProducto.Text != "") caso += 1;
                 if (txtCategoria.Text != "") caso += 2;
                 switch (caso)
                 {
                     case 1:
                         consultaFiltrada = $"SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE IdProducto {operadorProducto} @IdProducto";
                         break;
                     case 2:
                         consultaFiltrada = $"SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE IdCategoria {operadorCategoria} @IdCategoria";
                         break;
                     case 3:
                         consultaFiltrada = $"SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE IdProducto {operadorProducto} @IdProducto AND IdCategoria {operadorCategoria} @IdCategoria";
                         break;
                 }*/

           /* using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(consulta, connection);
                cmd.Parameters.AddWithValue("@IdProducto", txtProducto.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                gvProductos.DataSource = reader;
                gvProductos.DataBind();
            }*/

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                using (SqlDataAdapter cmd = new SqlDataAdapter(consulta, cn))
                {
                    if (!string.IsNullOrEmpty(idProducto))
                    {
                        cmd.SelectCommand.Parameters.AddWithValue("@IdProducto", idProducto);
                    }
                    if (!string.IsNullOrEmpty(idCategoria))
                    {
                        cmd.SelectCommand.Parameters.AddWithValue("@IdCategoría", idCategoria);
                    }

                    DataSet ds = new DataSet();
                    cmd.Fill(ds, "Productos");
                    gvProductos.DataSource = ds;
                    gvProductos.DataBind();
                }
            }
            // Limpia los TextBox después de filtrar
            txtProducto.Text = "";
            txtCategoria.Text = "";
        }

        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            txtCategoria.Text = "";
            txtProducto.Text = "";
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                SqlCommand cmdProductos = new SqlCommand(consultaSQL, connection);
                SqlDataReader sqlDataReader = cmdProductos.ExecuteReader();

                gvProductos.DataSource = sqlDataReader;
                gvProductos.DataBind();

                connection.Close();
            }
        }
    }
}
