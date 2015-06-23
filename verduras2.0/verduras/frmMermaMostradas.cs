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
    public partial class frmMermaMostradas : DevExpress.XtraEditors.XtraForm
    {
        public frmMermaMostradas()
        {
            InitializeComponent();
        }
        DataTable dtmostrar;
        public void actualizar()
        {
            label1.Text = "Mermas de hoy : " + System.DateTime.Now.ToString("dd/MM/yyy");
            dtmostrar = conexion.fnEjecutarConsulta("select " +
                                                            "m.codigo_producto as CÓDIGO, " +
                                                            "i.nombre_producto as PRODUCTO, " +
                                                            "m.cantidad as CANTIDAD, " +
                                                            "m.motivo as MOTIVO, " +
                                                            "u.usuario as ENCARGADO " +
                                                            "from verdureria.merma m, verdureria.usuario u, verdureria.inventario i " +
                                                            "where m.id_usuario=u.id_usuario and m.codigo_producto=i.codigo_producto and m.fecha = '"+System.DateTime.Now.ToString("yyyy/MM/dd")+ "'");
            dataGridView1.DataSource = dtmostrar;

            dataGridView1.Columns[0].HeaderText = "Codigo Producto";
            dataGridView1.Columns[0].Width = 100;

            dataGridView1.Columns[1].HeaderText = "Nombre Producto";
            dataGridView1.Columns[1].Width = 220;

            dataGridView1.Columns[2].HeaderText = "Cantidad Producto";
            dataGridView1.Columns[2].Width = 100;

            dataGridView1.Columns[3].HeaderText = "Motivo";
            dataGridView1.Columns[3].Width = 220;

            dataGridView1.Columns[4].HeaderText = "Responsable";
            dataGridView1.Columns[4].Width = 220;
        }
        private void frmMermaMostradas_Load(object sender, EventArgs e)
        {
            actualizar();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}