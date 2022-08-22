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
    public class DeclaracionesEmpresaRepository : IDeclaracionesEmpresaRepository
    {
        private DeclaracionesCn xObjCn = new DeclaracionesCn();
        private DeclaracionesEmpresaDto xObj = new DeclaracionesEmpresaDto();
        private List<DeclaracionesEmpresaDto> xLista = new List<DeclaracionesEmpresaDto>();
        private DeclaracionesEmpresaDto Objeto(IDataReader iDr)
        {
            DeclaracionesEmpresaDto xObjEnc = new DeclaracionesEmpresaDto();
            xObjEnc.CodigoEmpresa = iDr[DeclaracionesEmpresaDto.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[DeclaracionesEmpresaDto.NomEmp].ToString();
            xObjEnc.CorreoEmpresa = iDr[DeclaracionesEmpresaDto.CorEmp].ToString();
            xObjEnc.RucEmpresa = iDr[DeclaracionesEmpresaDto.RucEmp].ToString();
            xObjEnc.DireccionEmpresa = iDr[DeclaracionesEmpresaDto.DirEmp].ToString();
            xObjEnc.TelFijoEmpresa = iDr[DeclaracionesEmpresaDto.TelFijEmp].ToString();
            xObjEnc.TelCelularEmpresa = iDr[DeclaracionesEmpresaDto.TelCelEmp].ToString();
            xObjEnc.NextelEmpresa = iDr[DeclaracionesEmpresaDto.NexEmp].ToString();
            xObjEnc.LogoEmpresa = iDr[DeclaracionesEmpresaDto.LogEmp].ToString();
            xObjEnc.CEstadoEmpresa = iDr[DeclaracionesEmpresaDto.CEstEmp].ToString();
            xObjEnc.NEstadoEmpresa = iDr[DeclaracionesEmpresaDto.NEstEmp].ToString();
            xObjEnc.CTipoDocumento = iDr[DeclaracionesEmpresaDto.CTipDoc].ToString();
            xObjEnc.NTipoDocumento = iDr[DeclaracionesEmpresaDto.NTipDoc].ToString();
            xObjEnc.SerieDocumento = iDr[DeclaracionesEmpresaDto.SerDoc].ToString();
            xObjEnc.NumeroDocumento = iDr[DeclaracionesEmpresaDto.NumDoc].ToString();
            xObjEnc.ConceptoCuotaOrdinaria = iDr[DeclaracionesEmpresaDto.ConCuoOrd].ToString();
            xObjEnc.ConceptoCuotaLuz = iDr[DeclaracionesEmpresaDto.ConCuoLuz].ToString();
            xObjEnc.ConceptoCuotaAgua = iDr[DeclaracionesEmpresaDto.ConCuoAgu].ToString();
            xObjEnc.ConceptoCuotaMora = iDr[DeclaracionesEmpresaDto.ConCuoMor].ToString();
            xObjEnc.PorcentajeMora = Convert.ToDecimal(iDr[DeclaracionesEmpresaDto.PorMor]);
            xObjEnc.UsuarioAgrega = iDr[DeclaracionesEmpresaDto.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[DeclaracionesEmpresaDto.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[DeclaracionesEmpresaDto.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[DeclaracionesEmpresaDto.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.CodigoEmpresa;
            return xObjEnc;
        }

        private DeclaracionesEmpresaDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
        {
            this.xObj = new DeclaracionesEmpresaDto();
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
        private List<DeclaracionesEmpresaDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
        {
            xLista = new List<DeclaracionesEmpresaDto>();
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

        public List<DeclaracionesEmpresaDto> ListarEmpresas(DeclaracionesEmpresaDto pObj)
        {
            List<SqlParameter> lParameter = null;
            return this.ListarObjetos("isp_ListarEmpresas", lParameter);
        }
        public DeclaracionesEmpresaDto BuscarEmpresaXCodigo(DeclaracionesEmpresaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strCodEmp", pObj.CodigoEmpresa)
            };
            return this.BuscarObjeto("isp_BuscarEmpresaXCodigo", lParameter);
        }
        public void AgregarEmpresa(DeclaracionesEmpresaDto pObj)
        {
            xObjCn.Connection();
            //armando escript para insertar

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@strCodigoEmpresa",pObj.CodigoEmpresa),
                new SqlParameter("@strNombreEmpresa", pObj.NombreEmpresa),
                new SqlParameter("@strCorreoEmpresa", pObj.CorreoEmpresa),
                new SqlParameter("@strRucEmpresa", pObj.RucEmpresa),
                new SqlParameter("@strDireccionEmpresa", pObj.DireccionEmpresa),
                new SqlParameter("@strTelFijoEmpresa", pObj.TelFijoEmpresa),
                new SqlParameter("@strTelCelularEmpresa", pObj.TelCelularEmpresa),
                new SqlParameter("@strNextelEmpresa", pObj.NextelEmpresa),
                new SqlParameter("@strLogoEmpresa", pObj.LogoEmpresa),
                new SqlParameter("@strCEstadoEmpresa", pObj.CEstadoEmpresa),
                new SqlParameter("@strCTipoDocumento", pObj.CTipoDocumento),
                new SqlParameter("@strSerieDocumento", pObj.SerieDocumento),
                new SqlParameter("@strNumeroDocumento", pObj.NumeroDocumento),
                new SqlParameter("@strConceptoCuotaOrdinaria", pObj.ConceptoCuotaOrdinaria),
                new SqlParameter("@strConceptoCuotaLuz", pObj.ConceptoCuotaLuz),
                new SqlParameter("@strConceptoCuotaAgua", pObj.ConceptoCuotaAgua),
                new SqlParameter("@strConceptoCuotaMora", pObj.ConceptoCuotaMora),
                new SqlParameter("@decPorcentajeMora", pObj.PorcentajeMora),
                new SqlParameter("@strCodigoUsuario",Universal.gCodigoUsuario),
            };
            xObjCn.AssignParameters(sqlParameters);
            xObjCn.CommandStoreProcedure("isp_AgregarEmpresa");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ModificarEmpresa(DeclaracionesEmpresaDto pObj)
        {
            xObjCn.Connection();
            //armando escript para insertar

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@strCodigoEmpresa",pObj.CodigoEmpresa),
                new SqlParameter("@strNombreEmpresa", pObj.NombreEmpresa),
                new SqlParameter("@strCorreoEmpresa", pObj.CorreoEmpresa),
                new SqlParameter("@strRucEmpresa", pObj.RucEmpresa),
                new SqlParameter("@strDireccionEmpresa", pObj.DireccionEmpresa),
                new SqlParameter("@strTelFijoEmpresa", pObj.TelFijoEmpresa),
                new SqlParameter("@strTelCelularEmpresa", pObj.TelCelularEmpresa),
                new SqlParameter("@strNextelEmpresa", pObj.NextelEmpresa),
                new SqlParameter("@strLogoEmpresa", pObj.LogoEmpresa),
                new SqlParameter("@strCEstadoEmpresa", pObj.CEstadoEmpresa),
                new SqlParameter("@strCTipoDocumento", pObj.CTipoDocumento),
                new SqlParameter("@strSerieDocumento", pObj.SerieDocumento),
                new SqlParameter("@strNumeroDocumento", pObj.NumeroDocumento),
                new SqlParameter("@strConceptoCuotaOrdinaria", pObj.ConceptoCuotaOrdinaria),
                new SqlParameter("@strConceptoCuotaLuz", pObj.ConceptoCuotaLuz),
                new SqlParameter("@strConceptoCuotaAgua", pObj.ConceptoCuotaAgua),
                new SqlParameter("@strConceptoCuotaMora", pObj.ConceptoCuotaMora),
                new SqlParameter("@decPorcentajeMora", pObj.PorcentajeMora),
                new SqlParameter("@strCodigoUsuario",Universal.gCodigoUsuario),
            };
            xObjCn.AssignParameters(sqlParameters);
            xObjCn.CommandStoreProcedure("isp_ModificarEmpresa");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarEmpresa(DeclaracionesEmpresaDto pObj)
        {
            xObjCn.Connection();

            //armando escript para insertaranangelica   
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strCodEmp", pObj.CodigoEmpresa),
            };

            //ejecutar
            xObjCn.AssignParameters(lParameter);

            xObjCn.CommandStoreProcedure("isp_EliminarEmpresa");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
