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
    public class DeclaracionesTipoCambioController
    {
        private readonly IDeclaracionesTipoCambioRepository _iDeclaracionesTipoCambioRepository;

        public DeclaracionesTipoCambioController()
        {
            this._iDeclaracionesTipoCambioRepository = new DeclaracionesTipoCambioRepository();
        }
        public static DeclaracionesTipoCambioDto EnBlanco()
        {
            DeclaracionesTipoCambioDto iPerEN = new DeclaracionesTipoCambioDto();
            return iPerEN;
        }
        public static List<DeclaracionesTipoCambioDto> ListarTipoCambio(DeclaracionesTipoCambioDto pObj)
        {
            IDeclaracionesTipoCambioRepository iTipoCambio = new DeclaracionesTipoCambioRepository();
            return iTipoCambio.ListarTipoCambio(pObj);
        }
        public static List<DeclaracionesTipoCambioDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<DeclaracionesTipoCambioDto> pListaTipoOperaciones)
        {
            //lista resultado
            List<DeclaracionesTipoCambioDto> iLisRes = new List<DeclaracionesTipoCambioDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaTipoOperaciones; }

            //filtar la lista
            iLisRes = DeclaracionesTipoCambioController.FiltrarTipoOperacionesXTextoEnCualquierPosicion(pListaTipoOperaciones, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<DeclaracionesTipoCambioDto> FiltrarTipoOperacionesXTextoEnCualquierPosicion(List<DeclaracionesTipoCambioDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<DeclaracionesTipoCambioDto> iLisRes = new List<DeclaracionesTipoCambioDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (DeclaracionesTipoCambioDto xPer in pLista)
            {
                string iTexto = DeclaracionesTipoCambioController.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(DeclaracionesTipoCambioDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case DeclaracionesTipoCambioDto.ClaObj: return pObj.ClaveObjeto;
                case DeclaracionesTipoCambioDto.FecTipCam: return pObj.FechaTipoCambio;
                case DeclaracionesTipoCambioDto.ComTipCam: return pObj.CompraTipoCambio.ToString();
                case DeclaracionesTipoCambioDto.VtaTipCam: return pObj.VentaTipoCambio.ToString();
                case DeclaracionesTipoCambioDto.CEstTipCam: return pObj.CEstadoTipoCambio;
                case DeclaracionesTipoCambioDto.NEstTipCam: return pObj.NEstadoTipoCambio;
                case DeclaracionesTipoCambioDto.UsuAgr: return pObj.UsuarioAgrega;
                case DeclaracionesTipoCambioDto.FecAgr: return pObj.FechaAgrega.ToString();
                case DeclaracionesTipoCambioDto.UsuMod: return pObj.UsuarioModifica;
                case DeclaracionesTipoCambioDto.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }
        public static DeclaracionesTipoCambioDto EsCodigoTipoCambioDisponible(DeclaracionesTipoCambioDto pObj)
        {
            //objeto resultado
            DeclaracionesTipoCambioDto iTipOpeEN = new DeclaracionesTipoCambioDto();

            //valida cuando el codigo esta vacio
            if (pObj.FechaTipoCambio == string.Empty) { return iTipOpeEN; }

            //valida cuando existe el codigo
            //iTipOpeEN = TipoCambionRN.vali //TipoCambioRN.ValidaCuandoCodigoYaExiste(pObj);
            //if (iTipOpeEN.Adicionales.EsVerdad == false) { return iTipOpeEN; }

            //ok          
            return iTipOpeEN;
        }
        public static void AdicionarTipoCambio(DeclaracionesTipoCambioDto pObj)
        {
            IDeclaracionesTipoCambioRepository iTipoCambio = new DeclaracionesTipoCambioRepository();
            iTipoCambio.AgregarTipoCambio(pObj);
        }
        public static DeclaracionesTipoCambioDto EsTipoCambioExistente(DeclaracionesTipoCambioDto pObj)
        {
            //objeto resultado
            DeclaracionesTipoCambioDto iTipOpeEN = new DeclaracionesTipoCambioDto();

            //validar
            iTipOpeEN = DeclaracionesTipoCambioController.BuscarTipoCambioXFecha(pObj);
            if (iTipOpeEN.FechaTipoCambio == string.Empty)
            {
                iTipOpeEN.Adicionales.EsVerdad = false;
                iTipOpeEN.Adicionales.Mensaje = "El Tipo Cambio " + pObj.FechaTipoCambio + " no existe";
                return iTipOpeEN;
            }

            //ok         
            return iTipOpeEN;
        }
        public static DeclaracionesTipoCambioDto BuscarTipoCambioXFecha(DeclaracionesTipoCambioDto pObj)
        {
            IDeclaracionesTipoCambioRepository iTipoCambio = new DeclaracionesTipoCambioRepository();
            return iTipoCambio.BuscarTipoCambioXFecha(pObj);
        }
        public static DeclaracionesTipoCambioDto EsActoModificarTipoCambio(DeclaracionesTipoCambioDto pObj)
        {
            //objeto resultado
            DeclaracionesTipoCambioDto iTipOpeEN = new DeclaracionesTipoCambioDto();

            //validar si existe
            iTipOpeEN = DeclaracionesTipoCambioController.EsTipoCambioExistente(pObj);
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return iTipOpeEN; }

            //ok            
            return iTipOpeEN;
        }
        public static void ModificarTipoCambio(DeclaracionesTipoCambioDto pObj)
        {
            IDeclaracionesTipoCambioRepository iTipoCambio = new DeclaracionesTipoCambioRepository();
            iTipoCambio.ModificarTipoCambio(pObj);
        }
        public static DeclaracionesTipoCambioDto EsActoEliminarTipoCambio(DeclaracionesTipoCambioDto pObj)
        {
            //objeto resultado
            DeclaracionesTipoCambioDto iTipOpeEN = new DeclaracionesTipoCambioDto();

            //validar si existe
            iTipOpeEN = DeclaracionesTipoCambioController.EsTipoCambioExistente(pObj);
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return iTipOpeEN; }

            //valida si existe este tipooperacion en MovimientoCabe
            //DeclaracionesTipoCambioDto iTipOpeExiEN = DeclaracionesTipoCambioController.ValidaCuandoCodigoTipoOperacionEstaEnMovimientoCabe(iTipOpeEN);
            //if (iTipOpeExiEN.Adicionales.EsVerdad == false) { return iTipOpeExiEN; }

            //ok            
            return iTipOpeEN;
        }
        public static void EliminarTipoCambio(DeclaracionesTipoCambioDto pObj)
        {
            IDeclaracionesTipoCambioRepository iTipoCambio = new DeclaracionesTipoCambioRepository();
            iTipoCambio.EliminarTipoCambio(pObj);
        }
    }
}
