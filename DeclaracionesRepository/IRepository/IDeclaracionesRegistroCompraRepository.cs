using DeclaracionesModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesRepository.IRepository
{
    public interface IDeclaracionesRegistroCompraRepository
    {
        string ObtenerMaximoValorEnColumna(DeclaracionesRegistroCompraDto pObj);
        void AgregarRegistroCompra(DeclaracionesRegistroCompraDto pObj);
        List<DeclaracionesRegistroCompraDto> ListarRegistroCompraXPeriodo(DeclaracionesRegistroCompraDto pObj);
        DeclaracionesRegistroCompraDto BuscarRegistroCompraXClave(DeclaracionesRegistroCompraDto pObj);
        void ModificarRegistroCompra(DeclaracionesRegistroCompraDto pObj);
        void EliminarRegistroCompra(DeclaracionesRegistroCompraDto pObj);
    }
}
