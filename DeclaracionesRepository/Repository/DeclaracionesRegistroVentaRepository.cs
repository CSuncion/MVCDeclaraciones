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
    public class DeclaracionesRegistroVentaRepository : IDeclaracionesRegistroVentaRepository
    {
        private DeclaracionesCn xObjCn = new DeclaracionesCn();
        private DeclaracionesRegistroVentaDto xObj = new DeclaracionesRegistroVentaDto();
        private List<DeclaracionesRegistroVentaDto> xLista = new List<DeclaracionesRegistroVentaDto>();
        private DeclaracionesRegistroVentaDto Objeto(IDataReader iDr)
        {
            DeclaracionesRegistroVentaDto xObjEnc = new DeclaracionesRegistroVentaDto();
            xObjEnc.ClaveRegistroVenta = iDr[DeclaracionesRegistroVentaDto.ClaRegVen].ToString();
            xObjEnc.CodigoEmpresa = iDr[DeclaracionesRegistroVentaDto.CodEmp].ToString();
            xObjEnc.PeriodoRegistroVenta = iDr[DeclaracionesRegistroVentaDto.PerRegVen].ToString();
            xObjEnc.NumCorrelativoVenta = iDr[DeclaracionesRegistroVentaDto.NumCorrVen].ToString();
            xObjEnc.CodUnicoOperacionVenta = iDr[DeclaracionesRegistroVentaDto.CodUnOpVen].ToString();
            xObjEnc.FechaEmisionComprobantePagoVenta = iDr[DeclaracionesRegistroVentaDto.FecEmiCompPagVen].ToString();
            xObjEnc.FechaVencimientoPagoVenta = iDr[DeclaracionesRegistroVentaDto.FecVencPagVen].ToString();
            xObjEnc.TipoComprobantePagoVenta = iDr[DeclaracionesRegistroVentaDto.TipCompPagVen].ToString();
            xObjEnc.NTipoComprobantePagoVenta = iDr[DeclaracionesRegistroVentaDto.NTipCompPagVen].ToString();
            xObjEnc.SerieComprobantePagoVenta = iDr[DeclaracionesRegistroVentaDto.SerCompPagVen].ToString();
            xObjEnc.NumComprobantePagoVenta = iDr[DeclaracionesRegistroVentaDto.NumCompPagVen].ToString();
            xObjEnc.RegistroTicketsVenta = iDr[DeclaracionesRegistroVentaDto.RegTicVen].ToString();
            xObjEnc.TipoClienteVenta = iDr[DeclaracionesRegistroVentaDto.TipCliVen].ToString();
            xObjEnc.NumeroDocumentoClienteVenta = iDr[DeclaracionesRegistroVentaDto.NumDocCliVen].ToString();
            xObjEnc.ValorFacturadoExportacionVenta = Convert.ToDecimal(iDr[DeclaracionesRegistroVentaDto.ValFacExpVen].ToString());
            xObjEnc.BaseImponibleOperacionVenta = Convert.ToDecimal(iDr[DeclaracionesRegistroVentaDto.BasImpOpeVen].ToString());
            xObjEnc.DescuentoBaseImponibleVenta = Convert.ToDecimal(iDr[DeclaracionesRegistroVentaDto.DescBasImpVen].ToString());
            xObjEnc.ImpuestoGeneralVenta = Convert.ToDecimal(iDr[DeclaracionesRegistroVentaDto.ImpuGenVen].ToString());
            xObjEnc.DescuentoImpuestoGeneralVenta = Convert.ToDecimal(iDr[DeclaracionesRegistroVentaDto.DescImpuGenVen].ToString());
            xObjEnc.ImporteTotalExoneradaVenta = Convert.ToDecimal(iDr[DeclaracionesRegistroVentaDto.ImpTotExoVen].ToString());
            xObjEnc.ImporteTotalInafecta = Convert.ToDecimal(iDr[DeclaracionesRegistroVentaDto.ImpoTotInaf].ToString());
            xObjEnc.ImpuestoSelectivoConsumoVenta = Convert.ToDecimal(iDr[DeclaracionesRegistroVentaDto.ImpuSeleConsVen].ToString());
            xObjEnc.BaseImponibleGravadaVentaArrozPilado = Convert.ToDecimal(iDr[DeclaracionesRegistroVentaDto.BasImpoGravVenArrPil].ToString());
            xObjEnc.ImpuestoVentaArrozPilado = Convert.ToDecimal(iDr[DeclaracionesRegistroVentaDto.ImpuVenArrPil].ToString());
            xObjEnc.ImpuestoConsumoBolsaPlastico = Convert.ToDecimal(iDr[DeclaracionesRegistroVentaDto.ImpuConsBolPlas].ToString());
            xObjEnc.OtrosConceptoTributosCargosBaseImponible = Convert.ToDecimal(iDr[DeclaracionesRegistroVentaDto.OtrConcTribCarBasImpo].ToString());
            xObjEnc.ImporteTotalComprobantePagoVenta = Convert.ToDecimal(iDr[DeclaracionesRegistroVentaDto.ImpoTotCompPagVen].ToString());
            xObjEnc.CodigoMoneda = iDr[DeclaracionesRegistroVentaDto.CodMon].ToString();
            xObjEnc.TipoCambio = Convert.ToDecimal(iDr[DeclaracionesRegistroVentaDto.TipCamb].ToString());
            xObjEnc.FechaEmisionComprobantePagoModifica = iDr[DeclaracionesRegistroVentaDto.FecEmiCompPagMod].ToString();
            xObjEnc.TipoComprobantePagoModifica = iDr[DeclaracionesRegistroVentaDto.TipCompPMod].ToString();
            xObjEnc.SerieComprobantePagoModifica = iDr[DeclaracionesRegistroVentaDto.SerCompPagMod].ToString();
            xObjEnc.NumeroComprobantePagoModifica = iDr[DeclaracionesRegistroVentaDto.NumCompPagMod].ToString();
            xObjEnc.IdentificacionContratoProyecto = iDr[DeclaracionesRegistroVentaDto.IdenContProy].ToString();
            xObjEnc.ErrorTipo = iDr[DeclaracionesRegistroVentaDto.ErrTip].ToString();
            xObjEnc.IdentificadorComprobantePagoCancelados = iDr[DeclaracionesRegistroVentaDto.IdenCompPagCanc].ToString();
            xObjEnc.EstadoIdentificaAnotacion = iDr[DeclaracionesRegistroVentaDto.EstIdenAno].ToString();
            xObjEnc.CEstadoRegistroVenta = iDr[DeclaracionesRegistroVentaDto.CEstRegVen].ToString();
            xObjEnc.NEstadoRegistroVenta = iDr[DeclaracionesRegistroVentaDto.NEstRegVen].ToString();
            xObjEnc.UsuarioAgrega = iDr[DeclaracionesRegistroVentaDto.UsuAgr].ToString();
            xObjEnc.FechaAgrega = iDr[DeclaracionesRegistroVentaDto.FecAgr].ToString();
            xObjEnc.UsuarioModifica = iDr[DeclaracionesRegistroVentaDto.UsuMod].ToString();
            xObjEnc.FechaModifica = iDr[DeclaracionesRegistroVentaDto.FecMod].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[DeclaracionesRegistroVentaDto.DescAux].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClaveRegistroVenta;

            return xObjEnc;
        }
        private DeclaracionesRegistroVentaDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
        {
            this.xObj = new DeclaracionesRegistroVentaDto();
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
        private List<DeclaracionesRegistroVentaDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
        {
            xLista = new List<DeclaracionesRegistroVentaDto>();
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

        public string ObtenerMaximoValorEnColumna(DeclaracionesRegistroVentaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strVista", "vsRegistroVenta"),
                new SqlParameter("@strColumna", "NumCorrelativoVenta"),
                new SqlParameter("@strColumnaParametro", "PeriodoRegistroVenta"),
                new SqlParameter("@strCodEmpresa", Universal.gCodigoEmpresa),
                new SqlParameter("@strPerRegCom", pObj.PeriodoRegistroVenta),
            };
            return this.ObtenerValor("isp_ObtenerMaximoValorEnColumna", lParameter);
        }

        public void AgregarRegistroVenta(DeclaracionesRegistroVentaDto pObj)
        {
            xObjCn.Connection();
            //armando escript para insertar

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@strClaveRegistroVenta", pObj.ClaveRegistroVenta),
                new SqlParameter("@strCodigoEmpresa", Universal.gCodigoEmpresa),
                new SqlParameter("@strPeriodoRegistroVenta", pObj.PeriodoRegistroVenta),
                new SqlParameter("@strNumCorrelativoVenta", pObj.NumCorrelativoVenta),
                new SqlParameter("@strCodUnicoOperacionVenta", pObj.CodUnicoOperacionVenta),
                new SqlParameter("@strFechaEmisionComprobantePagoVenta", pObj.FechaEmisionComprobantePagoVenta),
                new SqlParameter("@strFechaVencimientoPagoVenta", pObj.FechaVencimientoPagoVenta),
                new SqlParameter("@strTipoComprobantePagoVenta", pObj.TipoComprobantePagoVenta),
                new SqlParameter("@strSerieComprobantePagoVenta", pObj.SerieComprobantePagoVenta),
                new SqlParameter("@strNumComprobantePagoVenta", pObj.NumComprobantePagoVenta),
                new SqlParameter("@strRegistroTicketsVenta", pObj.RegistroTicketsVenta),
                new SqlParameter("@strTipoClienteVenta", pObj.TipoClienteVenta),
                new SqlParameter("@strNumeroDocumentoClienteVenta", pObj.NumeroDocumentoClienteVenta),
                new SqlParameter("@strValorFacturadoExportacionVenta", pObj.ValorFacturadoExportacionVenta),
                new SqlParameter("@strBaseImponibleOperacionVenta", pObj.BaseImponibleOperacionVenta),
                new SqlParameter("@strDescuentoBaseImponibleVenta", pObj.DescuentoBaseImponibleVenta),
                new SqlParameter("@strImpuestoGeneralVenta", pObj.ImpuestoGeneralVenta),
                new SqlParameter("@strDescuentoImpuestoGeneralVenta", pObj.DescuentoImpuestoGeneralVenta),
                new SqlParameter("@strImporteTotalExoneradaVenta", pObj.ImporteTotalExoneradaVenta),
                new SqlParameter("@strImporteTotalInafecta", pObj.ImporteTotalInafecta),
                new SqlParameter("@strImpuestoSelectivoConsumoVenta", pObj.ImpuestoSelectivoConsumoVenta),
                new SqlParameter("@strBaseImponibleGravadaVentaArrozPilado", pObj.BaseImponibleGravadaVentaArrozPilado),
                new SqlParameter("@strImpuestoVentaArrozPilado", pObj.ImpuestoVentaArrozPilado),
                new SqlParameter("@strImpuestoConsumoBolsaPlastico", pObj.ImpuestoConsumoBolsaPlastico),
                new SqlParameter("@strOtrosConceptoTributosCargosBaseImponible", pObj.OtrosConceptoTributosCargosBaseImponible),
                new SqlParameter("@strImporteTotalComprobantePagoVenta", pObj.ImporteTotalComprobantePagoVenta),
                new SqlParameter("@strCodigoMoneda", pObj.CodigoMoneda),
                new SqlParameter("@strTipoCambio", pObj.TipoCambio),
                new SqlParameter("@strFechaEmisionComprobantePagoModifica", pObj.FechaEmisionComprobantePagoModifica),
                new SqlParameter("@strTipoComprobantePagoModifica", pObj.TipoComprobantePagoModifica),
                new SqlParameter("@strSerieComprobantePagoModifica", pObj.SerieComprobantePagoModifica),
                new SqlParameter("@strNumeroComprobantePagoModifica", pObj.NumeroComprobantePagoModifica),
                new SqlParameter("@strIdentificacionContratoProyecto", pObj.IdentificacionContratoProyecto),
                new SqlParameter("@strErrorTipo", pObj.ErrorTipo),
                new SqlParameter("@strIdentificadorComprobantePagoCancelados", pObj.IdentificadorComprobantePagoCancelados),
                new SqlParameter("@strEstadoIdentificaAnotacion", pObj.EstadoIdentificaAnotacion),
                new SqlParameter("@strCEstadoRegistroVenta", pObj.CEstadoRegistroVenta),
                new SqlParameter("@strUsuarioAgrega", Universal.gCodigoUsuario),
                new SqlParameter("@strUsuarioModifica", Universal.gCodigoUsuario),
            };
            xObjCn.AssignParameters(sqlParameters);
            xObjCn.CommandStoreProcedure("isp_AgregarRegistroVenta");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public List<DeclaracionesRegistroVentaDto> ListarRegistroVentaXPeriodo(DeclaracionesRegistroVentaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strCodEmp", Universal.gCodigoEmpresa),
                new SqlParameter("@strPerRegVen", pObj.PeriodoRegistroVenta),
            };
            return this.ListarObjetos("isp_ListarRegistroVentaXPeriodo", lParameter);
        }
        public DeclaracionesRegistroVentaDto BuscarRegistroVentaXClave(DeclaracionesRegistroVentaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strClaRegVen", pObj.ClaveRegistroVenta),
            };
            return this.BuscarObjeto("isp_BuscarRegistroVentaXClave", lParameter);
        }
        public void ModificarRegistroVenta(DeclaracionesRegistroVentaDto pObj)
        {
            xObjCn.Connection();
            //armando escript para modificar
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@strClaveRegistroVenta", pObj.ClaveRegistroVenta),
                new SqlParameter("@strCodUnicoOperacionVenta", pObj.CodUnicoOperacionVenta),
                new SqlParameter("@strFechaEmisionComprobantePagoVenta", pObj.FechaEmisionComprobantePagoVenta),
                new SqlParameter("@strFechaVencimientoPagoVenta", pObj.FechaVencimientoPagoVenta),
                new SqlParameter("@strTipoComprobantePagoVenta", pObj.TipoComprobantePagoVenta),
                new SqlParameter("@strSerieComprobantePagoVenta", pObj.SerieComprobantePagoVenta),
                new SqlParameter("@strNumComprobantePagoVenta", pObj.NumComprobantePagoVenta),
                new SqlParameter("@strRegistroTicketsVenta", pObj.RegistroTicketsVenta),
                new SqlParameter("@strTipoClienteVenta", pObj.TipoClienteVenta),
                new SqlParameter("@strNumeroDocumentoClienteVenta", pObj.NumeroDocumentoClienteVenta),
                new SqlParameter("@strValorFacturadoExportacionVenta", pObj.ValorFacturadoExportacionVenta),
                new SqlParameter("@strBaseImponibleOperacionVenta", pObj.BaseImponibleOperacionVenta),
                new SqlParameter("@strDescuentoBaseImponibleVenta", pObj.DescuentoBaseImponibleVenta),
                new SqlParameter("@strImpuestoGeneralVenta", pObj.ImpuestoGeneralVenta),
                new SqlParameter("@strDescuentoImpuestoGeneralVenta", pObj.DescuentoImpuestoGeneralVenta),
                new SqlParameter("@strImporteTotalExoneradaVenta", pObj.ImporteTotalExoneradaVenta),
                new SqlParameter("@strImporteTotalInafecta", pObj.ImporteTotalInafecta),
                new SqlParameter("@strImpuestoSelectivoConsumoVenta", pObj.ImpuestoSelectivoConsumoVenta),
                new SqlParameter("@strBaseImponibleGravadaVentaArrozPilado", pObj.BaseImponibleGravadaVentaArrozPilado),
                new SqlParameter("@strImpuestoVentaArrozPilado", pObj.ImpuestoVentaArrozPilado),
                new SqlParameter("@strImpuestoConsumoBolsaPlastico", pObj.ImpuestoConsumoBolsaPlastico),
                new SqlParameter("@strOtrosConceptoTributosCargosBaseImponible", pObj.OtrosConceptoTributosCargosBaseImponible),
                new SqlParameter("@strImporteTotalComprobantePagoVenta", pObj.ImporteTotalComprobantePagoVenta),
                new SqlParameter("@strCodigoMoneda", pObj.CodigoMoneda),
                new SqlParameter("@strTipoCambio", pObj.TipoCambio),
                new SqlParameter("@strFechaEmisionComprobantePagoModifica", pObj.FechaEmisionComprobantePagoModifica),
                new SqlParameter("@strTipoComprobantePagoModifica", pObj.TipoComprobantePagoModifica),
                new SqlParameter("@strSerieComprobantePagoModifica", pObj.SerieComprobantePagoModifica),
                new SqlParameter("@strNumeroComprobantePagoModifica", pObj.NumeroComprobantePagoModifica),
                new SqlParameter("@strIdentificacionContratoProyecto", pObj.IdentificacionContratoProyecto),
                new SqlParameter("@strErrorTipo", pObj.ErrorTipo),
                new SqlParameter("@strIdentificadorComprobantePagoCancelados", pObj.IdentificadorComprobantePagoCancelados),
                new SqlParameter("@strEstadoIdentificaAnotacion", pObj.EstadoIdentificaAnotacion),
                new SqlParameter("@strCEstadoRegistroVenta", pObj.CEstadoRegistroVenta),
                new SqlParameter("@strUsuarioModifica", Universal.gCodigoUsuario),
            };
            xObjCn.AssignParameters(sqlParameters);
            xObjCn.CommandStoreProcedure("isp_ModificarRegistroVenta");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarRegistroVenta(DeclaracionesRegistroVentaDto pObj)
        {
            xObjCn.Connection();
            //armando escript para eliminar

            //condicion
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@strClaveRegistroVenta",pObj.ClaveRegistroVenta),
            };

            xObjCn.AssignParameters(sqlParameters);
            xObjCn.CommandStoreProcedure("isp_EliminarRegistroVenta");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
