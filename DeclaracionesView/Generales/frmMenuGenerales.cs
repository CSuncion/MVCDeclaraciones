using DeclaracionesView.Maestros;
using DeclaracionesView.MdiPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles.ControlesWindows;

namespace DeclaracionesView.Generales
{
    public partial class frmMenuGenerales : Form
    {
        public frmMenuGenerales()
        {
            InitializeComponent();
        }

        #region Eventos
        private void tsmiPeriodos_Click(object sender, EventArgs e)
        {
            this.InstanciarPeriodos();

        }
        private void tsmiEmpresas_Click(object sender, EventArgs e)
        {
            this.InstanciarEmpresas();
        }
        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmMenuGenerales_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }
        private void tsmiAuxiliares_Click(object sender, EventArgs e)
        {
            this.InstanciarAuxiliar();
        }
        private void tsmiTipCambio_Click(object sender, EventArgs e)
        {
            this.InstanciarTipoCambio();
        }
        #endregion

        #region Metodos
        public void NewWindow()
        {
            this.Dock = DockStyle.Fill;
            this.Show();
        }
        public void InstanciarPeriodos()
        {
            frmPeriodos win = new frmPeriodos();
            this.FormatoVentanaHijoPrincipal(win, this.tsmiPeriodos, null, 0, 0);
            win.NuevaVentana();
        }
        public void InstanciarEmpresas()
        {
            frmEmpresas win = new frmEmpresas();
            this.FormatoVentanaHijoPrincipal(win, this.tsmiEmpresas, null, 0, 0);
            win.NuevaVentana();
        }
        public void InstanciarAuxiliar()
        {
            frmAuxiliar win = new frmAuxiliar();
            this.FormatoVentanaHijoPrincipal(win, this.tsmiAuxiliar, null, 0, 0);
            win.NuevaVentana();
        }
        public void InstanciarTipoCambio()
        {
            frmTipoCambio win = new frmTipoCambio();
            this.FormatoVentanaHijoPrincipal(win, this.tsmiTipCambio, null, 90, 90);
            win.NuevaVentana();
        }
        public void FormatoVentanaHijoPrincipal(Form pWin, ToolStripMenuItem pItem, ToolStripButton pAccDir, int PAncVen, int pAltVen)
        {
            pItem.Enabled = false;
            if (pAccDir != null) { pAccDir.Enabled = false; }
            this.tbcSubContenedor.Visible = true;
            //this.BackColor = System.Drawing.SystemColors.Control;
            this.BackColor = Color.White;
            TabCtrl.InsertarVentanaConTabPage(this.tbcSubContenedor, pWin, PAncVen, pAltVen);
        }
        public void CerrarVentanaHijo(Form pWin, ToolStripMenuItem pItem, ToolStripButton pAccDir)
        {
            pItem.Enabled = true;
            if (pAccDir != null) { pAccDir.Enabled = true; }
            TabCtrl.EliminarTabPageAlCerrarVentana(this.tbcSubContenedor, pWin);
            if (this.tbcSubContenedor.TabPages.Count == 0)
            {
                this.tbcSubContenedor.Visible = false;
                this.BackColor = Color.Gray;
            }
        }
        public void Cerrar()
        {
            //obtener al wMenu
            frmPrincipal wMen = (frmPrincipal)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.btnGenerales, null);
        }


        #endregion


    }
}
