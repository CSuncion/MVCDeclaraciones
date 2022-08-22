using DeclaracionesModel.ModelDto;
using DeclaracionesRepository.IRepository;
using DeclaracionesRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesController.Controller
{
    public  class DeclaracionesEmpresaController
    {
        private readonly IDeclaracionesEmpresaRepository _iDeclaracionesEmpresaRepository;
        public DeclaracionesEmpresaController()
        {
            this._iDeclaracionesEmpresaRepository = new DeclaracionesEmpresaRepository();
        }
        public static DeclaracionesEmpresaDto EnBlanco()
        {
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();
            return iEmpEN;
        }
        public static List<DeclaracionesEmpresaDto> ListarEmpresas(DeclaracionesEmpresaDto pObj)
        {
            IDeclaracionesEmpresaRepository iDeclaracionesEmpresaRepository = new DeclaracionesEmpresaRepository();
            return iDeclaracionesEmpresaRepository.ListarEmpresas(pObj);
        }
        public static List<DeclaracionesEmpresaDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<DeclaracionesEmpresaDto> pListaEmpresas)
        {
            //lista resultado
            List<DeclaracionesEmpresaDto> iLisRes = new List<DeclaracionesEmpresaDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaEmpresas; }

            //filtar la lista
            iLisRes = DeclaracionesEmpresaController.FiltrarEmpresasXTextoEnCualquierPosicion(pListaEmpresas, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<DeclaracionesEmpresaDto> FiltrarEmpresasXTextoEnCualquierPosicion(List<DeclaracionesEmpresaDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<DeclaracionesEmpresaDto> iLisRes = new List<DeclaracionesEmpresaDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (DeclaracionesEmpresaDto xEmp in pLista)
            {
                string iTexto = DeclaracionesEmpresaController.ObtenerValorDeCampo(xEmp, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xEmp);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(DeclaracionesEmpresaDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case DeclaracionesEmpresaDto.ClaObj: return pObj.ClaveObjeto;
                case DeclaracionesEmpresaDto.CodEmp: return pObj.CodigoEmpresa;
                case DeclaracionesEmpresaDto.NomEmp: return pObj.NombreEmpresa;
                case DeclaracionesEmpresaDto.DirEmp: return pObj.DireccionEmpresa;
                case DeclaracionesEmpresaDto.RucEmp: return pObj.RucEmpresa;
                case DeclaracionesEmpresaDto.TelFijEmp: return pObj.TelFijoEmpresa;
                case DeclaracionesEmpresaDto.TelCelEmp: return pObj.TelCelularEmpresa;
                case DeclaracionesEmpresaDto.CorEmp: return pObj.CorreoEmpresa;
                case DeclaracionesEmpresaDto.NEstEmp: return pObj.NEstadoEmpresa;
                case DeclaracionesEmpresaDto.UsuAgr: return pObj.UsuarioAgrega;
                case DeclaracionesEmpresaDto.FecAgr: return pObj.FechaAgrega.ToString();
                case DeclaracionesEmpresaDto.UsuMod: return pObj.UsuarioModifica;
                case DeclaracionesEmpresaDto.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }
        public static DeclaracionesEmpresaDto EsCodigoEmpresaDisponible(DeclaracionesEmpresaDto pObj)
        {
            //objeto resultado
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();

            //validar solo cuando hay codigo editado
            if (pObj.CodigoEmpresa != string.Empty)
            {
                //buscar en b.d si hay una empresa con este codigo
                iEmpEN = DeclaracionesEmpresaController.BuscarEmpresaXCodigo(pObj);

                //validar si ya esta registrado este codigo
                if (iEmpEN.CodigoEmpresa != string.Empty)
                {
                    iEmpEN.Adicionales.EsVerdad = false;
                    iEmpEN.Adicionales.Mensaje = "El codigo " + iEmpEN.CodigoEmpresa + " ya le pertenece a otra Empresa";
                    return iEmpEN;
                }
            }

            //ok
            iEmpEN.Adicionales.EsVerdad = true;
            return iEmpEN;
        }
        public static DeclaracionesEmpresaDto BuscarEmpresaXCodigo(DeclaracionesEmpresaDto pObj)
        {
            IDeclaracionesEmpresaRepository iDeclaracionesEmpresaRepository = new DeclaracionesEmpresaRepository();
            return iDeclaracionesEmpresaRepository.BuscarEmpresaXCodigo(pObj);
        }
        public static void AdicionarEmpresa(DeclaracionesEmpresaDto pObj)
        {
            IDeclaracionesEmpresaRepository iDeclaracionesEmpresaRepository = new DeclaracionesEmpresaRepository();
            iDeclaracionesEmpresaRepository.AgregarEmpresa(pObj);
        }
        public static DeclaracionesEmpresaDto EsActoModificarEmpresa(DeclaracionesEmpresaDto pEmp)
        {
            //objeto resultado
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();

            //validar si existe
            iEmpEN = DeclaracionesEmpresaController.EsEmpresaExistente(pEmp);
            if (iEmpEN.Adicionales.EsVerdad == false) { return iEmpEN; }

            //validar que no se pueda desactivar la empresa de acceso
            if (pEmp.CEstadoEmpresa == "0")//desactivada
            {
                if (iEmpEN.CodigoEmpresa == Universal.gCodigoEmpresa)
                {
                    iEmpEN.Adicionales.EsVerdad = false;
                    iEmpEN.Adicionales.Mensaje = "No se puede desactivar la empresa de acceso";
                    return iEmpEN;
                }
            }

            //ok
            iEmpEN.Adicionales.EsVerdad = true;
            return iEmpEN;
        }
        public static DeclaracionesEmpresaDto EsEmpresaExistente(DeclaracionesEmpresaDto pObj)
        {
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();
            iEmpEN = DeclaracionesEmpresaController.BuscarEmpresaXCodigo(pObj);
            if (iEmpEN.CodigoEmpresa == string.Empty)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "La Empresa " + pObj.CodigoEmpresa + " : " + pObj.NombreEmpresa + " no existe";
            }
            else
            {
                iEmpEN.Adicionales.EsVerdad = true;
            }
            return iEmpEN;
        }
        public static void ModificarEmpresa(DeclaracionesEmpresaDto pObj)
        {
            IDeclaracionesEmpresaRepository iDeclaracionesEmpresaRepository = new DeclaracionesEmpresaRepository();
            iDeclaracionesEmpresaRepository.ModificarEmpresa(pObj);
        }
        public static DeclaracionesEmpresaDto EsActoEliminarEmpresa(DeclaracionesEmpresaDto pObj)
        {
            //objeto de retorno
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();

            //validar si la empresa existe
            iEmpEN = DeclaracionesEmpresaController.EsEmpresaExistente(pObj);
            if (iEmpEN.Adicionales.EsVerdad == false) { return iEmpEN; }

            //validar cuando se quiere eliminar a la empresa de acceso
            DeclaracionesEmpresaDto iEmpAccEN = DeclaracionesEmpresaController.ValidaCuandoEliminaEmpresaAcceso(iEmpEN);
            if (iEmpAccEN.Adicionales.EsVerdad == false) { return iEmpAccEN; }

            //valida si existe este empresa en centro de costo
            //DeclaracionesEmpresaDto iEmpCenCosExiEN = DeclaracionesEmpresaController.ValidaCuandoCodigoEmpresaEstaEnCentroCosto(iEmpEN);
            //if (iEmpCenCosExiEN.Adicionales.EsVerdad == false) { return iEmpCenCosExiEN; }

            //valida si existe esta empresa en almacen
            //DeclaracionesEmpresaDto iEmpAlmExiEN = DeclaracionesEmpresaController.ValidaCuandoCodigoEmpresaEstaEnAlmacen(iEmpEN);
            //if (iEmpAlmExiEN.Adicionales.EsVerdad == false) { return iEmpAlmExiEN; }

            //valida si existe esta empresa en auxiliar
            //DeclaracionesEmpresaDto iEmpAuxExiEN = DeclaracionesEmpresaController.ValidaCuandoCodigoEmpresaEstaEnAuxiliar(iEmpEN);
            //if (iEmpAuxExiEN.Adicionales.EsVerdad == false) { return iEmpAuxExiEN; }

            //valida si existe esta empresa en personal
            //DeclaracionesEmpresaDto iEmpPerExiEN = DeclaracionesEmpresaController.ValidaCuandoCodigoEmpresaEstaEnPersonal(iEmpEN);
            //if (iEmpPerExiEN.Adicionales.EsVerdad == false) { return iEmpPerExiEN; }

            //valida si existe esta empresa en periodo
            DeclaracionesEmpresaDto iEmpPeriExiEN = DeclaracionesEmpresaController.ValidaCuandoCodigoEmpresaEstaEnPeriodo(iEmpEN);
            if (iEmpPeriExiEN.Adicionales.EsVerdad == false) { return iEmpPeriExiEN; }

            //ok            
            return iEmpEN;
        }
        public static DeclaracionesEmpresaDto ValidaCuandoCodigoEmpresaEstaEnPeriodo(DeclaracionesEmpresaDto pObj)
        {
            //objeto resultado
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();

            //valida
            bool iExisten = DeclaracionesPeriodoController.ExisteValorEnColumnaSinEmpresa(DeclaracionesPeriodoDto.CodEmp, pObj.CodigoEmpresa);
            if (iExisten == true)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "Hay periodos generados en esta empresa, no se puede realizar la operacion";
                return iEmpEN;
            }

            //ok
            return iEmpEN;
        }
        public static DeclaracionesEmpresaDto ValidaCuandoEliminaEmpresaAcceso(DeclaracionesEmpresaDto pObj)
        {
            //objeto resultado
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();

            //valida
            if (pObj.CodigoEmpresa == Universal.gCodigoEmpresa)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "No se puede eliminar la empresa de acceso";
                return iEmpEN;
            }

            //ok
            return iEmpEN;
        }
        public static DeclaracionesEmpresaDto ValidaCuandoCodigoEmpresaEstaEnCentroCosto(DeclaracionesEmpresaDto pObj)
        {
            //objeto resultado
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();

            ////valida
            //bool iExisten = ItemERN.ExisteValorEnColumnaSinEmpresa(ItemEEN.CodEmp, pObj.CodigoEmpresa);
            //if (iExisten == true)
            //{
            //    iEmpEN.Adicionales.EsVerdad = false;
            //    iEmpEN.Adicionales.Mensaje = "Hay centros de costos generados en esta empresa, no se puede realizar la operacion";
            //    return iEmpEN;
            //}

            ////ok
            return iEmpEN;
        }
        public static void EliminarEmpresa(DeclaracionesEmpresaDto pObj)
        {
            IDeclaracionesEmpresaRepository iDeclaracionesEmpresaRepository = new DeclaracionesEmpresaRepository();
            iDeclaracionesEmpresaRepository.EliminarEmpresa(pObj);
        }
    }
}
