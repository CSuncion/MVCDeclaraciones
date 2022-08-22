using DeclaracionesController.Controller;
using DeclaracionesModel.ModelDto;
using DeclaracionesView.Generales;
using DeclaracionesView.MdiPrincipal;
using System;
using System.Collections;
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

namespace DeclaracionesView.Maestros
{
    public partial class frmPeriodos : Form
    {
        //atributos
        string eNombreColumnaDgvPer = DeclaracionesPeriodoDto.CodPer;
        string eEncabezadoColumnaDgvPer = "Codigo";
        public string eClaveDgvPer = string.Empty;
        Dgv.Franja eFranjaDgvPer = Dgv.Franja.PorIndice;
        public List<DeclaracionesPeriodoDto> eLisPer = new List<DeclaracionesPeriodoDto>();
        int eVaBD = 1;//0 : no , 1 : si
        DeclaracionesPeriodoController declaracionesPeriodoController = new DeclaracionesPeriodoController();

        public frmPeriodos()
        {
            InitializeComponent();
        }
        #region Metodos
        public void NuevaVentana()
        {
            this.Dock = DockStyle.Fill;
            this.Show();
            this.ActualizarVentana();
        }
        public void ActualizarVentana()
        {
            this.ActualizarListaPeriodosDeBaseDatos();
            this.ActualizarDgvPer();
            Dgv.HabilitarDesplazadores(this.DgvPer, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            //this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvPer, this.sst1);
            this.AccionBuscar();
        }
        public void HabilitarAcciones()
        {
            //asignar parametros
            //ToolStrip iTs1 = tsPrincipal;
            //Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("002", DgvPer.Rows.Count);

            ////ejecutar metodo
            //Tst.HabilitarItems(iTs1, iLisPer);
        }
        public void ActualizarListaPeriodosDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvPer;
            this.eLisPer = this.declaracionesPeriodoController.ListarPeriodos();
        }
        public void ActualizarDgvPer()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvPer;
            List<DeclaracionesPeriodoDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvPer;
            string iClaveBusqueda = eClaveDgvPer;
            string iColumnaPintura = eNombreColumnaDgvPer;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvEmp();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        //public void HabilitarAcciones()
        //{
        //    //asignar parametros
        //    ToolStrip iTs1 = tsPrincipal;
        //    Hashtable iLisPer = declaracionesPeriodoController.ListarPermisosParaVentana("002", DgvPer.Rows.Count);

        //    //ejecutar metodo
        //    Tst.HabilitarItems(iTs1, iLisPer);
        //}
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvPer;
            this.tstBuscar.Focus();
        }
        public List<DeclaracionesPeriodoDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvPer;
            List<DeclaracionesPeriodoDto> iListaPeriodos = eLisPer;

            //ejecutar y retornar
            return this.declaracionesPeriodoController.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaPeriodos);
        }
        public List<DataGridViewColumn> ListarColumnasDgvEmp()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesPeriodoDto.CodPer, "Codigo", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesPeriodoDto.AnoPer, "Año", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesPeriodoDto.NMesPer, "Mes", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesPeriodoDto.NEstPer, "Estado", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesPeriodoDto.CodPer, "Codigo", 90, false));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesPeriodoDto.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }
        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvPer, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvPer, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
        public void Cerrar()
        {
            //obtener al wMenu
            frmMenuGenerales wMen = (frmMenuGenerales)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmiPeriodos, null);
        }
        public void AccionAdicionar()
        {
            frmEditPeriodo win = new frmEditPeriodo();
            win.wPer = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvPer = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public DeclaracionesPeriodoDto EsPeriodoExistente()
        {
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();
            this.AsignarPeriodo(iPerEN);
            iPerEN = DeclaracionesPeriodoController.EsPeriodoExistente(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, "Periodo");
            }
            return iPerEN;
        }
        public void AsignarPeriodo(DeclaracionesPeriodoDto pPer)
        {
            pPer.ClavePeriodo = Dgv.ObtenerValorCelda(this.DgvPer, DeclaracionesPeriodoDto.ClaObj);
            pPer.CodigoPeriodo = Dgv.ObtenerValorCelda(this.DgvPer, DeclaracionesPeriodoDto.CodPer);
        }
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesPeriodoDto iPerEN = this.EsPeriodoExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditPeriodo win = new frmEditPeriodo();
            win.wPer = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvPer = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iPerEN);
        }
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesPeriodoDto iPerEN = this.EsActoEliminarPeriodo();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditPeriodo win = new frmEditPeriodo();
            win.wPer = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvPer = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iPerEN);
        }
        public DeclaracionesPeriodoDto EsActoEliminarPeriodo()
        {
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();
            this.AsignarPeriodo(iPerEN);
            iPerEN = DeclaracionesPeriodoController.EsActoEliminarPeriodo(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, "Periodo");
            }
            return iPerEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesPeriodoDto iPerEN = this.EsPeriodoExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditPeriodo win = new frmEditPeriodo();
            win.wPer = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);
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
        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvPer = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvPer = this.DgvPer.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvPer = this.DgvPer.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }
        #endregion

        #region Eventos
        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }
        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmPeriodos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
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
        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvPer, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvPer, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvPer, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvPer, Dgv.Desplazar.Ultimo);
        }
        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvPer = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }
        private void DgvPer_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvPer, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvPer, this.sst1);
        }

        private void DgvPer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void DgvPer_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }
        #endregion


    }
}
