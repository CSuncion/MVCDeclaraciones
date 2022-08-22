using Comun;
using DeclaracionesController.Controller;
using DeclaracionesModel.ModelDto;
using DeclaracionesView.FuncionesGenericas;
using DeclaracionesView.Listas;
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

namespace DeclaracionesView.Declaraciones
{
    public partial class frmEditDeclaracionesVentas : Form
    {

        public frmDeclaracionesVentas wDecVen;
        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public string wTipoCambio, wano, wmes, wperiodo, wOrigenVentana;
        string eNombreColumnaDgvTipOpe = DeclaracionesTipoCambioDto.FecTipCam;
        public List<DeclaracionesTipoCambioDto> eLisTipCam = new List<DeclaracionesTipoCambioDto>();
        #endregion
        public frmEditDeclaracionesVentas()
        {
            InitializeComponent();
        }
        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;


            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodUnOp, true, "Codigo Unico de Operacion", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.dtpFecEmiRegVen, false, "Fecha Emision", "vvff", 20);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.dtpFecVenRegVen, false, "Fecha Vencimiento", "vvff", 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAux, false, "Auxiliar", "vvff", 40);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesAux, false, "Descripcion Auxiliar", "ffff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCTipDoc, false, "Tipo Documento", "vvff", 40);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNTipDoc, false, "Descripcion Documento", "ffff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtSerDoc, false, "Serie Documento", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNumDoc, false, "Número Documento", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMon, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipCam, false, "Tipo Cambio", "ffff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtBasImpo, false, "Base Imponible", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtImpGral, false, "Impuesto General", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtImpTot, false, "Importe Total", "ffff", 150);
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
            this.txtPerRegVen.Text = this.wDecVen.lblDescripcionPeriodo.Text;
            wano = this.txtPerRegVen.Text.Substring(0, 4);
            wmes = this.txtPerRegVen.Text.Substring(5).ToUpper();
            this.NumeroMesDelNombreDelMes();
            wperiodo = Universal.gCodigoEmpresa + "-" + wano + "-" + wmes;

            DeclaracionesPeriodoDto nPeri = new DeclaracionesPeriodoDto();
            nPeri.ClavePeriodo = wperiodo;
            nPeri = DeclaracionesPeriodoController.BuscarPeriodoXClave(nPeri);
            wTipoCambio = nPeri.TipoCambioPeriodo.ToString();

            this.InicializaVentana();
            this.MostrarRegistroVenta(DeclaracionesRegistroVentaController.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.CargarTipoCambio();
            this.txtPerRegVen.Focus();
        }
        public void MostrarRegistroVenta(DeclaracionesRegistroVentaDto pRegCom)
        {
            this.txtNumRegVen.Text = pRegCom.NumCorrelativoVenta;
            this.txtCodUnOp.Text = pRegCom.CodUnicoOperacionVenta;
            this.dtpFecEmiRegVen.Text = pRegCom.FechaEmisionComprobantePagoVenta;
            this.dtpFecVenRegVen.Text = pRegCom.FechaVencimientoPagoVenta;
            this.txtCodAux.Text = pRegCom.NumeroDocumentoClienteVenta;
            this.txtDesAux.Text = pRegCom.DescripcionAuxiliar;
            this.txtCTipDoc.Text = pRegCom.TipoComprobantePagoVenta;
            this.txtNTipDoc.Text = pRegCom.NTipoComprobantePagoVenta;
            this.txtSerDoc.Text = pRegCom.SerieComprobantePagoVenta;
            this.txtNumDoc.Text = pRegCom.NumComprobantePagoVenta;
            Cmb.SeleccionarValorItem(this.cmbMon, pRegCom.CodigoMoneda);
            this.txtCodMonSyD.Text = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            this.txtTipCam.Text = Formato.NumeroDecimal(pRegCom.TipoCambio, 2);
            this.txtBasImpo.Text = Formato.NumeroDecimal(pRegCom.BaseImponibleOperacionVenta, 2);
            this.txtImpGral.Text = Formato.NumeroDecimal(pRegCom.ImpuestoGeneralVenta, 2);
            this.txtImpTot.Text = Formato.NumeroDecimal(pRegCom.ImporteTotalComprobantePagoVenta, 2);
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wDecVen.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos      
            this.CargarMonedas();

            //valores x defecto
            this.ValoresXDefecto();

            // Deshabilitar al propietario
            this.wDecVen.Enabled = false;

            // Mostrar ventana
            this.Show();
        }
        public void NumeroMesDelNombreDelMes()
        {
            if (wmes == "ENERO")
            {
                wmes = "01";
            }
            if (wmes == "FEBRERO")
            {
                wmes = "02";
            }
            if (wmes == "MARZO")
            {
                wmes = "03";
            }
            if (wmes == "ABRIL")
            {
                wmes = "04";
            }
            if (wmes == "MAYO")
            {
                wmes = "05";
            }
            if (wmes == "JUNIO")
            {
                wmes = "06";
            }
            if (wmes == "JULIO")
            {
                wmes = "07";
            }
            if (wmes == "AGOSTO")
            {
                wmes = "08";
            }
            if (wmes == "SETIEMBRE")
            {
                wmes = "09";
            }
            if (wmes == "OCTUBRE")
            {
                wmes = "10";
            }
            if (wmes == "NOVIEMBRE")
            {
                wmes = "11";
            }
            if (wmes == "DICIEMBRE")
            {
                wmes = "12";
            }
        }
        public void CargarMonedas()
        {
            Cmb.Cargar(this.cmbMon, DeclaracionesItemGController.ListarItemsG("Moneda"), DeclaracionesItemGDto.CodIteG, DeclaracionesItemGDto.NomIteG);
        }
        public void ListarProveedores()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAux.ReadOnly == true) { return; }

            //instanciar
            frmLisAux win = new frmLisAux();
            win.eVentana = this;
            win.eTituloVentana = "Proveedores";
            win.eCtrlValor = this.txtCodAux;
            win.eCtrlFoco = this.txtCTipDoc;
            win.eCondicionLista = Listas.frmLisAux.Condicion.ProveedoresActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public bool EsProveedorValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAux.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();
            iAuxEN.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            iAuxEN = DeclaracionesAuxiliarController.EsProveedorActivoValido(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, this.wDecVen.eTitulo);
                this.txtCodAux.Focus();
            }

            //mostrar datos
            this.txtCodAux.Text = iAuxEN.CodigoAuxiliar;
            this.txtDesAux.Text = iAuxEN.DescripcionAuxiliar;

            //devolver
            return iAuxEN.Adicionales.EsVerdad;
        }
        public void ValoresXDefecto()
        {
            txtPerRegVen.Text = this.wDecVen.lblDescripcionPeriodo.Text;
        }

        public void ListarTiposDocumento()
        {
            //si es de lectura , entonces no lista
            if (this.txtCTipDoc.ReadOnly == true) { return; }

            //instanciar
            frmLisItemG win = new frmLisItemG();
            win.eVentana = this;
            win.eTituloVentana = "Tipos Documento";
            win.eCtrlValor = this.txtCTipDoc;
            win.eCtrlFoco = this.txtSerDoc;
            win.eIteEN.CodigoTabla = "TipCom";
            win.eCondicionLista = Listas.frmLisItemG.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public bool EsTipoDocumentoValido()
        {
            return Generico.EsCodigoItemGValido("TipCom", this.txtCTipDoc, this.txtNTipDoc, "Tipo documento");
        }
        public bool ValidaFechaRegistroVenta()
        {
            //validar solo cuando adiciona y modifica
            if (MiForm.VerdaderoCuandoAdicionaYModifica((int)this.eOperacion) == false) { return true; }

            //asignar parametros
            DeclaracionesRegistroVentaDto iMovCabEN = this.NuevoMovimientoCabeDeVentana();

            //validar
            iMovCabEN = DeclaracionesRegistroVentaController.ValidaCuandoFechaNoEsDelPeriodoElegido(iMovCabEN);
            if (iMovCabEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iMovCabEN.Adicionales.Mensaje, this.wDecVen.eTitulo);
                this.txtCodAux.Focus();
            }

            //devolver
            return iMovCabEN.Adicionales.EsVerdad;
        }
        public DeclaracionesRegistroVentaDto NuevoMovimientoCabeDeVentana()
        {
            DeclaracionesRegistroVentaDto iRegComDto = new DeclaracionesRegistroVentaDto();
            this.AsignarRegistroVenta(iRegComDto);
            return iRegComDto;
        }
        public void AsignarRegistroVenta(DeclaracionesRegistroVentaDto pRegComDto)
        {
            pRegComDto.CodigoEmpresa = Universal.gCodigoEmpresa;
            pRegComDto.PeriodoRegistroVenta = this.wDecVen.lblPeriodo.Text;
            pRegComDto.NumCorrelativoVenta = this.txtNumRegVen.Text.Trim();
            pRegComDto.FechaEmisionComprobantePagoVenta = dtpFecEmiRegVen.Text;
            pRegComDto.FechaVencimientoPagoVenta = dtpFecVenRegVen.Text;
            pRegComDto.CodUnicoOperacionVenta = this.txtCodUnOp.Text.Trim();
            pRegComDto.TipoClienteVenta = "1";
            pRegComDto.NumeroDocumentoClienteVenta = this.txtCodAux.Text.Trim();
            pRegComDto.TipoComprobantePagoVenta = this.txtCTipDoc.Text.Trim();
            pRegComDto.SerieComprobantePagoVenta = this.txtSerDoc.Text.Trim();
            pRegComDto.NumComprobantePagoVenta = this.txtNumDoc.Text.Trim();
            pRegComDto.CodigoMoneda = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            pRegComDto.TipoCambio = Conversion.ADecimal(this.txtTipCam.Text, 0);
            pRegComDto.BaseImponibleOperacionVenta = Conversion.ADecimal(this.txtBasImpo.Text, 0);
            pRegComDto.ImpuestoGeneralVenta = Conversion.ADecimal(this.txtImpGral.Text, 0);
            pRegComDto.ImporteTotalComprobantePagoVenta = Conversion.ADecimal(this.txtImpTot.Text, 2);
            pRegComDto.CEstadoRegistroVenta = "1";
            pRegComDto.ClaveRegistroVenta = DeclaracionesRegistroVentaController.ObtenerClaveMovimientoCabe(pRegComDto);
        }
        public void CargarTipoCambio()
        {
            decimal tipCam = 0;
            DeclaracionesTipoCambioDto objTipCam = new DeclaracionesTipoCambioDto();
            objTipCam.Adicionales.CampoOrden = eNombreColumnaDgvTipOpe;
            eLisTipCam = DeclaracionesTipoCambioController.ListarTipoCambio(objTipCam);

            string fechaTipoCambio = Fecha.ObtenerDiaMesAno(Conversion.ADateTime(dtpFecEmiRegVen.Text));

            if (eLisTipCam.Where(e => e.FechaTipoCambio == fechaTipoCambio).Count() == 0)
            {
                Mensaje.OperacionDenegada("Se debe ingresar un tipo de cambio para la fecha del documento.", this.wDecVen.eTitulo);
                txtTipCam.Text = Formato.NumeroDecimal(0, 4);
            }
            else
                txtTipCam.Text = eLisTipCam.FirstOrDefault(e => e.FechaTipoCambio == fechaTipoCambio).VentaTipoCambio.ToString();

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

            //volver a preguntar si es acto adicionar
            if (this.wDecVen.EsActoAdicionarRegistroVenta().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wDecVen.eTitulo) == false) { return; }

            //mostrar numero movimientoCabe
            this.MostrarNuevoNumero();

            //adicionando el registro
            this.AdicionarRegistroVenta();


            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego el registro Venta correctamente", this.wDecVen.eTitulo);

            //actualizar al propietario  
            this.wDecVen.eClaveDgvRegVen = this.ObtenerClaveRegistroVenta();
            this.wDecVen.ActualizarVentana();


            //limpiar controles
            this.MostrarRegistroVenta(this.ObtenerRegistroVentaParaSegundaAdicion());
            eMas.AccionPasarTextoPrincipal();
            //this.dtpFecMovCab.Focus();
        }
        public DeclaracionesRegistroVentaDto ObtenerRegistroVentaParaSegundaAdicion()
        {
            //objeto
            DeclaracionesRegistroVentaDto iMovCabEN = new DeclaracionesRegistroVentaDto();

            //pasamos los datos que queremos persistir para una segundo o mas adiciones
            iMovCabEN.FechaEmisionComprobantePagoVenta = this.dtpFecEmiRegVen.Text;

            //devolver
            return iMovCabEN;
        }
        public string ObtenerClaveRegistroVenta()
        {
            DeclaracionesRegistroVentaDto iRegComDto = new DeclaracionesRegistroVentaDto();
            this.AsignarRegistroVenta(iRegComDto);
            return iRegComDto.ClaveRegistroVenta;
        }
        public void AdicionarRegistroVenta()
        {
            DeclaracionesRegistroVentaDto iCuoEN = new DeclaracionesRegistroVentaDto();
            this.AsignarRegistroVenta(iCuoEN);
            DeclaracionesRegistroVentaController.AdicionarRegistroVenta(iCuoEN);
        }
        public void MostrarNuevoNumero()
        {
            //asignar parametros
            DeclaracionesRegistroVentaDto iMovCabEN = this.NuevoMovimientoCabeDeVentana();

            //obtener el nuevo numero
            string iNuevoNumero = DeclaracionesRegistroVentaController.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);

            //mostrar en pantalla
            this.txtNumRegVen.Text = iNuevoNumero;
        }
        private void MostrarImporteTotal()
        {
            this.txtImpTot.Text = (Convert.ToDecimal(this.txtBasImpo.Text) + Convert.ToDecimal(this.txtImpGral.Text)).ToString();
        }
        public void VentanaModificar(DeclaracionesRegistroVentaDto pRegCom)
        {
            this.InicializaVentana();
            this.MostrarRegistroVenta(pRegCom);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecEmiRegVen.Focus();
        }
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wDecVen.EsActoAdicionarRegistroVenta().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wDecVen.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarRegistroVenta();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico el registro Venta correctamente", this.wDecVen.eTitulo);

            //actualizar al wLot          
            this.wDecVen.eClaveDgvRegVen = this.ObtenerClaveRegistroVenta();
            this.wDecVen.ActualizarVentana();



            //salir de la ventana
            this.Close();
        }
        public void ModificarRegistroVenta()
        {
            DeclaracionesRegistroVentaDto iRegComDto = new DeclaracionesRegistroVentaDto();
            this.AsignarRegistroVenta(iRegComDto);
            iRegComDto = DeclaracionesRegistroVentaController.BuscarRegistroVentaXClave(iRegComDto);
            this.AsignarRegistroVenta(iRegComDto);
            DeclaracionesRegistroVentaController.ModificarRegistroVenta(iRegComDto);
        }
        public void VentanaEliminar(DeclaracionesRegistroVentaDto pRegCom)
        {
            this.InicializaVentana();
            this.MostrarRegistroVenta(pRegCom);
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wDecVen.EsActoAdicionarRegistroVenta().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wDecVen.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarRegistroVenta();


            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino el ingreso correctamente", this.wDecVen.eTitulo);

            this.wDecVen.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        public void EliminarRegistroVenta()
        {
            DeclaracionesRegistroVentaDto iRegCom = new DeclaracionesRegistroVentaDto();
            this.AsignarRegistroVenta(iRegCom);
            DeclaracionesRegistroVentaController.EliminarRegistroVenta(iRegCom);
        }

        public void VentanaVisualizar(DeclaracionesRegistroVentaDto pRegCom)
        {
            this.InicializaVentana();
            this.MostrarRegistroVenta(pRegCom);
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }



        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wDecVen.eTitulo);
        }

        private void txtCodAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarProveedores(); }
        }

        private void txtCodAux_DoubleClick(object sender, EventArgs e)
        {
            this.ListarProveedores();
        }

        private void txtCTipDoc_Validating(object sender, CancelEventArgs e)
        {
            this.EsTipoDocumentoValido();
        }

        private void txtCTipDoc_DoubleClick(object sender, EventArgs e)
        {
            this.ListarTiposDocumento();
        }

        private void txtCTipDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarTiposDocumento(); }
        }

        private void frmEditDeclaracionesVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wDecVen.Enabled = true;
        }

        private void txtBasImpo_Validated(object sender, EventArgs e)
        {
            this.MostrarImporteTotal();
        }

        private void txtImpGral_Validated(object sender, EventArgs e)
        {
            this.MostrarImporteTotal();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }
        private void dtpFecEmiRegVen_Validated(object sender, EventArgs e)
        {
            this.ValidaFechaRegistroVenta();
            this.CargarTipoCambio();
        }
        private void txtCodAux_Validating(object sender, CancelEventArgs e)
        {
            this.EsProveedorValido();
        }

    }
}