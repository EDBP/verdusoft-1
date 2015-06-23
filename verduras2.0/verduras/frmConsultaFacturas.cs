using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace verduras
{
    public partial class frmConsultaFacturas : DevExpress.XtraEditors.XtraForm
    {
        public frmConsultaFacturas()
        {
            InitializeComponent();
        }

        private static frmConsultaFacturas m_FormDefInstance;
        public static frmConsultaFacturas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmConsultaFacturas();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            mostrarFactura(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString());    
        }


        private void mostrarFactura(string id_venta)
        {
            DialogResult result = MessageBox.Show("¿Desea Re-Imprimir la Factura?", "-AVISO-", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                rptFactura factura = new rptFactura();
                factura.DataSource = conexion.fnEjecutarConsulta("Select  v.fecha, c.nombres,c.apellidos, c.direccion, c.nit, dt.cantidad, inv.nombre_producto, inv.precio_unitario, format((dt.cantidad*inv.precio_unitario),2) as subtotal " +
                                                                 "from venta v, cliente c, detalle_venta dt, inventario inv " +
                                                                 "where v.codigo_cliente=c.codigo_cliente and dt.id_venta=v.id_venta and dt.codigo_producto=inv.codigo_producto and v.id_venta='" + id_venta + "'");

                factura.fdia.Text = conexion.fnEjecutarEscalar("SELECT DATE_FORMAT(v.fecha, '%d') AS dia from venta v, cliente c, detalle_venta dt, inventario inv where v.codigo_cliente=c.codigo_cliente and dt.id_venta=v.id_venta and dt.codigo_producto=inv.codigo_producto and v.id_venta= '" + id_venta + "'").ToString();
                factura.fmes.Text = conexion.fnEjecutarEscalar("SELECT DATE_FORMAT(v.fecha, '%m') AS dia from venta v, cliente c, detalle_venta dt, inventario inv where v.codigo_cliente=c.codigo_cliente and dt.id_venta=v.id_venta and dt.codigo_producto=inv.codigo_producto and v.id_venta= '" + id_venta + "'").ToString();
                factura.fanio.Text = conexion.fnEjecutarEscalar("SELECT DATE_FORMAT(v.fecha, '%Y') AS dia from venta v, cliente c, detalle_venta dt, inventario inv where v.codigo_cliente=c.codigo_cliente and dt.id_venta=v.id_venta and dt.codigo_producto=inv.codigo_producto and v.id_venta= '" + id_venta + "'").ToString();

                string nomb= conexion.fnEjecutarEscalar("Select c.nombres from venta v, cliente c where v.codigo_cliente=c.codigo_cliente and v.id_venta='" + id_venta + "'").ToString();
                string appe = conexion.fnEjecutarEscalar("Select c.apellidos from venta v, cliente c where v.codigo_cliente=c.codigo_cliente and v.id_venta='" + id_venta + "'").ToString();

                factura.nombre.Text = nomb + " " + appe;
                factura.direccion.DataBindings.Add("Text", factura.DataSource, "direccion");
                factura.nit.DataBindings.Add("Text", factura.DataSource, "nit");
                factura.cantidad.DataBindings.Add("Text", factura.DataSource, "cantidad");
                factura.descripcion.DataBindings.Add("Text", factura.DataSource, "nombre_producto");
                factura.punitario.DataBindings.Add("Text", factura.DataSource, "precio_unitario");
                factura.stotal.DataBindings.Add("Text", factura.DataSource, "subtotal");
                if (conexion.fnEjecutarEscalar("SELECT descuento from venta  where id_venta= '" + id_venta + "'").ToString() != "1.00")
                {
                    factura.total.Text = string.Format("{0:f}", (conexion.fnEjecutarEscalar("Select  format(sum(dt.cantidad*inv.precio_unitario),2) as TOTAL " +
                                                                                        "from venta v, cliente c, detalle_venta dt, inventario inv " +
                                                                                        "where v.codigo_cliente=c.codigo_cliente and dt.id_venta=v.id_venta and dt.codigo_producto=inv.codigo_producto and v.id_venta= '" + id_venta + "'"))).ToString();
                    factura.xrLine2.Visible = true;
                }
                else
                {
                    string subtot;
                    subtot = (string)conexion.fnEjecutarEscalar("Select  format(sum(dt.cantidad*inv.precio_unitario),2) as TOTAL " +
                                                                                        "from venta v, cliente c, detalle_venta dt, inventario inv " +
                                                                                        "where v.codigo_cliente=c.codigo_cliente and dt.id_venta=v.id_venta and dt.codigo_producto=inv.codigo_producto and v.id_venta= '" + id_venta + "'");
                    double totales = 0.00;
                    factura.lsubtotal.Visible = true;
                    factura.ldescuento.Visible = true;
                    factura.subtotal.Visible = true;
                    factura.descuento.Visible = true;
                    factura.xrLine1.Visible = true;
                    factura.subtotal.Text= string.Format("{0:f}", double.Parse(subtot)).ToString();
                    factura.descuento.Text = string.Format("{0:f}", (double.Parse(subtot) * 0.10)).ToString();

                    totales = double.Parse(subtot) - (double.Parse(subtot) * 0.10);
                    factura.total.Text = string.Format("{0:f}", totales).ToString();
                }

                factura.ShowPreview();
            }
            else
            {
                this.Close();
            }
        }

        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            
            String fecha = dateEdit1.DateTime.Date.Year + "-" + dateEdit1.DateTime.Date.Month + "-" +
                                dateEdit1.DateTime.Date.Day;
            DataTable dtFacturas = new DataTable();
            dtFacturas = conexion.fnEjecutarConsulta("Select  v.id_venta as Venta, c.nombres as Nombre, c.apellidos as Apellido " +
                                                      "from venta v, cliente c " +
                                                      "where v.codigo_cliente=c.codigo_cliente and v.fecha='" + fecha + "'");
            dataGridView1.DataSource = dtFacturas;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
           mostrarFactura(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
        }
    }
}