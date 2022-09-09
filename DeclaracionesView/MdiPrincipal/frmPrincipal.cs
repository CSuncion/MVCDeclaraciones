using DeclaracionesView.Login;
//using RestaurantView.Reports;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinControles.ControlesWindows;
using System.Runtime.InteropServices;
using DeclaracionesUtil.Util;
using DeclaracionesView.Declaraciones;
using DeclaracionesView.Generales;

namespace DeclaracionesView.MdiPrincipal
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            //this.LoadTheme();
        }

        #region Events
        int lx, ly;
        int sw, sh;
        bool isSize = false;
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.NewWindowAccess();
        }
        private void btnDeclaraciones_Click(object sender, EventArgs e)
        {
            this.InstanciarDeclaraciones();
        }
        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.MaximizedWindow();
        }
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.RestoreWindow();
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        private void pnlBarTit_MouseMove(object sender, MouseEventArgs e)
        {
            WinPrincipal.ReleaseCapture();
            WinPrincipal.SendMessage(this.Handle, 0x112, 0xF012, 0);
        }
        private void tmOcultarMenu_Tick(object sender, EventArgs e)
        {
            if (this.pnlMenu.Width <= 60)
                this.tmOcultarMenu.Enabled = false;
            else
                this.pnlMenu.Width -= 40;
        }
        private void tmMostrarMenu_Tick(object sender, EventArgs e)
        {
            if (this.pnlMenu.Width >= 220)
                this.tmMostrarMenu.Enabled = false;
            else
                this.pnlMenu.Width += 40;
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (this.pnlMenu.Width == 220)
                this.tmOcultarMenu.Enabled = true;
            else if (this.pnlMenu.Width == 60)
                this.tmMostrarMenu.Enabled = true;
        }
        private void pnlBarTit_DoubleClick(object sender, EventArgs e)
        {
            if (this.isSize)
                this.RestoreWindow();
            else
                this.MaximizedWindow();

        }
        private void btnGenerales_Click(object sender, EventArgs e)
        {
            this.InstanciarGenerales();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Methods
        public void RestoreWindow()
        {
            this.isSize = false;
            this.btnRestaurar.Visible = false;
            this.btnMaximizar.Visible = true;
            //this.WindowState = FormWindowState.Normal;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }
        public void MaximizedWindow()
        {
            this.btnMaximizar.Visible = false;
            this.btnRestaurar.Visible = true;
            this.isSize = true;
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
        private void LoadTheme()
        {
            var themeColor = WinTheme.GetAccentColor();

            pnlLogo.BackColor = themeColor;
            pnlMenu.BackColor = themeColor;

            foreach (Button button in this.Controls.OfType<Button>())
            {
                button.BackColor = themeColor;
            }
            foreach (Button button in this.pnlMenu.Controls.OfType<Button>())
            {
                button.BackColor = themeColor;
            }
        }

        public void NewWindowAccess()
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.frmPrincipal = this;
            frmLogin.NewWindow();
        }
        public void EliminarTodasLasVentanasAbiertas()
        {
            //obtener la lista de ventanas a eliminar
            List<Form> iLisVenEli = this.ObtenerListaDeVentanasAbiertas();

            //obtener el numero de formularios abiertos
            int iNumeroVentanasAbiertas = iLisVenEli.Count;

            //ir eliminando cada ventana 
            for (int i = 0; i < iNumeroVentanasAbiertas; i++)
            {
                iLisVenEli[i].Close();
            }
        }
        public List<Form> ObtenerListaDeVentanasAbiertas()
        {
            //lista resultado
            List<Form> iLisRes = new List<Form>();

            //solo excepto el wMenu y el wAcceso
            foreach (Form xWin in Application.OpenForms)
            {
                if (xWin.Name != "frmPrincipal" && xWin.Name != "frmLogin")
                {
                    iLisRes.Add(xWin);
                }
            }

            //devolver
            return iLisRes;
        }
        public void EliminarTodosLosTabVentanas()
        {
            int iNroTabPage = this.tbcContainer.TabPages.Count;

            //eliminar todos los tabpage pero desde el indice 1
            for (int i = 0; i < iNroTabPage; i++)
            {
                this.tbcContainer.TabPages.RemoveAt(0);
            }
        }
        public void FormatoVentanaHijoPrincipal(Form pWin, Button pBtn, ToolStripButton pAccDir, int PAncVen, int pAltVen)
        {
            pBtn.Enabled = false;
            if (pAccDir != null) { pAccDir.Enabled = false; }
            this.tbcContainer.Visible = true;
            //this.BackColor = System.Drawing.SystemColors.Control;
            this.BackColor = Color.White;
            TabCtrl.InsertarVentanaConTabPage(this.tbcContainer, pWin, PAncVen, pAltVen);
        }
        public void InstanciarDeclaraciones()
        {
            frmMenuDeclaraciones win = new frmMenuDeclaraciones();
            this.FormatoVentanaHijoPrincipal(win, this.btnDeclaraciones, null, 0, 0);
            win.NewWindow();
        }
        public void InstanciarGenerales()
        {
            frmMenuGenerales win = new frmMenuGenerales();
            this.FormatoVentanaHijoPrincipal(win, this.btnGenerales, null, 0, 0);
            win.NewWindow();
        }
        public void CerrarVentanaHijo(Form pWin, Button pBtn, ToolStripButton pAccDir)
        {
            pBtn.Enabled = true;
            if (pAccDir != null) { pAccDir.Enabled = true; }
            TabCtrl.EliminarTabPageAlCerrarVentana(this.tbcContainer, pWin);
            if (this.tbcContainer.TabPages.Count == 0)
            {
                this.tbcContainer.Visible = false;
                this.BackColor = Color.Gray;
            }
        }

        #endregion
    }
}
