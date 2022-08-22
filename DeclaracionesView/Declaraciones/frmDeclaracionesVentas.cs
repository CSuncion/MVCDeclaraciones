using Comun;
using DeclaracionesController.Controller;
using DeclaracionesModel.ModelDto;
using DeclaracionesUtil.Util;
using DeclaracionesView.Generales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;
using PrinterAPI;

namespace DeclaracionesView.Declaraciones
{
    public partial class frmDeclaracionesVentas : Form
    {
        string eNombreColumnaDgvRegVen = DeclaracionesRegistroVentaDto.NumCorrVen;
        string eEncabezadoColumnaDgvRegVen = "Numero";
        public string eClaveDgvRegVen = string.Empty;
        Dgv.Franja eFranjaDgvRegVen = Dgv.Franja.PorIndice;
        public List<DeclaracionesRegistroVentaDto> eLisRegVen = new List<DeclaracionesRegistroVentaDto>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Registro Venta";
        clsPrinter obj = new clsPrinter();
        public frmDeclaracionesVentas()
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
            DeclaracionesRegistroVentaDto iRegVenDto = this.EsActoAdicionarRegistroVenta();
            if (iRegVenDto.Adicionales.EsVerdad == false) { return; }

            frmEditDeclaracionesVentas win = new frmEditDeclaracionesVentas();
            win.wDecVen = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvRegVen = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public DeclaracionesRegistroVentaDto EsActoAdicionarRegistroVenta()
        {
            DeclaracionesRegistroVentaDto iRegCom = new DeclaracionesRegistroVentaDto();
            this.AsignarMovimientoCabe(iRegCom);
            iRegCom = DeclaracionesRegistroVentaController.EsActoAdicionarMovimientoCabe(iRegCom);
            if (iRegCom.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iRegCom.Adicionales.Mensaje, this.eTitulo);
            }

            return iRegCom;
        }
        public void AsignarMovimientoCabe(DeclaracionesRegistroVentaDto pIng)
        {
            pIng.ClaveRegistroVenta = Dgv.ObtenerValorCelda(this.DgvDeclarar, DeclaracionesRegistroVentaDto.ClaObj);
            pIng.PeriodoRegistroVenta = lblPeriodo.Text;
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
            this.ActualizarListaRegistroVentaDeBaseDatos();
            this.ActualizarDgvRegCom();
            Dgv.HabilitarDesplazadores(this.DgvDeclarar, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvDeclarar, this.sst1);
            this.AccionBuscar();
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvRegVen;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvRegCom()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvDeclarar;
            List<DeclaracionesRegistroVentaDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvRegVen;
            string iClaveBusqueda = eClaveDgvRegVen;
            string iColumnaPintura = eNombreColumnaDgvRegVen;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvRegCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<DeclaracionesRegistroVentaDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvRegVen;
            List<DeclaracionesRegistroVentaDto> iListaMovimientoCabes = eLisRegVen;

            //ejecutar y retornar
            return DeclaracionesRegistroVentaController.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaMovimientoCabes);
        }
        public void ActualizarListaRegistroVentaDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            DeclaracionesRegistroVentaDto iCuoEN = new DeclaracionesRegistroVentaDto();
            iCuoEN.PeriodoRegistroVenta = lblPeriodo.Text;
            iCuoEN.Adicionales.CampoOrden = eNombreColumnaDgvRegVen;
            this.eLisRegVen = DeclaracionesRegistroVentaController.ListarRegistroVentaXPeriodo(iCuoEN);
        }
        public List<DataGridViewColumn> ListarColumnasDgvRegCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroVentaDto.NumCorrVen, "Numero", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroVentaDto.CodUnOpVen, "Cod. Unico Op.", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroVentaDto.FecEmiCompPagVen, "Fec. Emisión", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroVentaDto.FecVencPagVen, "Fec. Vencimiento", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroVentaDto.NTipCompPagVen, "Tip. Comprobante", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroVentaDto.SerCompPagVen, "Ser. Comprobante", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroVentaDto.NumCompPagVen, "Nro. Comprobante", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(DeclaracionesRegistroVentaDto.DescAux, "Raz. Social", 150, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroVentaDto.BasImpOpeVen, "Base Imponible", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroVentaDto.ImpuGenVen, "Impuesto", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroVentaDto.ImpoTotCompPagVen, "Importe Total", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesRegistroVentaDto.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesRegistroVentaDto iRegComDto = this.EsActoModificarMovimientoCabe();
            if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditDeclaracionesVentas win = new frmEditDeclaracionesVentas();
            win.wDecVen = this;
            win.eOperacion = Universal.Opera.Modificar;
            win.wOrigenVentana = "1";
            this.eFranjaDgvRegVen = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iRegComDto);
        }
        public DeclaracionesRegistroVentaDto EsActoModificarMovimientoCabe()
        {
            DeclaracionesRegistroVentaDto iRegComDto = new DeclaracionesRegistroVentaDto();
            this.AsignarMovimientoCabe(iRegComDto);
            iRegComDto = DeclaracionesRegistroVentaController.EsActoModificarRegistroVenta(iRegComDto);
            if (iRegComDto.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iRegComDto.Adicionales.Mensaje, this.eTitulo);
            }
            return iRegComDto;
        }
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesRegistroVentaDto iRegComDto = this.EsActoEliminarRegistroVenta();
            if (iRegComDto.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditDeclaracionesVentas win = new frmEditDeclaracionesVentas();
            win.wDecVen = this;
            win.eOperacion = Universal.Opera.Eliminar;
            win.wOrigenVentana = "1";
            this.eFranjaDgvRegVen = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iRegComDto);
        }
        public DeclaracionesRegistroVentaDto EsActoEliminarRegistroVenta()
        {
            DeclaracionesRegistroVentaDto iRegVenDto = new DeclaracionesRegistroVentaDto();
            this.AsignarMovimientoCabe(iRegVenDto);
            iRegVenDto = DeclaracionesRegistroVentaController.EsActoEliminarMovimientoCabe(iRegVenDto);
            if (iRegVenDto.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iRegVenDto.Adicionales.Mensaje, this.eTitulo);
            }
            return iRegVenDto;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesRegistroVentaDto iCuoEN = this.EsRegistroVentaExistente();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditDeclaracionesVentas win = new frmEditDeclaracionesVentas();
            win.wDecVen = this;
            win.eOperacion = Universal.Opera.Visualizar;
            win.wOrigenVentana = "1";
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iCuoEN);
        }
        public DeclaracionesRegistroVentaDto EsRegistroVentaExistente()
        {
            DeclaracionesRegistroVentaDto iRegComDto = new DeclaracionesRegistroVentaDto();
            this.AsignarMovimientoCabe(iRegComDto);
            iRegComDto = DeclaracionesRegistroVentaController.EsRegistroVentaExistente(iRegComDto);
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
            wMen.CerrarVentanaHijo(this, wMen.tsmiDecVen, null);
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
        public void GenerarArchivoSunatRegistroVenta()
        {
            DeclaracionesEmpresaDto iEmpresa = new DeclaracionesEmpresaDto();
            iEmpresa.CodigoEmpresa = Universal.gCodigoEmpresa;
            string identificadorFijo = ConfigurationManager.AppSettings["IdentificadorFijo"].ToString();
            iEmpresa = DeclaracionesEmpresaController.BuscarEmpresaXCodigo(iEmpresa);
            string ruc = iEmpresa.RucEmpresa;
            string anio = this.lblDescripcionPeriodo.Text.Substring(0, 4);
            string mes = UtilFecha.NumeroMesDelNombreDelMes(this.lblDescripcionPeriodo.Text.Substring(5).ToUpper());
            string periodo = anio.ToString() + mes.ToString() + "00";
            string identificadorLibro = ConfigurationManager.AppSettings["IdentificadorLibroVenta"].ToString();
            string identificadorSubLibro = ConfigurationManager.AppSettings["IdentificadorSubLibroVenta"].ToString();
            string identificadorSubSubLibro = ConfigurationManager.AppSettings["IdentificadorSubSubLibroVenta"].ToString();
            string identificadorLLLLLL = identificadorLibro.ToString() + identificadorSubLibro.ToString() + identificadorSubSubLibro.ToString();
            string codigoOportunidad = "00";
            string indicadorOperaciones = "1";
            string indicadorContenido = "1";
            string indicadorMoneda = "1";
            string indicadorPLE = "1";
            string nombreArchivo = identificadorFijo + ruc + periodo + identificadorLLLLLL + codigoOportunidad + indicadorOperaciones + indicadorContenido + indicadorMoneda + indicadorPLE;
            string ruta = ConfigurationManager.AppSettings["RutaArchivoRegistro"].ToString();
            UtilDirectorio.CrearCarpeta(ruta + "\\" + ruc);
            UtilDirectorio.CrearCarpeta(ruta + "\\" + ruc + "\\RegistroVentas");
            string rutaCompleta = ruta + "\\" + ruc + "\\RegistroVentas\\" + nombreArchivo + ".txt";
            this.CrearArchivo(rutaCompleta);
            Mensaje.OperacionSatisfactoria("Se generó el archivo correctamente", this.eTitulo);
        }
        public void CrearArchivo(string rutaCompleta)
        {
            UtilDirectorio.ExisteArchivo(rutaCompleta);
            using (StreamWriter miArchivoregistroVenta = File.AppendText(rutaCompleta))
            {
                foreach (DeclaracionesRegistroVentaDto registroVenta in this.eLisRegVen)
                {
                    StringBuilder lineas = new StringBuilder();
                    string anio = registroVenta.PeriodoRegistroVenta.Substring(0, 4);
                    string mes = registroVenta.PeriodoRegistroVenta.Substring(5).ToUpper();
                    string periodo = anio.ToString() + mes.ToString() + "00";
                    lineas.Append(periodo.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.CodUnicoOperacionVenta.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.NumCorrelativoVenta.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.FechaEmisionComprobantePagoVenta.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.FechaVencimientoPagoVenta.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.TipoComprobantePagoVenta.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.SerieComprobantePagoVenta.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.NumComprobantePagoVenta.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.RegistroTicketsVenta.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.TipoClienteVenta == "1" ? "6" : "1");
                    lineas.Append("|");
                    lineas.Append(registroVenta.NumeroDocumentoClienteVenta.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.DescripcionAuxiliar.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.ValorFacturadoExportacionVenta > 0 ? Formato.NumeroDecimalSinRedondeo(registroVenta.ValorFacturadoExportacionVenta.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroVenta.BaseImponibleOperacionVenta > 0 ? Formato.NumeroDecimalSinRedondeo(registroVenta.BaseImponibleOperacionVenta.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroVenta.DescuentoBaseImponibleVenta > 0 ? Formato.NumeroDecimalSinRedondeo(registroVenta.DescuentoBaseImponibleVenta.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroVenta.ImpuestoGeneralVenta > 0 ? Formato.NumeroDecimalSinRedondeo(registroVenta.ImpuestoGeneralVenta.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroVenta.DescuentoImpuestoGeneralVenta > 0 ? Formato.NumeroDecimalSinRedondeo(registroVenta.DescuentoImpuestoGeneralVenta.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroVenta.ImporteTotalExoneradaVenta > 0 ? Formato.NumeroDecimalSinRedondeo(registroVenta.ImporteTotalExoneradaVenta.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroVenta.ImporteTotalInafecta > 0 ? Formato.NumeroDecimalSinRedondeo(registroVenta.ImporteTotalInafecta.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroVenta.ImpuestoSelectivoConsumoVenta > 0 ? Formato.NumeroDecimalSinRedondeo(registroVenta.ImpuestoSelectivoConsumoVenta.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroVenta.BaseImponibleGravadaVentaArrozPilado > 0 ? Formato.NumeroDecimalSinRedondeo(registroVenta.BaseImponibleGravadaVentaArrozPilado.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroVenta.ImpuestoVentaArrozPilado > 0 ? Formato.NumeroDecimalSinRedondeo(registroVenta.ImpuestoVentaArrozPilado.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroVenta.ImpuestoConsumoBolsaPlastico > 0 ? Formato.NumeroDecimalSinRedondeo(registroVenta.ImpuestoConsumoBolsaPlastico.ToString().Trim(), 2) : "0.00");
                    lineas.Append("|");
                    lineas.Append(registroVenta.OtrosConceptoTributosCargosBaseImponible > 0 ? Formato.NumeroDecimalSinRedondeo(registroVenta.OtrosConceptoTributosCargosBaseImponible.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroVenta.ImporteTotalComprobantePagoVenta > 0 ? Formato.NumeroDecimalSinRedondeo(registroVenta.ImporteTotalComprobantePagoVenta.ToString().Trim(), 2) : "");
                    lineas.Append("|");
                    lineas.Append(registroVenta.CodigoMoneda == "0" ? "1" : "2");
                    lineas.Append("|");
                    lineas.Append(registroVenta.CodigoMoneda == "0" ? "" : registroVenta.TipoCambio.ToString().Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.FechaEmisionComprobantePagoModifica.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.TipoComprobantePagoModifica.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.SerieComprobantePagoModifica.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.NumeroComprobantePagoModifica.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.IdentificacionContratoProyecto.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.ErrorTipo.Trim());
                    lineas.Append("|");
                    lineas.Append(registroVenta.IdentificadorComprobantePagoCancelados.Trim().Length > 0 ? registroVenta.IdentificadorComprobantePagoCancelados.Trim() : "1");
                    lineas.Append("|");
                    lineas.Append(registroVenta.EstadoIdentificaAnotacion.Trim().Length > 0 ? registroVenta.IdentificadorComprobantePagoCancelados.Trim() : "1");
                    lineas.Append("|");
                    string linea = lineas.ToString();
                    miArchivoregistroVenta.WriteLine(linea);
                }
                miArchivoregistroVenta.Close();
            }
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

        private void tsbGenerar_Click(object sender, EventArgs e)
        {
            this.GenerarArchivoSunatRegistroVenta();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
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
            this.eFranjaDgvRegVen = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void btnPeriodo_Click(object sender, EventArgs e)
        {
            this.AccionSeleccionarPeriodo();
        }

        private void lblPeriodo_TextChanged(object sender, EventArgs e)
        {
            this.AccionCambiaPeriodo();
        }

        private void frmDeclaracionesVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }
    }
}
