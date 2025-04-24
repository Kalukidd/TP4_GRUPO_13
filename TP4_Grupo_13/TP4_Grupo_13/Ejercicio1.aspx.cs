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
        //private const string cadenaConexion = "Data Source=kalu\\sqlexpress;Initial Catalog=Viajes;Integrated Security = True";
        //private const string cadenaConexion = "Data Source=DESKTOP-MMELJR5\\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True;TrustServerCertificate=True";
<<<<<<< Updated upstream
=======
        private const string cadenaConexion = @"Data Source = LENOVO\SQLEXPRESS;Initial Catalog = Viajes; Integrated Security = True; Encrypt=False";
>>>>>>> Stashed changes
        private string consultaSQLProvincias = "SELECT IdProvincia, NombreProvincia FROM Provincias";
        private string consultasSQLLocalidades = "SELECT IdLocalidad, NombreLocalidad FROM Localidades WHERE IdProvincia = @idProvincia";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvinciasFinal();
                CargarProvinciasInicio();

                ddlLocalidadFinal.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
                ddlLocalidadInicio.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
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

        private void CargarProvinciasInicio()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(consultaSQLProvincias, connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


            ddlProvinciaInicio.DataSource = sqlDataReader;
            ddlProvinciaInicio.DataTextField = "NombreProvincia";
            ddlProvinciaInicio.DataValueField = "IdProvincia";
            ddlProvinciaInicio.DataBind();

            ddlProvinciaInicio.Items.Insert(0, new ListItem("-- Seleccione una provincia --", "0"));
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
                

                if (ddlLocalidadFinal.Items.Count != 1 || ddlLocalidadFinal.Items.Count == 1) {
                    ddlLocalidadFinal.Items.Clear();
                    ddlLocalidadFinal.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));

                }
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

        private void CargarLocalidadesInicio(int idProvincia)
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(consultasSQLLocalidades, connection);
            sqlCommand.Parameters.AddWithValue("@idProvincia", idProvincia);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            ddlLocalidadInicio.DataSource = sqlDataReader;
            ddlLocalidadInicio.DataTextField = "NombreLocalidad";
            ddlLocalidadInicio.DataValueField = "IdLocalidad";
            ddlLocalidadInicio.DataBind();

            ddlLocalidadFinal.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
            connection.Close();

        }

        protected void ddlProvinciaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = int.Parse(ddlProvinciaInicio.SelectedValue);
            if (idProvincia > 0)
            {
                CargarLocalidadesInicio(idProvincia);
                ddlLocalidadInicio.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
                

                CargarProvinciasFinal();
                ddlLocalidadFinal.Items.Clear();
                ddlLocalidadFinal.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));

                foreach (ListItem item in ddlProvinciaFinal.Items)
                {
                    if (item.Value == idProvincia.ToString())
                    {
                        ddlProvinciaFinal.Items.Remove(item);
                        break;
                    }
                   
                }
            }
            else
            {
                ddlLocalidadInicio.Items.Clear();
                ddlLocalidadInicio.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
                if (ddlLocalidadInicio.Items.Count != 1 || ddlLocalidadInicio.Items.Count == 1) {
                    ddlLocalidadInicio.Items.Clear();
                    ddlLocalidadInicio.Items.Insert(0, new ListItem("-- Seleccione una localidad --", "0"));
                }
                
            

            }
        }
    }
}