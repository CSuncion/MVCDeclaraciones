namespace DeclaracionesView.Generales
{
    partial class frmMenuGenerales
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuGenerales));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiPeriodos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEmpresas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiAuxiliar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.tbcSubContenedor = new System.Windows.Forms.TabControl();
            this.tsmiTipCambio = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.tsBtnSalir});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 23);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPeriodos,
            this.tsmiEmpresas});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(77, 20);
            this.toolStripDropDownButton1.Text = "Sistema";
            // 
            // tsmiPeriodos
            // 
            this.tsmiPeriodos.Image = ((System.Drawing.Image)(resources.GetObject("tsmiPeriodos.Image")));
            this.tsmiPeriodos.Name = "tsmiPeriodos";
            this.tsmiPeriodos.Size = new System.Drawing.Size(180, 22);
            this.tsmiPeriodos.Text = "Periodos";
            this.tsmiPeriodos.Click += new System.EventHandler(this.tsmiPeriodos_Click);
            // 
            // tsmiEmpresas
            // 
            this.tsmiEmpresas.Image = ((System.Drawing.Image)(resources.GetObject("tsmiEmpresas.Image")));
            this.tsmiEmpresas.Name = "tsmiEmpresas";
            this.tsmiEmpresas.Size = new System.Drawing.Size(180, 22);
            this.tsmiEmpresas.Text = "Empresas";
            this.tsmiEmpresas.Click += new System.EventHandler(this.tsmiEmpresas_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAuxiliar,
            this.tsmiTipCambio});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(84, 20);
            this.toolStripDropDownButton2.Text = "Maestros";
            // 
            // tsmiAuxiliar
            // 
            this.tsmiAuxiliar.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAuxiliar.Image")));
            this.tsmiAuxiliar.Name = "tsmiAuxiliar";
            this.tsmiAuxiliar.Size = new System.Drawing.Size(180, 22);
            this.tsmiAuxiliar.Text = "Auxiliar";
            this.tsmiAuxiliar.Click += new System.EventHandler(this.tsmiAuxiliares_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(49, 20);
            this.tsBtnSalir.Text = "Salir";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // tbcSubContenedor
            // 
            this.tbcSubContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcSubContenedor.Location = new System.Drawing.Point(0, 23);
            this.tbcSubContenedor.Name = "tbcSubContenedor";
            this.tbcSubContenedor.SelectedIndex = 0;
            this.tbcSubContenedor.Size = new System.Drawing.Size(800, 274);
            this.tbcSubContenedor.TabIndex = 1;
            // 
            // tsmiTipCambio
            // 
            this.tsmiTipCambio.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTipCambio.Image")));
            this.tsmiTipCambio.Name = "tsmiTipCambio";
            this.tsmiTipCambio.Size = new System.Drawing.Size(180, 22);
            this.tsmiTipCambio.Text = "Tipo de Cambio";
            this.tsmiTipCambio.Click += new System.EventHandler(this.tsmiTipCambio_Click);
            // 
            // frmMenuGenerales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 297);
            this.Controls.Add(this.tbcSubContenedor);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenuGenerales";
            this.Text = "Generales";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenuGenerales_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tbcSubContenedor;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        internal System.Windows.Forms.ToolStripMenuItem tsmiPeriodos;
        internal System.Windows.Forms.ToolStripMenuItem tsmiEmpresas;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        internal System.Windows.Forms.ToolStripMenuItem tsmiAuxiliar;
        internal System.Windows.Forms.ToolStripMenuItem tsmiTipCambio;
    }
}