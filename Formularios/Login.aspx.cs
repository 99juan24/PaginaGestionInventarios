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

    public partial class Login : System.Web.UI.Page
    {
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Formularios/RegistroUsuarios.aspx");
        }

        protected void Iniciar_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text == "" || txtclave.Text == "")
            {
                lblerror.Text = "Los campos no pueden quedar vacios";
            }
            else
            {
                string patron = "cavm";
                using (conexion)
                {
                    using (SqlCommand comando = new SqlCommand("Validar", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = txtusuario.Text;
                        comando.Parameters.Add("@Clave", SqlDbType.VarChar).Value = txtclave.Text;
                        comando.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;
                        conexion.Open();
                        SqlDataReader leer = comando.ExecuteReader();
                        if (leer.Read())
                        {
                            Session["usuariologueado"] = leer["Id"].ToString();
                            Response.Redirect("/Formularios/Index.aspx");
                        }
                        else
                        {
                            lblerror.Text = "Usuario o Contraseña no valida....";
                        }
                        conexion.Close();
                    }
                }
            }
        }
    }
}