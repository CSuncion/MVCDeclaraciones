using Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;

namespace DeclaracionesView.Generales
{
    public partial class frmSeleccionarPeriodo : Form
    {
        private Masivo eMas = new Masivo();
        public object eControlDevuelveValor;
        public Form eVentanaInvoca;
        public string ePeriodoActual;

        public frmSeleccionarPeriodo()
        {
            InitializeComponent();
        }
        private List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> controlEditarList = new List<ControlEditar>();
            ControlEditar controlEditar1 = new ControlEditar();
            controlEditar1.TxtNumeroSinEspacion((Control)this.txtAno, true, "Año", "vfff");
            controlEditarList.Add(controlEditar1);
            ControlEditar controlEditar2 = new ControlEditar();
            controlEditar2.Cmb((Control)this.cmbMes, "vfff");
            controlEditarList.Add(controlEditar2);
            ControlEditar controlEditar3 = new ControlEditar();
            controlEditar3.Btn((Control)this.btnAceptar, "vvvf");
            controlEditarList.Add(controlEditar3);
            ControlEditar controlEditar4 = new ControlEditar();
            controlEditar4.Btn((Control)this.btnCancelar, "vvvv");
            controlEditarList.Add(controlEditar4);
            return controlEditarList;
        }
        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.MostrarPeriodoActual();
            this.txtAno.Focus();
        }
        public void InicializaVentana()
        {
            this.eMas.lisCtrls = this.ListaCtrls();
            this.eMas.EjecutarTodosLosEventos();
            this.CargarMeses();
            this.eVentanaInvoca.Enabled = false;
            this.Show();
        }
        public void CargarMeses() => Cmb.Cargar(this.cmbMes, (object)AñoMes.ListarMeses(), "CodigoMes", "NombreMes");
        public void MostrarPeriodoActual()
        {
            this.txtAno.Text = AñoMes.ObtenerAñoPeriodo(this.ePeriodoActual);
            this.cmbMes.SelectedValue = (object)AñoMes.ObtenerCMesPeriodo(this.ePeriodoActual);
        }
        public void Aceptar()
        {
            if (!this.eMas.CamposObligatorios())
                return;
            this.PasarValor();
            this.Close();
        }
        public void PasarValor()
        {
            string str = this.txtAno.Text + "-" + Cmb.ObtenerValor(this.cmbMes, "");
            switch (this.eControlDevuelveValor.GetType().Name)
            {
                case "Label":
                    ((Control)this.eControlDevuelveValor).Text = str;
                    break;
                case "ToolStripLabel":
                    ((ToolStripItem)this.eControlDevuelveValor).Text = str;
                    break;
                case "TextBox":
                    ((Control)this.eControlDevuelveValor).Text = str;
                    break;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSeleccionarPeriodo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.eVentanaInvoca.Enabled = true;
        }
    }
}
