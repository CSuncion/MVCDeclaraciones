using Comun;
using DeclaracionesConnection.Connection;
using DeclaracionesModel.ModelDto;
using DeclaracionesRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesRepository.Repository
{
    public class DeclaracionesRegistroCompraRepository : IDeclaracionesRegistroCompraRepository
    {
        private DeclaracionesCn xObjCn = new DeclaracionesCn();
        private DeclaracionesRegistroCompraDto xObj = new DeclaracionesRegistroCompraDto();
        private List<DeclaracionesRegistroCompraDto> xLista = new List<DeclaracionesRegistroCompraDto>();
        private DeclaracionesRegistroCompraDto Objeto(IDataReader iDr)
        {
            DeclaracionesRegistroCompraDto xObjEnc = new DeclaracionesRegistroCompraDto();
            xObjEnc.ClaveRegistroCompra = iDr[DeclaracionesRegistroCompraDto.ClaRegCom].ToString();
            xObjEnc.CodigoEmpresa = iDr[DeclaracionesRegistroCompraDto.CodEmp].ToString();
            xObjEnc.PeriodoRegistroCompra = iDr[DeclaracionesRegistroCompraDto.PerRegCom].ToString();
            xObjEnc.NumCorrelativoCompra = iDr[DeclaracionesRegistroCompraDto.NumCorrCom].ToString();
            xObjEnc.CodUnicoOperacionCompra = iDr[DeclaracionesRegistroCompraDto.CodUnOpeCom].ToString();
            xObjEnc.FechaEmisionComprobantePagoCompra = iDr[DeclaracionesRegistroCompraDto.FecEmiCompPagCom].ToString();
            xObjEnc.FechaVencimientoPagoCompra = iDr[DeclaracionesRegistroCompraDto.FecVencPagCom].ToString();
            xObjEnc.TipoComprobantePagoCompra = iDr[DeclaracionesRegistroCompraDto.TipCompPagCom].ToString();
            xObjEnc.NTipoComprobantePagoCompra = iDr[DeclaracionesRegistroCompraDto.NTipCompPagCom].ToString();
            xObjEnc.SerieComprobantePagoCompra = iDr[DeclaracionesRegistroCompraDto.SerCompPagCom].ToString();
            xObjEnc.NumComprobantePagoCompra = iDr[DeclaracionesRegistroCompraDto.NumCompPagCom].ToString();
            xObjEnc.AnioEmisionDUA = iDr[DeclaracionesRegistroCompraDto.AnioEmiDUA].ToString();
            xObjEnc.ImporteTotalDiariaCreditoFiscal = iDr[DeclaracionesRegistroCompraDto.ImpTotalDiaCredFis].ToString();
            xObjEnc.TipoClienteCompra = iDr[DeclaracionesRegistroCompraDto.TipCliCom].ToString();
            xObjEnc.NumeroDocumentoClienteCompra = iDr[DeclaracionesRegistroCompraDto.NumDocCliCom].ToString();
            xObjEnc.BaseImponibleOperacionGravadasCompra = decimal.Parse(iDr[DeclaracionesRegistroCompraDto.BasImpoOpeGravCom].ToString());
            xObjEnc.MontoImpuestoGeneralVentas = decimal.Parse(iDr[DeclaracionesRegistroCompraDto.MontImpuGenVen].ToString());
            xObjEnc.BaseImponibleNoGravadasExportacionCompra = decimal.Parse(iDr[DeclaracionesRegistroCompraDto.BasImpoNoGravExporCom].ToString());
            xObjEnc.MontoImpuestoGeneralVentasSegundo = decimal.Parse(iDr[DeclaracionesRegistroCompraDto.MonImpuGeneVentSeg].ToString());
            xObjEnc.BaseImponibleNoGravadasExportacionCompraTercero = decimal.Parse(iDr[DeclaracionesRegistroCompraDto.BasImpoNoGravExporComTer].ToString());
            xObjEnc.MontoImpuestoGeneralVentasTercero = decimal.Parse(iDr[DeclaracionesRegistroCompraDto.MonImpuGeneVentasTer].ToString());
            xObjEnc.ValorAdquisicionesNoGravadas = decimal.Parse(iDr[DeclaracionesRegistroCompraDto.ValAdquiNoGrav].ToString());
            xObjEnc.MontoImpuestoSelectivo = decimal.Parse(iDr[DeclaracionesRegistroCompraDto.MonImpuSelec].ToString());
            xObjEnc.ImpuestoConsumoBolsasPlastico = decimal.Parse(iDr[DeclaracionesRegistroCompraDto.ImpuConsBolPlast].ToString());
            xObjEnc.OtrosConceptosTributosCargosBaseImponible = decimal.Parse(iDr[DeclaracionesRegistroCompraDto.OtrConceTribCargBasImpo].ToString());
            xObjEnc.ImporteTotalComprobantePagoCompra = decimal.Parse(iDr[DeclaracionesRegistroCompraDto.ImporTotComproPagCom].ToString());
            xObjEnc.CodigoMoneda = iDr[DeclaracionesRegistroCompraDto.CodMon].ToString();
            xObjEnc.TipoCambio = decimal.Parse(iDr[DeclaracionesRegistroCompraDto.TipCam].ToString());
            xObjEnc.FechaEmisionComprobantePagoModifica = iDr[DeclaracionesRegistroCompraDto.FechEmiComproPagoMod].ToString();
            xObjEnc.TipoComprobantePagoModifica = iDr[DeclaracionesRegistroCompraDto.TipComproPagMod].ToString();
            xObjEnc.SerieComprobantePagoModifica = iDr[DeclaracionesRegistroCompraDto.SerComproPagMod].ToString();
            xObjEnc.CodigoAduaneraDUA = iDr[DeclaracionesRegistroCompraDto.CodAduaDUA].ToString();
            xObjEnc.NumeroComprobantePagoModifica = iDr[DeclaracionesRegistroCompraDto.NumComproPagMod].ToString();
            xObjEnc.FechaEmisionConstanciaDepositoDetraccion = iDr[DeclaracionesRegistroCompraDto.FecEmiConstDepoDetra].ToString();
            xObjEnc.NumeroConstanciaDetraccion = iDr[DeclaracionesRegistroCompraDto.NumConstDetra].ToString();
            xObjEnc.MarcaComprobanteRetencion = iDr[DeclaracionesRegistroCompraDto.MarcComproRete].ToString();
            xObjEnc.ClasificacionBienesServicios = iDr[DeclaracionesRegistroCompraDto.ClasBieServ].ToString();
            xObjEnc.IdentificacionContratoProyecto = iDr[DeclaracionesRegistroCompraDto.IdentifContrProy].ToString();
            xObjEnc.ErrorTipo = iDr[DeclaracionesRegistroCompraDto.ErrTip].ToString();
            xObjEnc.ErrorTipoSegundo = iDr[DeclaracionesRegistroCompraDto.ErrTipSeg].ToString();
            xObjEnc.ErrorTipoTercero = iDr[DeclaracionesRegistroCompraDto.ErrTipTerc].ToString();
            xObjEnc.ErrorTipoCuarto = iDr[DeclaracionesRegistroCompraDto.ErrTipCuar].ToString();
            xObjEnc.IdentificadorComprobantePagoCancelados = iDr[DeclaracionesRegistroCompraDto.IdentifComproPagCanc].ToString();
            xObjEnc.EstadoIdentificaAnotacion = iDr[DeclaracionesRegistroCompraDto.EstaIdentiAnot].ToString();
            xObjEnc.CEstadoRegistroCompra = iDr[DeclaracionesRegistroCompraDto.CEstRegCom].ToString();
            xObjEnc.NEstadoRegistroCompra = iDr[DeclaracionesRegistroCompraDto.NEstRegCom].ToString();
            xObjEnc.UsuarioAgrega = iDr[DeclaracionesRegistroCompraDto.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[DeclaracionesRegistroCompraDto.FecAgr].ToString());
            xObjEnc.UsuarioModifica = iDr[DeclaracionesRegistroCompraDto.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[DeclaracionesRegistroCompraDto.FecMod].ToString());
            xObjEnc.DescripcionAuxiliar = iDr[DeclaracionesRegistroCompraDto.DescAux].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClaveRegistroCompra;
            return xObjEnc;
        }
        private DeclaracionesRegistroCompraDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
        {
            this.xObj = new DeclaracionesRegistroCompraDto();
            xObjCn.Connection();
            xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xObj = this.Objeto(xIdr);
            }
            xObjCn.Disconnect();
            return xObj;
        }
        private List<DeclaracionesRegistroCompraDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
        {
            xLista = new List<DeclaracionesRegistroCompraDto>();
            xObjCn.Connection();
            if (lParameter != null)
                xObjCn.AssignParameters(lParameter);

            xObjCn.CommandStoreProcedure(pScript);

            IDataReader xIdr = xObjCn.GetIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xLista.Add(this.Objeto(xIdr));
            }
            xObjCn.Disconnect();
            return xLista;
        }
        private bool ExisteObjeto(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            if (lParameter != null)
                xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            IDataReader xIdr = xObjCn.GetIdr();
            bool xResultado = false;
            while (xIdr.Read())
            {
                string xTxt = xIdr["Busqueda"].ToString();
                if (xTxt != string.Empty)
                {
                    xResultado = true;
                }
            }
            xObjCn.Disconnect();
            return xResultado;
        }
        private string ObtenerValor(string pScript, List<SqlParameter> lParameter)
        {
            xObjCn.Connection();
            if (lParameter != null)
                xObjCn.AssignParameters(lParameter);
            xObjCn.CommandStoreProcedure(pScript);
            string iValor = xObjCn.GetValue();
            xObjCn.Disconnect();
            return iValor;
        }

        public string ObtenerMaximoValorEnColumna(DeclaracionesRegistroCompraDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strVista", "vsRegistroCompra"),
                new SqlParameter("@strColumna", "NumCorrelativoCompra"),
                new SqlParameter("@strColumnaParametro", "PeriodoRegistroCompra"),
                new SqlParameter("@strCodEmpresa", Universal.gCodigoEmpresa),
                new SqlParameter("@strPerRegCom", pObj.PeriodoRegistroCompra),
            };
            return this.ObtenerValor("isp_ObtenerMaximoValorEnColumna", lParameter);
        }

        public void AgregarRegistroCompra(DeclaracionesRegistroCompraDto pObj)
        {
            xObjCn.Connection();
            //armando escript para insertar

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@strClaveRegistroCompra",pObj.ClaveRegistroCompra),
                new SqlParameter("@strCodigoEmpresa",Universal.gCodigoEmpresa),
                new SqlParameter("@strPeriodoRegistroCompra",pObj.PeriodoRegistroCompra),
                new SqlParameter("@strNumCorrelativoCompra",pObj.NumCorrelativoCompra),
                new SqlParameter("@strCodUnicoOperacionCompra",pObj.CodUnicoOperacionCompra),
                new SqlParameter("@strFechaEmisionComprobantePagoCompra",pObj.FechaEmisionComprobantePagoCompra),
                new SqlParameter("@strFechaVencimientoPagoCompra",pObj.FechaVencimientoPagoCompra),
                new SqlParameter("@strTipoComprobantePagoCompra",pObj.TipoComprobantePagoCompra),
                new SqlParameter("@strSerieComprobantePagoCompra",pObj.SerieComprobantePagoCompra),
                new SqlParameter("@strNumComprobantePagoCompra",pObj.NumComprobantePagoCompra),
                new SqlParameter("@strAnioEmisionDUA",pObj.AnioEmisionDUA),
                new SqlParameter("@strImporteTotalDiariaCreditoFiscal",pObj.ImporteTotalDiariaCreditoFiscal),
                new SqlParameter("@strTipoClienteCompra",pObj.TipoClienteCompra),
                new SqlParameter("@strNumeroDocumentoClienteCompra",pObj.NumeroDocumentoClienteCompra),
                new SqlParameter("@strBaseImponibleOperacionGravadasCompra",pObj.BaseImponibleOperacionGravadasCompra),
                new SqlParameter("@strMontoImpuestoGeneralVentas",pObj.MontoImpuestoGeneralVentas),
                new SqlParameter("@strBaseImponibleNoGravadasExportacionCompra",pObj.BaseImponibleNoGravadasExportacionCompra),
                new SqlParameter("@strMontoImpuestoGeneralVentasSegundo",pObj.MontoImpuestoGeneralVentasSegundo),
                new SqlParameter("@strBaseImponibleNoGravadasExportacionCompraTercero",pObj.BaseImponibleNoGravadasExportacionCompraTercero),
                new SqlParameter("@strMontoImpuestoGeneralVentasTercero",pObj.MontoImpuestoGeneralVentasTercero),
                new SqlParameter("@strValorAdquisicionesNoGravadas",pObj.ValorAdquisicionesNoGravadas),
                new SqlParameter("@strMontoImpuestoSelectivo",pObj.MontoImpuestoSelectivo),
                new SqlParameter("@strImpuestoConsumoBolsasPlastico",pObj.ImpuestoConsumoBolsasPlastico),
                new SqlParameter("@strOtrosConceptosTributosCargosBaseImponible",pObj.OtrosConceptosTributosCargosBaseImponible),
                new SqlParameter("@strImporteTotalComprobantePagoCompra",pObj.ImporteTotalComprobantePagoCompra),
                new SqlParameter("@strCodigoMoneda",pObj.CodigoMoneda),
                new SqlParameter("@strTipoCambio",pObj.TipoCambio),
                new SqlParameter("@strFechaEmisionComprobantePagoModifica",pObj.FechaEmisionComprobantePagoModifica),
                new SqlParameter("@strTipoComprobantePagoModifica",pObj.TipoComprobantePagoModifica),
                new SqlParameter("@strSerieComprobantePagoModifica",pObj.SerieComprobantePagoModifica),
                new SqlParameter("@strCodigoAduaneraDUA",pObj.CodigoAduaneraDUA),
                new SqlParameter("@strNumeroComprobantePagoModifica",pObj.NumeroComprobantePagoModifica),
                new SqlParameter("@strFechaEmisionConstanciaDepositoDetraccion",pObj.FechaEmisionConstanciaDepositoDetraccion),
                new SqlParameter("@strNumeroConstanciaDetraccion",pObj.NumeroConstanciaDetraccion),
                new SqlParameter("@strMarcaComprobanteRetencion",pObj.MarcaComprobanteRetencion),
                new SqlParameter("@strClasificacionBienesServicios",pObj.ClasificacionBienesServicios),
                new SqlParameter("@strIdentificacionContratoProyecto",pObj.IdentificacionContratoProyecto),
                new SqlParameter("@strErrorTipo",pObj.ErrorTipo),
                new SqlParameter("@strErrorTipoSegundo",pObj.ErrorTipoSegundo),
                new SqlParameter("@strErrorTipoTercero",pObj.ErrorTipoTercero),
                new SqlParameter("@strErrorTipoCuarto",pObj.ErrorTipoCuarto),
                new SqlParameter("@strIdentificadorComprobantePagoCancelados",pObj.IdentificadorComprobantePagoCancelados),
                new SqlParameter("@strEstadoIdentificaAnotacion",pObj.EstadoIdentificaAnotacion),
                new SqlParameter("@strCEstadoRegistroCompra",pObj.CEstadoRegistroCompra),
                new SqlParameter("@strUsuarioAgrega",Universal.gCodigoUsuario),
                new SqlParameter("@strUsuarioModifica",Universal.gCodigoUsuario),
            };
            xObjCn.AssignParameters(sqlParameters);
            xObjCn.CommandStoreProcedure("isp_AgregarRegistroCompra");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public List<DeclaracionesRegistroCompraDto> ListarRegistroCompraXPeriodo(DeclaracionesRegistroCompraDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strCodEmp", Universal.gCodigoEmpresa),
                new SqlParameter("@strPerRegCom", pObj.PeriodoRegistroCompra),
            };
            return this.ListarObjetos("isp_ListarRegistroCompraXPeriodo", lParameter);
        }
        public DeclaracionesRegistroCompraDto BuscarRegistroCompraXClave(DeclaracionesRegistroCompraDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strClaRegCom", pObj.ClaveRegistroCompra),
            };
            return this.BuscarObjeto("isp_BuscarRegistroCompraXClave", lParameter);
        }
        public void ModificarRegistroCompra(DeclaracionesRegistroCompraDto pObj)
        {
            xObjCn.Connection();
            //armando escript para modificar
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@strClaveRegistroCompra",pObj.ClaveRegistroCompra),
                new SqlParameter("@strCodUnicoOperacionCompra",pObj.CodUnicoOperacionCompra),
                new SqlParameter("@strFechaEmisionComprobantePagoCompra",pObj.FechaEmisionComprobantePagoCompra),
                new SqlParameter("@strFechaVencimientoPagoCompra",pObj.FechaVencimientoPagoCompra),
                new SqlParameter("@strTipoComprobantePagoCompra",pObj.TipoComprobantePagoCompra),
                new SqlParameter("@strSerieComprobantePagoCompra",pObj.SerieComprobantePagoCompra),
                new SqlParameter("@strNumComprobantePagoCompra",pObj.NumComprobantePagoCompra),
                new SqlParameter("@strAnioEmisionDUA",pObj.AnioEmisionDUA),
                new SqlParameter("@strImporteTotalDiariaCreditoFiscal",pObj.ImporteTotalDiariaCreditoFiscal),
                new SqlParameter("@strTipoClienteCompra",pObj.TipoClienteCompra),
                new SqlParameter("@strNumeroDocumentoClienteCompra",pObj.NumeroDocumentoClienteCompra),
                new SqlParameter("@strBaseImponibleOperacionGravadasCompra",pObj.BaseImponibleOperacionGravadasCompra),
                new SqlParameter("@strMontoImpuestoGeneralVentas",pObj.MontoImpuestoGeneralVentas),
                new SqlParameter("@strBaseImponibleNoGravadasExportacionCompra",pObj.BaseImponibleNoGravadasExportacionCompra),
                new SqlParameter("@strMontoImpuestoGeneralVentasSegundo",pObj.MontoImpuestoGeneralVentasSegundo),
                new SqlParameter("@strBaseImponibleNoGravadasExportacionCompraTercero",pObj.BaseImponibleNoGravadasExportacionCompraTercero),
                new SqlParameter("@strMontoImpuestoGeneralVentasTercero",pObj.MontoImpuestoGeneralVentasTercero),
                new SqlParameter("@strValorAdquisicionesNoGravadas",pObj.ValorAdquisicionesNoGravadas),
                new SqlParameter("@strMontoImpuestoSelectivo",pObj.MontoImpuestoSelectivo),
                new SqlParameter("@strImpuestoConsumoBolsasPlastico",pObj.ImpuestoConsumoBolsasPlastico),
                new SqlParameter("@strOtrosConceptosTributosCargosBaseImponible",pObj.OtrosConceptosTributosCargosBaseImponible),
                new SqlParameter("@strImporteTotalComprobantePagoCompra",pObj.ImporteTotalComprobantePagoCompra),
                new SqlParameter("@strCodigoMoneda",pObj.CodigoMoneda),
                new SqlParameter("@strTipoCambio",pObj.TipoCambio),
                new SqlParameter("@strFechaEmisionComprobantePagoModifica",pObj.FechaEmisionComprobantePagoModifica),
                new SqlParameter("@strTipoComprobantePagoModifica",pObj.TipoComprobantePagoModifica),
                new SqlParameter("@strSerieComprobantePagoModifica",pObj.SerieComprobantePagoModifica),
                new SqlParameter("@strCodigoAduaneraDUA",pObj.CodigoAduaneraDUA),
                new SqlParameter("@strNumeroComprobantePagoModifica",pObj.NumeroComprobantePagoModifica),
                new SqlParameter("@strFechaEmisionConstanciaDepositoDetraccion",pObj.FechaEmisionConstanciaDepositoDetraccion),
                new SqlParameter("@strNumeroConstanciaDetraccion",pObj.NumeroConstanciaDetraccion),
                new SqlParameter("@strMarcaComprobanteRetencion",pObj.MarcaComprobanteRetencion),
                new SqlParameter("@strClasificacionBienesServicios",pObj.ClasificacionBienesServicios),
                new SqlParameter("@strIdentificacionContratoProyecto",pObj.IdentificacionContratoProyecto),
                new SqlParameter("@strErrorTipo",pObj.ErrorTipo),
                new SqlParameter("@strErrorTipoSegundo",pObj.ErrorTipoSegundo),
                new SqlParameter("@strErrorTipoTercero",pObj.ErrorTipoTercero),
                new SqlParameter("@strErrorTipoCuarto",pObj.ErrorTipoCuarto),
                new SqlParameter("@strIdentificadorComprobantePagoCancelados",pObj.IdentificadorComprobantePagoCancelados),
                new SqlParameter("@strEstadoIdentificaAnotacion",pObj.EstadoIdentificaAnotacion),
                new SqlParameter("@strCEstadoRegistroCompra",pObj.CEstadoRegistroCompra),
                new SqlParameter("@strUsuarioModifica",Universal.gCodigoUsuario),
            };
            xObjCn.AssignParameters(sqlParameters);
            xObjCn.CommandStoreProcedure("isp_ModificarRegistroCompra");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarRegistroCompra(DeclaracionesRegistroCompraDto pObj)
        {
            xObjCn.Connection();
            //armando escript para eliminar

            //condicion
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@strClaveRegistroCompra",pObj.ClaveRegistroCompra),
            };

            xObjCn.AssignParameters(sqlParameters);
            xObjCn.CommandStoreProcedure("isp_EliminarRegistroCompra");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
