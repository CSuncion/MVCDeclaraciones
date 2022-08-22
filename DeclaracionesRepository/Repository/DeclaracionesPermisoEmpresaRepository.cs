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
    public class DeclaracionesPermisoEmpresaRepository : IDeclaracionesPermisoEmpresaRepository
    {
        private DeclaracionesCn xObjCn = new DeclaracionesCn();
        private DeclaracionesPermisoEmpresaDto xObj = new DeclaracionesPermisoEmpresaDto();
        private List<DeclaracionesPermisoEmpresaDto> xLista = new List<DeclaracionesPermisoEmpresaDto>();
        private DeclaracionesPermisoEmpresaDto Objeto(IDataReader iDr)
        {
            DeclaracionesPermisoEmpresaDto xObjEnc = new DeclaracionesPermisoEmpresaDto();
            xObjEnc.ClavePermisoEmpresa = iDr[DeclaracionesPermisoEmpresaDto.ClaPerEmp].ToString();
            xObjEnc.CodigoUsuario = iDr[DeclaracionesPermisoEmpresaDto.CodUsu].ToString();
            xObjEnc.NombreUsuario = iDr[DeclaracionesPermisoEmpresaDto.NomUsu].ToString();
            xObjEnc.CodigoPerfil = iDr[DeclaracionesPermisoEmpresaDto.CodPer].ToString();
            xObjEnc.NombrePerfil = iDr[DeclaracionesPermisoEmpresaDto.NomPer].ToString();
            xObjEnc.CodigoEmpresa = iDr[DeclaracionesPermisoEmpresaDto.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[DeclaracionesPermisoEmpresaDto.NomEmp].ToString();
            xObjEnc.CEstadoEmpresa = iDr[DeclaracionesPermisoEmpresaDto.CEstEmp].ToString();
            xObjEnc.NEstadoEmpresa = iDr[DeclaracionesPermisoEmpresaDto.NEstEmp].ToString();
            xObjEnc.CPermitir = iDr[DeclaracionesPermisoEmpresaDto.CPerm].ToString();
            xObjEnc.NPermitir = iDr[DeclaracionesPermisoEmpresaDto.NPerm].ToString();
            xObjEnc.VerdadFalso = Conversion.CadenaABoolean(xObjEnc.CPermitir, false);
            xObjEnc.UsuarioAgrega = iDr[DeclaracionesPermisoEmpresaDto.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[DeclaracionesPermisoEmpresaDto.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[DeclaracionesPermisoEmpresaDto.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[DeclaracionesPermisoEmpresaDto.FecMod]);
            return xObjEnc;
        }

        private DeclaracionesPermisoEmpresaDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
        {
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
        private List<DeclaracionesPermisoEmpresaDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
        {
            xLista = new List<DeclaracionesPermisoEmpresaDto>();
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
        public DeclaracionesPermisoEmpresaDto BuscarPermisoEmpresaXClave(DeclaracionesPermisoEmpresaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strClaPerEmp", pObj.ClavePermisoEmpresa)
                };

            return this.BuscarObjeto("isp_BuscarPermisoEmpresaXClave", lParameter);
        }

        public List<DeclaracionesPermisoEmpresaDto> ListarPermisosEmpresaActivasXUsuarioYAutorizadas(DeclaracionesPermisoEmpresaDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strCodUsu", pObj.CodigoUsuario),
                new SqlParameter("@strCEstEmp", "1"),
                new SqlParameter("@strCPermitir", pObj.CodigoPerfil != "01"? "1":""),
                };

            return this.ListarObjetos("isp_ListarPermisosEmpresaActivasXUsuarioYAutorizadas", lParameter);
        }
        public void AdicionarPermisoEmpresaMasivo(List<DeclaracionesPermisoEmpresaDto> pLista)
        {
            xObjCn.Connection();

            foreach (DeclaracionesPermisoEmpresaDto xPerEmp in pLista)
            {
                //armando escript para insertar
                List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strClavePermisoEmpresa", xPerEmp.ClavePermisoEmpresa),
                new SqlParameter("@strCodigoUsuario", xPerEmp.CodigoUsuario),
                new SqlParameter("@strCodigoEmpresa", xPerEmp.CodigoEmpresa),
                new SqlParameter("@strCPermitir",xPerEmp.CPermitir),
                new SqlParameter("@strgCodigoUsuario",Universal.gCodigoUsuario),
                };
                xObjCn.AssignParameters(lParameter);
                xObjCn.CommandStoreProcedure("isp_AdicionarPermisoEmpresaMasivo");
                xObjCn.ExecuteNotResult();

            }
            xObjCn.Disconnect();
        }

        public void EliminarPermisosEmpresaXEmpresa(DeclaracionesPermisoEmpresaDto pObj)
        {
            xObjCn.Connection();

            //armando escript para insertaranangelica   
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strCodEmp", pObj.CodigoEmpresa),
            };

            //ejecutar
            xObjCn.AssignParameters(lParameter);

            xObjCn.CommandStoreProcedure("isp_EliminarPermisosEmpresaXEmpresa");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
