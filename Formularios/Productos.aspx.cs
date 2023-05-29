using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestionInventario.Formularios
{
    public partial class Productos1 : System.Web.UI.Page
    {
        public ModeloProductosDataContext bd = new ModeloProductosDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnEliminar.Attributes.Add("Onclick", "return confirm('Desea eliminar el registro ? ')");
               
                btnModificar.Attributes.Add("Onclick", "return alert('Registro modificado...')");
                carga();
            }

        }
        public void carga()
        {
            DatosProductos.DataBind();
        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            var misdatos = from registros in bd.Productos select registros;
            e.Arguments.TotalRowCount = misdatos.Count();
            e.Result = misdatos;

        }



        public void limpiar()
        {
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtcantidad.Text = "";
            txtvalor.Text = "";
        }

       

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(txtcodigo.Text);
                int cuentaregistros = 0;
                var registro = bd.buscarProductos(codigo);
                foreach (var campo in registro)
                {
                    txtnombre.Text = campo.nombre;
                    txtcantidad.Text = campo.cantidad.ToString();
                    txtvalor.Text = campo.valorunitario.ToString();

                    cuentaregistros = 1;
                }
                if (cuentaregistros == 0)
                {
                    Response.Write("<script>alert('Nit no Existe...!!!');</script>");
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error en la información...!!!');</script>");
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(txtcodigo.Text);
                bd.eliminarProductos(codigo);
                carga();
                limpiar();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error en la información...!!!');</script>");
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(txtcodigo.Text);
                String nombre = txtnombre.Text;
                String cantidad = txtcantidad.Text;
                String valorunitario = txtvalor.Text;
                bd.actualizarProductos(codigo, nombre, int.Parse(cantidad), int.Parse(valorunitario));
                carga();
                limpiar();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error en la información...!!!');</script>");
            }

        }
    }
}