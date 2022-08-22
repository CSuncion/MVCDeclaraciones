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
    public partial class frmEditAuxiliar : Form
    {
        public frmAuxiliar wAux;
        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Auxiliar";
        #endregion
        public frmEditAuxiliar()
        {
            InitializeComponent();
        }
        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCodAux, true, "Codigo", "vfff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesAux, true, "Nombre", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDirAux, true, "Direccion", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTelAux, false, "Telefono", "vvff", 20);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCelAux, false, "Celular", "vvff", 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCorAux, false, "Correo", "vvff", 40);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtRefAux, false, "Referencia", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbTipAux, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstAux, "vvff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wAux.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos      
            this.CargarTiposAuxiliar();
            this.CargarEstadosAuxiliar();

            // Deshabilitar al propietario
            this.wAux.Enabled = false;

            // Mostrar ventana
            this.Show();
        }
        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarAuxiliar(DeclaracionesAuxiliarController.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodAux.Focus();
        }
        public void CargarTiposAuxiliar()
        {
            Cmb.Cargar(this.cmbTipAux, DeclaracionesItemGController.ListarItemsG("TipAux"), DeclaracionesItemGDto.CodIteG, DeclaracionesItemGDto.NomIteG);
        }

        public void CargarEstadosAuxiliar()
        {
            Cmb.Cargar(this.cmbEstAux, DeclaracionesItemGController.ListarItemsG("EstReg"), DeclaracionesItemGDto.CodIteG, DeclaracionesItemGDto.NomIteG);
        }
        public void MostrarAuxiliar(DeclaracionesAuxiliarDto pObj)
        {
            this.txtCodAux.Text = pObj.CodigoAuxiliar;
            this.txtDesAux.Text = pObj.DescripcionAuxiliar;
            this.txtDirAux.Text = pObj.DireccionAuxiliar;
            this.txtTelAux.Text = pObj.TelefonoAuxiliar;
            this.txtCelAux.Text = pObj.CelularAuxiliar;
            this.txtCorAux.Text = pObj.CorreoAuxiliar;
            this.txtRefAux.Text = pObj.ReferenciaAuxiliar;
            this.cmbTipAux.SelectedValue = pObj.CTipoAuxiliar;
            this.cmbEstAux.SelectedValue = pObj.CEstadoAuxiliar;
        }
        public void AsignarAuxiliar(DeclaracionesAuxiliarDto pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            pObj.DescripcionAuxiliar = this.txtDesAux.Text.Trim();
            pObj.DireccionAuxiliar = this.txtDirAux.Text.Trim();
            pObj.TelefonoAuxiliar = this.txtTelAux.Text.Trim();
            pObj.CelularAuxiliar = this.txtCelAux.Text.Trim();
            pObj.CorreoAuxiliar = this.txtCorAux.Text.Trim();
            pObj.ReferenciaAuxiliar = this.txtRefAux.Text.Trim();
            pObj.CTipoAuxiliar = Cmb.ObtenerValor(this.cmbTipAux, string.Empty);
            pObj.CEstadoAuxiliar = Cmb.ObtenerValor(this.cmbEstAux, string.Empty);
            pObj.ClaveAuxiliar = DeclaracionesAuxiliarController.ObtenerClaveAuxiliar(pObj);
        }
        public bool EsCodigoAuxiliarDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();
            this.AsignarAuxiliar(iAuxEN);
            iAuxEN = DeclaracionesAuxiliarController.EsCodigoAuxiliarDisponible(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, this.wAux.eTitulo);
                this.txtCodAux.Clear();
                this.txtCodAux.Focus();
            }
            return iAuxEN.Adicionales.EsVerdad;
        }
        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, eTitulo);
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
            if (this.EsCodigoAuxiliarDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAux.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarAuxiliar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Auxiliar se adiciono correctamente", this.wAux.eTitulo);

            //actualizar al propietario
            this.wAux.eClaveDgvAux = this.ObtenerClaveAuxiliar();
            this.wAux.ActualizarVentana();

            //limpiar controles
            this.MostrarAuxiliar(DeclaracionesAuxiliarController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.txtCodAux.Focus();
        }
        public void AdicionarAuxiliar()
        {
            DeclaracionesAuxiliarDto iPerEN = new DeclaracionesAuxiliarDto();
            this.AsignarAuxiliar(iPerEN);
            DeclaracionesAuxiliarController.AdicionarAuxiliar(iPerEN);
        }
        public string ObtenerClaveAuxiliar()
        {
            //asignar parametros
            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();
            this.AsignarAuxiliar(iAuxEN);

            //devolver
            return iAuxEN.ClaveAuxiliar;
        }
        public void VentanaModificar(DeclaracionesAuxiliarDto pObj)
        {
            this.InicializaVentana();
            this.MostrarAuxiliar(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtDesAux.Focus();
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wAux.EsActoModificarAuxiliar().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAux.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarAuxiliar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Auxiliar se modifico correctamente", this.wAux.eTitulo);

            //actualizar al wUsu
            this.wAux.eClaveDgvAux = this.ObtenerClaveAuxiliar();
            this.wAux.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void ModificarAuxiliar()
        {
            DeclaracionesAuxiliarDto iPerEN = new DeclaracionesAuxiliarDto();
            this.AsignarAuxiliar(iPerEN);
            iPerEN = DeclaracionesAuxiliarController.BuscarAuxiliarXClave(iPerEN);
            this.AsignarAuxiliar(iPerEN);
            DeclaracionesAuxiliarController.ModificarAuxiliar(iPerEN);
        }
        public void VentanaEliminar(DeclaracionesAuxiliarDto pObj)
        {
            this.InicializaVentana();
            this.MostrarAuxiliar(pObj);
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wAux.EsActoEliminarAuxiliar().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAux.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarAuxiliar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Auxiliar se elimino correctamente", this.wAux.eTitulo);

            //actualizar al propietario           
            this.wAux.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        public void EliminarAuxiliar()
        {
            DeclaracionesAuxiliarDto iPerEN = new DeclaracionesAuxiliarDto();
            this.AsignarAuxiliar(iPerEN);
            DeclaracionesAuxiliarController.EliminarAuxiliar(iPerEN);
        }
        public void VentanaVisualizar(DeclaracionesAuxiliarDto pObj)
        {
            this.InicializaVentana();
            this.MostrarAuxiliar(pObj);
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }
        private void txtCodAux_Validated(object sender, EventArgs e)
        {
            this.EsCodigoAuxiliarDisponible();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void frmEditAuxiliar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wAux.Enabled = true;
        }
    }
}
