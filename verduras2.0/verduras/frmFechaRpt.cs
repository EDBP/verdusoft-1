using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace verduras
{
    public partial class frmFechaRpt : Form
    {
        String tipo = "";
        public frmFechaRpt()
        {
            InitializeComponent();
        }
        private static frmFechaRpt m_FormDefInstance;
        public static frmFechaRpt DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmFechaRpt();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public void settipo(string tiporeporte)
        {
            tipo = tiporeporte;
        }
        private void btnBuscarRpt_Click(object sender, EventArgs e)
        {
            String fecha = dateEdit1.DateTime.Date.Year + "-" + dateEdit1.DateTime.Date.Month + "-" +
                                dateEdit1.DateTime.Date.Day;
            if (tipo.Equals("ingresos"))
            {
                Reportes.rptIngresos report = new Reportes.rptIngresos();

                report.llenarreporte(fecha);

                report.lblFecha.Text = dateEdit1.DateTime.Date.ToShortDateString();
                report.ShowPreview();
            }
            if (tipo.Equals("merma"))
            {
                Reportes.rptMermas report = new Reportes.rptMermas();
                report.lblFecha.Text = dateEdit1.DateTime.Date.ToShortDateString();
                report.llenarreporte(fecha);
                report.ShowPreview();

            }
            if (tipo.Equals("ventas"))
            {
                string t_s_d;
                string t_c_d;

                Reportes.rptVentas report = new Reportes.rptVentas();

                report.DataSource = conexion.fnEjecutarConsulta("SELECT i.nombre_producto, SUM(dv.cantidad) AS cantidad, dv.precio_venta " +
" FROM  detalle_venta dv, venta v, inventario i " +
" WHERE dv.id_venta = v.id_venta AND dv.codigo_producto = i.codigo_producto AND (v.fecha = '"+fecha+"') " +
" GROUP BY i.nombre_producto ");

                report.producto.DataBindings.Add("Text", report.DataSource, "nombre_producto");
                report.cantidad.DataBindings.Add("Text", report.DataSource, "cantidad");
                report.precio.DataBindings.Add("Text", report.DataSource, "precio_venta");
                

                //report.dtAdapterVenta.getVentas(dateEdit1.DateTime.Date);
                report.lblFecha.Text = dateEdit1.DateTime.Date.ToShortDateString();

                t_s_d = string.Format("{0:f}",(conexion.fnEjecutarEscalar("Select sum(dv.cantidad*dv.precio_venta) From venta v, detalle_venta dv where v.id_venta=dv.id_venta and v.descuento = 0.00 and v.fecha = '" + fecha + "'"))).ToString();
                t_c_d = string.Format("{0:f}", (conexion.fnEjecutarEscalar("Select sum((dv.cantidad*dv.precio_venta)-(dv.cantidad*dv.precio_venta)*.10) From venta v, detalle_venta dv where v.id_venta=dv.id_venta and v.descuento = 1.00 and v.fecha = '" + fecha + "'"))).ToString();
                if (t_s_d == "") 
                {
                    t_s_d = "0.00";
                }
                if (t_c_d == "")
                {
                    t_c_d = "0.00";
                }
                double total = double.Parse(t_s_d) + double.Parse(t_c_d);
                report.lblTotal.Text = string.Format("{0:f}",total).ToString();
                report.ShowPreview();
            }
        }
    }
}
