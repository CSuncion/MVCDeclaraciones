using DeclaracionesModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesRepository.IRepository
{
    public interface IDeclaracionesEmpresaRepository
    {
        List<DeclaracionesEmpresaDto> ListarEmpresas(DeclaracionesEmpresaDto pObj);
        DeclaracionesEmpresaDto BuscarEmpresaXCodigo(DeclaracionesEmpresaDto pObj);
        void AgregarEmpresa(DeclaracionesEmpresaDto pObj);
        void ModificarEmpresa(DeclaracionesEmpresaDto pObj);
        void EliminarEmpresa(DeclaracionesEmpresaDto pObj);
    }
}
