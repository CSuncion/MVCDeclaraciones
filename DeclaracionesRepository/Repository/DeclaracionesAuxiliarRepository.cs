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
    public class DeclaracionesAuxiliarRepository : IDeclaracionesAuxiliarRepository
    {
        private DeclaracionesCn xObjCn = new DeclaracionesCn();
        private DeclaracionesAuxiliarDto xObj = new DeclaracionesAuxiliarDto();
        private List<DeclaracionesAuxiliarDto> xLista = new List<DeclaracionesAuxiliarDto>();
        private DeclaracionesAuxiliarDto Objeto(IDataReader iDr)
        {
            DeclaracionesAuxiliarDto xObjEnc = new DeclaracionesAuxiliarDto();
            xObjEnc.ClaveAuxiliar = iDr[DeclaracionesAuxiliarDto.ClaAux].ToString();
            xObjEnc.CodigoEmpresa = iDr[DeclaracionesAuxiliarDto.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[DeclaracionesAuxiliarDto.NomEmp].ToString();
            xObjEnc.CodigoAuxiliar = iDr[DeclaracionesAuxiliarDto.CodAux].ToString();
            xObjEnc.ApellidoPaternoAuxiliar = iDr[DeclaracionesAuxiliarDto.ApePatAux].ToString();
            xObjEnc.ApellidoMaternoAuxiliar = iDr[DeclaracionesAuxiliarDto.ApeMatAux].ToString();
            xObjEnc.PrimerNombreAuxiliar = iDr[DeclaracionesAuxiliarDto.PriNomAux].ToString();
            xObjEnc.SegundoNombreAuxiliar = iDr[DeclaracionesAuxiliarDto.SegNomAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[DeclaracionesAuxiliarDto.DesAux].ToString();
            xObjEnc.DireccionAuxiliar = iDr[DeclaracionesAuxiliarDto.DirAux].ToString();
            xObjEnc.TelefonoAuxiliar = iDr[DeclaracionesAuxiliarDto.TelAux].ToString();
            xObjEnc.CelularAuxiliar = iDr[DeclaracionesAuxiliarDto.CelAux].ToString();
            xObjEnc.CorreoAuxiliar = iDr[DeclaracionesAuxiliarDto.CorAux].ToString();
            xObjEnc.ReferenciaAuxiliar = iDr[DeclaracionesAuxiliarDto.RefAux].ToString();
            xObjEnc.CTipoAuxiliar = iDr[DeclaracionesAuxiliarDto.CTipAux].ToString();
            xObjEnc.NTipoAuxiliar = iDr[DeclaracionesAuxiliarDto.NTipAux].ToString();
            xObjEnc.TipoDocumentoAuxiliar = iDr[DeclaracionesAuxiliarDto.TipDocAux].ToString();
            xObjEnc.PaisNoDomiciliadoAuxiliar = iDr[DeclaracionesAuxiliarDto.PaiNoDomAux].ToString();
            xObjEnc.FechaInscripcionSnpAuxiliar = iDr[DeclaracionesAuxiliarDto.FecInsSnpAux].ToString();
            xObjEnc.CEstadoAuxiliar = iDr[DeclaracionesAuxiliarDto.CEstAux].ToString();
            xObjEnc.NEstadoAuxiliar = iDr[DeclaracionesAuxiliarDto.NEstAux].ToString();
            xObjEnc.UsuarioAgrega = iDr[DeclaracionesAuxiliarDto.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[DeclaracionesAuxiliarDto.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[DeclaracionesAuxiliarDto.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[DeclaracionesAuxiliarDto.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveAuxiliar;
            return xObjEnc;
        }
        private DeclaracionesAuxiliarDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
        {
            this.xObj = new DeclaracionesAuxiliarDto();
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
        private List<DeclaracionesAuxiliarDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
        {
            xLista = new List<DeclaracionesAuxiliarDto>();
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
        public List<DeclaracionesAuxiliarDto> ListarAuxiliares(DeclaracionesAuxiliarDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strCodEmp", Universal.gCodigoEmpresa)
            };
            return this.ListarObjetos("isp_ListarAuxiliares", lParameter);
        }
        public DeclaracionesAuxiliarDto BuscarAuxiliarXClave(DeclaracionesAuxiliarDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strClaAux", pObj.ClaveAuxiliar)
            };
            return this.BuscarObjeto("isp_BuscarAuxiliarXClave", lParameter);
        }
        public void AgregarAuxiliar(DeclaracionesAuxiliarDto pObj)
        {
            xObjCn.Connection();
            //armando escript para insertar

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
              new SqlParameter("@strClaveAuxiliar", pObj.ClaveAuxiliar),
              new SqlParameter("@strCodigoEmpresa", pObj.CodigoEmpresa),
              new SqlParameter("@strCodigoAuxiliar", pObj.CodigoAuxiliar),
              new SqlParameter("@strApellidoPaternoAuxiliar", pObj.ApellidoPaternoAuxiliar),
              new SqlParameter("@strApellidoMaternoAuxiliar", pObj.ApellidoMaternoAuxiliar),
              new SqlParameter("@strPrimerNombreAuxiliar", pObj.PrimerNombreAuxiliar),
              new SqlParameter("@strSegundoNombreAuxiliar", pObj.SegundoNombreAuxiliar),
              new SqlParameter("@strDescripcionAuxiliar", pObj.DescripcionAuxiliar),
              new SqlParameter("@strDireccionAuxiliar", pObj.DireccionAuxiliar),
              new SqlParameter("@strTelefonoAuxiliar", pObj.TelefonoAuxiliar),
              new SqlParameter("@strCelularAuxiliar", pObj.CelularAuxiliar),
              new SqlParameter("@strCorreoAuxiliar", pObj.CorreoAuxiliar),
              new SqlParameter("@strReferenciaAuxiliar", pObj.ReferenciaAuxiliar),
              new SqlParameter("@strCTipoAuxiliar", pObj.CTipoAuxiliar),
              new SqlParameter("@strTipoDocumentoAuxiliar", pObj.TipoDocumentoAuxiliar),
              new SqlParameter("@strPaisNoDomiciliadoAuxiliar", pObj.PaisNoDomiciliadoAuxiliar),
              new SqlParameter("@strFechaInscripcionSnpAuxiliar", pObj.FechaInscripcionSnpAuxiliar),
              new SqlParameter("@strCOrigenVentanaCreacion", "1"),
              new SqlParameter("@strCEstadoAuxiliar", pObj.CEstadoAuxiliar),
              new SqlParameter("@strUsuarioAgrega", Universal.gCodigoUsuario),
              new SqlParameter("@strUsuarioModifica", Universal.gCodigoUsuario),
            };
            xObjCn.AssignParameters(sqlParameters);
            xObjCn.CommandStoreProcedure("isp_AgregarAuxiliar");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void ModificarAuxiliar(DeclaracionesAuxiliarDto pObj)
        {
            xObjCn.Connection();
            //armando escript para insertar

            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
              new SqlParameter("@strClaveAuxiliar", pObj.ClaveAuxiliar),
              new SqlParameter("@strApellidoPaternoAuxiliar", pObj.ApellidoPaternoAuxiliar),
              new SqlParameter("@strApellidoMaternoAuxiliar", pObj.ApellidoMaternoAuxiliar),
              new SqlParameter("@strPrimerNombreAuxiliar", pObj.PrimerNombreAuxiliar),
              new SqlParameter("@strSegundoNombreAuxiliar", pObj.SegundoNombreAuxiliar),
              new SqlParameter("@strDescripcionAuxiliar", pObj.DescripcionAuxiliar),
              new SqlParameter("@strDireccionAuxiliar", pObj.DireccionAuxiliar),
              new SqlParameter("@strTelefonoAuxiliar", pObj.TelefonoAuxiliar),
              new SqlParameter("@strCelularAuxiliar", pObj.CelularAuxiliar),
              new SqlParameter("@strCorreoAuxiliar", pObj.CorreoAuxiliar),
              new SqlParameter("@strReferenciaAuxiliar", pObj.ReferenciaAuxiliar),
              new SqlParameter("@strCTipoAuxiliar", pObj.CTipoAuxiliar),
              new SqlParameter("@strTipoDocumentoAuxiliar", pObj.TipoDocumentoAuxiliar),
              new SqlParameter("@strPaisNoDomiciliadoAuxiliar", pObj.PaisNoDomiciliadoAuxiliar),
              new SqlParameter("@strFechaInscripcionSnpAuxiliar", pObj.FechaInscripcionSnpAuxiliar),
              new SqlParameter("@strCOrigenVentanaCreacion", "1"),
              new SqlParameter("@strCEstadoAuxiliar", pObj.CEstadoAuxiliar),
              new SqlParameter("@strUsuarioModifica", Universal.gCodigoUsuario),
            };
            xObjCn.AssignParameters(sqlParameters);
            xObjCn.CommandStoreProcedure("isp_ModicarAuxiliar");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarAuxiliar(DeclaracionesAuxiliarDto pObj)
        {
            xObjCn.Connection();

            //armando escript para insertaranangelica   
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strClaAux", pObj.ClaveAuxiliar),
            };

            //ejecutar
            xObjCn.AssignParameters(lParameter);

            xObjCn.CommandStoreProcedure("isp_EliminarAuxiliar");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public List<DeclaracionesAuxiliarDto> ListarProveedoresActivos(DeclaracionesAuxiliarDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strCodigoEmpresa", Universal.gCodigoEmpresa),
                new SqlParameter("@strCEstAux", "1"),
                new SqlParameter("@strCTipAux", "'1','2'"),
            };
            return this.ListarObjetos("isp_ListarProveedoresActivos", lParameter);
        }
    }
}
