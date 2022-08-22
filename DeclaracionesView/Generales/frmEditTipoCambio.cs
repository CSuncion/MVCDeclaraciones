using Comun;
using DeclaracionesController.Controller;
using DeclaracionesModel.ModelDto;
using DeclaracionesView.FuncionesGenericas;
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
    public partial class frmEditTipoCambio : Form
    {
        public frmTipoCambio wTipOpe;
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Tipo de Cambio";
        public frmEditTipoCambio()
        {
            InitializeComponent();
        }
        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarTipoCambio(DeclaracionesTipoCambioController.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            //this.HabilitarParaClaseIngreso();
            this.dtpFecTipCam.Focus();
        }

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecTipCam, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtTipCamCom, true, "Tipo Cambio Compra", "vvff", 3, 7);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtTipCamVta, true, "Tipo Cambio Vta", "vvff", 3, 7);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstTipCam, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "vvvv");
            xLis.Add(xCtrl);

            return xLis;
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wTipOpe.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos            
            this.CargarEstadosTiposOperacion();

            // Deshabilitar al propietario
            this.wTipOpe.Enabled = false;

            // Mostrar ventana
            this.Show();
        }
        public void CargarEstadosTiposOperacion()
        {
            Cmb.Cargar(this.cmbEstTipCam, DeclaracionesItemGController.ListarItemsG("EstReg"), DeclaracionesItemGDto.CodIteG, DeclaracionesItemGDto.NomIteG);
        }
        public void MostrarTipoCambio(DeclaracionesTipoCambioDto pObj)
        {
            this.dtpFecTipCam.Text = pObj.FechaTipoCambio;
            this.txtTipCamCom.Text = Formato.NumeroDecimal(pObj.CompraTipoCambio.ToString(), 3);
            this.txtTipCamVta.Text = Formato.NumeroDecimal(pObj.VentaTipoCambio.ToString(), 3);
            this.cmbEstTipCam.SelectedValue = pObj.CEstadoTipoCambio;
        }
        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Adicionar(); break; }
                case Universal.Opera.Modificar: { this.Modificar(); break; }
                case Universal.Opera.Eliminar: { this.Eliminar(); break; }
                default: break;
            }
        }
        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //el codigo de usuario ya existe?
            if (this.EsCodigoTipoOperacionDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTipOpe.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarTipoCambio();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Cambio se adiciono correctamente", this.wTipOpe.eTitulo);

            //actualizar al propietario
            this.wTipOpe.eClaveDgvTipOpe = this.dtpFecTipCam.Text;
            this.wTipOpe.ActualizarVentana();

            //limpiar controles
            this.MostrarTipoCambio(DeclaracionesTipoCambioController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecTipCam.Focus();
        }
        public bool EsCodigoTipoOperacionDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            DeclaracionesTipoCambioDto iTipOpeEN = new DeclaracionesTipoCambioDto();
            this.AsignarTipoCambio(iTipOpeEN);
            iTipOpeEN = DeclaracionesTipoCambioController.EsCodigoTipoCambioDisponible(iTipOpeEN);
            if (iTipOpeEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipOpeEN.Adicionales.Mensaje, this.wTipOpe.eTitulo);
                //this.dtpFecTipCam.Clear();
                this.dtpFecTipCam.Focus();
            }
            return iTipOpeEN.Adicionales.EsVerdad;
        }
        public void AsignarTipoCambio(DeclaracionesTipoCambioDto pObj)
        {
            pObj.FechaTipoCambio = dtpFecTipCam.Text;
            pObj.CompraTipoCambio = Convert.ToDecimal(this.txtTipCamCom.Text);
            pObj.VentaTipoCambio = Convert.ToDecimal(this.txtTipCamVta.Text);
            pObj.CEstadoTipoCambio = Cmb.ObtenerValor(this.cmbEstTipCam, string.Empty);
        }
        public void AdicionarTipoCambio()
        {
            DeclaracionesTipoCambioDto iTipOpeEN = new DeclaracionesTipoCambioDto();
            this.AsignarTipoCambio(iTipOpeEN);
            DeclaracionesTipoCambioController.AdicionarTipoCambio(iTipOpeEN);
        }
        public void VentanaModificar(DeclaracionesTipoCambioDto pObj)
        {
            this.InicializaVentana();
            this.MostrarTipoCambio(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            //this.HabilitarParaClaseIngreso();
            this.txtTipCamCom.Focus();
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wTipOpe.EsTipoCambioExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTipOpe.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarTipoCambio();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Operacion se modifico correctamente", this.wTipOpe.eTitulo);

            //actualizar al wUsu
            this.wTipOpe.eClaveDgvTipOpe = this.dtpFecTipCam.Text;
            this.wTipOpe.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void ModificarTipoCambio()
        {
            DeclaracionesTipoCambioDto iTipOpeEN = new DeclaracionesTipoCambioDto();
            this.AsignarTipoCambio(iTipOpeEN);
            iTipOpeEN = DeclaracionesTipoCambioController.BuscarTipoCambioXFecha(iTipOpeEN);
            this.AsignarTipoCambio(iTipOpeEN);
            DeclaracionesTipoCambioController.ModificarTipoCambio(iTipOpeEN);
        }
        public void VentanaEliminar(DeclaracionesTipoCambioDto pObj)
        {
            this.InicializaVentana();
            this.MostrarTipoCambio(pObj);
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wTipOpe.EsActoEliminarTipoCambio().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTipOpe.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarTipoCambio();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Operacion se elimino correctamente", this.wTipOpe.eTitulo);

            //actualizar al propietario           
            this.wTipOpe.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        public void EliminarTipoCambio()
        {
            DeclaracionesTipoCambioDto iTipOpeEN = new DeclaracionesTipoCambioDto();
            this.AsignarTipoCambio(iTipOpeEN);
            DeclaracionesTipoCambioController.EliminarTipoCambio(iTipOpeEN);
        }
        public void VentanaVisualizar(DeclaracionesTipoCambioDto pObj)
        {
            this.InicializaVentana();
            this.MostrarTipoCambio(pObj);
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }
        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wTipOpe.eTitulo);
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void frmEditTipoCambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wTipOpe.Enabled = true;
        }
    }
}
