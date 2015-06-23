using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace verduras.Reportes
{
    public partial class rptMermas : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMermas()
        {
            InitializeComponent();
        }
        public void llenarreporte(string fecha)
        {
            gridControl1.DataSource = conexion.fnEjecutarConsulta("select " +
                                                            "m.codigo_producto as CÓDIGO, " +
                                                            "i.nombre_producto as PRODUCTO, " +
                                                            "m.cantidad as CANTIDAD, " +
                                                            "m.motivo as MOTIVO, " +
                                                            "u.usuario as ENCARGADO " +
                                                            "from verdureria.merma m, verdureria.usuario u, verdureria.inventario i " +
                                                            "where m.id_usuario=u.id_usuario and m.codigo_producto=i.codigo_producto and m.fecha = '" + fecha + "'");
                
        }
    }
}
