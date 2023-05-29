using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace gestionInventario.Formularios
{
    public partial class FrmImagen : System.Web.UI.Page
    {
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] == null)
            {
                Response.Redirect("/Formulario/Login.aspx");
            }
            else
            {
                int id = int.Parse(Session["usuariologueado"].ToString());
                using (conexion)
                {
                    using (SqlCommand comando = new SqlCommand("CargarImagen", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@Id", SqlDbType.Int).Value = Request.QueryString["id"];
                        conexion.Open();
                        SqlDataReader leer = comando.ExecuteReader();
                        if (leer.Read())
                        {
                            byte[] imagen = (byte[])leer["Imagen"];
                            Response.BinaryWrite(imagen);
                        }
                        conexion.Close();
                    }
                }
            }
        }
    }
}