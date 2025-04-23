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
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        private const string cadenaConexion = @"Data Source=DESKTOP-IN37CD7\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True;TrustServerCertificate=True";
        private string consultaSQLProvincias = "SELECT IdProvincia, NombreProvincia FROM Provincias";
        private string consultasSQLLocalidades = "SELECT IdLocalidad, NombreLocalidad FROM Localidades WHERE IdProvincia = @idProvincia";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvinciasFinal();

                ddlLocalidadFinal.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
            }
        }

        private void CargarProvinciasFinal()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(consultaSQLProvincias, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            ddlProvinciaFinal.DataSource = sqlDataReader;
            ddlProvinciaFinal.DataTextField = "NombreProvincia";
            ddlProvinciaFinal.DataValueField = "IdProvincia";
            ddlProvinciaFinal.DataBind();

            ddlProvinciaFinal.Items.Insert(0, new ListItem("-- Seleccione una provincia --", "0"));
            connection.Close();
        }

        protected void ddlProvinciaFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = int.Parse(ddlProvinciaFinal.SelectedValue);

            if (idProvincia > 0)
            {
                CargarLocalidadesFinal(idProvincia);
            }
            else
            {
                ddlLocalidadFinal.Items.Clear();
                ddlLocalidadFinal.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
            }
        }

        private void CargarLocalidadesFinal(int idProvincia)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(consultasSQLLocalidades, connection);
            sqlCommand.Parameters.AddWithValue("@idProvincia", idProvincia);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            ddlLocalidadFinal.DataSource = sqlDataReader;
            ddlLocalidadFinal.DataTextField = "NombreLocalidad";
            ddlLocalidadFinal.DataValueField = "IdLocalidad";
            ddlLocalidadFinal.DataBind();

            ddlLocalidadFinal.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
            connection.Close();

        }
    }
}