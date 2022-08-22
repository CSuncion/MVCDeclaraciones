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
    public class DeclaracionesTipoCambioRepository : IDeclaracionesTipoCambioRepository
    {
        private DeclaracionesCn xObjCn = new DeclaracionesCn();
        private DeclaracionesTipoCambioDto xObj = new DeclaracionesTipoCambioDto();
        private List<DeclaracionesTipoCambioDto> xLista = new List<DeclaracionesTipoCambioDto>();

        private DeclaracionesTipoCambioDto Objeto(IDataReader iDr)
        {
            DeclaracionesTipoCambioDto xObjEnc = new DeclaracionesTipoCambioDto();
            xObjEnc.FechaTipoCambio = Fecha.ObtenerDiaMesAno(iDr[DeclaracionesTipoCambioDto.FecTipCam].ToString());
            xObjEnc.CompraTipoCambio = Convert.ToDecimal(iDr[DeclaracionesTipoCambioDto.ComTipCam]);
            xObjEnc.VentaTipoCambio = Convert.ToDecimal(iDr[DeclaracionesTipoCambioDto.VtaTipCam]);
            xObjEnc.PeriodoTipoCambio = iDr[DeclaracionesTipoCambioDto.PerTipCam].ToString();
            xObjEnc.CEstadoTipoCambio = iDr[DeclaracionesTipoCambioDto.CEstTipCam].ToString();
            xObjEnc.NEstadoTipoCambio = iDr[DeclaracionesTipoCambioDto.NEstTipCam].ToString();
            xObjEnc.UsuarioAgrega = iDr[DeclaracionesTipoCambioDto.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[DeclaracionesTipoCambioDto.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[DeclaracionesTipoCambioDto.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[DeclaracionesTipoCambioDto.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.FechaTipoCambio;
            return xObjEnc;
        }
        private DeclaracionesTipoCambioDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
        {
            this.xObj = new DeclaracionesTipoCambioDto();
            xObjCn.Connection();
            if (lParameter != null)
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
        private List<DeclaracionesTipoCambioDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
        {
            xLista = new List<DeclaracionesTipoCambioDto>();
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
        public List<DeclaracionesTipoCambioDto> ListarTipoCambio(DeclaracionesTipoCambioDto pObj)
        {
            List<SqlParameter> lParameter = null;

            return this.ListarObjetos("isp_ListarTipoCambio", lParameter);
        }
        public void AgregarTipoCambio(DeclaracionesTipoCambioDto pObj)
        {
            xObjCn.Connection();

            //armando escript para insertaranangelica   
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strFechaTipoCambio", pObj.FechaTipoCambio),
                new SqlParameter("@decCompraTipoCambio", pObj.CompraTipoCambio),
                new SqlParameter("@decVentaTipoCambio", pObj.VentaTipoCambio),
                new SqlParameter("@strPeriodoTipoCambio", pObj.PeriodoTipoCambio),
                new SqlParameter("@strCEstadoTipoCambio", pObj.CEstadoTipoCambio),
                new SqlParameter("@strUsuarioAgrega", Universal.gCodigoUsuario),
                new SqlParameter("@strUsuarioModifica",Universal.gCodigoUsuario),
            };

            xObjCn.AssignParameters(lParameter);

            xObjCn.CommandStoreProcedure("isp_AgregarTipoCambio");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public DeclaracionesTipoCambioDto BuscarTipoCambioXFecha(DeclaracionesTipoCambioDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strFechaTipoCambio", pObj.FechaTipoCambio)
            };

            return this.BuscarObjeto("isp_BuscarTipoCambioXFecha", lParameter);
        }
        public void ModificarTipoCambio(DeclaracionesTipoCambioDto pObj)
        {
            xObjCn.Connection();

            //armando escript para insertaranangelica   
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strFechaTipoCambio", pObj.FechaTipoCambio),
                new SqlParameter("@decCompraTipoCambio", pObj.CompraTipoCambio),
                new SqlParameter("@decVentaTipoCambio", pObj.VentaTipoCambio),
                new SqlParameter("@strPeriodoTipoCambio", pObj.PeriodoTipoCambio),
                new SqlParameter("@strCEstadoTipoCambio", pObj.CEstadoTipoCambio),
                new SqlParameter("@strUsuarioModifica",Universal.gCodigoUsuario),
            };

            xObjCn.AssignParameters(lParameter);

            xObjCn.CommandStoreProcedure("isp_ModificarTipoCambio");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarTipoCambio(DeclaracionesTipoCambioDto pObj)
        {
            xObjCn.Connection();

            //armando escript para insertaranangelica   
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strFechaTipoCambio", pObj.FechaTipoCambio),
            };

            xObjCn.AssignParameters(lParameter);

            xObjCn.CommandStoreProcedure("isp_EliminarTipoCambio");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
    }
}
