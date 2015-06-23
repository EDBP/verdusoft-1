namespace verduras
{
    partial class rptFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.cantidad = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.descripcion = new DevExpress.XtraReports.UI.XRTableCell();
            this.punitario = new DevExpress.XtraReports.UI.XRTableCell();
            this.stotal = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.fdia = new DevExpress.XtraReports.UI.XRLabel();
            this.fanio = new DevExpress.XtraReports.UI.XRLabel();
            this.fmes = new DevExpress.XtraReports.UI.XRLabel();
            this.nit = new DevExpress.XtraReports.UI.XRLabel();
            this.direccion = new DevExpress.XtraReports.UI.XRLabel();
            this.nombre = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.total = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.subtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.lsubtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.descuento = new DevExpress.XtraReports.UI.XRLabel();
            this.ldescuento = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.HeightF = 19.16667F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-07F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(452.5001F, 19.16667F);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cantidad,
            this.xrTableCell1,
            this.descripcion,
            this.punitario,
            this.stotal});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // cantidad
            // 
            this.cantidad.Name = "cantidad";
            this.cantidad.StylePriority.UseTextAlignment = false;
            this.cantidad.Text = "cantidad";
            this.cantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cantidad.Weight = 0.37916675567626951D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = " ";
            this.xrTableCell1.Weight = 0.13125D;
            // 
            // descripcion
            // 
            this.descripcion.Name = "descripcion";
            this.descripcion.Text = "descripcion";
            this.descripcion.Weight = 2.5208333189085841D;
            // 
            // punitario
            // 
            this.punitario.Name = "punitario";
            this.punitario.StylePriority.UseTextAlignment = false;
            this.punitario.Text = "punitario";
            this.punitario.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.punitario.Weight = 0.61458343488768619D;
            // 
            // stotal
            // 
            this.stotal.Name = "stotal";
            this.stotal.StylePriority.UseTextAlignment = false;
            this.stotal.Text = "stotal";
            this.stotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.stotal.Weight = 0.8791674802978523D;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.fdia,
            this.fanio,
            this.fmes,
            this.nit,
            this.direccion,
            this.nombre});
            this.TopMargin.HeightF = 248F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fdia
            // 
            this.fdia.LocationFloat = new DevExpress.Utils.PointFloat(123.9584F, 138.7917F);
            this.fdia.Name = "fdia";
            this.fdia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fdia.SizeF = new System.Drawing.SizeF(63.95837F, 23F);
            this.fdia.Text = "xrLabel1";
            // 
            // fanio
            // 
            this.fanio.LocationFloat = new DevExpress.Utils.PointFloat(251.875F, 138.7917F);
            this.fanio.Name = "fanio";
            this.fanio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fanio.SizeF = new System.Drawing.SizeF(63.95837F, 23F);
            this.fanio.Text = "xrLabel1";
            // 
            // fmes
            // 
            this.fmes.LocationFloat = new DevExpress.Utils.PointFloat(187.9167F, 138.7917F);
            this.fmes.Name = "fmes";
            this.fmes.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fmes.SizeF = new System.Drawing.SizeF(63.95837F, 23F);
            this.fmes.Text = "xrLabel1";
            // 
            // nit
            // 
            this.nit.LocationFloat = new DevExpress.Utils.PointFloat(376.0417F, 184.7917F);
            this.nit.Name = "nit";
            this.nit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.nit.SizeF = new System.Drawing.SizeF(76.45837F, 23F);
            this.nit.Text = "xrLabel1";
            // 
            // direccion
            // 
            this.direccion.LocationFloat = new DevExpress.Utils.PointFloat(70.83334F, 184.7917F);
            this.direccion.Name = "direccion";
            this.direccion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.direccion.SizeF = new System.Drawing.SizeF(281.25F, 23F);
            this.direccion.Text = "xrLabel1";
            // 
            // nombre
            // 
            this.nombre.LocationFloat = new DevExpress.Utils.PointFloat(70.83334F, 161.7917F);
            this.nombre.Name = "nombre";
            this.nombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.nombre.SizeF = new System.Drawing.SizeF(381.25F, 23F);
            this.nombre.Text = "xrLabel1";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 38F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // total
            // 
            this.total.LocationFloat = new DevExpress.Utils.PointFloat(376.0417F, 53.04165F);
            this.total.Name = "total";
            this.total.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.total.SizeF = new System.Drawing.SizeF(76.45837F, 20F);
            this.total.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:c}";
            this.total.Summary = xrSummary1;
            this.total.Text = "total";
            this.total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLine2,
            this.xrLine1,
            this.descuento,
            this.ldescuento,
            this.lsubtotal,
            this.subtotal,
            this.total});
            this.PageFooter.HeightF = 99.99998F;
            this.PageFooter.Name = "PageFooter";
            // 
            // subtotal
            // 
            this.subtotal.LocationFloat = new DevExpress.Utils.PointFloat(375.625F, 2F);
            this.subtotal.Name = "subtotal";
            this.subtotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.subtotal.SizeF = new System.Drawing.SizeF(76.45837F, 18F);
            this.subtotal.StylePriority.UseTextAlignment = false;
            xrSummary6.FormatString = "{0:c}";
            this.subtotal.Summary = xrSummary6;
            this.subtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.subtotal.Visible = false;
            // 
            // lsubtotal
            // 
            this.lsubtotal.LocationFloat = new DevExpress.Utils.PointFloat(50.62491F, 2F);
            this.lsubtotal.Name = "lsubtotal";
            this.lsubtotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lsubtotal.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.lsubtotal.StylePriority.UseTextAlignment = false;
            xrSummary5.FormatString = "{0:c}";
            this.lsubtotal.Summary = xrSummary5;
            this.lsubtotal.Text = "Sub Total...";
            this.lsubtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lsubtotal.Visible = false;
            // 
            // descuento
            // 
            this.descuento.LocationFloat = new DevExpress.Utils.PointFloat(376.0417F, 20.49998F);
            this.descuento.Name = "descuento";
            this.descuento.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.descuento.SizeF = new System.Drawing.SizeF(76.04163F, 18F);
            this.descuento.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:c}";
            this.descuento.Summary = xrSummary3;
            this.descuento.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.descuento.Visible = false;
            // 
            // ldescuento
            // 
            this.ldescuento.LocationFloat = new DevExpress.Utils.PointFloat(51.04167F, 20.49998F);
            this.ldescuento.Name = "ldescuento";
            this.ldescuento.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ldescuento.SizeF = new System.Drawing.SizeF(200F, 18F);
            this.ldescuento.StylePriority.UseTextAlignment = false;
            xrSummary4.FormatString = "{0:c}";
            this.ldescuento.Summary = xrSummary4;
            this.ldescuento.Text = "Descuento";
            this.ldescuento.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.ldescuento.Visible = false;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(351.0417F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(110.4167F, 2F);
            this.xrLine1.Visible = false;
            // 
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(351.0416F, 51.04163F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(110.4167F, 2F);
            this.xrLine2.Visible = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(51.04168F, 53.04165F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(76.45837F, 20F);
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:c}";
            this.xrLabel1.Summary = xrSummary2;
            this.xrLabel1.Text = "TOTAL";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // rptFactura
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageFooter});
            this.DisplayName = "Factura";
            this.Margins = new System.Drawing.Printing.Margins(38, 38, 248, 38);
            this.PageHeight = 795;
            this.PageWidth = 551;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "12.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        public DevExpress.XtraReports.UI.XRTableCell cantidad;
        public DevExpress.XtraReports.UI.XRTableCell descripcion;
        public DevExpress.XtraReports.UI.XRTableCell punitario;
        public DevExpress.XtraReports.UI.XRLabel nit;
        public DevExpress.XtraReports.UI.XRLabel direccion;
        public DevExpress.XtraReports.UI.XRLabel nombre;
        public DevExpress.XtraReports.UI.XRLabel fdia;
        public DevExpress.XtraReports.UI.XRLabel fanio;
        public DevExpress.XtraReports.UI.XRLabel fmes;
        public DevExpress.XtraReports.UI.XRTableCell stotal;
        public DevExpress.XtraReports.UI.XRLabel total;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        public DevExpress.XtraReports.UI.XRLabel descuento;
        public DevExpress.XtraReports.UI.XRLabel ldescuento;
        public DevExpress.XtraReports.UI.XRLabel lsubtotal;
        public DevExpress.XtraReports.UI.XRLabel subtotal;
        public DevExpress.XtraReports.UI.XRLabel xrLabel1;
        public DevExpress.XtraReports.UI.XRLine xrLine1;
        public DevExpress.XtraReports.UI.XRLine xrLine2;
    }
}
