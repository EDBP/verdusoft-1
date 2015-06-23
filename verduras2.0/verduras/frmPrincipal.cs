using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using MySql.Data.MySqlClient;

namespace verduras
{
    public partial class frmPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Form padre;
        
        public int usuario = 1;

        public frmPrincipal(Form Padre)
        {
            this.padre = Padre;
            InitializeComponent();           
        }

        public void identificarusuario(int quien)
        {
            usuario = quien;
        }

        private void barBotonClientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmClientes.DefInstance.MdiParent = this;
            frmClientes.DefInstance.Show();
            frmClientes.DefInstance.Activate();
            frmClientes.DefInstance.BringToFront();
        }

        private void barBotonInventario_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmInventario.DefInstance.MdiParent = this;
            frmInventario.DefInstance.Show();
            frmInventario.DefInstance.Activate();
            
            frmInventario.DefInstance.BringToFront();
        }

        private void barBotonVenta_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmVenta.DefInstance.MdiParent = this;
            frmVenta.DefInstance.identificarusuario(usuario);
            frmVenta.DefInstance.Show();
            frmVenta.DefInstance.Activate();
            frmVenta.DefInstance.BringToFront();
        }

        private void barBotonIngreso_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmIngreso.DefInstance.MdiParent = this;
            frmIngreso.DefInstance.identificarusuario(usuario);
            frmIngreso.DefInstance.Show();
            frmIngreso.DefInstance.Activate();
            frmIngreso.DefInstance.BringToFront();
            
        }

        private void barBotonMerma_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMerma.DefInstance.MdiParent = this;
            frmMerma.DefInstance.identificarusuario(usuario);
            frmMerma.DefInstance.Show();
            frmMerma.DefInstance.Activate();
            frmMerma.DefInstance.BringToFront();
        }

        private void barButtonUsuarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUsuarios.DefInstance.MdiParent = this;
            frmUsuarios.DefInstance.Show();
            frmUsuarios.DefInstance.Activate();
            frmUsuarios.DefInstance.BringToFront();
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.padre.Dispose();
        }
        
        private void barBotonVerInventario_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reportes.rptInventario report = new Reportes.rptInventario();
            //report.dtAdapterInventario.getInventario();
            report.ShowPreview();
        }

        private void barBotonIngresos_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmFechaRpt.DefInstance.MdiParent = this;
            frmFechaRpt.DefInstance.settipo("ingresos");
            frmFechaRpt.DefInstance.Show();
            frmFechaRpt.DefInstance.Activate();
            frmFechaRpt.DefInstance.BringToFront();
        }
        

        private void barBtnMerma_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmFechaRpt.DefInstance.MdiParent = this;
            frmFechaRpt.DefInstance.settipo("merma");
            frmFechaRpt.DefInstance.Show();
            frmFechaRpt.DefInstance.Activate();
            frmFechaRpt.DefInstance.BringToFront();
        }

        private void barBtnVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmFechaRpt.DefInstance.MdiParent = this;
            frmFechaRpt.DefInstance.settipo("ventas");
            frmFechaRpt.DefInstance.Show();
            frmFechaRpt.DefInstance.Activate();
            frmFechaRpt.DefInstance.BringToFront();
        }

        private void barBtnConsultaFac_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmConsultaFacturas.DefInstance.MdiParent = this;
            frmConsultaFacturas.DefInstance.Show();
            frmConsultaFacturas.DefInstance.Activate();
            frmConsultaFacturas.DefInstance.BringToFront();
        }

    }
}