using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestionInventario.Formularios
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] != null)
            {
                int id = int.Parse(Session["usuariologueado"].ToString());
                SqlCommand comando = new SqlCommand("Perfil", conexion);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                leer.Read();
                this.lblusuario.Text = leer["Apellidos"].ToString() + " , " + leer["Nombres"].ToString();
                ImgPerfil.ImageUrl = "/Formularios/FrmImagen.aspx?id=" + id;
                conexion.Close();
            }
            else
            {
                Response.Redirect("/Formulario/Login.aspx");
            }

        }
        protected void Perfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Formularios/Perfil.aspx");
        }
        protected void Salir_Click(object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Response.Redirect("/Formularios/Login.aspx");
        }
    }
}