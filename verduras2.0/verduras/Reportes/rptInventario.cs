using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace verduras.Reportes
{
    public partial class rptInventario : DevExpress.XtraReports.UI.XtraReport
    {
        public rptInventario()
        {
            InitializeComponent();

        }


        private void rptInventario_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataSource = conexion.fnEjecutarConsulta("SELECT * FROM verdureria.inventario");

            codigo.DataBindings.Add("Text", DataSource, "codigo_producto");
            producto.DataBindings.Add("Text", DataSource, "nombre_producto");
            existencia.DataBindings.Add("Text", DataSource, "existencia");
            precio.DataBindings.Add("Text", DataSource, "precio_unitario");
        }
        


    }
}
