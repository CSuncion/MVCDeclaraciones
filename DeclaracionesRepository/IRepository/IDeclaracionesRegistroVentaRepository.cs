using DeclaracionesModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesRepository.IRepository
{
    public interface IDeclaracionesRegistroVentaRepository
    {
        string ObtenerMaximoValorEnColumna(DeclaracionesRegistroVentaDto pObj);
        void AgregarRegistroVenta(DeclaracionesRegistroVentaDto pObj);
        List<DeclaracionesRegistroVentaDto> ListarRegistroVentaXPeriodo(DeclaracionesRegistroVentaDto pObj);
        DeclaracionesRegistroVentaDto BuscarRegistroVentaXClave(DeclaracionesRegistroVentaDto pObj);
        void ModificarRegistroVenta(DeclaracionesRegistroVentaDto pObj);
        void EliminarRegistroVenta(DeclaracionesRegistroVentaDto pObj);
    }
}
