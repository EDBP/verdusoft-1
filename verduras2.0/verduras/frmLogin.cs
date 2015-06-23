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
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable datos = conexion.fnEjecutarConsulta("SELECT * FROM usuario WHERE usuario= '" + txtUsuario.Text + "'");
            if (datos.Rows.Count > 0)
            {
                if (datos.Rows[0][3].ToString().Equals(txtContraseña.Text))
                {
                    frmPrincipal principal = new frmPrincipal(this);
                    principal.identificarusuario(int.Parse(datos.Rows[0][0].ToString()));
                    
                    if (datos.Rows[0][9].ToString().Equals("0"))
                    {
                        principal.barButtonUsuarios.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    principal.Show();
                    this.Hide(); //Por el momento solamente se esconderá ésta ventana.
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta");
                    txtUsuario.Focus();
                }
            }
            else
            {
                MessageBox.Show("Usuario no existe");
                txtUsuario.Focus();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}