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
        //private const string cadenaConexion = @"Data Source=GERSONGUTIERREZ\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True;Encrypt=False";
        private const string cadenaConexion = @"Data Source=DESKTOP-IN37CD7\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True;TrustServerCertificate=True";
        
        private const string consultaSQLProvincias = "SELECT IdProvincia, NombreProvincia FROM Provincias";
        private const string consultaSQLLocalidades = "SELECT IdLocalidad, NombreLocalidad FROM Localidades WHERE IdProvincia = @idProvincia";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias(ddlProvinciaInicio);
                CargarProvincias(ddlProvinciaFinal);

                ddlLocalidadInicio.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
                ddlLocalidadFinal.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
            }
        }

        private void CargarProvincias(DropDownList ddlProvincia)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(consultaSQLProvincias, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    ddlProvincia.DataSource = reader;
                    ddlProvincia.DataTextField = "NombreProvincia";
                    ddlProvincia.DataValueField = "IdProvincia";
                    ddlProvincia.DataBind();
                }
            }
            ddlProvincia.Items.Insert(0, new ListItem("-- Seleccione una provincia --", "0"));
        }

        private void CargarLocalidades(DropDownList ddlLocalidad, int idProvincia)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(consultaSQLLocalidades, connection);
                cmd.Parameters.AddWithValue("@idProvincia", idProvincia);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    ddlLocalidad.DataSource = reader;
                    ddlLocalidad.DataTextField = "NombreLocalidad";
                    ddlLocalidad.DataValueField = "IdLocalidad";
                    ddlLocalidad.DataBind();
                }
            }
            ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
        }

        protected void ddlProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = int.Parse(ddlProvinciaInicio.SelectedValue);

            ddlLocalidadInicio.Items.Clear();
            if (idProvincia > 0)
            {
                CargarLocalidades(ddlLocalidadInicio, idProvincia);

                CargarProvincias(ddlProvinciaFinal);
                ddlProvinciaFinal.Items.Remove(ddlProvinciaFinal.Items.FindByValue(idProvincia.ToString()));

                ddlLocalidadFinal.Items.Clear();
                ddlLocalidadFinal.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
            }
            else
            {
                ddlLocalidadInicio.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
            }
        }

        protected void ddlProvinciaFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = int.Parse(ddlProvinciaFinal.SelectedValue);

            ddlLocalidadFinal.Items.Clear();
            if (idProvincia > 0)
            {
                CargarLocalidades(ddlLocalidadFinal, idProvincia);
            }
            else
            {
                ddlLocalidadFinal.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
            }
        }
    }
}