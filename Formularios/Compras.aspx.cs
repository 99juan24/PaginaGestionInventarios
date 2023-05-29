using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace gestionInventario.Formularios
{
    public partial class Compras : System.Web.UI.Page
    {
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString);
        public ModeloProductosDataContext bd = new ModeloProductosDataContext();
        public SqlCommand comando;
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void proveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtnit.Text = proveedores.SelectedValue;
            String consulta = "SELECT * FROM proveedores WHERE nit=" + txtnit.Text;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            
                DataTable dt = rellenartabla();
                DataRow fila;
                fila = dt.NewRow();
                fila["Codigo"] = txtcodigo.Text;
                fila["Producto"] = txtnombre.Text;
                fila["Valor unitario"] = txtvalor.Text;
                fila["Cantidad"] = txtcantidad.Text;
                fila["Valor Total"] = int.Parse(txtcantidad.Text) * int.Parse(txtvalor.Text);
                dt.Rows.Add(fila);
                detalleproducto.DataSource = dt;
                detalleproducto.DataBind();
                Session["dt"] = dt;
           
        int sumas = 0;
            for (int i = 0; i <= detalleproducto.Rows.Count - 1; i++)
            {
                GridViewRow sumafila = detalleproducto.Rows[i];
        sumas = sumas + int.Parse(sumafila.Cells[4].Text);
    }
            txttotalcompra.Text = "" + sumas;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(txtcodigo.Text);
                String nombre = txtnombre.Text;
                String cantidad = txtcantidad.Text;
                int valorunitario = int.Parse(txtvalor.Text)*2;
                bd.insertarProductos(codigo, nombre, int.Parse(cantidad), valorunitario);
                Response.Write("<script>alert('Prooductos gardados...!!!');</script>");
                limpiar();
            }
            catch (Exception ex)
            {
                Response.Write("<script language='JavaScript'>alert('Error en la información...!!!');</script>");
            }

        }
        public void limpiar()
        {
            txtnrofactura.Text = "";
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtfecha.Text = "";
            txtobservacion.Text = "";
            txtnit.Text = "";
            txtciudad.Text = "";
            txtdireccion.Text = "";
            txtcantidad.Text = "";
            txttelefono.Text = "";
            txtvalor.Text = "";
            txttotalcompra.Text = "";
            detalleproducto.DataSource = "";
            detalleproducto.DataBind();


        }


    }
}