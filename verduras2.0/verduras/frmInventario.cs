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
    public partial class frmInventario : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtinventario;
        private static frmInventario m_FormDefInstance;

        public frmInventario()
        {
            InitializeComponent();
        }
        
        public static frmInventario DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmInventario();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
       
        public void actualizar()
        {
            dtinventario = conexion.fnEjecutarConsulta("SELECT * FROM inventario");
            dataGridView1.DataSource = dtinventario;
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int fila = row.Index;
                if (row.Cells[0].Value != null)
                {
                    if (float.Parse(row.Cells[2].Value.ToString()) < 0)
                    {
                        dataGridView1.Rows[fila].DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
            
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            frmInventario.DefInstance.actualizar();
            dataGridView1.Columns[0].HeaderText = "Codigo Producto";
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].HeaderText = "Descripción";
            dataGridView1.Columns[1].Width = 600;
            dataGridView1.Columns[2].HeaderText = "Existencia";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].HeaderText = "Precio";
            dataGridView1.Columns[3].Width = 100;
        }


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString() == "")
            {
                DialogResult result = MessageBox.Show("Producto no encontrado, ¿Desea crear un nuevo Registro?", "Agregar", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    nuevoproducto();
                }
                else if (result == DialogResult.No)
                {
                }

            }
            else
            {
                frmInventarioMantenimiento datosinventario = new frmInventarioMantenimiento(dtinventario.Rows[dataGridView1.CurrentRow.Index]);
                
                datosinventario.Text = "-'- Editar Producto -'-";

                datosinventario.ShowDialog();
            }
        }
        public void nuevoproducto()
        {
            frmInventarioMantenimiento datos = new frmInventarioMantenimiento();
            
            datos.Text = "Nuevo Producto";
            datos.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInventario_Activated(object sender, EventArgs e)
        {
            frmInventario.DefInstance.actualizar();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            nuevoproducto();
        }
    }
}