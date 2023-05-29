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
    public partial class Ventas : System.Web.UI.Page
    {
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString);
        public SqlCommand comando;
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtnit.Text = clientes.SelectedValue;
            String consulta = "SELECT * FROM clientes WHERE identificacion=" + txtnit.Text;
            comando = new SqlCommand(consulta, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read())
            {
                txtdireccion.Text = (leer.GetString(2));
                txttelefono.Text = (leer.GetString(3));
                txtciudad.Text = (leer.GetString(4));
            }
            conexion.Close();
        }
        public DataTable rellenartabla()
        {
            var dt = new DataTable();
            dt.Columns.Add("Codigo", Type.GetType("System.String"));
            dt.Columns.Add("Producto", Type.GetType("System.String"));
            dt.Columns.Add("Valor unitario", Type.GetType("System.String"));
            dt.Columns.Add("Cantidad", Type.GetType("System.String"));
            dt.Columns.Add("Valor Total", Type.GetType("System.String"));
            return dt;
        }

        protected void comboproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var codigoproducto = comboproductos.SelectedValue;
                String consulta = "SELECT * FROM productos WHERE codigo=" + codigoproducto;
                comando = new SqlCommand(consulta, conexion);
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    txtvalor.Text = (leer.GetInt32(3).ToString());
                }
                conexion.Close();
            }
            catch (Exception ex) { txtvalor.Text = ex.Message; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String consulta = "SELECT * FROM productos WHERE codigo=" + comboproductos.SelectedValue.ToString();
            comando = new SqlCommand(consulta, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();
            int cantidadactual = 0;
            if (leer.Read())
            {
                cantidadactual = (int)leer.GetInt32(2);

            }
            if (cantidadactual < int.Parse(txtcantidad.Text))
            {
                Response.Write("<script language='JavaScript'>alert('No existe esa cantidad...!!!');</script>");
                txtcantidad.Text = "";
                txtcantidad.Focus();
            }
            else
            {
                
                    DataTable dt = rellenartabla();
                    DataRow fila;
                    fila = dt.NewRow();
                    fila["Codigo"] = comboproductos.SelectedValue.ToString();
                    fila["Producto"] = comboproductos.SelectedItem;
                    fila["Valor unitario"] = txtvalor.Text;
                    fila["Cantidad"] = txtcantidad.Text;
                    fila["Valor Total"] = int.Parse(txtcantidad.Text) * int.Parse(txtvalor.Text);
                    dt.Rows.Add(fila);
                    detalleproducto.DataSource = dt;
                    detalleproducto.DataBind();
                    Session["dt"] = dt;
                
            }
            int sumas = 0;
            for (int i = 0; i <= detalleproducto.Rows.Count - 1; i++)
            {
                GridViewRow sumafila = detalleproducto.Rows[i];
                sumas = sumas + int.Parse(sumafila.Cells[4].Text);
            }
            txttotalventa.Text = "" + sumas;
            conexion.Close();
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String insertarfactura = "Insert into Pedidos values(" + txtnrofactura.Text
                  + "," + txtnit.Text + ",'" + txtfecha.Text + "','" + txtobservacion.Text + "')";
            String insertarventa = "Insert into DetalleVentas values(@nropedido,@codigo,@cantidadvendida,@precioventa)";

            SqlCommand comando = new SqlCommand();
            try
            {
                comando.CommandText = insertarfactura;
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                foreach (GridViewRow fila in detalleproducto.Rows)
                {
                    SqlCommand insertarv = new SqlCommand(insertarventa, conexion);
                    insertarv.Parameters.Clear();
                    insertarv.Parameters.Add("@nropedido", SqlDbType.Int).Value = int.Parse(txtnrofactura.Text);
                    insertarv.Parameters.Add("@codigo", SqlDbType.Int).Value = int.Parse(fila.Cells[0].Text);
                    insertarv.Parameters.Add("@cantidadvendida", SqlDbType.Int).Value = int.Parse(fila.Cells[3].Text);
                    insertarv.Parameters.Add("@precioventa", SqlDbType.Int).Value = int.Parse(fila.Cells[2].Text);
                    insertarv.ExecuteNonQuery();
                }
                foreach (GridViewRow fila in detalleproducto.Rows)
                {
                    String consulta = "SELECT * FROM productos WHERE codigo=" + int.Parse(fila.Cells[0].Text);
                    comando = new SqlCommand(consulta, conexion);
                    //   conexion.Open();
                    SqlDataReader leer = comando.ExecuteReader();
                    int cantidadactual = 0;
                    if (leer.Read())
                    {
                        cantidadactual = (int)leer.GetInt32(2);

                    }
                    leer.Close();
                    int nuevacantidad = cantidadactual - int.Parse(fila.Cells[3].Text);
                    String actualizarproducto = "Update Productos set cantidad=@nvacantidad where codigo=" + int.Parse(fila.Cells[0].Text);
                    SqlCommand actualizarp = new SqlCommand(actualizarproducto, conexion);
                    actualizarp.Parameters.Clear();
                    actualizarp.Parameters.Add("@nvacantidad", SqlDbType.Int).Value = nuevacantidad;
                    actualizarp.ExecuteNonQuery();
                }
                conexion.Close();
                limpiar();
                Response.Write("<script language='JavaScript'>alert('Registro guardado...!!!');</script>");


            }
            catch (SqlException ex) { }

            catch (Exception ex) { }

            finally
            {
                conexion.Close();
            }
        }
        public void limpiar()
        {
            txtnrofactura.Text = "";
            txtobservacion.Text = "";
            txtnit.Text = "";
            txtciudad.Text = "";
            txtdireccion.Text = "";
            txtcantidad.Text = "";
            txttelefono.Text = "";
            txtvalor.Text = "";
            detalleproducto.DataSource = "";
            detalleproducto.DataBind();
            
        }
    }
}