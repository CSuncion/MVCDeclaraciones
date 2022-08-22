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
    public class DeclaracionesPeriodoRepository : IDeclaracionesPeriodoRepository
    {
        #region Variables

        private DeclaracionesCn xObjCn = new DeclaracionesCn();
        private DeclaracionesPeriodoDto xObj = new DeclaracionesPeriodoDto();
        private List<DeclaracionesPeriodoDto> xLista = new List<DeclaracionesPeriodoDto>();

        #endregion

        #region Metodos privados

        private DeclaracionesPeriodoDto Objeto(IDataReader iDr)
        {
            DeclaracionesPeriodoDto xObjEnc = new DeclaracionesPeriodoDto();
            xObjEnc.ClavePeriodo = iDr[DeclaracionesPeriodoDto.ClaPer].ToString();
            xObjEnc.CodigoPeriodo = iDr[DeclaracionesPeriodoDto.CodPer].ToString();
            xObjEnc.CodigoEmpresa = iDr[DeclaracionesPeriodoDto.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[DeclaracionesPeriodoDto.NomEmp].ToString();
            xObjEnc.AnoPeriodo = iDr[DeclaracionesPeriodoDto.AnoPer].ToString();
            xObjEnc.CMesPeriodo = iDr[DeclaracionesPeriodoDto.CMesPer].ToString();
            xObjEnc.NMesPeriodo = iDr[DeclaracionesPeriodoDto.NMesPer].ToString();
            xObjEnc.TipoCambioPeriodo = Convert.ToDecimal(iDr[DeclaracionesPeriodoDto.TipCamPer].ToString());
            xObjEnc.CEstadoPeriodo = iDr[DeclaracionesPeriodoDto.CEstPer].ToString();
            xObjEnc.NEstadoPeriodo = iDr[DeclaracionesPeriodoDto.NEstPer].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClavePeriodo;
            return xObjEnc;
        }
        private DeclaracionesPeriodoDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
        {
            this.xObj = new DeclaracionesPeriodoDto();
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
        private List<DeclaracionesPeriodoDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
        {
            xLista = new List<DeclaracionesPeriodoDto>();
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
        #endregion

        public List<DeclaracionesPeriodoDto> ListarPeriodos()
        {
            List<SqlParameter> lParameter = null;

            return this.ListarObjetos("isp_ListarPeriodos", lParameter);
        }

        public DeclaracionesPeriodoDto BuscarPeriodoXClave(DeclaracionesPeriodoDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strClaPer", pObj.ClavePeriodo)
            };

            return this.BuscarObjeto("isp_BuscarPeriodoXClave", lParameter);
        }
        public void AgregarPeriodo(DeclaracionesPeriodoDto pObj)
        {
            xObjCn.Connection();

            //armando escript para insertaranangelica   
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strClaPer", pObj.ClavePeriodo),
                new SqlParameter("@strCodPer", pObj.CodigoPeriodo),
                new SqlParameter("@strCodEmp", pObj.CodigoEmpresa),
                new SqlParameter("@strAnoPer", pObj.AnoPeriodo),
                new SqlParameter("@strCMesPer", pObj.CMesPeriodo),
                new SqlParameter("@strTipCamPer", pObj.TipoCambioPeriodo.ToString()),
                new SqlParameter("@strCEstPer", pObj.CEstadoPeriodo),
                new SqlParameter("@strUsuAgr", Universal.gCodigoUsuario),
                new SqlParameter("@strUsuMod", Universal.gCodigoUsuario),
            };

            xObjCn.AssignParameters(lParameter);

            xObjCn.CommandStoreProcedure("isp_AgregarPeriodo");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }

        public void ModificarPeriodo(DeclaracionesPeriodoDto pObj)
        {
            xObjCn.Connection();

            //armando escript para insertaranangelica   
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strClaPer", pObj.ClavePeriodo),
                new SqlParameter("@strTipCamPer", pObj.TipoCambioPeriodo.ToString()),
                new SqlParameter("@strCEstPer", pObj.CEstadoPeriodo),
                new SqlParameter("@strUsuMod", Universal.gCodigoUsuario),
            };

            xObjCn.AssignParameters(lParameter);

            xObjCn.CommandStoreProcedure("isp_ModificarPeriodo");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }
        public void EliminarPeriodo(DeclaracionesPeriodoDto pObj)
        {
            xObjCn.Connection();

            //armando escript para insertaranangelica   
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strClaPer", pObj.ClavePeriodo),
            };

            //ejecutar
            xObjCn.AssignParameters(lParameter);

            xObjCn.CommandStoreProcedure("isp_EliminarPeriodo");
            xObjCn.ExecuteNotResult();
            xObjCn.Disconnect();
        }

        public bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strColumnaBusqueda", pColumnaBusqueda),
                new SqlParameter("@strValorBusqueda", pValorBusqueda),
            };

            return this.ExisteObjeto("isp_ExisteValorEnColumnaSinEmpresa", lParameter);
        }
    }
}
