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
    public partial class frmTipoCambio : Form
    {
        string eNombreColumnaDgvTipOpe = DeclaracionesTipoCambioDto.FecTipCam;
        string eEncabezadoColumnaDvgTipOpe = "Codigo";
        public string eClaveDgvTipOpe = string.Empty;
        Dgv.Franja eFranjaDgvTipOpe = Dgv.Franja.PorIndice;
        public List<DeclaracionesTipoCambioDto> eLisTipOpe = new List<DeclaracionesTipoCambioDto>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Tipo Cambio";

        public frmTipoCambio()
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
            this.ActualizarListaTiposOperacionDeBaseDatos();
            this.ActualizarDgvTipOpe();
            Dgv.HabilitarDesplazadores(this.DgvTipCam, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            //this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvTipCam, this.sst1);
        }
        public void ActualizarListaTiposOperacionDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            DeclaracionesTipoCambioDto iTipOpeEN = new DeclaracionesTipoCambioDto();
            iTipOpeEN.Adicionales.CampoOrden = eNombreColumnaDgvTipOpe;
            this.eLisTipOpe = DeclaracionesTipoCambioController.ListarTipoCambio(iTipOpeEN);
        }
        public void ActualizarDgvTipOpe()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvTipCam;
            List<DeclaracionesTipoCambioDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvTipOpe;
            string iClaveBusqueda = eClaveDgvTipOpe;
            string iColumnaPintura = eNombreColumnaDgvTipOpe;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvTipOpe();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<DeclaracionesTipoCambioDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvTipOpe;
            List<DeclaracionesTipoCambioDto> iLisTipOpe = eLisTipOpe;

            //ejecutar y retornar
            return DeclaracionesTipoCambioController.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisTipOpe);
        }
        public List<DataGridViewColumn> ListarColumnasDgvTipOpe()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesTipoCambioDto.FecTipCam, "Fecha", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(DeclaracionesTipoCambioDto.ComTipCam, "T.C.Compra", 100, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(DeclaracionesTipoCambioDto.VtaTipCam, "T.C.Venta", 100, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesTipoCambioDto.NEstTipCam, "Estado", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesTipoCambioDto.ClaObj, "Clave", 100, false));

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
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
            frmEditTipoCambio win = new frmEditTipoCambio();
            win.wTipOpe = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvTipOpe = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public DeclaracionesTipoCambioDto EsTipoCambioExistente()
        {
            DeclaracionesTipoCambioDto iTipamEN = new DeclaracionesTipoCambioDto();
            this.AsignarTipoCambio(iTipamEN);
            iTipamEN = DeclaracionesTipoCambioController.EsTipoCambioExistente(iTipamEN);
            if (iTipamEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipamEN.Adicionales.Mensaje, eTitulo);
            }
            return iTipamEN;
        }
        public void AsignarTipoCambio(DeclaracionesTipoCambioDto pObj)
        {
            pObj.FechaTipoCambio = Dgv.ObtenerValorCelda(this.DgvTipCam, DeclaracionesTipoCambioDto.FecTipCam);
        }
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesTipoCambioDto iTipCamEN = this.EsActoModificarTipoCambio();
            if (iTipCamEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditTipoCambio win = new frmEditTipoCambio();
            win.wTipOpe = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvTipOpe = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iTipCamEN);
        }
        public DeclaracionesTipoCambioDto EsActoModificarTipoCambio()
        {
            DeclaracionesTipoCambioDto iTipamEN = new DeclaracionesTipoCambioDto();
            this.AsignarTipoCambio(iTipamEN);
            iTipamEN = DeclaracionesTipoCambioController.EsActoModificarTipoCambio(iTipamEN);
            if (iTipamEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipamEN.Adicionales.Mensaje, eTitulo);
            }
            return iTipamEN;
        }
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesTipoCambioDto iTipamEN = this.EsActoEliminarTipoCambio();
            if (iTipamEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditTipoCambio win = new frmEditTipoCambio();
            win.wTipOpe = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvTipOpe = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iTipamEN);
        }
        public DeclaracionesTipoCambioDto EsActoEliminarTipoCambio()
        {
            DeclaracionesTipoCambioDto iTipCamEN = new DeclaracionesTipoCambioDto();
            this.AsignarTipoCambio(iTipCamEN);
            iTipCamEN = DeclaracionesTipoCambioController.EsActoEliminarTipoCambio(iTipCamEN);
            if (iTipCamEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipCamEN.Adicionales.Mensaje, eTitulo);
            }
            return iTipCamEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesTipoCambioDto iTipamEN = this.EsTipoCambioExistente();
            if (iTipamEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditTipoCambio win = new frmEditTipoCambio();
            win.wTipOpe = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iTipamEN);
        }
        public void Cerrar()
        {
            //obtener al wMenu
            frmMenuGenerales wMen = (frmMenuGenerales)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmiTipCambio, null);
        }
        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvTipOpe = Dgv.Franja.PorIndice;
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

        private void frmTipoCambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }
    }
}
