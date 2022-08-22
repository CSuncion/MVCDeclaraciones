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
    public class DeclaracionesAuxiliarController
    {
        private readonly IDeclaracionesAuxiliarRepository _iDeclaracionesAuxiliarRepository;
        public DeclaracionesAuxiliarController()
        {
            this._iDeclaracionesAuxiliarRepository = new DeclaracionesAuxiliarRepository();
        }
        public static DeclaracionesAuxiliarDto EnBlanco()
        {
            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();
            return iAuxEN;
        }
        public static List<DeclaracionesAuxiliarDto> ListarAuxiliares(DeclaracionesAuxiliarDto pObj)
        {
            IDeclaracionesAuxiliarRepository iDeclaracionesAuxiliarRepository = new DeclaracionesAuxiliarRepository();
            return iDeclaracionesAuxiliarRepository.ListarAuxiliares(pObj);
        }
        public static List<DeclaracionesAuxiliarDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<DeclaracionesAuxiliarDto> pListaAuxiliares)
        {
            //lista resultado
            List<DeclaracionesAuxiliarDto> iLisRes = new List<DeclaracionesAuxiliarDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaAuxiliares; }

            //filtar la lista
            iLisRes = DeclaracionesAuxiliarController.FiltrarAuxiliaresXTextoEnCualquierPosicion(pListaAuxiliares, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<DeclaracionesAuxiliarDto> FiltrarAuxiliaresXTextoEnCualquierPosicion(List<DeclaracionesAuxiliarDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<DeclaracionesAuxiliarDto> iLisRes = new List<DeclaracionesAuxiliarDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (DeclaracionesAuxiliarDto xPer in pLista)
            {
                string iTexto = DeclaracionesAuxiliarController.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }
        public static string ObtenerValorDeCampo(DeclaracionesAuxiliarDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case DeclaracionesAuxiliarDto.ClaObj: return pObj.ClaveObjeto;
                case DeclaracionesAuxiliarDto.ClaAux: return pObj.ClaveAuxiliar;
                case DeclaracionesAuxiliarDto.CodEmp: return pObj.CodigoEmpresa;
                case DeclaracionesAuxiliarDto.NomEmp: return pObj.NombreEmpresa;
                case DeclaracionesAuxiliarDto.CodAux: return pObj.CodigoAuxiliar;
                case DeclaracionesAuxiliarDto.ApePatAux: return pObj.ApellidoPaternoAuxiliar;
                case DeclaracionesAuxiliarDto.ApeMatAux: return pObj.ApellidoMaternoAuxiliar;
                case DeclaracionesAuxiliarDto.PriNomAux: return pObj.PrimerNombreAuxiliar;
                case DeclaracionesAuxiliarDto.SegNomAux: return pObj.SegundoNombreAuxiliar;
                case DeclaracionesAuxiliarDto.DesAux: return pObj.DescripcionAuxiliar;
                case DeclaracionesAuxiliarDto.DirAux: return pObj.DireccionAuxiliar;
                case DeclaracionesAuxiliarDto.TelAux: return pObj.TelefonoAuxiliar;
                case DeclaracionesAuxiliarDto.CelAux: return pObj.CelularAuxiliar;
                case DeclaracionesAuxiliarDto.CorAux: return pObj.CorreoAuxiliar;
                case DeclaracionesAuxiliarDto.RefAux: return pObj.ReferenciaAuxiliar;
                case DeclaracionesAuxiliarDto.CTipAux: return pObj.CTipoAuxiliar;
                case DeclaracionesAuxiliarDto.NTipAux: return pObj.NTipoAuxiliar;
                case DeclaracionesAuxiliarDto.TipDocAux: return pObj.TipoDocumentoAuxiliar;
                case DeclaracionesAuxiliarDto.PaiNoDomAux: return pObj.PaisNoDomiciliadoAuxiliar;
                case DeclaracionesAuxiliarDto.FecInsSnpAux: return pObj.FechaInscripcionSnpAuxiliar;
                case DeclaracionesAuxiliarDto.CEstAux: return pObj.CEstadoAuxiliar;
                case DeclaracionesAuxiliarDto.NEstAux: return pObj.NEstadoAuxiliar;
                case DeclaracionesAuxiliarDto.UsuAgr: return pObj.UsuarioAgrega;
                case DeclaracionesAuxiliarDto.FecAgr: return pObj.FechaAgrega.ToString();
                case DeclaracionesAuxiliarDto.UsuMod: return pObj.UsuarioModifica;
                case DeclaracionesAuxiliarDto.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }
        public static DeclaracionesAuxiliarDto EsActoModificarAuxiliar(DeclaracionesAuxiliarDto pObj)
        {
            //objeto resultado
            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();

            //validar si existe
            iAuxEN = DeclaracionesAuxiliarController.EsAuxiliarExistente(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //ok            
            return iAuxEN;
        }
        public static DeclaracionesAuxiliarDto EsAuxiliarExistente(DeclaracionesAuxiliarDto pObj)
        {
            //objeto resultado
            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();

            //validar
            pObj.ClaveAuxiliar = DeclaracionesAuxiliarController.ObtenerClaveAuxiliar(pObj);
            iAuxEN = DeclaracionesAuxiliarController.BuscarAuxiliarXClave(pObj);
            if (iAuxEN.CodigoAuxiliar == string.Empty)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El Auxiliar " + pObj.CodigoAuxiliar + " no existe";
                return iAuxEN;
            }

            //ok         
            return iAuxEN;
        }
        public static string ObtenerClaveAuxiliar(DeclaracionesAuxiliarDto pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoAuxiliar;

            //retornar
            return iClave;
        }
        public static DeclaracionesAuxiliarDto BuscarAuxiliarXClave(DeclaracionesAuxiliarDto pObj)
        {
            IDeclaracionesAuxiliarRepository iDeclaracionesAuxiliarRepository = new DeclaracionesAuxiliarRepository();
            return iDeclaracionesAuxiliarRepository.BuscarAuxiliarXClave(pObj);
        }

        public static DeclaracionesAuxiliarDto EsCodigoAuxiliarDisponible(DeclaracionesAuxiliarDto pObj)
        {
            //objeto resultado
            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAuxiliar == string.Empty) { return iAuxEN; }

            //valida cuando existe el codigo
            iAuxEN = DeclaracionesAuxiliarController.ValidaCuandoCodigoYaExiste(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //ok          
            return iAuxEN;
        }
        public static DeclaracionesAuxiliarDto ValidaCuandoCodigoYaExiste(DeclaracionesAuxiliarDto pObj)
        {
            //objeto resultado
            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();

            //validar     
            pObj.ClaveAuxiliar = DeclaracionesAuxiliarController.ObtenerClaveAuxiliar(pObj);
            iAuxEN = DeclaracionesAuxiliarController.BuscarAuxiliarXClave(pObj);
            if (iAuxEN.CodigoAuxiliar != string.Empty)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoAuxiliar + " ya existe";
                return iAuxEN;
            }

            //ok
            iAuxEN.Adicionales.EsVerdad = true;
            return iAuxEN;
        }
        public static void AdicionarAuxiliar(DeclaracionesAuxiliarDto pObj)
        {
            IDeclaracionesAuxiliarRepository iDeclaracionesAuxiliarRepository = new DeclaracionesAuxiliarRepository();
            iDeclaracionesAuxiliarRepository.AgregarAuxiliar(pObj);
        }
        public static void ModificarAuxiliar(DeclaracionesAuxiliarDto pObj)
        {
            IDeclaracionesAuxiliarRepository iDeclaracionesAuxiliarRepository = new DeclaracionesAuxiliarRepository();
            iDeclaracionesAuxiliarRepository.ModificarAuxiliar(pObj);
        }
        public static DeclaracionesAuxiliarDto EsActoEliminarAuxiliar(DeclaracionesAuxiliarDto pObj)
        {
            //objeto resultado
            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();

            //validar si existe
            iAuxEN = DeclaracionesAuxiliarController.EsAuxiliarExistente(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //valida si existe este Personal en MovimientoCabe
            //DeclaracionesAuxiliarDto iAuxExiEN = DeclaracionesAuxiliarController.ValidaCuandoCodigoAuxiliarEstaEnMovimientoCabe(iAuxEN);
            //if (iAuxExiEN.Adicionales.EsVerdad == false) { return iAuxExiEN; }

            //ok            
            return iAuxEN;
        }

        public static void EliminarAuxiliar(DeclaracionesAuxiliarDto pObj)
        {
            IDeclaracionesAuxiliarRepository iDeclaracionesAuxiliarRepository = new DeclaracionesAuxiliarRepository();
            iDeclaracionesAuxiliarRepository.EliminarAuxiliar(pObj);
        }

        public static List<DeclaracionesAuxiliarDto> ListarProveedoresActivos(DeclaracionesAuxiliarDto pObj)
        {
            IDeclaracionesAuxiliarRepository iDeclaracionesAuxiliarRepository = new DeclaracionesAuxiliarRepository();
            return iDeclaracionesAuxiliarRepository.ListarProveedoresActivos(pObj);
        }
        public static DeclaracionesAuxiliarDto EsProveedorActivoValido(DeclaracionesAuxiliarDto pObj)
        {
            //objeto resultado
            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAuxiliar == string.Empty) { return iAuxEN; }

            //valida cuando el codigo no existe
            iAuxEN = DeclaracionesAuxiliarController.EsAuxiliarExistente(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //valida cuando no es proveedor o cliente/proveedor
            DeclaracionesAuxiliarDto iAuxProEN = DeclaracionesAuxiliarController.ValidaCuandoNoEsProveedor(iAuxEN);
            if (iAuxProEN.Adicionales.EsVerdad == false) { return iAuxProEN; }

            //valida cuando esta desactivado
            DeclaracionesAuxiliarDto iAuxDesEN = DeclaracionesAuxiliarController.ValidaCuandoProveedorEstaDesactivado(iAuxEN);
            if (iAuxDesEN.Adicionales.EsVerdad == false) { return iAuxDesEN; }

            //ok
            return iAuxEN;
        }
        public static DeclaracionesAuxiliarDto ValidaCuandoNoEsProveedor(DeclaracionesAuxiliarDto pObj)
        {
            //objeto resultado
            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();

            //validar                 
            if (Cadena.ExisteValorEnConjuntoDeValores(pObj.CTipoAuxiliar, "1,2") == false)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoAuxiliar + " no es de un proveedor";
                return iAuxEN;
            }

            //ok
            iAuxEN.Adicionales.EsVerdad = true;
            return iAuxEN;
        }
        public static DeclaracionesAuxiliarDto ValidaCuandoProveedorEstaDesactivado(DeclaracionesAuxiliarDto pObj)
        {
            //objeto resultado
            DeclaracionesAuxiliarDto iAuxEN = new DeclaracionesAuxiliarDto();

            //validar                 
            if (pObj.CEstadoAuxiliar == "0")//desactivado
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El proveedor " + pObj.CodigoAuxiliar + " esta desactivado";
                return iAuxEN;
            }

            //ok
            iAuxEN.Adicionales.EsVerdad = true;
            return iAuxEN;
        }
    }
}
