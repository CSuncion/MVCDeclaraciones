using Comun;
using DeclaracionesController.Controller;
using DeclaracionesModel.ModelDto;
using DeclaracionesView.FuncionesGenericas;
using DeclaracionesView.Maestros;
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
    public partial class frmEditPeriodo : Form
    {
        public frmPeriodos wPer;
        //atributos
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Periodo";
        DeclaracionesPeriodoController declaracionesPeriodoController = new DeclaracionesPeriodoController();
        DeclaracionesItemGController declaracionesItemGController = new DeclaracionesItemGController();

        public frmEditPeriodo()
        {
            InitializeComponent();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarPeriodo(this.declaracionesPeriodoController.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtAnoPer.Focus();
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos
            this.CargarMeses();
            this.CargarEstadosPeriodoes();

            // Deshabilitar al propietario
            this.wPer.Enabled = false;

            // Mostrar ventana
            this.Show();
        }

        public void MostrarPeriodo(DeclaracionesPeriodoDto pPer)
        {
            this.txtCodPer.Text = pPer.CodigoPeriodo;
            this.txtAnoPer.Text = pPer.AnoPeriodo;
            this.cmbMesPer.SelectedValue = pPer.CMesPeriodo;
            this.txtTipCamPer.Text = Formato.NumeroDecimal(pPer.TipoCambioPeriodo.ToString(), 4);
            this.cmbEstPer.SelectedValue = pPer.CEstadoPeriodo;
        }
        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodPer, txtAnoPer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtAnoPer, true, "Año", "vfff", 4);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMesPer, "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtTipCamPer, false, "Tipo Cambio", "vvff", 4, 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstPer, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "vvvv");
            xLis.Add(xCtrl);

            return xLis;
        }
        public void CargarMeses()
        {
            Cmb.Cargar(this.cmbMesPer, DeclaracionesItemGController.ListarItemsG("Mes"), DeclaracionesItemGDto.CodIteG, DeclaracionesItemGDto.NomIteG);
        }

        public void CargarEstadosPeriodoes()
        {
            Cmb.Cargar(this.cmbEstPer, DeclaracionesItemGController.ListarItemsG("EstPer"), DeclaracionesItemGDto.CodIteG, DeclaracionesItemGDto.NomIteG);
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
        public void AsignarPeriodo(DeclaracionesPeriodoDto pPer)
        {
            pPer.CodigoEmpresa = Universal.gCodigoEmpresa;
            pPer.CodigoPeriodo = this.txtCodPer.Text.Trim();
            pPer.AnoPeriodo = this.txtAnoPer.Text.Trim();
            pPer.CMesPeriodo = Cmb.ObtenerValor(this.cmbMesPer, string.Empty);
            pPer.NMesPeriodo = cmbMesPer.Text;
            pPer.TipoCambioPeriodo = Convert.ToDecimal(this.txtTipCamPer.Text);
            pPer.CEstadoPeriodo = Cmb.ObtenerValor(this.cmbEstPer, string.Empty);
            pPer.ClavePeriodo = DeclaracionesPeriodoController.ObtenerClavePeriodo(pPer);
        }
        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //el codigo ya existe?
            if (this.EsCodigoPeriodoDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //mostrar nuevo codigo
            this.MostrarCodigoPeriodo();

            //adicionando el registro
            this.AdicionarPeriodo();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Periodo se adiciono correctamente", "Periodo");

            //actualizar al propietario
            this.wPer.eClaveDgvPer = this.ObtenerClaveObjeto();
            this.wPer.ActualizarVentana();

            //limpiar controles
            this.MostrarPeriodo(declaracionesPeriodoController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.txtAnoPer.Focus();
        }
        public void MostrarCodigoPeriodo()
        {
            txtCodPer.Text = txtAnoPer.Text + "-" + Cmb.ObtenerValor(cmbMesPer, "");
        }
        public string ObtenerClaveObjeto()
        {
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();
            this.AsignarPeriodo(iPerEN);
            return iPerEN.ClavePeriodo;
        }
        public bool EsCodigoPeriodoDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();
            this.AsignarPeriodo(iPerEN);
            iPerEN = declaracionesPeriodoController.EsPeriodoDisponible(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, "Periodo");
                this.txtAnoPer.Clear();
                this.txtAnoPer.Focus();
            }
            return iPerEN.Adicionales.EsVerdad;
        }
        public void AdicionarPeriodo()
        {
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();
            this.AsignarPeriodo(iPerEN);
            declaracionesPeriodoController.AdicionarPeriodo(iPerEN);
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wPer.EsPeriodoExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarPeriodo();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Periodo se modifico correctamente", "Periodo");

            //actualizar al wUsu
            this.wPer.eClaveDgvPer = this.ObtenerClaveObjeto();
            this.wPer.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void VentanaModificar(DeclaracionesPeriodoDto pPer)
        {
            this.InicializaVentana();
            this.MostrarPeriodo(pPer);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.cmbEstPer.Focus();
        }
        public void ModificarPeriodo()
        {
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();
            this.AsignarPeriodo(iPerEN);
            iPerEN = DeclaracionesPeriodoController.BuscarPeriodoXClave(iPerEN);
            this.AsignarPeriodo(iPerEN);
            DeclaracionesPeriodoController.ModificarPeriodo(iPerEN);
        }
        public void VentanaEliminar(DeclaracionesPeriodoDto pPer)
        {
            this.InicializaVentana();
            this.MostrarPeriodo(pPer);
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wPer.EsActoEliminarPeriodo().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarPeriodo();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Periodo se elimino correctamente", "Periodo");

            //actualizar al propietario           
            this.wPer.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        public void EliminarPeriodo()
        {
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();
            this.AsignarPeriodo(iPerEN);
            DeclaracionesPeriodoController.EliminarPeriodo(iPerEN);
        }
        public void VentanaVisualizar(DeclaracionesPeriodoDto pPer)
        {
            this.InicializaVentana();
            this.MostrarPeriodo(pPer);
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void frmEditPeriodo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wPer.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }
    }
}
