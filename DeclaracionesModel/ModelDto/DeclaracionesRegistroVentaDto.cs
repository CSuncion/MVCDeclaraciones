using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesModel.ModelDto
{
    public class DeclaracionesRegistroVentaDto
    {
        public const string ClaObj = "ClaveObjeto";
        public const string ClaRegVen = "ClaveRegistroVenta";
        public const string CodEmp = "CodigoEmpresa";
        public const string PerRegVen = "PeriodoRegistroVenta";
        public const string NumCorrVen = "NumCorrelativoVenta";
        public const string CodUnOpVen = "CodUnicoOperacionVenta";
        public const string FecEmiCompPagVen = "FechaEmisionComprobantePagoVenta";
        public const string FecVencPagVen = "FechaVencimientoPagoVenta";
        public const string TipCompPagVen = "TipoComprobantePagoVenta";
        public const string NTipCompPagVen = "NTipoComprobantePagoVenta";
        public const string SerCompPagVen = "SerieComprobantePagoVenta";
        public const string NumCompPagVen = "NumComprobantePagoVenta";
        public const string RegTicVen = "RegistroTicketsVenta";
        public const string TipCliVen = "TipoClienteVenta";
        public const string NumDocCliVen = "NumeroDocumentoClienteVenta";
        public const string ValFacExpVen = "ValorFacturadoExportacionVenta";
        public const string BasImpOpeVen = "BaseImponibleOperacionVenta";
        public const string DescBasImpVen = "DescuentoBaseImponibleVenta";
        public const string ImpuGenVen = "ImpuestoGeneralVenta";
        public const string DescImpuGenVen = "DescuentoImpuestoGeneralVenta";
        public const string ImpTotExoVen = "ImporteTotalExoneradaVenta";
        public const string ImpoTotInaf = "ImporteTotalInafecta";
        public const string ImpuSeleConsVen = "ImpuestoSelectivoConsumoVenta";
        public const string BasImpoGravVenArrPil = "BaseImponibleGravadaVentaArrozPilado";
        public const string ImpuVenArrPil = "ImpuestoVentaArrozPilado";
        public const string ImpuConsBolPlas = "ImpuestoConsumoBolsaPlastico";
        public const string OtrConcTribCarBasImpo = "OtrosConceptoTributosCargosBaseImponible";
        public const string ImpoTotCompPagVen = "ImporteTotalComprobantePagoVenta";
        public const string CodMon = "CodigoMoneda";
        public const string TipCamb = "TipoCambio";
        public const string FecEmiCompPagMod = "FechaEmisionComprobantePagoModifica";
        public const string TipCompPMod = "TipoComprobantePagoModifica";
        public const string SerCompPagMod = "SerieComprobantePagoModifica";
        public const string NumCompPagMod = "NumeroComprobantePagoModifica";
        public const string IdenContProy = "IdentificacionContratoProyecto";
        public const string ErrTip = "ErrorTipo";
        public const string IdenCompPagCanc = "IdentificadorComprobantePagoCancelados";
        public const string EstIdenAno = "EstadoIdentificaAnotacion";
        public const string CEstRegVen = "CEstadoRegistroVenta";
        public const string NEstRegVen = "NEstadoRegistroVenta";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";
        public const string DescAux = "DescripcionAuxiliar";

        private string _ClaveObjeto = string.Empty;
        private string _ClaveRegistroVenta = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _PeriodoRegistroVenta = string.Empty;
        private string _NumCorrelativoVenta = string.Empty;
        private string _CodUnicoOperacionVenta = string.Empty;
        private string _FechaEmisionComprobantePagoVenta = string.Empty;
        private string _FechaVencimientoPagoVenta = string.Empty;
        private string _TipoComprobantePagoVenta = string.Empty;
        private string _NTipoComprobantePagoVenta = string.Empty;
        private string _SerieComprobantePagoVenta = string.Empty;
        private string _NumComprobantePagoVenta = string.Empty;
        private string _RegistroTicketsVenta = string.Empty;
        private string _TipoClienteVenta = string.Empty;
        private string _NumeroDocumentoClienteVenta = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;
        private decimal _ValorFacturadoExportacionVenta = 0;
        private decimal _BaseImponibleOperacionVenta = 0;
        private decimal _DescuentoBaseImponibleVenta = 0;
        private decimal _ImpuestoGeneralVenta = 0;
        private decimal _DescuentoImpuestoGeneralVenta = 0;
        private decimal _ImporteTotalExoneradaVenta = 0;
        private decimal _ImporteTotalInafecta = 0;
        private decimal _ImpuestoSelectivoConsumoVenta = 0;
        private decimal _BaseImponibleGravadaVentaArrozPilado = 0;
        private decimal _ImpuestoVentaArrozPilado = 0;
        private decimal _ImpuestoConsumoBolsaPlastico = 0;
        private decimal _OtrosConceptoTributosCargosBaseImponible = 0;
        private decimal _ImporteTotalComprobantePagoVenta = 0;
        private string _CodigoMoneda = string.Empty;
        private decimal _TipoCambio = 0;
        private string _FechaEmisionComprobantePagoModifica = string.Empty;
        private string _TipoComprobantePagoModifica = string.Empty;
        private string _SerieComprobantePagoModifica = string.Empty;
        private string _NumeroComprobantePagoModifica = string.Empty;
        private string _IdentificacionContratoProyecto = string.Empty;
        private string _ErrorTipo = string.Empty;
        private string _IdentificadorComprobantePagoCancelados = string.Empty;
        private string _EstadoIdentificaAnotacion = string.Empty;
        private string _CEstadoRegistroVenta = string.Empty;
        private string _NEstadoRegistroVenta = string.Empty;
        private string _UsuarioAgrega;
        private string _FechaAgrega;
        private string _UsuarioModifica;
        private string _FechaModifica;
        private Additional _Adicionales = new Additional();

        public string ClaveRegistroVenta { get => _ClaveRegistroVenta; set => _ClaveRegistroVenta = value; }
        public string CodigoEmpresa { get => _CodigoEmpresa; set => _CodigoEmpresa = value; }
        public string PeriodoRegistroVenta { get => _PeriodoRegistroVenta; set => _PeriodoRegistroVenta = value; }
        public string NumCorrelativoVenta { get => _NumCorrelativoVenta; set => _NumCorrelativoVenta = value; }
        public string CodUnicoOperacionVenta { get => _CodUnicoOperacionVenta; set => _CodUnicoOperacionVenta = value; }
        public string FechaEmisionComprobantePagoVenta { get => _FechaEmisionComprobantePagoVenta; set => _FechaEmisionComprobantePagoVenta = value; }
        public string FechaVencimientoPagoVenta { get => _FechaVencimientoPagoVenta; set => _FechaVencimientoPagoVenta = value; }
        public string TipoComprobantePagoVenta { get => _TipoComprobantePagoVenta; set => _TipoComprobantePagoVenta = value; }
        public string NTipoComprobantePagoVenta { get => _NTipoComprobantePagoVenta; set => _NTipoComprobantePagoVenta = value; }
        public string SerieComprobantePagoVenta { get => _SerieComprobantePagoVenta; set => _SerieComprobantePagoVenta = value; }
        public string NumComprobantePagoVenta { get => _NumComprobantePagoVenta; set => _NumComprobantePagoVenta = value; }
        public string RegistroTicketsVenta { get => _RegistroTicketsVenta; set => _RegistroTicketsVenta = value; }
        public string TipoClienteVenta { get => _TipoClienteVenta; set => _TipoClienteVenta = value; }
        public string NumeroDocumentoClienteVenta { get => _NumeroDocumentoClienteVenta; set => _NumeroDocumentoClienteVenta = value; }
        public decimal ValorFacturadoExportacionVenta { get => _ValorFacturadoExportacionVenta; set => _ValorFacturadoExportacionVenta = value; }
        public decimal BaseImponibleOperacionVenta { get => _BaseImponibleOperacionVenta; set => _BaseImponibleOperacionVenta = value; }
        public decimal DescuentoBaseImponibleVenta { get => _DescuentoBaseImponibleVenta; set => _DescuentoBaseImponibleVenta = value; }
        public decimal ImpuestoGeneralVenta { get => _ImpuestoGeneralVenta; set => _ImpuestoGeneralVenta = value; }
        public decimal DescuentoImpuestoGeneralVenta { get => _DescuentoImpuestoGeneralVenta; set => _DescuentoImpuestoGeneralVenta = value; }
        public decimal ImporteTotalExoneradaVenta { get => _ImporteTotalExoneradaVenta; set => _ImporteTotalExoneradaVenta = value; }
        public decimal ImporteTotalInafecta { get => _ImporteTotalInafecta; set => _ImporteTotalInafecta = value; }
        public decimal ImpuestoSelectivoConsumoVenta { get => _ImpuestoSelectivoConsumoVenta; set => _ImpuestoSelectivoConsumoVenta = value; }
        public decimal BaseImponibleGravadaVentaArrozPilado { get => _BaseImponibleGravadaVentaArrozPilado; set => _BaseImponibleGravadaVentaArrozPilado = value; }
        public decimal ImpuestoVentaArrozPilado { get => _ImpuestoVentaArrozPilado; set => _ImpuestoVentaArrozPilado = value; }
        public decimal ImpuestoConsumoBolsaPlastico { get => _ImpuestoConsumoBolsaPlastico; set => _ImpuestoConsumoBolsaPlastico = value; }
        public decimal OtrosConceptoTributosCargosBaseImponible { get => _OtrosConceptoTributosCargosBaseImponible; set => _OtrosConceptoTributosCargosBaseImponible = value; }
        public decimal ImporteTotalComprobantePagoVenta { get => _ImporteTotalComprobantePagoVenta; set => _ImporteTotalComprobantePagoVenta = value; }
        public string CodigoMoneda { get => _CodigoMoneda; set => _CodigoMoneda = value; }
        public decimal TipoCambio { get => _TipoCambio; set => _TipoCambio = value; }
        public string FechaEmisionComprobantePagoModifica { get => _FechaEmisionComprobantePagoModifica; set => _FechaEmisionComprobantePagoModifica = value; }
        public string TipoComprobantePagoModifica { get => _TipoComprobantePagoModifica; set => _TipoComprobantePagoModifica = value; }
        public string SerieComprobantePagoModifica { get => _SerieComprobantePagoModifica; set => _SerieComprobantePagoModifica = value; }
        public string NumeroComprobantePagoModifica { get => _NumeroComprobantePagoModifica; set => _NumeroComprobantePagoModifica = value; }
        public string IdentificacionContratoProyecto { get => _IdentificacionContratoProyecto; set => _IdentificacionContratoProyecto = value; }
        public string ErrorTipo { get => _ErrorTipo; set => _ErrorTipo = value; }
        public string IdentificadorComprobantePagoCancelados { get => _IdentificadorComprobantePagoCancelados; set => _IdentificadorComprobantePagoCancelados = value; }
        public string EstadoIdentificaAnotacion { get => _EstadoIdentificaAnotacion; set => _EstadoIdentificaAnotacion = value; }
        public string CEstadoRegistroVenta { get => _CEstadoRegistroVenta; set => _CEstadoRegistroVenta = value; }
        public string NEstadoRegistroVenta { get => _NEstadoRegistroVenta; set => _NEstadoRegistroVenta = value; }
        public string UsuarioAgrega { get => _UsuarioAgrega; set => _UsuarioAgrega = value; }
        public string FechaAgrega { get => _FechaAgrega; set => _FechaAgrega = value; }
        public string UsuarioModifica { get => _UsuarioModifica; set => _UsuarioModifica = value; }
        public string FechaModifica { get => _FechaModifica; set => _FechaModifica = value; }
        public Additional Adicionales { get => _Adicionales; set => _Adicionales = value; }
        public string DescripcionAuxiliar { get => _DescripcionAuxiliar; set => _DescripcionAuxiliar = value; }
        public string ClaveObjeto { get => _ClaveObjeto; set => _ClaveObjeto = value; }
    }
}
