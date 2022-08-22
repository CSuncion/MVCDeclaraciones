using Comun;
using DeclaracionesController.Controller;
using DeclaracionesModel.ModelDto;
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

namespace DeclaracionesView.Listas
{
    public partial class frmLisPerEmpExt : Form
    {
        public enum Condicion
        {
            EmpresasAutorizadasDeUsuario = 0,
        }


        public Form eVentana = new Form();
        public DeclaracionesPermisoEmpresaDto ePemEN = new DeclaracionesPermisoEmpresaDto();
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;
        DeclaracionesPermisoEmpresaController declaracionesPermisoEmpresaController = new DeclaracionesPermisoEmpresaController();
        public frmLisPerEmpExt()
        {
            InitializeComponent();
        }


        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            ePemEN.Adicionales.CampoOrden = DeclaracionesPermisoEmpresaDto.NomEmp;
            this.Text = "Listado de" + Cadena.Espacios(1) + this.eTituloVentana;
            this.eCampoBusqueda = "Descripcion";
            this.ActualizaVentana();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.Show();
        }

        public void ActualizaVentana()
        {
            this.gbBus.Text = "Criterio de busqueda / Por :" + this.eCampoBusqueda;
            this.ActualizarDgvLista();
            Dgv.PintarColumna(this.DgvLista, ePemEN.Adicionales.CampoOrden);
        }

        public void ActualizarDgvLista()
        {
            List<DeclaracionesPermisoEmpresaDto> iLis = new List<DeclaracionesPermisoEmpresaDto>();
            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.EmpresasAutorizadasDeUsuario: { iLis = declaracionesPermisoEmpresaController.ListarPermisosEmpresaActivasXUsuarioYAutorizadas(ePemEN); break; }
            }

            //llenar la grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvLista;
            iDgv.RefrescarDatosGrilla(iLis);
            //asignando columnas
            iDgv.AsignarColumnaTextCadena(DeclaracionesPermisoEmpresaDto.CodEmp, "Codigo", 50);
            iDgv.AsignarColumnaTextCadena(DeclaracionesPermisoEmpresaDto.NomEmp, "Descripcion", 276);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, DeclaracionesPermisoEmpresaDto.CodEmp);
                this.Close();
                this.eCtrlValor.Focus();
                this.eCtrlFoco.Focus();
            }
        }

        public void OrdenarPorColumna(int pColumna)
        {
            ePemEN.Adicionales.CampoOrden = this.DgvLista.Columns[pColumna].Name;
            this.eCampoBusqueda = this.DgvLista.Columns[pColumna].HeaderText;
            this.ActualizaVentana();
            Txt.CursorAlUltimo(this.txtBus);
        }

        private void txtBus_KeyPress(object sender, KeyPressEventArgs e)
        {
            //si se selecciono la barra espaciadora
            if (Encoding.ASCII.GetBytes(e.KeyChar.ToString())[0] == 13) { this.DevolverDato(); }
        }

        private void txtBus_KeyUp(object sender, KeyEventArgs e)
        {
            Dgv.BusquedaInteligenteEnColumna(this.DgvLista, ePemEN.Adicionales.CampoOrden, this.txtBus, e);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.DevolverDato();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLisPerEmpExt_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.eVentana.Enabled = true;
        }

        private void DgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DevolverDato();
        }

        private void DgvLista_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }
    }
}
