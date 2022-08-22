using DeclaracionesModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesRepository.IRepository
{
    public interface IDeclaracionesAuxiliarRepository
    {
        List<DeclaracionesAuxiliarDto> ListarAuxiliares(DeclaracionesAuxiliarDto pObj);
        DeclaracionesAuxiliarDto BuscarAuxiliarXClave(DeclaracionesAuxiliarDto pObj);
        void AgregarAuxiliar(DeclaracionesAuxiliarDto pObj);
        void ModificarAuxiliar(DeclaracionesAuxiliarDto pObj);
        void EliminarAuxiliar(DeclaracionesAuxiliarDto pObj);
        List<DeclaracionesAuxiliarDto> ListarProveedoresActivos(DeclaracionesAuxiliarDto pObj);
    }
}
