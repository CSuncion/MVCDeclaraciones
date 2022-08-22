using Comun;
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
    public class DeclaracionesPeriodoController
    {
        private readonly IDeclaracionesPeriodoRepository _iDeclaracionesPeriodoRepository;
        public DeclaracionesPeriodoController()
        {
            this._iDeclaracionesPeriodoRepository = new DeclaracionesPeriodoRepository();
        }
        public List<DeclaracionesPeriodoDto> ListarPeriodos()
        {
            return this._iDeclaracionesPeriodoRepository.ListarPeriodos(); ;
        }

        public List<DeclaracionesPeriodoDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<DeclaracionesPeriodoDto> pListaPeriodos)
        {
            //lista resultado
            List<DeclaracionesPeriodoDto> iLisRes = new List<DeclaracionesPeriodoDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaPeriodos; }

            //filtar la lista
            iLisRes = DeclaracionesPeriodoController.FiltrarPeriodosXTextoEnCualquierPosicion(pListaPeriodos, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static List<DeclaracionesPeriodoDto> FiltrarPeriodosXTextoEnCualquierPosicion(List<DeclaracionesPeriodoDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<DeclaracionesPeriodoDto> iLisRes = new List<DeclaracionesPeriodoDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (DeclaracionesPeriodoDto xPer in pLista)
            {
                string iTexto = DeclaracionesPeriodoController.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(DeclaracionesPeriodoDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case DeclaracionesPeriodoDto.ClaObj: return pObj.ClaveObjeto;
                case DeclaracionesPeriodoDto.ClaPer: return pObj.ClavePeriodo;
                case DeclaracionesPeriodoDto.CodPer: return pObj.CodigoPeriodo;
                case DeclaracionesPeriodoDto.CodEmp: return pObj.CodigoEmpresa;
                case DeclaracionesPeriodoDto.NomEmp: return pObj.NombreEmpresa;
                case DeclaracionesPeriodoDto.AnoPer: return pObj.AnoPeriodo;
                case DeclaracionesPeriodoDto.CMesPer: return pObj.CMesPeriodo;
                case DeclaracionesPeriodoDto.NMesPer: return pObj.NMesPeriodo;
                case DeclaracionesPeriodoDto.CEstPer: return pObj.CEstadoPeriodo;
                case DeclaracionesPeriodoDto.NEstPer: return pObj.NEstadoPeriodo;
                case DeclaracionesPeriodoDto.UsuAgr: return pObj.UsuarioAgrega;
                case DeclaracionesPeriodoDto.FecAgr: return pObj.FechaAgrega.ToString();
                case DeclaracionesPeriodoDto.UsuMod: return pObj.UsuarioModifica;
                case DeclaracionesPeriodoDto.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }
        public DeclaracionesPeriodoDto EnBlanco()
        {
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();
            return iPerEN;
        }
        public static string ObtenerClavePeriodo(DeclaracionesPeriodoDto pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.AnoPeriodo + "-";
            iClave += pPer.CMesPeriodo;

            //retornar
            return iClave;
        }
        public DeclaracionesPeriodoDto EsPeriodoDisponible(DeclaracionesPeriodoDto pObj)
        {
            //objeto resultado
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();

            //validar que los dos campos esten llenos
            if (pObj.AnoPeriodo != string.Empty && pObj.CMesPeriodo != string.Empty)
            {
                //buscar por clave periodo
                iPerEN = DeclaracionesPeriodoController.BuscarPeriodoXClave(pObj);
                if (iPerEN.ClavePeriodo != string.Empty)
                {
                    iPerEN.Adicionales.EsVerdad = false;
                    iPerEN.Adicionales.Mensaje = "El periodo " + pObj.AnoPeriodo + " - " + pObj.NMesPeriodo + " ya esta registrado";
                    return iPerEN;
                }
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }
        public static DeclaracionesPeriodoDto BuscarPeriodoXClave(DeclaracionesPeriodoDto pObj)
        {
            IDeclaracionesPeriodoRepository iPeriodo = new DeclaracionesPeriodoRepository();
            return iPeriodo.BuscarPeriodoXClave(pObj);
        }
        public void AdicionarPeriodo(DeclaracionesPeriodoDto pObj)
        {
            IDeclaracionesPeriodoRepository iPeriodo = new DeclaracionesPeriodoRepository();
            iPeriodo.AgregarPeriodo(pObj);
        }
        public static DeclaracionesPeriodoDto EsPeriodoExistente(DeclaracionesPeriodoDto pObj)
        {
            //objeto resultado
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();

            //validar si existe en b.d           
            pObj.AnoPeriodo = AñoMes.ObtenerAñoPeriodo(pObj.CodigoPeriodo);
            pObj.CMesPeriodo = AñoMes.ObtenerCMesPeriodo(pObj.CodigoPeriodo);
            pObj.ClavePeriodo = DeclaracionesPeriodoController.ObtenerClavePeriodo(pObj);
            iPerEN = DeclaracionesPeriodoController.BuscarPeriodoXClave(pObj);
            if (iPerEN.ClavePeriodo == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Periodo " + pObj.AnoPeriodo + " - " + Fecha.ObtenerMesEnNombre(pObj.CMesPeriodo) + " no existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }
        public static void ModificarPeriodo(DeclaracionesPeriodoDto pObj)
        {
            IDeclaracionesPeriodoRepository iPeriodo = new DeclaracionesPeriodoRepository();
            iPeriodo.ModificarPeriodo(pObj);
        }
        public static DeclaracionesPeriodoDto EsActoEliminarPeriodo(DeclaracionesPeriodoDto pPer)
        {
            //objeto resultado
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();

            //validar si existe
            iPerEN = DeclaracionesPeriodoController.EsPeriodoExistente(pPer);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si existe este periodo en movimientocabe
            //DeclaracionesPeriodoDto iPerMovCabExiEN = DeclaracionesPeriodoController.ValidaCuandoCodigoPeriodoEstaEnMovimientoCabe(iPerEN);
            //if (iPerMovCabExiEN.Adicionales.EsVerdad == false) { return iPerMovCabExiEN; }

            //ok            
            return iPerEN;
        }
        public static void EliminarPeriodo(DeclaracionesPeriodoDto pObj)
        {
            IDeclaracionesPeriodoRepository iPeriodo = new DeclaracionesPeriodoRepository();
            iPeriodo.EliminarPeriodo(pObj);
        }
        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            IDeclaracionesPeriodoRepository iPeriodo = new DeclaracionesPeriodoRepository();
            return iPeriodo.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }
        public static DeclaracionesPeriodoDto EsActoRegistrarEnEstePeriodo(DeclaracionesPeriodoDto pPer)
        {
            //objeto resultado
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();

            //valida cuando el periodo esta vacio
            iPerEN = DeclaracionesPeriodoController.ValidaCuandoPeriodoEstaVacio(pPer.CodigoPeriodo);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si existe
            iPerEN = DeclaracionesPeriodoController.EsPeriodoExistente(pPer);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si esta cerrado
            DeclaracionesPeriodoDto iPerCerEN = DeclaracionesPeriodoController.ValidaPeriodoCerrado(iPerEN);
            if (iPerCerEN.Adicionales.EsVerdad == false) { return iPerCerEN; }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static DeclaracionesPeriodoDto ValidaCuandoPeriodoEstaVacio(string pCodigoPeriodo)
        {
            //objeto resultado
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();

            //validar
            if (pCodigoPeriodo == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "Debes Elegir un periodo, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }
        public static DeclaracionesPeriodoDto ValidaPeriodoCerrado(DeclaracionesPeriodoDto pPer)
        {
            //objeto resultado
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();

            //valida
            if (pPer.CEstadoPeriodo == "0")//cerrado
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El periodo " + pPer.AnoPeriodo + " : " + pPer.NMesPeriodo +
                                                " esta cerrado, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }
    }
}
