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
    public partial class Clientes1 : System.Web.UI.Page
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
            string consulta = "SELECT * FROM Clientes";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable datos = new DataTable();
            try
            {
                adaptador.Fill(datos);
                tablaclientes.DataSource = datos;
                tablaclientes.DataBind();
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
            string campoidentificacion = txtidentificacion.Text;
            string camponombre = txtnombre.Text;
            string campodireccion = txtdireccion.Text;
            string campotelefono = txttelefono.Text;
            string campociudad = txtciudad.Text;
            string consulta = "INSERT INTO Clientes VALUES(@identificacion, @nombre, @direccion,@telefono, @ciudad)";
            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@identificacion", campoidentificacion);
            comando.Parameters.AddWithValue("@nombre", camponombre);
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
            tablaclientes.EditIndex = e.NewEditIndex;
            this.EnlazarGrid();
        }

        // método para actualizar un registro
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int identificacioncliente = Convert.ToInt32(tablaclientes.DataKeys[e.RowIndex].Value.ToString());
            TextBox nombrecliente = (TextBox)tablaclientes.Rows[e.RowIndex].Cells[1].Controls[0];
            TextBox direccioncliente = (TextBox)tablaclientes.Rows[e.RowIndex].Cells[2].Controls[0];
            TextBox telefonocliente = (TextBox)tablaclientes.Rows[e.RowIndex].Cells[3].Controls[0];
            TextBox ciudadcliente = (TextBox)tablaclientes.Rows[e.RowIndex].Cells[4].Controls[0];
            string consulta = "UPDATE Clientes SET nombre=@nombre,direccion = @direccion,telefono = @telefono, ciudad = @ciudad  WHERE identificacion = @identificacion";
            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@identificacion", identificacioncliente);
            comando.Parameters.AddWithValue("@nombre", nombrecliente.Text);
            comando.Parameters.AddWithValue("@direccion", direccioncliente.Text);
            comando.Parameters.AddWithValue("@telefono", telefonocliente.Text);
            comando.Parameters.AddWithValue("@ciudad", ciudadcliente.Text);
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            comando.Dispose();
            tablaclientes.EditIndex = -1;
            this.EnlazarGrid();
        }

        // método para cancelar una modificación de un registro
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            tablaclientes.EditIndex = -1;
            this.EnlazarGrid();
        }

        // método para eliminar un registro
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int nitcliente = Convert.ToInt32(tablaclientes.DataKeys[e.RowIndex].Values[0]);
            string consulta = "DELETE FROM Clientes WHERE identificacion=@identificacion";
            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@identificacion", nitcliente);
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
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != tablaclientes.EditIndex)
            {
                // como existen 7 elementos en el formulario y el séptimo elemento es el link Eliminar, se lanza 
                //  una mensaje de confirmación para eliminar el registro
                (e.Row.Cells[6].Controls[0] as Button).Attributes["onclick"] = "return confirm('Seguro de eliminar el registro?'); ";
            }
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            tablaclientes.PageIndex = e.NewPageIndex;
            this.EnlazarGrid();
        }
    }
}