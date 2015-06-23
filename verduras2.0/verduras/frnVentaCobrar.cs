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
    public partial class frnVentaCobrar : DevExpress.XtraEditors.XtraForm
    {
        public frnVentaCobrar()
        {
            InitializeComponent();
        }
        string descuento = "";
        
        public void recibirtotal(string cantidad,string descu)
        {
            textEdit1.Text = cantidad;
            descuento = descu;
        }
        string id_venta;
        public void recibiventa(string numeroventa)
        {
            id_venta = numeroventa;
        }
        private void frnVentaCobrar_Load(object sender, EventArgs e)
        {
            textEdit2.Focus();
            simpleButton1.Enabled = false;
            simpleButton2.Enabled = false;
        }

        private void textEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (double.Parse(textEdit1.Text) <= double.Parse(textEdit2.Text))
                {
                    textEdit3.Text =string.Format("{0:f}", (double.Parse(textEdit2.Text) - double.Parse(textEdit1.Text))).ToString();
                    simpleButton1.Enabled = true;
                    simpleButton2.Enabled = true;
                    SendKeys.Send("{tab}");
                }
                else
                {
                    MessageBox.Show("EL PAGO ES MENOR A LA CANITDAD CONSUMIDA","Alerta");
                    textEdit3.Text = "";
                    textEdit2.Text = "";
                    textEdit3.Focus();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            rptFactura factura = new rptFactura();
            factura.DataSource = conexion.fnEjecutarConsulta("Select  v.fecha, c.nombres,c.apellidos, c.direccion, c.nit, dt.cantidad, inv.nombre_producto, inv.precio_unitario, format((dt.cantidad*inv.precio_unitario),2) as subtotal " +
                                                             "from venta v, cliente c, detalle_venta dt, inventario inv "+
                                                             "where v.codigo_cliente=c.codigo_cliente and dt.id_venta=v.id_venta and dt.codigo_producto=inv.codigo_producto and v.id_venta='" + id_venta + "'");

            factura.fdia.Text = conexion.fnEjecutarEscalar("SELECT DATE_FORMAT(v.fecha, '%d') AS dia from venta v, cliente c, detalle_venta dt, inventario inv where v.codigo_cliente=c.codigo_cliente and dt.id_venta=v.id_venta and dt.codigo_producto=inv.codigo_producto and v.id_venta= '" + id_venta + "'").ToString();
            factura.fmes.Text = conexion.fnEjecutarEscalar("SELECT DATE_FORMAT(v.fecha, '%m') AS dia from venta v, cliente c, detalle_venta dt, inventario inv where v.codigo_cliente=c.codigo_cliente and dt.id_venta=v.id_venta and dt.codigo_producto=inv.codigo_producto and v.id_venta= '" + id_venta + "'").ToString();
            factura.fanio.Text = conexion.fnEjecutarEscalar("SELECT DATE_FORMAT(v.fecha, '%Y') AS dia from venta v, cliente c, detalle_venta dt, inventario inv where v.codigo_cliente=c.codigo_cliente and dt.id_venta=v.id_venta and dt.codigo_producto=inv.codigo_producto and v.id_venta= '" + id_venta + "'").ToString();

            string nomb = conexion.fnEjecutarEscalar("Select c.nombres from venta v, cliente c where v.codigo_cliente=c.codigo_cliente and v.id_venta='" + id_venta + "'").ToString();
            string appe = conexion.fnEjecutarEscalar("Select c.apellidos from venta v, cliente c where v.codigo_cliente=c.codigo_cliente and v.id_venta='" + id_venta + "'").ToString();

            factura.nombre.Text = nomb + " " + appe;

            factura.direccion.DataBindings.Add("Text", factura.DataSource, "direccion "+"apellidos");
            factura.nit.DataBindings.Add("Text", factura.DataSource, "nit");
            factura.cantidad.DataBindings.Add("Text", factura.DataSource, "cantidad");
            factura.descripcion.DataBindings.Add("Text", factura.DataSource, "nombre_producto");
            factura.punitario.DataBindings.Add("Text", factura.DataSource, "precio_unitario");
            factura.stotal.DataBindings.Add("Text", factura.DataSource, "subtotal");
            if (descuento != "1")
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
                factura.subtotal.Text = string.Format("{0:f}", double.Parse(subtot)).ToString();
                factura.descuento.Text = string.Format("{0:f}", (double.Parse(subtot) * 0.10)).ToString();

                totales = double.Parse(subtot) - (double.Parse(subtot) * 0.10);
                factura.total.Text = string.Format("{0:f}", totales).ToString();
            }

            factura.ShowPreview();
        }
    }
}