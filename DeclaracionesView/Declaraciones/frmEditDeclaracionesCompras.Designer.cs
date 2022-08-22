namespace DeclaracionesView.Declaraciones
{
    partial class frmEditDeclaracionesCompras
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
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtImpTot = new System.Windows.Forms.TextBox();
            this.txtBasImpo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtImpGral = new System.Windows.Forms.TextBox();
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
            this.dtpFecVenRegCom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodUnOp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFecEmiRegCom = new System.Windows.Forms.DateTimePicker();
            this.lblFecRegConCab = new System.Windows.Forms.Label();
            this.txtNumRegCom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodAux = new System.Windows.Forms.TextBox();
            this.txtPerRegCom = new System.Windows.Forms.TextBox();
            this.txtDesAux = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.DarkGray;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(1, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(730, 15);
            this.label12.TabIndex = 443;
            this.label12.Text = "Datos ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.groupBox2.Location = new System.Drawing.Point(482, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 127);
            this.groupBox2.TabIndex = 442;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Totales";
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
            // txtImpTot
            // 
            this.txtImpTot.Location = new System.Drawing.Point(108, 86);
            this.txtImpTot.Name = "txtImpTot";
            this.txtImpTot.Size = new System.Drawing.Size(86, 20);
            this.txtImpTot.TabIndex = 438;
            // 
            // txtBasImpo
            // 
            this.txtBasImpo.Location = new System.Drawing.Point(108, 32);
            this.txtBasImpo.Name = "txtBasImpo";
            this.txtBasImpo.Size = new System.Drawing.Size(86, 20);
            this.txtBasImpo.TabIndex = 434;
            this.txtBasImpo.Validated += new System.EventHandler(this.txtBasImpo_Validated);
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 437;
            this.label11.Text = "Importe Total :";
            // 
            // txtImpGral
            // 
            this.txtImpGral.Location = new System.Drawing.Point(108, 60);
            this.txtImpGral.Name = "txtImpGral";
            this.txtImpGral.Size = new System.Drawing.Size(86, 20);
            this.txtImpGral.TabIndex = 436;
            this.txtImpGral.Validated += new System.EventHandler(this.txtImpGral_Validated);
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
            this.groupBox1.Controls.Add(this.dtpFecVenRegCom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCodUnOp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpFecEmiRegCom);
            this.groupBox1.Controls.Add(this.lblFecRegConCab);
            this.groupBox1.Controls.Add(this.txtNumRegCom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCodAux);
            this.groupBox1.Controls.Add(this.txtPerRegCom);
            this.groupBox1.Controls.Add(this.txtDesAux);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 198);
            this.groupBox1.TabIndex = 441;
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
            // dtpFecVenRegCom
            // 
            this.dtpFecVenRegCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecVenRegCom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecVenRegCom.Location = new System.Drawing.Point(562, 80);
            this.dtpFecVenRegCom.Name = "dtpFecVenRegCom";
            this.dtpFecVenRegCom.Size = new System.Drawing.Size(100, 20);
            this.dtpFecVenRegCom.TabIndex = 425;
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
            // dtpFecEmiRegCom
            // 
            this.dtpFecEmiRegCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecEmiRegCom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecEmiRegCom.Location = new System.Drawing.Point(562, 48);
            this.dtpFecEmiRegCom.Name = "dtpFecEmiRegCom";
            this.dtpFecEmiRegCom.Size = new System.Drawing.Size(100, 20);
            this.dtpFecEmiRegCom.TabIndex = 421;
            this.dtpFecEmiRegCom.Validated += new System.EventHandler(this.dtpFecEmiRegCom_Validated);
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
            // txtNumRegCom
            // 
            this.txtNumRegCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumRegCom.Location = new System.Drawing.Point(562, 18);
            this.txtNumRegCom.MaxLength = 4;
            this.txtNumRegCom.Name = "txtNumRegCom";
            this.txtNumRegCom.ReadOnly = true;
            this.txtNumRegCom.Size = new System.Drawing.Size(100, 20);
            this.txtNumRegCom.TabIndex = 411;
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
            // txtPerRegCom
            // 
            this.txtPerRegCom.Location = new System.Drawing.Point(119, 18);
            this.txtPerRegCom.MaxLength = 4;
            this.txtPerRegCom.Name = "txtPerRegCom";
            this.txtPerRegCom.ReadOnly = true;
            this.txtPerRegCom.Size = new System.Drawing.Size(127, 20);
            this.txtPerRegCom.TabIndex = 409;
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
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor :";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(482, 364);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 445;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(597, 364);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 444;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmEditDeclaracionesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 438);
            this.ControlBox = false;
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEditDeclaracionesCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Registro Compras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditDeclaracionesCompras_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtImpTot;
        internal System.Windows.Forms.TextBox txtBasImpo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox txtImpGral;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox txtTipCam;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtCodMonSyD;
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMon;
        internal System.Windows.Forms.TextBox txtSerDoc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtCTipDoc;
        private System.Windows.Forms.TextBox txtNTipDoc;
        private System.Windows.Forms.DateTimePicker dtpFecVenRegCom;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtCodUnOp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFecEmiRegCom;
        private System.Windows.Forms.Label lblFecRegConCab;
        internal System.Windows.Forms.TextBox txtNumRegCom;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtCodAux;
        internal System.Windows.Forms.TextBox txtPerRegCom;
        private System.Windows.Forms.TextBox txtDesAux;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}