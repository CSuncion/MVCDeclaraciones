namespace DeclaracionesView.Declaraciones
{
    partial class frmMenuDeclaraciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuDeclaraciones));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiDecCom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDecVen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.tbcSubContenedor = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.tsBtnSalir});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 23);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDecCom,
            this.tsmiDecVen});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(140, 20);
            this.toolStripDropDownButton1.Text = "Registros Contables";
            // 
            // tsmiDecCom
            // 
            this.tsmiDecCom.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDecCom.Image")));
            this.tsmiDecCom.Name = "tsmiDecCom";
            this.tsmiDecCom.Size = new System.Drawing.Size(180, 22);
            this.tsmiDecCom.Text = "Registro Compras";
            this.tsmiDecCom.Click += new System.EventHandler(this.tsmiDecCom_Click);
            // 
            // tsmiDecVen
            // 
            this.tsmiDecVen.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDecVen.Image")));
            this.tsmiDecVen.Name = "tsmiDecVen";
            this.tsmiDecVen.Size = new System.Drawing.Size(180, 22);
            this.tsmiDecVen.Text = "Registro Ventas";
            this.tsmiDecVen.Click += new System.EventHandler(this.tsmiDecVen_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(49, 20);
            this.tsBtnSalir.Text = "Salir";
            // 
            // tbcSubContenedor
            // 
            this.tbcSubContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcSubContenedor.Location = new System.Drawing.Point(0, 23);
            this.tbcSubContenedor.Name = "tbcSubContenedor";
            this.tbcSubContenedor.SelectedIndex = 0;
            this.tbcSubContenedor.Size = new System.Drawing.Size(800, 427);
            this.tbcSubContenedor.TabIndex = 2;
            // 
            // frmMenuDeclaraciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.tbcSubContenedor);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenuDeclaraciones";
            this.Text = "Registros";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        internal System.Windows.Forms.ToolStripMenuItem tsmiDecCom;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.TabControl tbcSubContenedor;
        internal System.Windows.Forms.ToolStripMenuItem tsmiDecVen;
    }
}