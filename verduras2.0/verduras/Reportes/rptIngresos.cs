using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace verduras.Reportes
{
    public partial class rptIngresos : DevExpress.XtraReports.UI.XtraReport
    {
        public rptIngresos()
        {
            InitializeComponent();
        }
        public void llenarreporte(string fecha)
        {
            DataSource = conexion.fnEjecutarConsulta("select ig.codigo_producto, iv.nombre_producto, ig.cantidad, u.usuario "+
                                                                "from ingreso ig, inventario iv , usuario u "+
                                                                "where ig.codigo_producto=iv.codigo_producto and ig.id_usuario=u.id_usuario and ig.fecha = '" + fecha + "'");

                codigo.DataBindings.Add("Text", DataSource, "codigo_producto");
                descripcion.DataBindings.Add("Text", DataSource, "nombre_producto");
                cantidad.DataBindings.Add("Text", DataSource, "cantidad");
                responsable.DataBindings.Add("Text", DataSource, "usuario");
        }
    }
}
