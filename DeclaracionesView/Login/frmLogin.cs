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
using Comun;
using WinControles.ControlesWindows;
using DeclaracionesUtil.Util;
using DeclaracionesModel.ModelDto;
using DeclaracionesController.Controller;
using DeclaracionesView.MdiPrincipal;
using DeclaracionesView.Listas;

namespace DeclaracionesView.Login
{
    public partial class frmLogin : Form
    {
        #region Owner
        Masivo eMas = new Masivo();
        public frmPrincipal frmPrincipal;
        DeclaracionesAccessController declaracionesAccessController = new DeclaracionesAccessController();
        UtilDeclaraciones utilCredits = new UtilDeclaraciones();
        public int eFlagInvoca = 0;//0: al iniciar el sistema,1: cambio de usuario
        #endregion

        public frmLogin()
        {
            InitializeComponent();
        }

        #region Methods
        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNameUsr, this.txtCodUsr, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtProfile, this.txtCodUsr, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodUsr, true, "Usuario", "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtPwd, true, "Contraseña", "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodEmp, true, "Empresa", "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomEmp, this.txtCodUsr, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnGetInto, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancel, "f");
            xLis.Add(xCtrl);

            return xLis;
        }
        public void InitWindow()
        {
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
        }
        public void NewWindow()
        {
            this.InitWindow();
            this.MostrarPersistencia();
            this.ShowDialog();
        }
        public void MostrarPersistencia()
        {
            this.txtNameUsr.Text = Properties.Settings.Default.GuardarNombreUsuario;
            this.txtCodUsr.Text = Properties.Settings.Default.GuardarCodigoUsuario;
            this.txtCodPro.Text = Properties.Settings.Default.GuardarCodigoPerfil;
            this.txtProfile.Text = Properties.Settings.Default.GuardarNombrePerfil;
            this.txtPwd.Text = Properties.Settings.Default.GuardarClaveUsuario;
            this.txtCodEmp.Text = Properties.Settings.Default.GuardarCodigoEmpresa;
            this.txtNomEmp.Text = Properties.Settings.Default.GuardarNombreEmpresa;
            this.ckbUsr.Checked = Conversion.CadenaABoolean(Properties.Settings.Default.GuardarCheckUsuario, false);
            this.ckbPwd.Checked = Conversion.CadenaABoolean(Properties.Settings.Default.GuardarCheckClave, false);
            this.ckbEmp.Checked = Conversion.CadenaABoolean(Properties.Settings.Default.GuardarCheckEmpresa, false);
        }
        public void AccessSystem()
        {
            if (eMas.CamposObligatorios() == false) { return; }

            //chequear si el usuario es valido
            if (this.EsUsuarioValido() == false) { return; }
            //comprobar si la clave es correcta     
            if (this.EsClaveDeUsuario() == false) { return; }

            //aqui paso todas las validaciones
            //pasamos las variables globales
            this.GuardarValoresUniversales();

            //Guardar la persistencia de datos
            this.GrabarPersistencia();

            //barra de estado para el menu         
            this.frmPrincipal.tssStatusBar.Text = Universal.EstadoBarra();

            //eliminar todas las ventanas abiertas
            this.frmPrincipal.EliminarTodasLasVentanasAbiertas();

            //eliminar todos los TabModulos que esten abiertos
            this.frmPrincipal.EliminarTodosLosTabVentanas();

            //cerrar ventana acceso
            this.Close();
        }
        public bool EsUsuarioValido()
        {
            DeclaracionesAccessDto iUsuEN = new DeclaracionesAccessDto();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = this.declaracionesAccessController.EsUsuarioValido(iUsuEN);
            if (iUsuEN.Additionals.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Additionals.Mensaje, "Usuario");
                this.txtCodUsr.Focus();
            }
            this.txtCodUsr.Text = iUsuEN.CodigoUsuario;
            this.txtNameUsr.Text = iUsuEN.NombreUsuario;
            this.txtCodPro.Text = iUsuEN.CodigoPerfil;
            this.txtProfile.Text = iUsuEN.NombrePerfil;
            return iUsuEN.Additionals.EsVerdad;
        }
        public void AsignarUsuario(DeclaracionesAccessDto pUsu)
        {
            pUsu.CodigoUsuario = this.txtCodUsr.Text.Trim();
            pUsu.NombreUsuario = this.txtNameUsr.Text.Trim();
            pUsu.ClaveUsuario = Encriptacion.Encriptar(this.txtPwd.Text.Trim());
        }

        public bool EsClaveDeUsuario()
        {
            DeclaracionesAccessDto iUsuEN = new DeclaracionesAccessDto();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = this.declaracionesAccessController.EsContrasenaDeUsuario(iUsuEN);
            if (iUsuEN.Additionals.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Additionals.Mensaje, "Clave");
                this.txtPwd.Clear();
                this.txtPwd.Focus();
            }
            return iUsuEN.Additionals.EsVerdad;
        }

        public void GuardarValoresUniversales()
        {
            Universal.gCodigoUsuario = this.txtCodUsr.Text.Trim();
            Universal.gNombreUsuario = this.txtNameUsr.Text.Trim();
            Universal.gCodigoEmpresa = this.txtCodEmp.Text.Trim();
            Universal.gNombreEmpresa = this.txtNomEmp.Text.Trim();
            Universal.gNombreUsuario = this.txtNameUsr.Text.Trim();
            Universal.gNombrePerfil = this.txtProfile.Text.Trim();
        }

        public void GrabarPersistencia()
        {
            //guardando datos usuario
            Properties.Settings.Default.GuardarCheckUsuario = this.ckbUsr.Checked.ToString().ToLower();
            bool iValor = this.ckbUsr.Checked;
            Properties.Settings.Default.GuardarCodigoUsuario = Cadena.ObtenerValor(iValor, this.txtCodUsr.Text);
            Properties.Settings.Default.GuardarNombreUsuario = Cadena.ObtenerValor(iValor, this.txtNameUsr.Text);
            Properties.Settings.Default.GuardarNombrePerfil = Cadena.ObtenerValor(iValor, this.txtProfile.Text);

            //guardando datos clave
            Properties.Settings.Default.GuardarCheckClave = this.ckbPwd.Checked.ToString().ToLower();
            iValor = this.ckbPwd.Checked;
            Properties.Settings.Default.GuardarClaveUsuario = Cadena.ObtenerValor(iValor, this.txtPwd.Text);

            //guardar todos los datos
            Properties.Settings.Default.Save();
        }
        public void Cancelar()
        {
            //segun flag de invocacion de la ventana
            if (this.eFlagInvoca == 0)
            {
                Application.Exit();
            }
            else
            {
                //habilitamos el menu principal
                if (this.frmPrincipal.tbcContainer.TabPages.Count != 0)
                {
                    this.frmPrincipal.tbcContainer.Visible = true;
                    this.frmPrincipal.BackColor = Color.LightYellow;
                }
                this.Close();
            }
        }
        public bool EsEmpresaDeUsuario()
        {
            //preguntamos si la empresa que se digita es del usuario seleccionado
            DeclaracionesPermisoEmpresaDto iPemEN = new DeclaracionesPermisoEmpresaDto();
            iPemEN.CodigoUsuario = this.txtCodUsr.Text.Trim();
            iPemEN.CodigoEmpresa = this.txtCodEmp.Text.Trim();
            iPemEN.ClavePermisoEmpresa = DeclaracionesPermisoEmpresaController.ObtenerClavePermisoEmpresa(iPemEN);
            iPemEN = DeclaracionesPermisoEmpresaController.EsEmpresaDeUsuario(iPemEN);
            if (iPemEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPemEN.Adicionales.Mensaje, "Empresa");
                this.txtCodEmp.Focus();
            }
            this.txtCodEmp.Text = iPemEN.CodigoEmpresa;
            this.txtNomEmp.Text = iPemEN.NombreEmpresa;
            return iPemEN.Adicionales.EsVerdad;
        }
        public void ListarUsuarios()
        {
            frmLisUsrExt win = new frmLisUsrExt();
            this.AddOwnedForm(win);
            win.eVentana = this;
            win.eTituloVentana = "Usuarios activos";
            win.eCtrlValor = this.txtCodUsr;
            win.eCtrlFoco = this.txtPwd;
            win.eCondicionLista = frmLisUsrExt.Condicion.UsuariosActivos;
            win.NuevaVentana();
        }
        public void ListarEmpresasDeUsuario()
        {
            frmLisPerEmpExt win = new frmLisPerEmpExt();
            win.eVentana = this;
            win.eTituloVentana = "Empresas autorizadas";
            win.eCtrlValor = this.txtCodEmp;
            win.eCtrlFoco = this.btnGetInto;
            //condicion
            win.ePemEN.CodigoUsuario = this.txtCodUsr.Text.Trim();
            win.eCondicionLista = frmLisPerEmpExt.Condicion.EmpresasAutorizadasDeUsuario;
            win.NuevaVentana();
        }
        #endregion

        #region Eventos
        private void btnGetInto_Click(object sender, EventArgs e)
        {
            this.AccessSystem();
        }
        private void txtCodUsr_Validating(object sender, CancelEventArgs e)
        {
            this.EsUsuarioValido();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodEmp_Validating(object sender, CancelEventArgs e)
        {
            this.EsEmpresaDeUsuario();
        }
        private void txtCodUsr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarUsuarios(); }
        }

        private void txtCodUsr_DoubleClick(object sender, EventArgs e)
        {
            this.ListarUsuarios();
        }

        private void txtCodEmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarEmpresasDeUsuario(); }
        }

        private void txtCodEmp_DoubleClick(object sender, EventArgs e)
        {
            this.ListarEmpresasDeUsuario();
        }
        #endregion


    }
}
