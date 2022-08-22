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
    public class DeclaracionesRegistroVentaController
    {
        public static DeclaracionesRegistroVentaDto EnBlanco()
        {
            DeclaracionesRegistroVentaDto iRegComDto = new DeclaracionesRegistroVentaDto();
            return iRegComDto;
        }
        public static DeclaracionesRegistroVentaDto EsActoAdicionarMovimientoCabe(DeclaracionesRegistroVentaDto pObj)
        {
            //objeto resultado
            DeclaracionesRegistroVentaDto iRegComDto = new DeclaracionesRegistroVentaDto();

            //valida cuando es no es acto registrar en este periodo
            iRegComDto = DeclaracionesRegistroVentaController.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iRegComDto.Adicionales.EsVerdad == false) { return iRegComDto; }

            //ok          
            return iRegComDto;
        }
        public static DeclaracionesRegistroVentaDto ValidaCuandoNoEsActoRegistrarEnPeriodo(DeclaracionesRegistroVentaDto pObj)
        {
            //objeto resultado
            DeclaracionesRegistroVentaDto iRegComDto = new DeclaracionesRegistroVentaDto();

            //validar
            DeclaracionesPeriodoDto iPerEN = new DeclaracionesPeriodoDto();
            iPerEN.CodigoPeriodo = pObj.PeriodoRegistroVenta;
            iPerEN = DeclaracionesPeriodoController.EsActoRegistrarEnEstePeriodo(iPerEN);

            //pasamos datos de la validacion
            iRegComDto.Adicionales.EsVerdad = iPerEN.Adicionales.EsVerdad;
            iRegComDto.Adicionales.Mensaje = iPerEN.Adicionales.Mensaje;

            //devolver
            return iRegComDto;
        }
        public static DeclaracionesRegistroVentaDto ValidaCuandoFechaNoEsDelPeriodoElegido(DeclaracionesRegistroVentaDto pObj)
        {
            //objeto resultado
            DeclaracionesRegistroVentaDto iMovCabEN = new DeclaracionesRegistroVentaDto();

            //validar
            bool iEsVerdad = Periodo.EsFechaDePeriodo(pObj.FechaEmisionComprobantePagoVenta, pObj.PeriodoRegistroVenta);
            if (iEsVerdad == false)
            {
                iMovCabEN.Adicionales.EsVerdad = false;
                iMovCabEN.Adicionales.Mensaje = "La fecha " + pObj.FechaEmisionComprobantePagoVenta + " debe ser del periodo " +
                                                Periodo.FormatoAñoYNombreMes(pObj.PeriodoRegistroVenta);
                return iMovCabEN;
            }

            //ok
            return iMovCabEN;
        }
        public static string ObtenerClaveMovimientoCabe(DeclaracionesRegistroVentaDto pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.PeriodoRegistroVenta + "-";
            iClave += pPer.NumCorrelativoVenta;

            //retornar
            return iClave;
        }
        public static string ObtenerNuevoNumeroMovimientoCabeAutogenerado(DeclaracionesRegistroVentaDto pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = DeclaracionesRegistroVentaController.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 3);

            //devuelve
            return iNumero;
        }
        public static string ObtenerMaximoValorEnColumna(DeclaracionesRegistroVentaDto pObj)
        {
            IDeclaracionesRegistroVentaRepository iDeclaracionesRegistroVentaRepository = new DeclaracionesRegistroVentaRepository();
            return iDeclaracionesRegistroVentaRepository.ObtenerMaximoValorEnColumna(pObj);
        }

        public static void AdicionarRegistroVenta(DeclaracionesRegistroVentaDto pObj)
        {
            IDeclaracionesRegistroVentaRepository iDeclaracionesRegistroVentaRepository = new DeclaracionesRegistroVentaRepository();
            iDeclaracionesRegistroVentaRepository.AgregarRegistroVenta(pObj);
        }

        public static List<DeclaracionesRegistroVentaDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<DeclaracionesRegistroVentaDto> pListaRegistroVenta)
        {
            //lista resultado
            List<DeclaracionesRegistroVentaDto> iLisRes = new List<DeclaracionesRegistroVentaDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaRegistroVenta; }

            //filtar la lista
            iLisRes = DeclaracionesRegistroVentaController.FiltrarMovimientoCabesXTextoEnCualquierPosicion(pListaRegistroVenta, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<DeclaracionesRegistroVentaDto> FiltrarMovimientoCabesXTextoEnCualquierPosicion(List<DeclaracionesRegistroVentaDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<DeclaracionesRegistroVentaDto> iLisRes = new List<DeclaracionesRegistroVentaDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (DeclaracionesRegistroVentaDto xPer in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<DeclaracionesRegistroVentaDto>(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }
        public static List<DeclaracionesRegistroVentaDto> ListarRegistroVentaXPeriodo(DeclaracionesRegistroVentaDto pObj)
        {
            IDeclaracionesRegistroVentaRepository iDeclaracionesRegistroVentaRepository = new DeclaracionesRegistroVentaRepository();
            return iDeclaracionesRegistroVentaRepository.ListarRegistroVentaXPeriodo(pObj);
        }
        public static DeclaracionesRegistroVentaDto EsActoModificarRegistroVenta(DeclaracionesRegistroVentaDto pObj)
        {
            //objeto resultado
            DeclaracionesRegistroVentaDto iRegComDto = new DeclaracionesRegistroVentaDto();

            //valida cuando es no es acto registrar en este periodo
            iRegComDto = DeclaracionesRegistroVentaController.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iRegComDto.Adicionales.EsVerdad == false) { return iRegComDto; }

            //valida si existe
            iRegComDto = DeclaracionesRegistroVentaController.EsRegistroVentaExistente(pObj);
            if (iRegComDto.Adicionales.EsVerdad == false) { return iRegComDto; }

            //ok          
            return iRegComDto;
        }
        public static DeclaracionesRegistroVentaDto EsRegistroVentaExistente(DeclaracionesRegistroVentaDto pObj)
        {
            //objeto resultado
            DeclaracionesRegistroVentaDto iExiEN = new DeclaracionesRegistroVentaDto();

            //validar si existe en b.d
            iExiEN = DeclaracionesRegistroVentaController.BuscarRegistroVentaXClave(pObj);
            if (iExiEN.ClaveRegistroVenta == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El registro no existe";
                return iExiEN;
            }

            //ok        
            return iExiEN;
        }
        public static DeclaracionesRegistroVentaDto BuscarRegistroVentaXClave(DeclaracionesRegistroVentaDto pObj)
        {
            IDeclaracionesRegistroVentaRepository iDeclaracionesRegistroVentaRepository = new DeclaracionesRegistroVentaRepository();
            return iDeclaracionesRegistroVentaRepository.BuscarRegistroVentaXClave(pObj);
        }
        public static void ModificarRegistroVenta(DeclaracionesRegistroVentaDto pObj)
        {
            IDeclaracionesRegistroVentaRepository iDeclaracionesRegistroVentaRepository = new DeclaracionesRegistroVentaRepository();
            iDeclaracionesRegistroVentaRepository.ModificarRegistroVenta(pObj);
        }
        public static DeclaracionesRegistroVentaDto EsActoEliminarMovimientoCabe(DeclaracionesRegistroVentaDto pObj)
        {
            //objeto resultado
            DeclaracionesRegistroVentaDto iMovCabEN = new DeclaracionesRegistroVentaDto();

            //valida cuando es no es acto eliminar en este periodo
            iMovCabEN = DeclaracionesRegistroVentaController.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida si existe
            iMovCabEN = DeclaracionesRegistroVentaController.EsRegistroVentaExistente(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //ok          
            return iMovCabEN;
        }
        public static void EliminarRegistroVenta(DeclaracionesRegistroVentaDto pObj)
        {
            IDeclaracionesRegistroVentaRepository iDeclaracionesRegistroVentaRepository = new DeclaracionesRegistroVentaRepository();
            iDeclaracionesRegistroVentaRepository.EliminarRegistroVenta(pObj);
        }
    }
}
