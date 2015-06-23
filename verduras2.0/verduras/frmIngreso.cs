using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace verduras
{
    public partial class frmIngreso : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtbuscarproducto;
        public int user = 1;

        private static frmIngreso m_FormDefInstance;
        public static frmIngreso DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmIngreso();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public void identificarusuario(int quien)
        {
            user = quien;
        }

        public frmIngreso()
        {
            InitializeComponent();
        }

        private void frmIngreso_Load(object sender, EventArgs e)
        {
            limpiar();
        }

       
        public void buscarproducto()
        {
            dtbuscarproducto = conexion.fnEjecutarConsulta("SELECT * FROM inventario Where codigo_producto='" + textEdit1.Text + "'");
            if (dtbuscarproducto.Rows.Count != 0)
            {
                textEdit3.Text = dtbuscarproducto.Rows[0]["nombre_producto"].ToString();
                textEdit4.Text = dtbuscarproducto.Rows[0]["existencia"].ToString();
                textEdit5.Text = dtbuscarproducto.Rows[0]["precio_unitario"].ToString();
                textEdit2.Focus();
            }
            else
            {
                DialogResult result = MessageBox.Show("Producto no encontrado, ¿Desea crear un nuevo Registro?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    frmInventarioMantenimiento datos = new frmInventarioMantenimiento();
                    
                    datos.Text = "Nuevo Producto";
                    datos.ShowDialog();
                }
                else if (result == DialogResult.No)
                {
                    limpiar();
                }
            }

        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                buscarproducto();
            }
        }

        
        private void realizar_ingreso()
        {
            DialogResult result = MessageBox.Show("¿Desea Ingresar Al Inventario?", "-AVISO-", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                try
                {
                    MySqlParameter[] registro = new MySqlParameter[]{
                    new MySqlParameter("codigo_prod",textEdit1.Text.ToString()),
                    new MySqlParameter("id_usuario",user.ToString()),
                    new MySqlParameter("cantidad",textEdit2.Text.ToString()),
                    new MySqlParameter("fecha",dateTimePicker1.Value),
                };
                    conexion.fnobjEjecutarProcedimientoEscalar("ingreso_producto", registro);
                    MessageBox.Show("Ingreso Exitoso", "- Ingreso Producto -", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se produjo el siguiente error: " + ex);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            realizar_ingreso();                   
        }

        private void limpiar()
        {
            textEdit1.Text = "";
            textEdit2.Text = "";
            dateTimePicker1.Value = System.DateTime.Now;
            textEdit3.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            textEdit1.Focus();
        }

        private void textEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                realizar_ingreso();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            realizar_ingreso();
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mostrarform()
        {
            frmIngresoBusqueda busqueda = new frmIngresoBusqueda();
            busqueda.identificar("ingreso");
            busqueda.ShowDialog();
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            mostrarform();   
        }

        public void mensaje(string valor)
        {
            textEdit1.Text = valor;
            SendKeys.Send("{tab}");
            SendKeys.Send("{tab}");
            SendKeys.Send("{tab}");
            SendKeys.Send("{enter}");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Reportes.rptIngresos report = new Reportes.rptIngresos();
            report.llenarreporte((System.DateTime.Now.ToString("yyyy/MM/dd")));
            report.lblFecha.Text = dateTimePicker1.Text;
            report.ShowPreview();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frmMermaMostrar mostrar_ingreso = new frmMermaMostrar();
            mostrar_ingreso.ShowDialog();
        }

        
    }
}