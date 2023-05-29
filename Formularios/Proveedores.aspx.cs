using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestionInventario.Formularios
{
    public partial class Proveedores : System.Web.UI.Page
    {
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.EnlazarGrid();
            }

        }
        // se codifica la función EnlazarGrid()
        private void EnlazarGrid()
        {
            string consulta = "SELECT * FROM proveedores";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable datos = new DataTable();
            try
            {
                adaptador.Fill(datos);
                tablaprveedores.DataSource = datos;
                tablaprveedores.DataBind();
            }
            catch (Exception ex) { Console.WriteLine("" + ex.Message.ToString()); }
            finally
            {
                comando.Dispose();
                adaptador.Dispose();
                datos.Dispose();
            }
        }

        // se crea el método Insertar, para adicionar registros a la tabla
        protected void Insertar(object sender, EventArgs e)
        {
            string camponit = txtnit.Text;
            string campoempresa = txtepresa.Text;
            string campodireccion = txtdireccion.Text;
            string campotelefono = txttelefono.Text;
            string campociudad = txtciudad.Text;
            string consulta = "INSERT INTO proveedores VALUES(@nit, @empresa, @direccion,@telefono, @ciudad)";
            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@nit", camponit);
            comando.Parameters.AddWithValue("@empresa", campoempresa);
            comando.Parameters.AddWithValue("@direccion", campodireccion);
            comando.Parameters.AddWithValue("@telefono", campotelefono);
            comando.Parameters.AddWithValue("@ciudad", campociudad);
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            comando.Dispose();
            this.EnlazarGrid();
        }






        // método para editar un registro
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            tablaprveedores.EditIndex = e.NewEditIndex;
            this.EnlazarGrid();
        }

        // método para actualizar un registro
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int nitempresa = Convert.ToInt32(tablaprveedores.DataKeys[e.RowIndex].Value.ToString());
            TextBox nombreempresa = (TextBox)tablaprveedores.Rows[e.RowIndex].Cells[1].Controls[0];
            TextBox direccionempresa = (TextBox)tablaprveedores.Rows[e.RowIndex].Cells[2].Controls[0];
            TextBox telefonoempresa = (TextBox)tablaprveedores.Rows[e.RowIndex].Cells[3].Controls[0];
            TextBox ciudadempresa = (TextBox)tablaprveedores.Rows[e.RowIndex].Cells[4].Controls[0];
            string consulta = "UPDATE Proveedores SET empresa=@empresa,direccion = @direccion,telefono = @telefono, ciudad = @ciudad  WHERE nit = @nit";
            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@nit", nitempresa);
            comando.Parameters.AddWithValue("@empresa", nombreempresa.Text);
            comando.Parameters.AddWithValue("@direccion", direccionempresa.Text);
            comando.Parameters.AddWithValue("@telefono", telefonoempresa.Text);
            comando.Parameters.AddWithValue("@ciudad", ciudadempresa.Text);
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            comando.Dispose();
            tablaprveedores.EditIndex = -1;
            this.EnlazarGrid();
        }

        // método para cancelar una modificación de un registro
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            tablaprveedores.EditIndex = -1;
            this.EnlazarGrid();
        }

        // método para eliminar un registro
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int nitempresa = Convert.ToInt32(tablaprveedores.DataKeys[e.RowIndex].Values[0]);
            string consulta = "DELETE FROM proveedores WHERE nit=@nit";
            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@nit", nitempresa);
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            comando.Dispose();
            this.EnlazarGrid();
        }

        // método para actualizar el grid cuando se edita o elimina un registro.
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != tablaprveedores.EditIndex)
            {
                // como existen 7 elementos en el formulario y el séptimo elemento es el link Eliminar, se lanza 
                //  una mensaje de confirmación para eliminar el registro
                (e.Row.Cells[6].Controls[0] as Button).Attributes["onclick"] = "return confirm('Seguro de eliminar el registro?'); ";
            }
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            tablaprveedores.PageIndex = e.NewPageIndex;
            this.EnlazarGrid();
        }
    }
}