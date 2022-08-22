using DeclaracionesModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesRepository.IRepository
{
    public interface IDeclaracionesItemGRepository
    {
        List<DeclaracionesItemGDto> ListarItemsGActivosXTabla(DeclaracionesItemGDto pObj);
        DeclaracionesItemGDto BuscarItemGXClave(DeclaracionesItemGDto pObj);
    }
}
