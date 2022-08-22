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
    public class DeclaracionesRegistroCompraController
    {
        public static DeclaracionesRegistroCompraDto EnBlanco()
        {
            DeclaracionesRegistroCompraDto iRegComDto = new DeclaracionesRegistroCompraDto();
            return iRegComDto;
        }
        public static DeclaracionesRegistroCompraDto EsActoAdicionarMovimientoCabe(DeclaracionesRegistroCompraDto pObj)
        {
            //objeto resultado
            DeclaracionesRegistroCompraDto iRegComDto = new DeclaracionesRegistroCompraDto();

            //valida cuando es no es acto registrar en este periodo
            iRegComDto = DeclaracionesRegistroCompraController.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iRegComDto.Adicionales.EsVerdad == false) { return iRegComDto; }

            //ok          
            return iRegComDto;
        }
        public static DeclaracionesRegistroCompraDto ValidaCuandoNoEsActoRegistrarEnPeriodo(DeclaracionesRegistroCompraDto pObj)
        {
            //objeto resultado
            DeclaracionesRegistroCompraDto iRegComDto = new DeclaracionesRegistroCompraDto();

            //validar
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();
            iPerEN.CodigoPeriodo = pObj.PeriodoRegistroCompra;
            iPerEN = DeclaracionesPeriodoController.EsActoRegistrarEnEstePeriodo(iPerEN);

            //pasamos datos de la validacion
            iRegComDto.Adicionales.EsVerdad = iPerEN.Adicionales.EsVerdad;
            iRegComDto.Adicionales.Mensaje = iPerEN.Adicionales.Mensaje;

            //devolver
            return iRegComDto;
        }
        public static DeclaracionesRegistroCompraDto ValidaCuandoFechaNoEsDelPeriodoElegido(DeclaracionesRegistroCompraDto pObj)
        {
            //objeto resultado
            DeclaracionesRegistroCompraDto iMovCabEN = new DeclaracionesRegistroCompraDto();

            //validar
            bool iEsVerdad = Periodo.EsFechaDePeriodo(pObj.FechaEmisionComprobantePagoCompra, pObj.PeriodoRegistroCompra);
            if (iEsVerdad == false)
            {
                iMovCabEN.Adicionales.EsVerdad = false;
                iMovCabEN.Adicionales.Mensaje = "La fecha " + pObj.FechaEmisionComprobantePagoCompra + " debe ser del periodo " +
                                                Periodo.FormatoAñoYNombreMes(pObj.PeriodoRegistroCompra);
                return iMovCabEN;
            }

            //ok
            return iMovCabEN;
        }
        public static string ObtenerClaveMovimientoCabe(DeclaracionesRegistroCompraDto pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.PeriodoRegistroCompra + "-";
            iClave += pPer.NumCorrelativoCompra;

            //retornar
            return iClave;
        }
        public static string ObtenerNuevoNumeroMovimientoCabeAutogenerado(DeclaracionesRegistroCompraDto pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = DeclaracionesRegistroCompraController.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 3);

            //devuelve
            return iNumero;
        }
        public static string ObtenerMaximoValorEnColumna(DeclaracionesRegistroCompraDto pObj)
        {
            IDeclaracionesRegistroCompraRepository iDeclaracionesRegistroCompraRepository = new DeclaracionesRegistroCompraRepository();
            return iDeclaracionesRegistroCompraRepository.ObtenerMaximoValorEnColumna(pObj);
        }

        public static void AdicionarRegistroCompra(DeclaracionesRegistroCompraDto pObj)
        {
            IDeclaracionesRegistroCompraRepository iDeclaracionesRegistroCompraRepository = new DeclaracionesRegistroCompraRepository();
            iDeclaracionesRegistroCompraRepository.AgregarRegistroCompra(pObj);
        }

        public static List<DeclaracionesRegistroCompraDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<DeclaracionesRegistroCompraDto> pListaRegistroCompra)
        {
            //lista resultado
            List<DeclaracionesRegistroCompraDto> iLisRes = new List<DeclaracionesRegistroCompraDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaRegistroCompra; }

            //filtar la lista
            iLisRes = DeclaracionesRegistroCompraController.FiltrarMovimientoCabesXTextoEnCualquierPosicion(pListaRegistroCompra, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<DeclaracionesRegistroCompraDto> FiltrarMovimientoCabesXTextoEnCualquierPosicion(List<DeclaracionesRegistroCompraDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<DeclaracionesRegistroCompraDto> iLisRes = new List<DeclaracionesRegistroCompraDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (DeclaracionesRegistroCompraDto xPer in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<DeclaracionesRegistroCompraDto>(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }
        public static List<DeclaracionesRegistroCompraDto> ListarRegistroCompraXPeriodo(DeclaracionesRegistroCompraDto pObj)
        {
            IDeclaracionesRegistroCompraRepository iDeclaracionesRegistroCompraRepository = new DeclaracionesRegistroCompraRepository();
            return iDeclaracionesRegistroCompraRepository.ListarRegistroCompraXPeriodo(pObj);
        }
        public static DeclaracionesRegistroCompraDto EsActoModificarRegistroCompra(DeclaracionesRegistroCompraDto pObj)
        {
            //objeto resultado
            DeclaracionesRegistroCompraDto iRegComDto = new DeclaracionesRegistroCompraDto();

            //valida cuando es no es acto registrar en este periodo
            iRegComDto = DeclaracionesRegistroCompraController.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iRegComDto.Adicionales.EsVerdad == false) { return iRegComDto; }

            //valida si existe
            iRegComDto = DeclaracionesRegistroCompraController.EsRegistroCompraExistente(pObj);
            if (iRegComDto.Adicionales.EsVerdad == false) { return iRegComDto; }

            //ok          
            return iRegComDto;
        }
        public static DeclaracionesRegistroCompraDto EsRegistroCompraExistente(DeclaracionesRegistroCompraDto pObj)
        {
            //objeto resultado
            DeclaracionesRegistroCompraDto iExiEN = new DeclaracionesRegistroCompraDto();

            //validar si existe en b.d
            iExiEN = DeclaracionesRegistroCompraController.BuscarRegistroCompraXClave(pObj);
            if (iExiEN.ClaveRegistroCompra == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El registro no existe";
                return iExiEN;
            }

            //ok        
            return iExiEN;
        }
        public static DeclaracionesRegistroCompraDto BuscarRegistroCompraXClave(DeclaracionesRegistroCompraDto pObj)
        {
            IDeclaracionesRegistroCompraRepository iDeclaracionesRegistroCompraRepository = new DeclaracionesRegistroCompraRepository();
            return iDeclaracionesRegistroCompraRepository.BuscarRegistroCompraXClave(pObj);
        }
        public static void ModificarRegistroCompra(DeclaracionesRegistroCompraDto pObj)
        {
            IDeclaracionesRegistroCompraRepository iDeclaracionesRegistroCompraRepository = new DeclaracionesRegistroCompraRepository();
            iDeclaracionesRegistroCompraRepository.ModificarRegistroCompra(pObj);
        }
        public static DeclaracionesRegistroCompraDto EsActoEliminarMovimientoCabe(DeclaracionesRegistroCompraDto pObj)
        {
            //objeto resultado
            DeclaracionesRegistroCompraDto iMovCabEN = new DeclaracionesRegistroCompraDto();

            //valida cuando es no es acto eliminar en este periodo
            iMovCabEN = DeclaracionesRegistroCompraController.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida si existe
            iMovCabEN = DeclaracionesRegistroCompraController.EsRegistroCompraExistente(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //ok          
            return iMovCabEN;
        }
        public static void EliminarRegistroCompra(DeclaracionesRegistroCompraDto pObj)
        {
            IDeclaracionesRegistroCompraRepository iDeclaracionesRegistroCompraRepository = new DeclaracionesRegistroCompraRepository();
            iDeclaracionesRegistroCompraRepository.EliminarRegistroCompra(pObj);
        }
    }
}
