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
    public partial class frmMermaMostrar : DevExpress.XtraEditors.XtraForm
    {
        public frmMermaMostrar()
        {
            InitializeComponent();
        }
        DataTable dtmostrar;
        public void actualizar()
        {
            label1.Text = "Ingresos de hoy : " + System.DateTime.Now.ToString("dd/MM/yyy");
            dtmostrar = conexion.fnEjecutarConsulta("select ig.codigo_producto, iv.nombre_producto, ig.cantidad, u.usuario "+
                                                    "from ingreso ig, inventario iv , usuario u "+
                                                    "where ig.codigo_producto=iv.codigo_producto and ig.id_usuario=u.id_usuario and ig.fecha = '" + 
                                                    System.DateTime.Now.ToString("yyyy/MM/dd") + "'");
            dataGridView1.DataSource = dtmostrar;
            
            dataGridView1.Columns[0].HeaderText = "Codigo Producto";
            dataGridView1.Columns[0].Width = 100;

            dataGridView1.Columns[1].HeaderText = "Nombre Producto";
            dataGridView1.Columns[1].Width = 220;

            dataGridView1.Columns[2].HeaderText = "Cantidad Producto";
            dataGridView1.Columns[2].Width = 100;

            dataGridView1.Columns[3].HeaderText = "Responsable";
            dataGridView1.Columns[3].Width = 220;
           
        }
        private void frmIngresoMostrar_Load(object sender, EventArgs e)
        {
            actualizar();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}