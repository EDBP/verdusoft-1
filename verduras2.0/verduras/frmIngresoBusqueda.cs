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
    public partial class frmIngresoBusqueda : DevExpress.XtraEditors.XtraForm
    {
        public frmIngresoBusqueda()
        {
            InitializeComponent();
        }

        DataTable dtbusqueda;
        public void actualizar()
        {
            dtbusqueda = conexion.fnEjecutarConsulta("select codigo_producto, nombre_producto from inventario");
            dataGridView1.DataSource = dtbusqueda;

            dataGridView1.Columns[0].HeaderText = "Codigo Producto";
            dataGridView1.Columns[0].Width = 100;

            dataGridView1.Columns[1].HeaderText = "Nombre Producto";
            dataGridView1.Columns[1].Width = 220;

            for (int i = 0; i <= 1; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 11F, FontStyle.Regular);
                dataGridView1.Columns[i].ReadOnly = true;
                dataGridView1.Columns[i].Resizable = DataGridViewTriState.False;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void identificar(string texto)
        {
            label1.Text = texto;
        }

        private void frmIngresoBusqueda_Load(object sender, EventArgs e)
        {
            actualizar();
        }
        private void enviar()
        {
            if (label1.Text == "ingreso")
            {
                frmIngreso.DefInstance.mensaje(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                this.Close();
            }
            if (label1.Text == "venta")
            {
                frmVenta.DefInstance.mensaje(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                this.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            enviar();            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            enviar();
        }
    }
}