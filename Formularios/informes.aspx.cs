using Microsoft.Reporting.WebForms;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace gestionInventario.Formularios
{
    public partial class informes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport("Clientes");
            }
        }

        protected void ddlTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tablaSeleccionada = ddlTabla.SelectedValue;
            LoadReport(tablaSeleccionada);
        }

        private void LoadReport(string tablaSeleccionada)
        {
            DataTable dt = GetData(tablaSeleccionada);

            ReportViewer1.LocalReport.ReportPath = Server.MapPath($"~/Formularios/{tablaSeleccionada}Report.rdlc");
            ReportDataSource rds = new ReportDataSource($"{tablaSeleccionada}DataSet", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);

            ReportViewer1.LocalReport.Refresh();
        }

        private DataTable GetData(string tablaSeleccionada)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString;
            string query = $"SELECT * FROM {tablaSeleccionada}";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }





    }
}