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
    public partial class frmLisAux : Form
    {
        #region Enumeraciones

        public enum Condicion
        {
            Proveedores = 0,
            Clientes,
            ProveedoresActivos,
            ClientesActivos,
        }


        #endregion

        public Form eVentana = new Form();
        public DeclaracionesAuxiliarDto eAuxEN = new DeclaracionesAuxiliarDto();
        public List<DeclaracionesAuxiliarDto> eLisAux = new List<DeclaracionesAuxiliarDto>();
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;
        public frmLisAux()
        {
            InitializeComponent();
        }
        #region Metodos
        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            eAuxEN.Adicionales.CampoOrden = DeclaracionesAuxiliarDto.DesAux;
            this.Text = "Listado de" + Cadena.Espacios(1) + this.eTituloVentana;
            this.eCampoBusqueda = "Descripcion";
            this.ActualizaVentana();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.Show();
            this.txtBus.Focus();
        }

        public void ActualizaVentana()
        {
            this.ActualizarListaAuxiliarsDeBaseDatos();
            this.gbBus.Text = "Criterio de busqueda / Por :" + this.eCampoBusqueda;
            this.ActualizarDgvLista();
            Dgv.PintarColumna(this.DgvLista, eAuxEN.Adicionales.CampoOrden);
        }

        public void ActualizarDgvLista()
        {
            //llenar la grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvLista;
            iDgv.RefrescarDatosGrilla(this.ObtenerDatosParaGrilla());

            //asignando columnas
            iDgv.AsignarColumnaTextCadena(DeclaracionesAuxiliarDto.CodAux, "Codigo", 80);
            iDgv.AsignarColumnaTextCadena(DeclaracionesAuxiliarDto.DesAux, "Descripcion", 260);
        }

        public void ActualizarListaAuxiliarsDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (txtBus.Text.Trim() != string.Empty) { return; }

            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                //case Condicion.Proveedores: { this.eLisAux = DeclaracionesAuxiliarController.ListarProveedores(eAuxEN); break; }
                //case Condicion.Clientes: { this.eLisAux = DeclaracionesAuxiliarController.ListarClientes(eAuxEN); break; }
                case Condicion.ProveedoresActivos: { this.eLisAux = DeclaracionesAuxiliarController.ListarProveedoresActivos(eAuxEN); break; }
                //case Condicion.ClientesActivos: { this.eLisAux = DeclaracionesAuxiliarController.ListarClientesActivos(eAuxEN); break; }
            }
        }

        public List<DeclaracionesAuxiliarDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = txtBus.Text.Trim();
            string iCampoBusqueda = eAuxEN.Adicionales.CampoOrden;
            List<DeclaracionesAuxiliarDto> iListaAuxiliars = eLisAux;

            //ejecutar y retornar
            return DeclaracionesAuxiliarController.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaAuxiliars);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, DeclaracionesAuxiliarDto.CodAux);
                this.Close();
                this.eCtrlValor.Focus();
                this.eCtrlFoco.Focus();
            }
        }

        public void OrdenarPorColumna(int pColumna)
        {
            eAuxEN.Adicionales.CampoOrden = this.DgvLista.Columns[pColumna].Name;
            this.eCampoBusqueda = this.DgvLista.Columns[pColumna].HeaderText;
            this.ActualizaVentana();
            Txt.CursorAlUltimo(this.txtBus);
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvLista, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.txtBus); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvLista, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.txtBus); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        this.ActualizaVentana();
                        break;
                    }
            }
        }

        #endregion

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.DevolverDato();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBus_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void txtBus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Encoding.ASCII.GetBytes(e.KeyChar.ToString())[0] == 13) { this.DevolverDato(); }
        }

        private void DgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DevolverDato();
        }

        private void DgvLista_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void frmLisAux_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.eVentana.Enabled = true;
        }
    }
}
