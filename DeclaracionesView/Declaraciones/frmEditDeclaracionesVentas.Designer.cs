namespace DeclaracionesView.Declaraciones
{
    partial class frmEditDeclaracionesVentas
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
            this.dtpFecEmiRegVen = new System.Windows.Forms.DateTimePicker();
            this.lblFecRegConCab = new System.Windows.Forms.Label();
            this.txtNumRegVen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodAux = new System.Windows.Forms.TextBox();
            this.txtPerRegVen = new System.Windows.Forms.TextBox();
            this.txtDesAux = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTipCam = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodMonSyD = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbMon = new System.Windows.Forms.ComboBox();
            this.txtSerDoc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCTipDoc = new System.Windows.Forms.TextBox();
            this.txtNTipDoc = new System.Windows.Forms.TextBox();
            this.dtpFecVenRegVen = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodUnOp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBasImpo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtImpGral = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtImpTot = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFecEmiRegVen
            // 
            this.dtpFecEmiRegVen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecEmiRegVen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecEmiRegVen.Location = new System.Drawing.Point(562, 48);
            this.dtpFecEmiRegVen.Name = "dtpFecEmiRegVen";
            this.dtpFecEmiRegVen.Size = new System.Drawing.Size(100, 20);
            this.dtpFecEmiRegVen.TabIndex = 421;
            this.dtpFecEmiRegVen.Validated += new System.EventHandler(this.dtpFecEmiRegVen_Validated);
            // 
            // lblFecRegConCab
            // 
            this.lblFecRegConCab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecRegConCab.AutoSize = true;
            this.lblFecRegConCab.Location = new System.Drawing.Point(475, 55);
            this.lblFecRegConCab.Name = "lblFecRegConCab";
            this.lblFecRegConCab.Size = new System.Drawing.Size(79, 13);
            this.lblFecRegConCab.TabIndex = 420;
            this.lblFecRegConCab.Text = "Fecha Emision:";
            // 
            // txtNumRegVen
            // 
            this.txtNumRegVen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumRegVen.Location = new System.Drawing.Point(562, 18);
            this.txtNumRegVen.MaxLength = 4;
            this.txtNumRegVen.Name = "txtNumRegVen";
            this.txtNumRegVen.ReadOnly = true;
            this.txtNumRegVen.Size = new System.Drawing.Size(100, 20);
            this.txtNumRegVen.TabIndex = 411;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 410;
            this.label3.Text = "Numero :";
            // 
            // txtCodAux
            // 
            this.txtCodAux.Location = new System.Drawing.Point(119, 84);
            this.txtCodAux.Name = "txtCodAux";
            this.txtCodAux.Size = new System.Drawing.Size(86, 20);
            this.txtCodAux.TabIndex = 418;
            this.txtCodAux.DoubleClick += new System.EventHandler(this.txtCodAux_DoubleClick);
            this.txtCodAux.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAux_KeyDown);
            this.txtCodAux.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAux_Validating);
            // 
            // txtPerRegVen
            // 
            this.txtPerRegVen.Location = new System.Drawing.Point(119, 18);
            this.txtPerRegVen.MaxLength = 4;
            this.txtPerRegVen.Name = "txtPerRegVen";
            this.txtPerRegVen.ReadOnly = true;
            this.txtPerRegVen.Size = new System.Drawing.Size(127, 20);
            this.txtPerRegVen.TabIndex = 409;
            // 
            // txtDesAux
            // 
            this.txtDesAux.Location = new System.Drawing.Point(215, 84);
            this.txtDesAux.Name = "txtDesAux";
            this.txtDesAux.ReadOnly = true;
            this.txtDesAux.Size = new System.Drawing.Size(231, 20);
            this.txtDesAux.TabIndex = 419;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 388;
            this.label2.Text = "Periodo :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor / Cliente :";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtTipCam);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCodMonSyD);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtNumDoc);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbMon);
            this.groupBox1.Controls.Add(this.txtSerDoc);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCTipDoc);
            this.groupBox1.Controls.Add(this.txtNTipDoc);
            this.groupBox1.Controls.Add(this.dtpFecVenRegVen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCodUnOp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpFecEmiRegVen);
            this.groupBox1.Controls.Add(this.lblFecRegConCab);
            this.groupBox1.Controls.Add(this.txtNumRegVen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCodAux);
            this.groupBox1.Controls.Add(this.txtPerRegVen);
            this.groupBox1.Controls.Add(this.txtDesAux);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(11, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 198);
            this.groupBox1.TabIndex = 388;
            this.groupBox1.TabStop = false;
            // 
            // txtTipCam
            // 
            this.txtTipCam.Location = new System.Drawing.Point(398, 158);
            this.txtTipCam.MaxLength = 10;
            this.txtTipCam.Name = "txtTipCam";
            this.txtTipCam.Size = new System.Drawing.Size(76, 20);
            this.txtTipCam.TabIndex = 453;
            this.txtTipCam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(475, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 432;
            this.label8.Text = "N°.Documento :";
            // 
            // txtCodMonSyD
            // 
            this.txtCodMonSyD.BackColor = System.Drawing.SystemColors.Control;
            this.txtCodMonSyD.Location = new System.Drawing.Point(478, 158);
            this.txtCodMonSyD.Name = "txtCodMonSyD";
            this.txtCodMonSyD.Size = new System.Drawing.Size(11, 20);
            this.txtCodMonSyD.TabIndex = 451;
            this.txtCodMonSyD.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(349, 165);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(33, 13);
            this.label20.TabIndex = 452;
            this.label20.Text = "T.C. :";
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumDoc.Location = new System.Drawing.Point(588, 125);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(74, 20);
            this.txtNumDoc.TabIndex = 431;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 430;
            this.label7.Text = "Serie :";
            // 
            // cmbMon
            // 
            this.cmbMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMon.Location = new System.Drawing.Point(119, 162);
            this.cmbMon.Name = "cmbMon";
            this.cmbMon.Size = new System.Drawing.Size(93, 21);
            this.cmbMon.TabIndex = 450;
            // 
            // txtSerDoc
            // 
            this.txtSerDoc.Location = new System.Drawing.Point(398, 124);
            this.txtSerDoc.Name = "txtSerDoc";
            this.txtSerDoc.Size = new System.Drawing.Size(48, 20);
            this.txtSerDoc.TabIndex = 429;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 449;
            this.label13.Text = "Moneda :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 428;
            this.label6.Text = "Tipo Documento :";
            // 
            // txtCTipDoc
            // 
            this.txtCTipDoc.Location = new System.Drawing.Point(119, 124);
            this.txtCTipDoc.Name = "txtCTipDoc";
            this.txtCTipDoc.Size = new System.Drawing.Size(33, 20);
            this.txtCTipDoc.TabIndex = 426;
            this.txtCTipDoc.DoubleClick += new System.EventHandler(this.txtCTipDoc_DoubleClick);
            this.txtCTipDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCTipDoc_KeyDown);
            this.txtCTipDoc.Validating += new System.ComponentModel.CancelEventHandler(this.txtCTipDoc_Validating);
            // 
            // txtNTipDoc
            // 
            this.txtNTipDoc.Location = new System.Drawing.Point(158, 124);
            this.txtNTipDoc.Name = "txtNTipDoc";
            this.txtNTipDoc.ReadOnly = true;
            this.txtNTipDoc.Size = new System.Drawing.Size(168, 20);
            this.txtNTipDoc.TabIndex = 427;
            // 
            // dtpFecVenRegVen
            // 
            this.dtpFecVenRegVen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecVenRegVen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecVenRegVen.Location = new System.Drawing.Point(562, 80);
            this.dtpFecVenRegVen.Name = "dtpFecVenRegVen";
            this.dtpFecVenRegVen.Size = new System.Drawing.Size(100, 20);
            this.dtpFecVenRegVen.TabIndex = 425;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(475, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 424;
            this.label5.Text = "Fecha Venc.:";
            // 
            // txtCodUnOp
            // 
            this.txtCodUnOp.Location = new System.Drawing.Point(119, 52);
            this.txtCodUnOp.Name = "txtCodUnOp";
            this.txtCodUnOp.Size = new System.Drawing.Size(86, 20);
            this.txtCodUnOp.TabIndex = 423;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 422;
            this.label4.Text = "CUO :";
            // 
            // txtBasImpo
            // 
            this.txtBasImpo.Location = new System.Drawing.Point(108, 32);
            this.txtBasImpo.Name = "txtBasImpo";
            this.txtBasImpo.Size = new System.Drawing.Size(86, 20);
            this.txtBasImpo.TabIndex = 434;
            this.txtBasImpo.Validated += new System.EventHandler(this.txtBasImpo_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 433;
            this.label9.Text = "Base Imponible :";
            // 
            // txtImpGral
            // 
            this.txtImpGral.Location = new System.Drawing.Point(108, 60);
            this.txtImpGral.Name = "txtImpGral";
            this.txtImpGral.Size = new System.Drawing.Size(86, 20);
            this.txtImpGral.TabIndex = 436;
            this.txtImpGral.Validated += new System.EventHandler(this.txtImpGral_Validated);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 435;
            this.label10.Text = "Impuesto General :";
            // 
            // txtImpTot
            // 
            this.txtImpTot.Location = new System.Drawing.Point(108, 86);
            this.txtImpTot.Name = "txtImpTot";
            this.txtImpTot.Size = new System.Drawing.Size(86, 20);
            this.txtImpTot.TabIndex = 438;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 437;
            this.label11.Text = "Importe Total :";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtImpTot);
            this.groupBox2.Controls.Add(this.txtBasImpo);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtImpGral);
            this.groupBox2.Location = new System.Drawing.Point(491, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 127);
            this.groupBox2.TabIndex = 439;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Totales";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.DarkGray;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(-1, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(741, 14);
            this.label12.TabIndex = 440;
            this.label12.Text = "Datos ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(487, 363);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 442;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(601, 363);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 441;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmEditDeclaracionesVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 431);
            this.ControlBox = false;
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEditDeclaracionesVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Registro Ventas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditDeclaracionesVentas_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpFecEmiRegVen;
        private System.Windows.Forms.Label lblFecRegConCab;
        internal System.Windows.Forms.TextBox txtNumRegVen;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtCodAux;
        internal System.Windows.Forms.TextBox txtPerRegVen;
        private System.Windows.Forms.TextBox txtDesAux;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtSerDoc;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtCTipDoc;
        private System.Windows.Forms.TextBox txtNTipDoc;
        private System.Windows.Forms.DateTimePicker dtpFecVenRegVen;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtCodUnOp;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtBasImpo;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtImpGral;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtImpTot;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        internal System.Windows.Forms.TextBox txtTipCam;
        internal System.Windows.Forms.TextBox txtCodMonSyD;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbMon;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}