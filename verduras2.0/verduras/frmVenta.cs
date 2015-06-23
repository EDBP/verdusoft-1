using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace verduras
{
    public partial class frmVenta : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtbuscarproducto;
        public int user = 1;
        double desc = 0.00;

        public frmVenta()
        {
            InitializeComponent();
        }
        public void identificarusuario(int quien)
        {
            user = quien;
        }

        private static frmVenta m_FormDefInstance;
        public static frmVenta DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmVenta();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }


        public void buscarproducto()
        {
            dtbuscarproducto = conexion.fnEjecutarConsulta("SELECT * FROM inventario Where codigo_producto='"+textEdit1.Text+"'");
            if (dtbuscarproducto.Rows.Count != 0)
            {
                textEdit3.Text = dtbuscarproducto.Rows[0]["nombre_producto"].ToString();
                textEdit4.Text = dtbuscarproducto.Rows[0]["precio_unitario"].ToString();
                textEdit5.Text = dtbuscarproducto.Rows[0]["existencia"].ToString();
                textEdit2.Focus();
            }
            else
            {
                MessageBox.Show("Codigo de Producto No encontrado", "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Information);
                limpiar();
            }
        }
        int id_cliente;
        public void buscarcliente()
        {
            dtbuscarproducto = conexion.fnEjecutarConsulta("SELECT * FROM cliente Where nit='" + textEdit6.Text + "'");
            if (dtbuscarproducto.Rows.Count != 0)
            {
                id_cliente = int.Parse(dtbuscarproducto.Rows[0]["codigo_cliente"].ToString());
                textEdit7.Text = dtbuscarproducto.Rows[0]["nombres"].ToString() + " " + dtbuscarproducto.Rows[0]["apellidos"].ToString();
                textEdit9.Text = dtbuscarproducto.Rows[0]["direccion"].ToString();
            }
            else
            {
                DialogResult result = MessageBox.Show("No encontrado, ¿Desea crear un nuevo cliente?", "Aviso", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    frmClientesMantenimiento datos = new frmClientesMantenimiento();
                    datos.Text = "Nuevo Cliente";
                    datos.ShowDialog();
                }
                else if (result == DialogResult.No)
                {
                }
                
                
                
            }
        }

      
        private void textEdit1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                buscarproducto();
            }
        }
        private void limpiar()
        {
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            textEdit1.Focus();
        }
        private void nueva_venta()
        {
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            textEdit6.Text = "";
            textEdit7.Text = "";
            dataGridView1.Rows.Clear();
            textEdit9.Text = "";
            textEdit10.Text = "0.00";
            simpleButton2.Enabled = true;
            textEdit6.Focus();
            desc = 0.00;
        }
        private void textEdit2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
               
                    float subtotal = 0;
                    subtotal += float.Parse(textEdit2.Text) * float.Parse(textEdit4.Text);

                    float total = float.Parse(textEdit10.Text);
                    total += float.Parse(textEdit2.Text) * float.Parse(textEdit4.Text);
                    textEdit10.Text = string.Format("{0:f}", total).ToString();

                    dataGridView1.Rows.Add(textEdit1.Text,
                        textEdit2.Text,
                        textEdit3.Text,
                        textEdit4.Text,
                        string.Format("{0:f}", subtotal).ToString());
                    limpiar();
                
            }
        }

        private void textEdit6_KeyPress(object sender, KeyPressEventArgs e)
        {
            string primera_cadena = "";
            string segunda_cadena = "";
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                primera_cadena = textEdit6.Text.Substring(0, (textEdit6.Text.Length - 1));
                segunda_cadena = textEdit6.Text.Substring(textEdit6.Text.Length - 1, 1);
                textEdit6.Text = primera_cadena + "-" + segunda_cadena;
                buscarcliente();
                SendKeys.Send("{TAB}");
            }
        }


        private void simpleButton1_Click_1(object sender, EventArgs e)
        { 
            MySqlParameter[] registro = new MySqlParameter[]{
                new MySqlParameter("codigo_cliente",id_cliente.ToString()),
                new MySqlParameter("id_usuario",user.ToString()),
                new MySqlParameter("fecha",dateTimePicker1.Value),
                new MySqlParameter("descuento",desc.ToString())
                                                            };
            object id_venta = -1;
            id_venta = conexion.fnobjEjecutarProcedimientoEscalar("encabezado_venta", registro);
            if (int.Parse(id_venta.ToString()) != -1)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                       try
                        { 
                           string guardar = "INSERT INTO detalle_venta(id_venta,codigo_producto,cantidad,precio_venta) " +
                                            "VALUES('" + id_venta.ToString() +
                                            "','" + row.Cells[0].Value.ToString() +
                                            "','" + row.Cells[1].Value.ToString() +
                                            "','" + row.Cells[3].Value.ToString() + "')";
                           conexion.fnEjecutarComando(guardar);

                           double disponible = double.Parse(conexion.fnEjecutarEscalar("SELECT existencia FROM inventario WHERE codigo_producto= " + row.Cells[0].Value.ToString()).ToString())-double.Parse(row.Cells[1].Value.ToString());
                        
                           string descargadeinventario = "UPDATE inventario SET existencia='" +
                                disponible + "' WHERE codigo_producto= " + row.Cells[0].Value.ToString();

                           conexion.fnEjecutarComando(descargadeinventario);
                           
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Se produjo el siguiente error: " + ex);
                        }
                    }
                }
            }
            frnVentaCobrar cobro = new frnVentaCobrar();
            cobro.recibirtotal(textEdit10.Text,desc.ToString());
            cobro.recibiventa(id_venta.ToString());
            cobro.ShowDialog();
            nueva_venta();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            float cantidad = float.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString());
            float precio   = float.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].Value.ToString());
            dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[4].Value = string.Format("{0:f}", (cantidad* precio)).ToString();
            total();
        }

        public void total()
        {
            float total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    total+=float.Parse(row.Cells[4].Value.ToString());
                }
            }
            textEdit10.Text = string.Format("{0:F}", total).ToString();
        }

        private void textEdit7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            { SendKeys.Send("{TAB}");}
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            
        }
        
        public void mensaje(string valor)
        {
            textEdit1.Text = valor;
            textEdit1.Select();
            SendKeys.Send("{tab}");
            SendKeys.Send("{enter}");
        }

        private void pictureEdit1_MouseClick(object sender, MouseEventArgs e)
        {
            frmIngresoBusqueda busqueda = new frmIngresoBusqueda();
            busqueda.identificar("venta");
            busqueda.ShowDialog();
        }

        private void textEdit9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                textEdit1.Focus();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            textEdit10.Text = String.Format("{0:F}",(double.Parse(textEdit10.Text) - (double.Parse(textEdit10.Text) * 0.10))).ToString();
            simpleButton2.Enabled = false;
            desc = 1.00;
        }
   
      

        
    }
}