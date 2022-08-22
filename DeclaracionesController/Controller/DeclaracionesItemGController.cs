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
    public class DeclaracionesItemGController
    {
        private readonly IDeclaracionesItemGRepository _iCreditItemRepository;
        public DeclaracionesItemGController()
        {
            this._iCreditItemRepository = new DeclaracionesItemGRepository();
        }
        public static List<DeclaracionesItemGDto> ListarItemsG(string pTabla)
        {
            DeclaracionesItemGDto iTipUsuEN = new DeclaracionesItemGDto();
            iTipUsuEN.CodigoTabla = pTabla;
            iTipUsuEN.Adicionales.CampoOrden = DeclaracionesItemGDto.CodIteG;
            return DeclaracionesItemGController.ListarItemsGActivosXTabla(iTipUsuEN);
        }
        public static List<DeclaracionesItemGDto> ListarItemsGActivosXTabla(DeclaracionesItemGDto pObj)
        {
            IDeclaracionesItemGRepository iTipUsuEN = new DeclaracionesItemGRepository(); ;
            return iTipUsuEN.ListarItemsGActivosXTabla(pObj); ;
        }
        public static DeclaracionesItemGDto EsItemGValido(DeclaracionesItemGDto pObj)
        {
            DeclaracionesItemGDto iIteEN = new DeclaracionesItemGDto();

            //validar cuando hay codigo
            if (pObj.CodigoItemG != string.Empty)
            {
                //validar si existe
                iIteEN.ClaveItemG = DeclaracionesItemGController.ObtenerClaveItemG(pObj);
                iIteEN = DeclaracionesItemGController.buscarItemGXClave(iIteEN);
                if (iIteEN.CodigoItemG == string.Empty)
                {
                    iIteEN.Adicionales.EsVerdad = false;
                    iIteEN.Adicionales.Mensaje = "El Item" + Cadena.Espacios(1) + pObj.CodigoItemG + Cadena.Espacios(1) + "no existe";
                    return iIteEN;
                }

                //validar si esta dasctivado
                if (iIteEN.CEstadoItemG == "0") //desactivado
                {
                    iIteEN = DeclaracionesItemGController.EnBlanco();
                    iIteEN.Adicionales.EsVerdad = false;
                    iIteEN.Adicionales.Mensaje = "El Item" + Cadena.Espacios(1) + pObj.CodigoItemG + Cadena.Espacios(1) + "esta desactivado";
                    return iIteEN;
                }
            }

            //ok
            iIteEN.Adicionales.EsVerdad = true;
            return iIteEN;
        }
        public static string ObtenerClaveItemG(DeclaracionesItemGDto pObj)
        {
            //variavle resulatdo
            string iClave = string.Empty;
            iClave += pObj.CodigoTabla + "-";
            iClave += pObj.CodigoItemG;
            return iClave;
        }
        public static DeclaracionesItemGDto EnBlanco()
        {
            DeclaracionesItemGDto iIteEN = new DeclaracionesItemGDto();
            return iIteEN;
        }

        public static DeclaracionesItemGDto buscarItemGXClave(DeclaracionesItemGDto pObj)
        {
            IDeclaracionesItemGRepository iItemG = new DeclaracionesItemGRepository(); ;
            return iItemG.BuscarItemGXClave(pObj);
        }
        public static List<DeclaracionesItemGDto> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<DeclaracionesItemGDto> pListaItemG)
        {
            //lista resultado
            List<DeclaracionesItemGDto> iLisRes = new List<DeclaracionesItemGDto>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaItemG; }

            //filtar la lista
            iLisRes = DeclaracionesItemGController.FiltrarItemGsXTextoEnCualquierPosicion(pListaItemG, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }
        public static List<DeclaracionesItemGDto> FiltrarItemGsXTextoEnCualquierPosicion(List<DeclaracionesItemGDto> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<DeclaracionesItemGDto> iLisRes = new List<DeclaracionesItemGDto>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (DeclaracionesItemGDto xCli in pLista)
            {
                string iTexto = DeclaracionesItemGController.ObtenerValorDeCampo(xCli, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xCli);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerValorDeCampo(DeclaracionesItemGDto pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case DeclaracionesItemGDto.CodIteG: return pObj.CodigoItemG;
                case DeclaracionesItemGDto.NomIteG: return pObj.NombreItemG;
            }
            //retorna
            return iValor;
        }
    }
}
