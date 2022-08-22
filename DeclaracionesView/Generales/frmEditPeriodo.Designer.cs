namespace DeclaracionesView.Generales
{
    partial class frmEditPeriodo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTipCamPer = new System.Windows.Forms.TextBox();
            this.cmbMesPer = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbEstPer = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAnoPer = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodPer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 90;
            this.label1.Text = "T.C.Mes:";
            // 
            // txtTipCamPer
            // 
            this.txtTipCamPer.Location = new System.Drawing.Point(84, 116);
            this.txtTipCamPer.MaxLength = 50;
            this.txtTipCamPer.Name = "txtTipCamPer";
            this.txtTipCamPer.Size = new System.Drawing.Size(78, 20);
            this.txtTipCamPer.TabIndex = 91;
            // 
            // cmbMesPer
            // 
            this.cmbMesPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesPer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMesPer.Location = new System.Drawing.Point(84, 88);
            this.cmbMesPer.Name = "cmbMesPer";
            this.cmbMesPer.Size = new System.Drawing.Size(120, 21);
            this.cmbMesPer.TabIndex = 89;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 88;
            this.label14.Text = "Mes:";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(12, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(295, 14);
            this.label21.TabIndex = 87;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(84, 176);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 86;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(198, 176);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 85;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbEstPer
            // 
            this.cmbEstPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstPer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstPer.Location = new System.Drawing.Point(84, 144);
            this.cmbEstPer.Name = "cmbEstPer";
            this.cmbEstPer.Size = new System.Drawing.Size(120, 21);
            this.cmbEstPer.TabIndex = 84;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 83;
            this.label13.Text = "Estado:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 81;
            this.label12.Text = "Año:";
            // 
            // txtAnoPer
            // 
            this.txtAnoPer.Location = new System.Drawing.Point(84, 60);
            this.txtAnoPer.MaxLength = 50;
            this.txtAnoPer.Name = "txtAnoPer";
            this.txtAnoPer.Size = new System.Drawing.Size(78, 20);
            this.txtAnoPer.TabIndex = 82;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 79;
            this.label11.Text = "Codigo:";
            // 
            // txtCodPer
            // 
            this.txtCodPer.Location = new System.Drawing.Point(84, 32);
            this.txtCodPer.MaxLength = 2;
            this.txtCodPer.Name = "txtCodPer";
            this.txtCodPer.ReadOnly = true;
            this.txtCodPer.Size = new System.Drawing.Size(78, 20);
            this.txtCodPer.TabIndex = 80;
            // 
            // frmEditPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 229);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTipCamPer);
            this.Controls.Add(this.cmbMesPer);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbEstPer);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAnoPer);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCodPer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmEditPeriodo";
            this.Text = "Editar Periodo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditPeriodo_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTipCamPer;
        private System.Windows.Forms.ComboBox cmbMesPer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbEstPer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAnoPer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodPer;
    }
}