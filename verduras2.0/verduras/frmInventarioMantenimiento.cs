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
    public partial class frmInventarioMantenimiento : DevExpress.XtraEditors.XtraForm
    {
        int idproducto;
        public frmInventarioMantenimiento()
        {
            InitializeComponent();
            
        }
        public frmInventarioMantenimiento(DataRow datos_inventario)
        {
            InitializeComponent();
            textEdit1.Text = datos_inventario.ItemArray[0].ToString();
            textEdit2.Text = datos_inventario.ItemArray[1].ToString();
            textEdit3.Text = datos_inventario.ItemArray[2].ToString();
            textEdit4.Text = datos_inventario.ItemArray[3].ToString();
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (simpleButton1.Text == "Guardar Cambios")
            {
                guardarcambios();
            }
            else
            {
                guardarNuevo();
            }
        }

        private void guardarcambios()
        {
            try
            {
                string guardar = "UPDATE inventario SET codigo_producto= '" +textEdit1.Text + "',nombre_producto='" +textEdit2.Text + "',existencia='" +textEdit3.Text + "',precio_unitario= '"+textEdit4.Text + "' WHERE codigo_producto= "+idproducto;
                conexion.fnEjecutarComando(guardar);
                MessageBox.Show("Producto Modificado Exitosamente!","Modificación",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo el siguiente error: " + ex);
            }
            frmInventario.DefInstance.actualizar();
            Close();
        }

        private void guardarNuevo()
        {   
            string guardar = "INSERT INTO inventario(codigo_producto,nombre_producto,existencia,precio_unitario) " +
                "VALUES(" + textEdit1.Text +
                ",'" + textEdit2.Text +
                "','" + textEdit3.Text +
                "','" + textEdit4.Text  + "')";
            conexion.fnEjecutarComando(guardar);
            MessageBox.Show("Nuevo Producto Agregado", "-Agregar-", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            frmInventario.DefInstance.actualizar();
            Close();
        }

        private void frmInventarioMantenimiento_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void frmInventarioMantenimiento_Load(object sender, EventArgs e)
        {
            if (this.Text == "-'- Editar Producto -'-")
            {
                simpleButton1.Text = "Guardar Cambios";
                idproducto = int.Parse(textEdit1.Text);
            }
            else
            {
                simpleButton1.Text = "Guardar Nuevo";
            }
        }
    }

}