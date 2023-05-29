using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestionInventario.Formularios
{
    public partial class Perfil : System.Web.UI.Page
    {
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString);
        public static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Session["usuariologueado"].ToString());
            if (Session["usuariologueado"] == null)
            {
                Response.Redirect("/Formulario/Login.aspx");
            }
            else
            {
                try
                {
                    
                    SqlCommand comando = new SqlCommand("Perfil", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    conexion.Open();
                    SqlDataReader leer = comando.ExecuteReader();
                    if (leer.Read())
                    {
                        image.ImageUrl = "/Formularios/FrmImagen.aspx?id=" + id;
                        this.txtnombres.Text = leer["Nombres"].ToString();
                        this.txtapellidos.Text = leer["Apellidos"].ToString();
                        this.txtfecha.Text = leer["Fecha"].ToString();
                        
                        this.txtusuario.Text = leer["Usuario"].ToString();
                        leer.Close();
                    }
                    conexion.Close();
                    
                }
                catch (Exception exx)
                {
                    lblerror.Text = exx.Message;
                }

            }

        }
        void metodoOcultar()
        {
            if (contrasena.Visible == false)
            {
                contrasena.Visible = true;
                btnGuardar.Visible = true;
                btnCambiar.Text = "Cancelar";
                lblerror.Text = "";
            }
            else
            {
                contrasena.Visible = false;
                btnGuardar.Visible = false;
                btnCambiar.Text = "Cambiar Contraseña";
                lblerror.Text = "";
            }
        }
        protected void btnAplicarCambios_Click(object sender, EventArgs e)
        {
            int tamañoarchivo;
            byte[] imagen = FUImage.FileBytes;
            tamañoarchivo = int.Parse(FUImage.FileContent.Length.ToString());
            if (tamañoarchivo >= 2097151000)
            {
                lblerror.Text = "El tamaño de la imagen debe ser menor a 10 MB";
            }
            else if (FUImage.HasFile)
            {
                using (conexion)
                {
                    using (SqlCommand comando = new SqlCommand("CambiarImagen", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@imagen", SqlDbType.Image).Value = imagen;
                        comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        conexion.Close();
                        lblerror.Text = "";
                    }
                }
            }
            else
            {
                lblerror.Text = "No se ha cargado una imagen de perfil nueva....";
            }
        }
        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            metodoOcultar();
        }
        protected void eliminar_Click(object sender, EventArgs e)
        {
            using (conexion)
            {
                using (SqlCommand comando = new SqlCommand("Eliminar", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    Session.Remove("usuariologueado");
                    Response.Redirect("/Formularios/login.aspx");
                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string validarcontrasena = clave.Text;
            Regex letras = new Regex(@"[a-zA-Z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex especiales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]{|}~]");
            if (clave.Text == "" || clave2.Text == "")
            {
                lblerrorclave.Text = "Los campos no pueden quedae vacios....";
            }
            else if (clave.Text != clave2.Text)
            {
                lblerrorclave.Text = "Claves  no coinciden....";
            }
            else if (!letras.IsMatch(validarcontrasena))
            {
                lblerrorclave.Text = "Las contraseñas deben tener letras!!!";
            }
            else if (!numeros.IsMatch(validarcontrasena))
            {
                lblerrorclave.Text = "Las contraseñas deben tener numeros!!!";
            }
            else if (!especiales.IsMatch(validarcontrasena))
            {
                lblerrorclave.Text = "Las contraseñas deben tener caracteres especiales!!!";
            }
            else
            {
                try
                {
                    using (conexion)
                    {
                        using (SqlCommand comando = new SqlCommand("CambiarContrasena", conexion))
                        {
                            string patron = "cavm";
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                            comando.Parameters.Add("@Clave", SqlDbType.VarChar).Value = clave.Text;
                            comando.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;
                            conexion.Open();
                            comando.ExecuteNonQuery();
                            conexion.Close();
                            metodoOcultar();
                            lblerrorclave.Text = "";
                        }
                    }

                }
                catch (Exception ex)
                {
                    lblerrorclave.Text = ex.Message;
                }
            }

        }
    }
}