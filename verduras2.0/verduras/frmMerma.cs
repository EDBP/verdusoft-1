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
    public partial class frmMerma : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtbuscarproducto;
        public int user = 1;

        private static frmMerma m_FormDefInstance;
        public static frmMerma DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmMerma();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public frmMerma()
        {
            InitializeComponent();
        }

        public void identificarusuario(int quien)
        {
            user = quien;
        }

        public void buscarproducto()
        {
            dtbuscarproducto = conexion.fnEjecutarConsulta("SELECT * FROM inventario Where codigo_producto='" + textEdit1.Text + "'");
            if (dtbuscarproducto.Rows.Count != 0)
            {
                textEdit4.Text = dtbuscarproducto.Rows[0]["nombre_producto"].ToString();
                textEdit5.Text = dtbuscarproducto.Rows[0]["existencia"].ToString();
                textEdit6.Text = dtbuscarproducto.Rows[0]["precio_unitario"].ToString();
                textEdit2.Focus();
            }
            else
            {
                MessageBox.Show("Producto no encontrado... ", "¡Error!", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                limpiar();                
            }
        }

        private void limpiar()
        {
            textEdit1.Text = "";
            textEdit2.Text = "";
            dateTimePicker1.Value = System.DateTime.Now;
            memoEdit1.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            textEdit6.Text = "";
            textEdit1.Focus();
        }


        
        private void realizar_merma()
        {
            DialogResult result = MessageBox.Show("¿Desea descargar de Inventario?", "-AVISO-", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (result == DialogResult.Yes)
            {
                try
                {
                    MySqlParameter[] registro = new MySqlParameter[]{
                    new MySqlParameter("codigo_prod",textEdit1.Text.ToString()),
                    new MySqlParameter("id_usuario",user.ToString()),//************************
                    new MySqlParameter("cantidad",textEdit2.Text.ToString()),
                    new MySqlParameter("fecha",dateTimePicker1.Value),
                    new MySqlParameter("motivo",memoEdit1.Text.ToString()),
                };
                    conexion.fnobjEjecutarProcedimientoEscalar("descarga_producto", registro);
                    MessageBox.Show("Descarga Realizada", "-Descarga de Inventario-", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se produjo el siguiente error: " + ex);
                }
            }
            else
            {
                limpiar();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            realizar_merma();
        }

      
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textEdit1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                buscarproducto();
            }
        }

        private void textEdit2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                memoEdit1.Focus();
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            String fecha = System.DateTime.Now.Date.Year + "-" + System.DateTime.Now.Date.Month + "-" +
                                System.DateTime.Now.Date.Day;
            Reportes.rptMermas report = new Reportes.rptMermas();
            report.lblFecha.Text = System.DateTime.Now.ToString();
            report.gridControl1.DataSource = conexion.fnEjecutarConsulta("select " +
                                                            "m.codigo_producto as CÓDIGO, " +
                                                            "i.nombre_producto as PRODUCTO, " +
                                                            "m.cantidad as CANTIDAD, " +
                                                            "m.motivo as MOTIVO, " +
                                                            "u.usuario as ENCARGADO " +
                                                            "from verdureria.merma m, verdureria.usuario u, verdureria.inventario i " +
                                                            "where m.id_usuario=u.id_usuario and m.codigo_producto=i.codigo_producto and m.fecha = '" + fecha + "'");
            report.ShowPreview();
            
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frmMermaMostradas mostrar_merma = new frmMermaMostradas();
            mostrar_merma.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

    }
}