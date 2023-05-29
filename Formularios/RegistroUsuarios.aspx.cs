using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestionInventario.Formularios
{
    public partial class RegistroUsuarios : System.Web.UI.Page
    {
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Formularios/Login.aspx");
        }
        protected void Registrar_Click(object sender, EventArgs e)
        {
            int timagen = int.Parse(FUImage.FileContent.Length.ToString());
            string validarcontrasena = txtclave.Text;
            Regex letras = new Regex(@"[a-zA-Z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex especiales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]{|}~]");
            conexion.Open();
            SqlCommand usuario = new SqlCommand("ContarUsuario", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            usuario.Parameters.Add("@usuario", SqlDbType.VarChar).Value = txtusuario.Text;
            int miusuario = Convert.ToInt32(usuario.ExecuteScalar());
            if (txtnombres.Text == "" || txtapellidos.Text == "" || txtfecha.Text == "" || txtusuario.Text == "")
            {
                lblerror.Text = "Los campos no deben quedar vacios";
            }
            else if (miusuario >= 1)
            {
                lblerror.Text = "El usuario " + txtusuario.Text + " ya existe!!!";
            }
            else if (txtclave.Text != txtclave2.Text)
            {
                lblerror.Text = "Claves  no coinciden....";
            }
            else if (!letras.IsMatch(validarcontrasena))
            {
                lblerror.Text = "Las contraseñas deben tener letras!!!";
            }
            else if (!numeros.IsMatch(validarcontrasena))
            {
                lblerror.Text = "Las contraseñas deben tener numeros!!!";
            }
            else if (!especiales.IsMatch(validarcontrasena))
            {
                lblerror.Text = "Las contraseñas deben tener caracteres especiales!!!";
            }
            else if (!FUImage.HasFile)
            {
                lblerror.Text = "No se ha cargado una imagen de perfil!!!";
            }
            else if (timagen >= 209715000)
            {
                lblerror.Text = "El tamaño de la imagen no puede ser mayor de 10 MB!!!";
            }
            else
            {
                byte[] imagen = FUImage.FileBytes;
                string patron = "cavm";
                using (conexion)
                {
                    using (SqlCommand comando = new SqlCommand("Registrar", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = txtnombres.Text;
                        comando.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = txtapellidos.Text;
                        comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = txtfecha.Text;
                        comando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = txtusuario.Text;
                        comando.Parameters.Add("@Clave", SqlDbType.VarChar).Value = txtclave.Text;
                        comando.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;
                        comando.Parameters.Add("@Imagen", SqlDbType.Image).Value = imagen;
                        comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = 0;
                        comando.ExecuteNonQuery();

                    }
                    conexion.Close();
                    Response.Redirect("/Formularios/Login.aspx");
                }
            }
        }
    }
}