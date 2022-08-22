using DeclaracionesModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesRepository.IRepository
{
    public interface IDeclaracionesAccessRepository
    {
        DeclaracionesAccessDto BuscarUsuarioXCodigo(DeclaracionesAccessDto pObj);
        List<DeclaracionesAccessDto> ListarUsuariosXEstado(DeclaracionesAccessDto pObj);
        List<DeclaracionesAccessDto> ListarUsuarios();
    }
}
