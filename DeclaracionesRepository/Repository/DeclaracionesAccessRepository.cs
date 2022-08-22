using DeclaracionesConnection.Connection;
using DeclaracionesModel.ModelDto;
using DeclaracionesRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DeclaracionesRepository.Repository
{
    public class DeclaracionesAccessRepository : IDeclaracionesAccessRepository
    {
        private DeclaracionesCn xObjCn = new DeclaracionesCn();
        private DeclaracionesAccessDto xObj = new DeclaracionesAccessDto();
        private List<DeclaracionesAccessDto> xLista = new List<DeclaracionesAccessDto>();
        private DeclaracionesAccessDto Objeto(IDataReader iDr)
        {
            DeclaracionesAccessDto xObjEnc = new DeclaracionesAccessDto();
            xObjEnc.CodigoUsuario = iDr[DeclaracionesAccessDto.CodUsu].ToString();
            xObjEnc.NombreUsuario = iDr[DeclaracionesAccessDto.NomUsu].ToString();
            xObjEnc.ClaveUsuario = iDr[DeclaracionesAccessDto.ClaUsu].ToString();
            xObjEnc.DireccionUsuario = iDr[DeclaracionesAccessDto.DirUsu].ToString();
            xObjEnc.FotoUsuario = iDr[DeclaracionesAccessDto.FotUsu].ToString();
            xObjEnc.CorreoUsuario = iDr[DeclaracionesAccessDto.CorUsu].ToString();
            xObjEnc.CodigoPerfil = iDr[DeclaracionesAccessDto.CodPer].ToString();
            xObjEnc.NombrePerfil = iDr[DeclaracionesAccessDto.NomPer].ToString();
            xObjEnc.CEstadoUsuario = iDr[DeclaracionesAccessDto.CEstUsu].ToString();
            xObjEnc.NEstadoUsuario = iDr[DeclaracionesAccessDto.NEstUsu].ToString();
            xObjEnc.TelFijoUsuario = iDr[DeclaracionesAccessDto.TelFijUsu].ToString();
            xObjEnc.TelCelularUsuario = iDr[DeclaracionesAccessDto.TelCelUsu].ToString();
            xObjEnc.CodigoPersonal = iDr[DeclaracionesAccessDto.CodPrs].ToString();
            xObjEnc.UsuarioAgrega = iDr[DeclaracionesAccessDto.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[DeclaracionesAccessDto.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[DeclaracionesAccessDto.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[DeclaracionesAccessDto.FecMod]);
            xObjEnc.ClaveObjeto = iDr[DeclaracionesAccessDto.CodUsu].ToString();
            return xObjEnc;
        }
        private DeclaracionesAccessDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
        {
            xObj = new DeclaracionesAccessDto();
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
        private List<DeclaracionesAccessDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
        {
            xLista = new List<DeclaracionesAccessDto>();
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
        public DeclaracionesAccessDto BuscarUsuarioXCodigo(DeclaracionesAccessDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strCodigoUsuario", pObj.CodigoUsuario)
                };

            return this.BuscarObjeto("isp_BuscarUsuarioXCodigo", lParameter);
        }

        public List<DeclaracionesAccessDto> ListarUsuariosXEstado(DeclaracionesAccessDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
                {
                new SqlParameter("@strCEstUsu", pObj.CEstadoUsuario)
                };

            return this.ListarObjetos("isp_ListarUsuariosXEstado", lParameter);
        }
        public List<DeclaracionesAccessDto> ListarUsuarios()
        {
            List<SqlParameter> lParameter = null;

            return this.ListarObjetos("isp_ListarUsuarios", lParameter);
        }
    }
}
