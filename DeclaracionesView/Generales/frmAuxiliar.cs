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
using WinControles;
using WinControles.ControlesWindows;

namespace DeclaracionesView.Generales
{
    public partial class frmAuxiliar : Form
    {
        #region Atributos

        string eNombreColumnaDgvAux = DeclaracionesAuxiliarDto.CodAux;
        string eEncabezadoColumnaDgvAux = "Codigo";
        public string eClaveDgvAux = string.Empty;
        Dgv.Franja eFranjaDgvAux = Dgv.Franja.PorIndice;
        public List<DeclaracionesAuxiliarDto> eLisPer = new List<DeclaracionesAuxiliarDto>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Auxiliar";

        #endregion
        public frmAuxiliar()
        {
            InitializeComponent();
        }
        public void NuevaVentana()
        {
            this.Dock = DockStyle.Fill;
            this.Show();
            this.ActualizarVentana();
        }
        public void ActualizarVentana()
        {
            this.ActualizarListaAuxiliaresDeBaseDatos();
            this.ActualizarDgvAux();
            Dgv.HabilitarDesplazadores(this.DgvAux, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            //this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvAux, this.sst1);
        }
        public void ActualizarListaAuxiliaresDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            DeclaracionesAuxiliarDto iPerEN = new DeclaracionesAuxiliarDto();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvAux;
            this.eLisPer = DeclaracionesAuxiliarController.ListarAuxiliares(iPerEN);
        }
        public void ActualizarDgvAux()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvAux;
            List<DeclaracionesAuxiliarDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvAux;
            string iClaveBusqueda = eClaveDgvAux;
            string iColumnaPintura = eNombreColumnaDgvAux;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvAux();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<DeclaracionesAuxiliarDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvAux;
            List<DeclaracionesAuxiliarDto> iLisPer = eLisPer;

            //ejecutar y retornar
            return DeclaracionesAuxiliarController.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisPer);
        }
        public List<DataGridViewColumn> ListarColumnasDgvAux()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesAuxiliarDto.CodAux, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesAuxiliarDto.DesAux, "Nombre", 276));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesAuxiliarDto.DirAux, "Direccion", 256));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesAuxiliarDto.TelAux, "Telefono", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesAuxiliarDto.CelAux, "Celular", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesAuxiliarDto.CorAux, "Email", 90));
            //iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesAuxiliarDto.RefAux, "Referencia", 150));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesAuxiliarDto.NTipAux, "Tipo", 120));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesAuxiliarDto.NEstAux, "Estado", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesAuxiliarDto.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }
        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvAux = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvAux = this.DgvAux.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvAux = this.DgvAux.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }
        public void AccionModificarAlHacerDobleClick(int pColumna, int pFila)
        {
            //no debe pasar cuando la fila o columna sea -1
            if (pColumna == -1 || pFila == -1) { return; }

            //preguntar si este usuario tiene acceso a la accion modificar
            //basta con ver si el boton modificar esta habilitado o no
            if (tsbModificar.Enabled == false)
            {
                Mensaje.OperacionDenegada("Tu usuario no tiene permiso para modificar este registro", "Modificar");
            }
            else
            {
                this.AccionModificar();
            }
        }
        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAux, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAux, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        if (this.tstBuscar.Text != string.Empty) { eVaBD = 0; }
                        this.ActualizarVentana();
                        eVaBD = 1;
                        break;
                    }
            }
        }


        public void AccionAdicionar()
        {
            frmEditAuxiliar win = new frmEditAuxiliar();
            win.wAux = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvAux = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesAuxiliarDto iAuxEN = this.EsActoModificarAuxiliar();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditAuxiliar win = new frmEditAuxiliar();
            win.wAux = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvAux = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iAuxEN);
        }
        public DeclaracionesAuxiliarDto EsActoModificarAuxiliar()
        {
            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();
            this.AsignarAuxiliar(iAuxEN);
            iAuxEN = DeclaracionesAuxiliarController.EsActoModificarAuxiliar(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }
        public DeclaracionesAuxiliarDto EsActoEliminarAuxiliar()
        {
            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();
            this.AsignarAuxiliar(iAuxEN);
            iAuxEN = DeclaracionesAuxiliarController.EsActoEliminarAuxiliar(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }
        public void AsignarAuxiliar(DeclaracionesAuxiliarDto pObj)
        {
            pObj.CodigoAuxiliar = Dgv.ObtenerValorCelda(this.DgvAux, DeclaracionesAuxiliarDto.CodAux);
        }
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesAuxiliarDto iAuxEN = this.EsActoEliminarAuxiliar();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditAuxiliar win = new frmEditAuxiliar();
            win.wAux = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvAux = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iAuxEN);
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesAuxiliarDto iAuxEN = this.EsAuxiliarExistente();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditAuxiliar win = new frmEditAuxiliar();
            win.wAux = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iAuxEN);
        }
        public DeclaracionesAuxiliarDto EsAuxiliarExistente()
        {
            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();
            this.AsignarAuxiliar(iAuxEN);
            iAuxEN = DeclaracionesAuxiliarController.EsAuxiliarExistente(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }
        public void Cerrar()
        {
            //obtener al wMenu
            frmMenuGenerales wMen = (frmMenuGenerales)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmiAuxiliar, null);
        }
        private void DgvAux_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvAux, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvAux, this.sst1);
        }

        private void DgvAux_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void DgvAux_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAux, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAux, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAux, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAux, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvAux = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionAdicionar();
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            this.AccionEliminar();
        }

        private void tsbVisualizar_Click(object sender, EventArgs e)
        {
            this.AccionVisualizar();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAuxiliar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }
    }
}
