using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesModel.ModelDto
{
    public class DeclaracionesRegistroCompraDto
    {
        public const string ClaObj = "ClaveObjeto";
        public const string ClaRegCom = "ClaveRegistroCompra";
        public const string CodEmp = "CodigoEmpresa";
        public const string PerRegCom = "PeriodoRegistroCompra";
        public const string NumCorrCom = "NumCorrelativoCompra";
        public const string CodUnOpeCom = "CodUnicoOperacionCompra";
        public const string FecEmiCompPagCom = "FechaEmisionComprobantePagoCompra";
        public const string FecVencPagCom = "FechaVencimientoPagoCompra";
        public const string TipCompPagCom = "TipoComprobantePagoCompra";
        public const string NTipCompPagCom = "NTipoComprobantePagoCompra";
        public const string SerCompPagCom = "SerieComprobantePagoCompra";
        public const string NumCompPagCom = "NumComprobantePagoCompra";
        public const string AnioEmiDUA = "AnioEmisionDUA";
        public const string ImpTotalDiaCredFis = "ImporteTotalDiariaCreditoFiscal";
        public const string TipCliCom = "TipoClienteCompra";
        public const string NumDocCliCom = "NumeroDocumentoClienteCompra";
        public const string BasImpoOpeGravCom = "BaseImponibleOperacionGravadasCompra";
        public const string MontImpuGenVen = "MontoImpuestoGeneralVentas";
        public const string BasImpoNoGravExporCom = "BaseImponibleNoGravadasExportacionCompra";
        public const string MonImpuGeneVentSeg = "MontoImpuestoGeneralVentasSegundo";
        public const string BasImpoNoGravExporComTer = "BaseImponibleNoGravadasExportacionCompraTercero";
        public const string MonImpuGeneVentasTer = "MontoImpuestoGeneralVentasTercero";
        public const string ValAdquiNoGrav = "ValorAdquisicionesNoGravadas";
        public const string MonImpuSelec = "MontoImpuestoSelectivo";
        public const string ImpuConsBolPlast = "ImpuestoConsumoBolsasPlastico";
        public const string OtrConceTribCargBasImpo = "OtrosConceptosTributosCargosBaseImponible";
        public const string ImporTotComproPagCom = "ImporteTotalComprobantePagoCompra";
        public const string CodMon = "CodigoMoneda";
        public const string TipCam = "TipoCambio";
        public const string FechEmiComproPagoMod = "FechaEmisionComprobantePagoModifica";
        public const string TipComproPagMod = "TipoComprobantePagoModifica";
        public const string SerComproPagMod = "SerieComprobantePagoModifica";
        public const string CodAduaDUA = "CodigoAduaneraDUA";
        public const string NumComproPagMod = "NumeroComprobantePagoModifica";
        public const string FecEmiConstDepoDetra = "FechaEmisionConstanciaDepositoDetraccion";
        public const string NumConstDetra = "NumeroConstanciaDetraccion";
        public const string MarcComproRete = "MarcaComprobanteRetencion";
        public const string ClasBieServ = "ClasificacionBienesServicios";
        public const string IdentifContrProy = "IdentificacionContratoProyecto";
        public const string ErrTip = "ErrorTipo";
        public const string ErrTipSeg = "ErrorTipoSegundo";
        public const string ErrTipTerc = "ErrorTipoTercero";
        public const string ErrTipCuar = "ErrorTipoCuarto";
        public const string IdentifComproPagCanc = "IdentificadorComprobantePagoCancelados";
        public const string EstaIdentiAnot = "EstadoIdentificaAnotacion";
        public const string CEstRegCom = "CEstadoRegistroCompra";
        public const string NEstRegCom = "NEstadoRegistroCompra";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";
        public const string DescAux = "DescripcionAuxiliar";

        private string _ClaveObjeto = string.Empty;
        private string _ClaveRegistroCompra = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _PeriodoRegistroCompra = string.Empty;
        private string _NumCorrelativoCompra = string.Empty;
        private string _CodUnicoOperacionCompra = string.Empty;
        private string _FechaEmisionComprobantePagoCompra = string.Empty;
        private string _FechaVencimientoPagoCompra = string.Empty;
        private string _TipoComprobantePagoCompra = string.Empty;
        private string _NTipoComprobantePagoCompra = string.Empty;
        private string _SerieComprobantePagoCompra = string.Empty;
        private string _NumComprobantePagoCompra = string.Empty;
        private string _AnioEmisionDUA = string.Empty;
        private string _ImporteTotalDiariaCreditoFiscal = string.Empty;
        private string _TipoClienteCompra = string.Empty;
        private string _NumeroDocumentoClienteCompra = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;
        private decimal _BaseImponibleOperacionGravadasCompra = 0;
        private decimal _MontoImpuestoGeneralVentas = 0;
        private decimal _BaseImponibleNoGravadasExportacionCompra = 0;
        private decimal _MontoImpuestoGeneralVentasSegundo = 0;
        private decimal _BaseImponibleNoGravadasExportacionCompraTercero = 0;
        private decimal _MontoImpuestoGeneralVentasTercero = 0;
        private decimal _ValorAdquisicionesNoGravadas = 0;
        private decimal _MontoImpuestoSelectivo = 0;
        private decimal _ImpuestoConsumoBolsasPlastico = 0;
        private decimal _OtrosConceptosTributosCargosBaseImponible = 0;
        private decimal _ImporteTotalComprobantePagoCompra = 0;
        private string _CodigoMoneda = "0";
        private decimal _TipoCambio = 0;
        private string _FechaEmisionComprobantePagoModifica = string.Empty;
        private string _TipoComprobantePagoModifica = string.Empty;
        private string _SerieComprobantePagoModifica = string.Empty;
        private string _CodigoAduaneraDUA = string.Empty;
        private string _NumeroComprobantePagoModifica = string.Empty;
        private string _FechaEmisionConstanciaDepositoDetraccion = string.Empty;
        private string _NumeroConstanciaDetraccion = string.Empty;
        private string _MarcaComprobanteRetencion = string.Empty;
        private string _ClasificacionBienesServicios = string.Empty;
        private string _IdentificacionContratoProyecto = string.Empty;
        private string _ErrorTipo = string.Empty;
        private string _ErrorTipoSegundo = string.Empty;
        private string _ErrorTipoTercero = string.Empty;
        private string _ErrorTipoCuarto = string.Empty;
        private string _IdentificadorComprobantePagoCancelados = string.Empty;
        private string _EstadoIdentificaAnotacion = string.Empty;
        private string _CEstadoRegistroCompra = string.Empty;
        private string _NEstadoRegistroCompra = string.Empty;
        private string _UsuarioAgrega;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica;
        private DateTime _FechaModifica;
        private Additional _Adicionales = new Additional();

        public string ClaveRegistroCompra { get => _ClaveRegistroCompra; set => _ClaveRegistroCompra = value; }
        public string CodigoEmpresa { get => _CodigoEmpresa; set => _CodigoEmpresa = value; }
        public string PeriodoRegistroCompra { get => _PeriodoRegistroCompra; set => _PeriodoRegistroCompra = value; }
        public string NumCorrelativoCompra { get => _NumCorrelativoCompra; set => _NumCorrelativoCompra = value; }
        public string CodUnicoOperacionCompra { get => _CodUnicoOperacionCompra; set => _CodUnicoOperacionCompra = value; }
        public string FechaEmisionComprobantePagoCompra { get => _FechaEmisionComprobantePagoCompra; set => _FechaEmisionComprobantePagoCompra = value; }
        public string FechaVencimientoPagoCompra { get => _FechaVencimientoPagoCompra; set => _FechaVencimientoPagoCompra = value; }
        public string TipoComprobantePagoCompra { get => _TipoComprobantePagoCompra; set => _TipoComprobantePagoCompra = value; }
        public string NTipoComprobantePagoCompra { get => _NTipoComprobantePagoCompra; set => _NTipoComprobantePagoCompra = value; }
        public string SerieComprobantePagoCompra { get => _SerieComprobantePagoCompra; set => _SerieComprobantePagoCompra = value; }
        public string NumComprobantePagoCompra { get => _NumComprobantePagoCompra; set => _NumComprobantePagoCompra = value; }
        public string AnioEmisionDUA { get => _AnioEmisionDUA; set => _AnioEmisionDUA = value; }
        public string ImporteTotalDiariaCreditoFiscal { get => _ImporteTotalDiariaCreditoFiscal; set => _ImporteTotalDiariaCreditoFiscal = value; }
        public string TipoClienteCompra { get => _TipoClienteCompra; set => _TipoClienteCompra = value; }
        public string NumeroDocumentoClienteCompra { get => _NumeroDocumentoClienteCompra; set => _NumeroDocumentoClienteCompra = value; }
        public decimal BaseImponibleOperacionGravadasCompra { get => _BaseImponibleOperacionGravadasCompra; set => _BaseImponibleOperacionGravadasCompra = value; }
        public decimal MontoImpuestoGeneralVentas { get => _MontoImpuestoGeneralVentas; set => _MontoImpuestoGeneralVentas = value; }
        public decimal BaseImponibleNoGravadasExportacionCompra { get => _BaseImponibleNoGravadasExportacionCompra; set => _BaseImponibleNoGravadasExportacionCompra = value; }
        public decimal MontoImpuestoGeneralVentasSegundo { get => _MontoImpuestoGeneralVentasSegundo; set => _MontoImpuestoGeneralVentasSegundo = value; }
        public decimal BaseImponibleNoGravadasExportacionCompraTercero { get => _BaseImponibleNoGravadasExportacionCompraTercero; set => _BaseImponibleNoGravadasExportacionCompraTercero = value; }
        public decimal MontoImpuestoGeneralVentasTercero { get => _MontoImpuestoGeneralVentasTercero; set => _MontoImpuestoGeneralVentasTercero = value; }
        public decimal ValorAdquisicionesNoGravadas { get => _ValorAdquisicionesNoGravadas; set => _ValorAdquisicionesNoGravadas = value; }
        public decimal MontoImpuestoSelectivo { get => _MontoImpuestoSelectivo; set => _MontoImpuestoSelectivo = value; }
        public decimal ImpuestoConsumoBolsasPlastico { get => _ImpuestoConsumoBolsasPlastico; set => _ImpuestoConsumoBolsasPlastico = value; }
        public decimal OtrosConceptosTributosCargosBaseImponible { get => _OtrosConceptosTributosCargosBaseImponible; set => _OtrosConceptosTributosCargosBaseImponible = value; }
        public decimal ImporteTotalComprobantePagoCompra { get => _ImporteTotalComprobantePagoCompra; set => _ImporteTotalComprobantePagoCompra = value; }
        public string CodigoMoneda { get => _CodigoMoneda; set => _CodigoMoneda = value; }
        public decimal TipoCambio { get => _TipoCambio; set => _TipoCambio = value; }
        public string FechaEmisionComprobantePagoModifica { get => _FechaEmisionComprobantePagoModifica; set => _FechaEmisionComprobantePagoModifica = value; }
        public string TipoComprobantePagoModifica { get => _TipoComprobantePagoModifica; set => _TipoComprobantePagoModifica = value; }
        public string SerieComprobantePagoModifica { get => _SerieComprobantePagoModifica; set => _SerieComprobantePagoModifica = value; }
        public string CodigoAduaneraDUA { get => _CodigoAduaneraDUA; set => _CodigoAduaneraDUA = value; }
        public string NumeroComprobantePagoModifica { get => _NumeroComprobantePagoModifica; set => _NumeroComprobantePagoModifica = value; }
        public string FechaEmisionConstanciaDepositoDetraccion { get => _FechaEmisionConstanciaDepositoDetraccion; set => _FechaEmisionConstanciaDepositoDetraccion = value; }
        public string NumeroConstanciaDetraccion { get => _NumeroConstanciaDetraccion; set => _NumeroConstanciaDetraccion = value; }
        public string MarcaComprobanteRetencion { get => _MarcaComprobanteRetencion; set => _MarcaComprobanteRetencion = value; }
        public string ClasificacionBienesServicios { get => _ClasificacionBienesServicios; set => _ClasificacionBienesServicios = value; }
        public string IdentificacionContratoProyecto { get => _IdentificacionContratoProyecto; set => _IdentificacionContratoProyecto = value; }
        public string ErrorTipo { get => _ErrorTipo; set => _ErrorTipo = value; }
        public string ErrorTipoSegundo { get => _ErrorTipoSegundo; set => _ErrorTipoSegundo = value; }
        public string ErrorTipoTercero { get => _ErrorTipoTercero; set => _ErrorTipoTercero = value; }
        public string ErrorTipoCuarto { get => _ErrorTipoCuarto; set => _ErrorTipoCuarto = value; }
        public string IdentificadorComprobantePagoCancelados { get => _IdentificadorComprobantePagoCancelados; set => _IdentificadorComprobantePagoCancelados = value; }
        public string EstadoIdentificaAnotacion { get => _EstadoIdentificaAnotacion; set => _EstadoIdentificaAnotacion = value; }
        public string CEstadoRegistroCompra { get => _CEstadoRegistroCompra; set => _CEstadoRegistroCompra = value; }
        public string NEstadoRegistroCompra { get => _NEstadoRegistroCompra; set => _NEstadoRegistroCompra = value; }
        public string UsuarioAgrega { get => _UsuarioAgrega; set => _UsuarioAgrega = value; }
        public DateTime FechaAgrega { get => _FechaAgrega; set => _FechaAgrega = value; }
        public string UsuarioModifica { get => _UsuarioModifica; set => _UsuarioModifica = value; }
        public DateTime FechaModifica { get => _FechaModifica; set => _FechaModifica = value; }
        public Additional Adicionales { get => _Adicionales; set => _Adicionales = value; }
        public string DescripcionAuxiliar { get => _DescripcionAuxiliar; set => _DescripcionAuxiliar = value; }
        public string ClaveObjeto { get => _ClaveObjeto; set => _ClaveObjeto = value; }
    }
}
