using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;




namespace TP4_Grupo_13
{

    public partial class Ejercicio2 : System.Web.UI.Page

    {
        private const string cadenaConexion = @"Data Source=DESKTOP-IN37CD7\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;TrustServerCertificate=True";
        //private const string cadenaConexion = @"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=False";
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

            lblMensaje.Text = "";

            if (Page.IsValid)
            {
                string idProducto = txtProducto.Text;
                string filtrodeProducto = ddlIdProducto.SelectedValue;
                string idCategoria = txtCategoria.Text;
                string filtrodeCategoria = ddlIdCategoria.SelectedValue;


                string consulta = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE 1=1";


                if (!string.IsNullOrEmpty(idProducto))
                {
                    if (int.TryParse(idProducto, out int idProd))
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
                }

                if (!string.IsNullOrEmpty(idCategoria))
                {

                    if (!consulta.Contains("WHERE"))
                    {
                        consulta += " WHERE 1=1";
                    }

                    if (int.TryParse(idCategoria, out int idCat))
                    {
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
                }

                using (SqlConnection cn = new SqlConnection(cadenaConexion))
                {
                    using (SqlDataAdapter cmd = new SqlDataAdapter(consulta, cn))
                    {
                        if (!string.IsNullOrEmpty(idProducto) && int.TryParse(idProducto, out int idProd))
                        {
                            cmd.SelectCommand.Parameters.AddWithValue("@IdProducto", idProd);
                        }

                        if (!string.IsNullOrEmpty(idCategoria) && int.TryParse(idCategoria, out int idCat))
                        {
                            cmd.SelectCommand.Parameters.AddWithValue("@IdCategoría", idCat);
                        }

                        DataSet ds = new DataSet();
                        cmd.Fill(ds, "Productos");

                        if (ds.Tables["Productos"].Rows.Count == 0)
                        {
                            gvProductos.DataSource = null;
                            gvProductos.DataBind();
                            lblMensaje.Text = "No se encontraron productos";
                        }
                        else
                        {
                            gvProductos.DataSource = ds;
                            gvProductos.DataBind();
                            lblMensaje.Text = "";
                        }

                    }
                }

                // Limpia los TextBox después de filtrar
                txtProducto.Text = "";
                txtCategoria.Text = "";

            }
            else
            {
                gvProductos.DataSource = null;
                gvProductos.DataBind();
                lblMensaje.Text = "";
            }

        }
        /*protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string idProducto = txtProducto.Text;
            string filtrodeProducto = ddlIdProducto.SelectedValue;
            string idCategoria = txtCategoria.Text;
            string filtrodeCategoria = ddlIdCategoria.SelectedValue;

            string regex = @"^[0-9,$]*$";
            bool esValidoPROD = Regex.IsMatch(idProducto, regex);
            bool esValidoCAT = Regex.IsMatch(idCategoria, regex);

            if (string.IsNullOrEmpty(idProducto) && string.IsNullOrEmpty(idCategoria)) {
                lblProdER.Text = "Debe ingresar al menos un número";
                lblCatER.Text = "Debe ingresar al menos un número";
            }

            if (!string.IsNullOrEmpty(idProducto) && !esValidoPROD) {
                lblProdER.Text = "* El número debe ser mayor o igual a 1";
            }

            if (!string.IsNullOrEmpty(idCategoria) && !esValidoCAT)
            {
                lblCatER.Text = "* El número debe ser mayor o igual a 1";
            }
            
            string consulta = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE 1=1";

           
            if (!string.IsNullOrEmpty(idProducto) && esValidoPROD)
            {
                lblProdER.Text = "";
                lblCatER.Text = "";
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

            if (!string.IsNullOrEmpty(idCategoria) && esValidoCAT)
            {
                lblProdER.Text = "";
                lblCatER.Text = "";
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

            if (esValidoCAT || esValidoPROD) {
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
            
            
        }*/

        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            txtCategoria.Text = "";
            txtProducto.Text = "";

            /*lblProdER.Text = "";
            lblCatER.Text = "";*/

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
