using DeclaracionesModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesRepository.IRepository
{
    public interface IDeclaracionesTipoCambioRepository
    {
        List<DeclaracionesTipoCambioDto> ListarTipoCambio(DeclaracionesTipoCambioDto pObj);
        void AgregarTipoCambio(DeclaracionesTipoCambioDto pObj);
        DeclaracionesTipoCambioDto BuscarTipoCambioXFecha(DeclaracionesTipoCambioDto pObj);
        void ModificarTipoCambio(DeclaracionesTipoCambioDto pObj);
        void EliminarTipoCambio(DeclaracionesTipoCambioDto pObj);
    }
}
