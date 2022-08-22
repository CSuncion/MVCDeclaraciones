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
    public class DeclaracionesItemGRepository : IDeclaracionesItemGRepository
    {

        private DeclaracionesCn xObjCn = new DeclaracionesCn();
        private DeclaracionesItemGDto xObj = new DeclaracionesItemGDto();
        private List<DeclaracionesItemGDto> xLista = new List<DeclaracionesItemGDto>();
        private DeclaracionesItemGDto Objeto(IDataReader iDr)
        {
            DeclaracionesItemGDto xObjEnc = new DeclaracionesItemGDto();
            xObjEnc.ClaveItemG = iDr[DeclaracionesItemGDto.ClaIteG].ToString();
            xObjEnc.CodigoTabla = iDr[DeclaracionesItemGDto.CodTab].ToString();
            xObjEnc.NombreTabla = iDr[DeclaracionesItemGDto.NomTab].ToString();
            xObjEnc.CodigoItemG = iDr[DeclaracionesItemGDto.CodIteG].ToString();
            xObjEnc.NombreItemG = iDr[DeclaracionesItemGDto.NomIteG].ToString();
            xObjEnc.AbreviaItemG = iDr[DeclaracionesItemGDto.AbrIteG].ToString();
            xObjEnc.CEstadoItemG = iDr[DeclaracionesItemGDto.CEstIteG].ToString();
            xObjEnc.NEstadoItemG = iDr[DeclaracionesItemGDto.NEstIteG].ToString();
            xObjEnc.UsuarioAgrega = iDr[DeclaracionesItemGDto.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[DeclaracionesItemGDto.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[DeclaracionesItemGDto.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[DeclaracionesItemGDto.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveItemG;
            return xObjEnc;
        }

        private DeclaracionesItemGDto BuscarObjeto(string pScript, List<SqlParameter> lParameter)
        {
            this.xObj = new DeclaracionesItemGDto();
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
        private List<DeclaracionesItemGDto> ListarObjetos(string pScript, List<SqlParameter> lParameter)
        {
            xLista = new List<DeclaracionesItemGDto>();
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

        public List<DeclaracionesItemGDto> ListarItemsGActivosXTabla(DeclaracionesItemGDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strCodigoTabla", pObj.CodigoTabla),
                new SqlParameter("@strEstado", "1"),
            };

            return this.ListarObjetos("isp_ListarItemsGActivosXTabla", lParameter);
        }
        public DeclaracionesItemGDto BuscarItemGXClave(DeclaracionesItemGDto pObj)
        {
            List<SqlParameter> lParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strClaIteG", pObj.ClaveItemG)
            };

            return this.BuscarObjeto("isp_BuscarItemGXClave", lParameter);
        }
    }
}
