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
    public partial class frmEditEmpresa : Form
    {
        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Empresa";
        DeclaracionesEmpresaController eDeclaracionesController = new DeclaracionesEmpresaController();
        #endregion

        #region Propietario

        public frmEmpresas wEmp;

        #endregion
        public frmEditEmpresa()
        {
            InitializeComponent();
        }
        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCodEmp, true, "Codigo", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNomEmp, true, "Nombre", "vvff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtRucEmp, true, "Ruc", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstEmp, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDirEmp, false, "Direccion", "vvff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCorEmp, false, "Correo", "vvff", 50);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConEspacion(this.txtTelFijEmp, false, "Tel Fijo", "vvff", 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConEspacion(this.txtTelCelEmp, false, "Tel Celular", "vvff", 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "vvvv");
            xLis.Add(xCtrl);

            return xLis;
        }
        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarEmpresa(DeclaracionesEmpresaController.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodEmp.Focus();
        }
        public void MostrarEmpresa(DeclaracionesEmpresaDto pEmp)
        {
            this.txtCodEmp.Text = pEmp.CodigoEmpresa;
            this.txtNomEmp.Text = pEmp.NombreEmpresa;
            this.cmbEstEmp.SelectedValue = pEmp.CEstadoEmpresa;
            this.txtRucEmp.Text = pEmp.RucEmpresa;
            this.txtDirEmp.Text = pEmp.DireccionEmpresa;
            this.txtCorEmp.Text = pEmp.CorreoEmpresa;
            this.txtTelFijEmp.Text = pEmp.TelFijoEmpresa;
            this.txtTelCelEmp.Text = pEmp.TelCelularEmpresa;
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos
            this.CargarEstadosEmpresa();

            //Deshabilitar al propietario de esta ventana
            this.wEmp.Enabled = false;

            //mostrar ventana
            this.Show();
        }
        public void CargarEstadosEmpresa()
        {
            Cmb.Cargar(this.cmbEstEmp, DeclaracionesItemGController.ListarItemsG("EstReg"), DeclaracionesItemGDto.CodIteG, DeclaracionesItemGDto.NomIteG);
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

            //el codigo es disponible?
            if (this.EsCodigoEmpresaDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarEmpresa();

            //generar los permisos empresa para esta empresa
            this.GenerarPermisosEmpresa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria(this.eTitulo + " adicionada correctamente", this.eTitulo);

            //actualizar al propietario
            this.wEmp.eClaveDgvEmp = this.txtCodEmp.Text.Trim();
            this.wEmp.ActualizarVentana();

            //limpiar controles
            this.MostrarEmpresa(DeclaracionesEmpresaController.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.txtCodEmp.Focus();
        }
        public bool EsCodigoEmpresaDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            //validar
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();
            this.AsignarEmpresa(iEmpEN);
            iEmpEN = DeclaracionesEmpresaController.EsCodigoEmpresaDisponible(iEmpEN);
            if (iEmpEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iEmpEN.Adicionales.Mensaje, this.eTitulo);
                this.txtCodEmp.Clear();
                this.txtCodEmp.Focus();
            }
            return iEmpEN.Adicionales.EsVerdad;
        }
        public void AsignarEmpresa(DeclaracionesEmpresaDto pEmp)
        {
            pEmp.CodigoEmpresa = this.txtCodEmp.Text.Trim();
            pEmp.NombreEmpresa = this.txtNomEmp.Text.Trim();
            pEmp.CEstadoEmpresa = Cmb.ObtenerValor(this.cmbEstEmp, string.Empty);
            pEmp.RucEmpresa = this.txtRucEmp.Text.Trim();
            pEmp.DireccionEmpresa = this.txtDirEmp.Text.Trim();
            pEmp.CorreoEmpresa = this.txtCorEmp.Text.Trim();
            pEmp.TelFijoEmpresa = this.txtTelFijEmp.Text.Trim();
            pEmp.TelCelularEmpresa = this.txtTelCelEmp.Text.Trim();
        }
        public void AdicionarEmpresa()
        {
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();
            this.AsignarEmpresa(iEmpEN);
            DeclaracionesEmpresaController.AdicionarEmpresa(iEmpEN);
        }
        public void GenerarPermisosEmpresa()
        {
            DeclaracionesPermisoEmpresaDto iPemEN = new DeclaracionesPermisoEmpresaDto();
            iPemEN.CodigoEmpresa = this.txtCodEmp.Text.Trim();
            DeclaracionesPermisoEmpresaController.AdicionarPermisosEmpresaXEmpresa(iPemEN);
        }
        public void VentanaModificar(DeclaracionesEmpresaDto pEmp)
        {
            this.InicializaVentana();
            this.MostrarEmpresa(pEmp);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtNomEmp.Focus();
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.EsActoModificarEmpresa() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarEmpresa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria(this.eTitulo + " modificada correctamente", this.eTitulo);

            //actualizar al propietario
            this.wEmp.eClaveDgvEmp = this.txtCodEmp.Text.Trim();
            this.wEmp.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public bool EsActoModificarEmpresa()
        {
            //validar
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();
            this.AsignarEmpresa(iEmpEN);
            iEmpEN = DeclaracionesEmpresaController.EsActoModificarEmpresa(iEmpEN);
            if (iEmpEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iEmpEN.Adicionales.Mensaje, this.eTitulo);
                this.cmbEstEmp.Focus();
            }
            return iEmpEN.Adicionales.EsVerdad;
        }

        public void ModificarEmpresa()
        {
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();
            this.AsignarEmpresa(iEmpEN);
            iEmpEN = DeclaracionesEmpresaController.BuscarEmpresaXCodigo(iEmpEN);
            this.AsignarEmpresa(iEmpEN);
            DeclaracionesEmpresaController.ModificarEmpresa(iEmpEN);
        }
        public void VentanaEliminar(DeclaracionesEmpresaDto pEmp)
        {
            this.InicializaVentana();
            this.MostrarEmpresa(pEmp);
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }
        public void Eliminar()
        {
            //es acto eliminar esta empresa
            if (this.wEmp.EsActoEliminarEmpresa().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarEmpresa();

            //eliminar los permisos empresa de esta empresa
            this.EliminarPermisosEmpresa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria(this.eTitulo + " eliminada correctamente", this.eTitulo);

            //actualizar al wUsu           
            this.wEmp.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        public void EliminarEmpresa()
        {
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();
            this.AsignarEmpresa(iEmpEN);
            DeclaracionesEmpresaController.EliminarEmpresa(iEmpEN);
        }
        public void EliminarPermisosEmpresa()
        {
            DeclaracionesPermisoEmpresaDto iPemEN = new DeclaracionesPermisoEmpresaDto();
            iPemEN.CodigoEmpresa = this.txtCodEmp.Text.Trim();
            DeclaracionesPermisoEmpresaController.EliminarPermisosEmpresaXEmpresa(iPemEN);
        }
        public void VentanaVisualizar(DeclaracionesEmpresaDto pEmp)
        {
            this.InicializaVentana();
            this.MostrarEmpresa(pEmp);
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }
        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, eTitulo);
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void txtCodEmp_Validated(object sender, EventArgs e)
        {
            this.EsCodigoEmpresaDisponible();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void frmEditEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wEmp.Enabled = true;
        }
    }
}
