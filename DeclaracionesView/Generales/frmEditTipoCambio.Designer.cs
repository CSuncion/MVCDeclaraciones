namespace DeclaracionesView.Generales
{
    partial class frmEditTipoCambio
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
            this.txtTipCamVta = new System.Windows.Forms.TextBox();
            this.txtTipCamCom = new System.Windows.Forms.TextBox();
            this.dtpFecTipCam = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbEstTipCam = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTipCamVta
            // 
            this.txtTipCamVta.Location = new System.Drawing.Point(153, 89);
            this.txtTipCamVta.MaxLength = 10;
            this.txtTipCamVta.Name = "txtTipCamVta";
            this.txtTipCamVta.Size = new System.Drawing.Size(135, 20);
            this.txtTipCamVta.TabIndex = 435;
            this.txtTipCamVta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTipCamCom
            // 
            this.txtTipCamCom.Location = new System.Drawing.Point(153, 61);
            this.txtTipCamCom.MaxLength = 10;
            this.txtTipCamCom.Name = "txtTipCamCom";
            this.txtTipCamCom.Size = new System.Drawing.Size(135, 20);
            this.txtTipCamCom.TabIndex = 434;
            this.txtTipCamCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpFecTipCam
            // 
            this.dtpFecTipCam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecTipCam.Location = new System.Drawing.Point(153, 31);
            this.dtpFecTipCam.Name = "dtpFecTipCam";
            this.dtpFecTipCam.Size = new System.Drawing.Size(135, 20);
            this.dtpFecTipCam.TabIndex = 433;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 432;
            this.label1.Text = "Tipo Cambio Venta:";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(12, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(405, 14);
            this.label21.TabIndex = 431;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(195, 159);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 430;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(309, 159);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 429;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 13);
            this.label15.TabIndex = 428;
            this.label15.Text = "Tipo Cambio Compra:";
            // 
            // cmbEstTipCam
            // 
            this.cmbEstTipCam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstTipCam.Location = new System.Drawing.Point(153, 117);
            this.cmbEstTipCam.Name = "cmbEstTipCam";
            this.cmbEstTipCam.Size = new System.Drawing.Size(135, 21);
            this.cmbEstTipCam.TabIndex = 427;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 426;
            this.label13.Text = "Estado:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 425;
            this.label11.Text = "Fecha:";
            // 
            // frmEditTipoCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 232);
            this.ControlBox = false;
            this.Controls.Add(this.txtTipCamVta);
            this.Controls.Add(this.txtTipCamCom);
            this.Controls.Add(this.dtpFecTipCam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbEstTipCam);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEditTipoCambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Tipo Cambio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditTipoCambio_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTipCamVta;
        private System.Windows.Forms.TextBox txtTipCamCom;
        internal System.Windows.Forms.DateTimePicker dtpFecTipCam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbEstTipCam;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
    }
}