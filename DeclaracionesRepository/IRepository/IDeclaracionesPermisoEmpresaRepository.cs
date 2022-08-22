using DeclaracionesModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesRepository.IRepository
{
    public interface IDeclaracionesPermisoEmpresaRepository
    {
        DeclaracionesPermisoEmpresaDto BuscarPermisoEmpresaXClave(DeclaracionesPermisoEmpresaDto pObj);
        List<DeclaracionesPermisoEmpresaDto> ListarPermisosEmpresaActivasXUsuarioYAutorizadas(DeclaracionesPermisoEmpresaDto pObj);
        void AdicionarPermisoEmpresaMasivo(List<DeclaracionesPermisoEmpresaDto> pLista);
        void EliminarPermisosEmpresaXEmpresa(DeclaracionesPermisoEmpresaDto pObj);
    }
}
