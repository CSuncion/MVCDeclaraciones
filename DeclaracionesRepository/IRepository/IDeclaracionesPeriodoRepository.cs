using DeclaracionesModel.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesRepository.IRepository
{
    public interface IDeclaracionesPeriodoRepository
    {
        List<DeclaracionesPeriodoDto> ListarPeriodos();
        DeclaracionesPeriodoDto BuscarPeriodoXClave(DeclaracionesPeriodoDto pObj);
        void AgregarPeriodo(DeclaracionesPeriodoDto pObj);
        void ModificarPeriodo(DeclaracionesPeriodoDto pObj);
        void EliminarPeriodo(DeclaracionesPeriodoDto pObj);
        bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda);
    }
}
