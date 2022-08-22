using Comun;
using DeclaracionesController.Controller;
using DeclaracionesModel.ModelDto;
using DeclaracionesUtil.Util;
using DeclaracionesView.Generales;
using Heredados.VentanasPersonalizadas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;
using PrinterAPI;
namespace DeclaracionesView.Declaraciones
{
    public partial class frmDeclaracionesCompras : Form
    {
        string eNombreColumnaDgvRegCom = DeclaracionesRegistroCompraDto.NumCorrCom;
        string eEncabezadoColumnaDgvRegCom = "Numero";
        public string eClaveDgvRegCom = string.Empty;
        Dgv.Franja eFranjaDgvRegCom = Dgv.Franja.PorIndice;
        public List<DeclaracionesRegistroCompraDto> eLisRegCom = new List<DeclaracionesRegistroCompraDto>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Registro Compra";
        public clsPrinter objPrinter = new clsPrinter();

        public frmDeclaracionesCompras()
        {
            InitializeComponent();
        }
        public void NuevaVentana()
        {
            this.Dock = DockStyle.Fill;
            this.MostrarPersistencia();
            this.Show();
            this.ActualizarVentana();
        }
        public void MostrarPersistencia()
        {
            TsL.MostrarValor(lblPeriodo, Properties.Settings.Default.GuardarPeriodoIngresos, Universal.gCodigoEmpresa);
        }
        public void AccionAdicionar()
        {
            DeclaracionesRegistroCompraDto iRegComDto = this.EsActoAdicionarRegistroCompra();
            if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            frmEditDeclaracionesCompras win = new frmEditDeclaracionesCompras();
            win.wDecCom = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvRegCom = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public DeclaracionesRegistroCompraDto EsActoAdicionarRegistroCompra()
        {
            DeclaracionesRegistroCompraDto iRegCom = new DeclaracionesRegistroCompraDto();
            this.AsignarMovimientoCabe(iRegCom);
            iRegCom = DeclaracionesRegistroCompraController.EsActoAdicionarMovimientoCabe(iRegCom);
            if (iRegCom.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iRegCom.Adicionales.Mensaje, this.eTitulo);
            }

            return iRegCom;
        }
        public void AsignarMovimientoCabe(DeclaracionesRegistroCompraDto pIng)
        {
            pIng.ClaveRegistroCompra = Dgv.ObtenerValorCelda(this.DgvDeclarar, DeclaracionesRegistroCompraDto.ClaObj);
            pIng.PeriodoRegistroCompra = lblPeriodo.Text;
        }
        public void AccionCambiaPeriodo()
        {
            //poner la descripcion del mes
            lblDescripcionPeriodo.Text = AñoMes.ObtenerDescripcionPeriodo(lblPeriodo.Text);

            //MessageBox.Show(lblDescripcionPeriodo.Text);

            //guardar el nuevo periodo
            Properties.Settings.Default.GuardarPeriodoIngresos = TsL.ModificarValor(Properties.Settings.Default.GuardarPeriodoIngresos, Universal.gCodigoEmpresa, lblPeriodo);
            Properties.Settings.Default.Save();

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionSeleccionarPeriodo()
        {
            frmSeleccionarPeriodo win = new frmSeleccionarPeriodo();
            win.eVentanaInvoca = this;
            win.eControlDevuelveValor = lblPeriodo;
            win.ePeriodoActual = lblPeriodo.Text;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public void ActualizarVentana()
        {
            this.ActualizarListaRegistroCompraDeBaseDatos();
            this.ActualizarDgvRegCom();
            Dgv.HabilitarDesplazadores(this.DgvDeclarar, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvDeclarar, this.sst1);
            this.AccionBuscar();
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvRegCom;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvRegCom()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvDeclarar;
            List<DeclaracionesRegistroCompraDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvRegCom;
            string iClaveBusqueda = eClaveDgvRegCom;
            string iColumnaPintura = eNombreColumnaDgvRegCom;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvRegCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<DeclaracionesRegistroCompraDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvRegCom;
            List<DeclaracionesRegistroCompraDto> iListaMovimientoCabes = eLisRegCom;

            //ejecutar y retornar
            return DeclaracionesRegistroCompraController.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaMovimientoCabes);
        }
        public void ActualizarListaRegistroCompraDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            DeclaracionesRegistroCompraDto iCuoEN = new DeclaracionesRegistroCompraDto();
            iCuoEN.PeriodoRegistroCompra = lblPeriodo.Text;
            iCuoEN.Adicionales.CampoOrden = eNombreColumnaDgvRegCom;
            this.eLisRegCom = DeclaracionesRegistroCompraController.ListarRegistroCompraXPeriodo(iCuoEN);
        }
        public List<DataGridViewColumn> ListarColumnasDgvRegCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroCompraDto.NumCorrCom, "Numero", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroCompraDto.CodUnOpeCom, "Cod. Unico Op.", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroCompraDto.FecEmiCompPagCom, "Fec. Emisión", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroCompraDto.FecVencPagCom, "Fec. Vencimiento", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroCompraDto.NTipCompPagCom, "Tip. Comprobante", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroCompraDto.SerCompPagCom, "Ser. Comprobante", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroCompraDto.NumCompPagCom, "Nro. Comprobante", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(DeclaracionesRegistroCompraDto.DescAux, "Raz. Social", 150, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroCompraDto.BasImpoOpeGravCom, "Base Imponible", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroCompraDto.MontImpuGenVen, "Impuesto", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroCompraDto.ImporTotComproPagCom, "Importe Total", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroCompraDto.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesRegistroCompraDto iRegComDto = this.EsActoModificarMovimientoCabe();
            if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditDeclaracionesCompras win = new frmEditDeclaracionesCompras();
            win.wDecCom = this;
            win.eOperacion = Universal.Opera.Modificar;
            win.wOrigenVentana = "1";
            this.eFranjaDgvRegCom = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iRegComDto);
        }
        public DeclaracionesRegistroCompraDto EsActoModificarMovimientoCabe()
        {
            DeclaracionesRegistroCompraDto iRegComDto = new DeclaracionesRegistroCompraDto();
            this.AsignarMovimientoCabe(iRegComDto);
            iRegComDto = DeclaracionesRegistroCompraController.EsActoModificarRegistroCompra(iRegComDto);
            if (iRegComDto.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iRegComDto.Adicionales.Mensaje, this.eTitulo);
            }
            return iRegComDto;
        }
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesRegistroCompraDto iRegComDto = this.EsActoEliminarRegistroCompra();
            if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditDeclaracionesCompras win = new frmEditDeclaracionesCompras();
            win.wDecCom = this;
            win.eOperacion = Universal.Opera.Eliminar;
            win.wOrigenVentana = "1";
            this.eFranjaDgvRegCom = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iRegComDto);
        }
        public DeclaracionesRegistroCompraDto EsActoEliminarRegistroCompra()
        {
            DeclaracionesRegistroCompraDto iRegComDto = new DeclaracionesRegistroCompraDto();
            this.AsignarMovimientoCabe(iRegComDto);
            iRegComDto = DeclaracionesRegistroCompraController.EsActoEliminarMovimientoCabe(iRegComDto);
            if (iRegComDto.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iRegComDto.Adicionales.Mensaje, this.eTitulo);
            }
            return iRegComDto;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesRegistroCompraDto iCuoEN = this.EsRegistroCompraExistente();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditDeclaracionesCompras win = new frmEditDeclaracionesCompras();
            win.wDecCom = this;
            win.eOperacion = Universal.Opera.Visualizar;
            win.wOrigenVentana = "1";
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iCuoEN);
        }
        public DeclaracionesRegistroCompraDto EsRegistroCompraExistente()
        {
            DeclaracionesRegistroCompraDto iRegComDto = new DeclaracionesRegistroCompraDto();
            this.AsignarMovimientoCabe(iRegComDto);
            iRegComDto = DeclaracionesRegistroCompraController.EsRegistroCompraExistente(iRegComDto);
            if (iRegComDto.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iRegComDto.Adicionales.Mensaje, this.eTitulo);
            }
            return iRegComDto;
        }
        public void Cerrar()
        {
            //obtener al wMenu
            frmMenuDeclaraciones wMen = (frmMenuDeclaraciones)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmiDecCom, null);
        }
        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {
                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvDeclarar, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvDeclarar, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
        public void GenerarArchivoSunatRegistroCompra()
        {
            DeclaracionesEmpresaDto iEmpresa = new DeclaracionesEmpresaDto();
            iEmpresa.CodigoEmpresa = Universal.gCodigoEmpresa;
            string identificadorFijo = ConfigurationManager.AppSettings["IdentificadorFijo"].ToString();
            iEmpresa = DeclaracionesEmpresaController.BuscarEmpresaXCodigo(iEmpresa);
            string ruc = iEmpresa.RucEmpresa;
            string anio = this.lblDescripcionPeriodo.Text.Substring(0, 4);
            string mes = UtilFecha.NumeroMesDelNombreDelMes(this.lblDescripcionPeriodo.Text.Substring(5).ToUpper());
            string periodo = anio.ToString() + mes.ToString() + "00";
            string identificadorLibro = ConfigurationManager.AppSettings["IdentificadorLibroCompra"].ToString();
            string identificadorSubLibro = ConfigurationManager.AppSettings["IdentificadorSubLibroCompra"].ToString();
            string identificadorSubSubLibro = ConfigurationManager.AppSettings["IdentificadorSubSubLibroCompra"].ToString();
            string identificadorLLLLLL = identificadorLibro.ToString() + identificadorSubLibro.ToString() + identificadorSubSubLibro.ToString();
            string codigoOportunidad = "00";
            string indicadorOperaciones = "1";
            string indicadorContenido = "1";
            string indicadorMoneda = "1";
            string indicadorPLE = "1";
            string nombreArchivo = identificadorFijo + ruc + periodo + identificadorLLLLLL + codigoOportunidad + indicadorOperaciones + indicadorContenido + indicadorMoneda + indicadorPLE;
            string ruta = ConfigurationManager.AppSettings["RutaArchivoRegistro"].ToString();
            UtilDirectorio.CrearCarpeta(ruta + "\\" + ruc);
            UtilDirectorio.CrearCarpeta(ruta + "\\" + ruc + "\\RegistroCompras");
            string rutaCompleta = ruta + "\\" + ruc + "\\RegistroCompras\\" + nombreArchivo + ".txt";
            this.CrearArchivo(rutaCompleta);
            Mensaje.OperacionSatisfactoria("Se generó el archivo correctamente", this.eTitulo);
        }
        public void CrearArchivo(string rutaCompleta)
        {
            UtilDirectorio.ExisteArchivo(rutaCompleta);
            using (StreamWriter miArchivoRegistroCompra = File.AppendText(rutaCompleta))
            {
                foreach (DeclaracionesRegistroCompraDto registroCompra in this.eLisRegCom)
                {
                    StringBuilder lineas = new StringBuilder();
                    string anio = registroCompra.PeriodoRegistroCompra.Substring(0, 4);
                    string mes = registroCompra.PeriodoRegistroCompra.Substring(5).ToUpper();
                    string periodo = anio.ToString() + mes.ToString() + "00";
                    lineas.Append(periodo.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.CodUnicoOperacionCompra.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.NumCorrelativoCompra.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.FechaEmisionComprobantePagoCompra.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.FechaVencimientoPagoCompra.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.TipoComprobantePagoCompra.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.SerieComprobantePagoCompra.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.AnioEmisionDUA.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.NumComprobantePagoCompra.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.ImporteTotalDiariaCreditoFiscal.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.TipoClienteCompra == "1" ? "6" : "1");
                    lineas.Append("|");
                    lineas.Append(registroCompra.NumeroDocumentoClienteCompra.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.DescripcionAuxiliar.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.BaseImponibleOperacionGravadasCompra > 0 ? Formato.NumeroDecimalSinRedondeo(registroCompra.BaseImponibleOperacionGravadasCompra.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroCompra.MontoImpuestoGeneralVentas > 0 ? Formato.NumeroDecimalSinRedondeo(registroCompra.MontoImpuestoGeneralVentas.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroCompra.BaseImponibleNoGravadasExportacionCompra > 0 ? Formato.NumeroDecimalSinRedondeo(registroCompra.BaseImponibleNoGravadasExportacionCompra.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroCompra.MontoImpuestoGeneralVentasSegundo > 0 ? Formato.NumeroDecimalSinRedondeo(registroCompra.MontoImpuestoGeneralVentasSegundo.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroCompra.BaseImponibleNoGravadasExportacionCompraTercero > 0 ? Formato.NumeroDecimalSinRedondeo(registroCompra.BaseImponibleNoGravadasExportacionCompraTercero.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroCompra.MontoImpuestoGeneralVentasTercero > 0 ? Formato.NumeroDecimalSinRedondeo(registroCompra.MontoImpuestoGeneralVentasTercero.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroCompra.ValorAdquisicionesNoGravadas > 0 ? Formato.NumeroDecimalSinRedondeo(registroCompra.ValorAdquisicionesNoGravadas.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroCompra.MontoImpuestoSelectivo > 0 ? Formato.NumeroDecimalSinRedondeo(registroCompra.MontoImpuestoSelectivo.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroCompra.ImpuestoConsumoBolsasPlastico > 0 ? Formato.NumeroDecimalSinRedondeo(registroCompra.ImpuestoConsumoBolsasPlastico.ToString().Trim(), 2) : "0.00");
                    lineas.Append("|");
                    lineas.Append(registroCompra.OtrosConceptosTributosCargosBaseImponible > 0 ? Formato.NumeroDecimalSinRedondeo(registroCompra.OtrosConceptosTributosCargosBaseImponible.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroCompra.ImporteTotalComprobantePagoCompra > 0 ? Formato.NumeroDecimalSinRedondeo(registroCompra.ImporteTotalComprobantePagoCompra.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroCompra.CodigoMoneda == "0" ? "1" : "2");
                    lineas.Append("|");
                    lineas.Append(registroCompra.CodigoMoneda == "0" ? "" : registroCompra.TipoCambio.ToString().Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.FechaEmisionComprobantePagoModifica.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.TipoComprobantePagoModifica.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.SerieComprobantePagoModifica.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.CodigoAduaneraDUA.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.NumeroComprobantePagoModifica.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.NumeroConstanciaDetraccion.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.MarcaComprobanteRetencion.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.ClasificacionBienesServicios.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.IdentificacionContratoProyecto.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.ErrorTipo.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.ErrorTipoSegundo.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.ErrorTipoTercero.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.ErrorTipoCuarto.Trim());
                    lineas.Append("|");
                    lineas.Append(registroCompra.IdentificadorComprobantePagoCancelados.Trim().Length > 0 ? registroCompra.IdentificadorComprobantePagoCancelados.Trim() : "1");
                    lineas.Append("|");
                    lineas.Append(registroCompra.EstadoIdentificaAnotacion.Trim().Length > 0 ? registroCompra.IdentificadorComprobantePagoCancelados.Trim() : "1");
                    lineas.Append("|");
                    string linea = lineas.ToString();
                    miArchivoRegistroCompra.WriteLine(linea);
                }
                miArchivoRegistroCompra.Close();
            }
        }

        public void AccionImprimirCompras()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesRegistroCompraDto iRegComEN = this.EsRegistroCompraExistente();
            if (iRegComEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            objPrinter.PrintNewPage();
            objPrinter.PrintDataLn(("Estudios Contables Angelica").PadRight(40));
            objPrinter.PrintDataLn(("Av. Brasil 4112").PadRight(40));
            objPrinter.PrintEndDoc();
        }
        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionAdicionar();
        }

        private void lblPeriodo_TextChanged(object sender, EventArgs e)
        {
            this.AccionCambiaPeriodo();
        }

        private void btnPeriodo_Click(object sender, EventArgs e)
        {
            this.AccionSeleccionarPeriodo();
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvDeclarar, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvDeclarar, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvDeclarar, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvDeclarar, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvRegCom = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
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

        private void frmDeclaracionesCompras_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void tsbGenerar_Click(object sender, EventArgs e)
        {
            this.GenerarArchivoSunatRegistroCompra();
        }

        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            this.AccionImprimirCompras();
        }
    }
}
