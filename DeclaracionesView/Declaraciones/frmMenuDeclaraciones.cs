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

namespace DeclaracionesView.Declaraciones
{
    public partial class frmMenuDeclaraciones : Form
    {
        public frmMenuDeclaraciones()
        {
            InitializeComponent();
        }
        public void NewWindow()
        {
            this.Dock = DockStyle.Fill;
            this.Show();
        }
        private void tsmiDecCom_Click(object sender, EventArgs e)
        {
            this.InstanciarRegistroCompras();
        }

        private void tsmiDecVen_Click(object sender, EventArgs e)
        {
            this.InstanciarRegistroVentas();
        }
        public void InstanciarRegistroCompras()
        {
            frmDeclaracionesCompras win = new frmDeclaracionesCompras();
            this.FormatoVentanaHijoPrincipal(win, this.tsmiDecCom, null, 0, 0);
            win.NuevaVentana();
        }
        public void InstanciarRegistroVentas()
        {
            frmDeclaracionesVentas win = new frmDeclaracionesVentas();
            this.FormatoVentanaHijoPrincipal(win, this.tsmiDecVen, null, 0, 0);
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


    }
}
