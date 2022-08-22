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
    public class DeclaracionesPermisoEmpresaController
    {
        private readonly IDeclaracionesPermisoEmpresaRepository _iDeclaracionesPermisoEmpresaRepository;
        public DeclaracionesPermisoEmpresaController()
        {
            this._iDeclaracionesPermisoEmpresaRepository = new DeclaracionesPermisoEmpresaRepository();
        }
        public static string ObtenerClavePermisoEmpresa(DeclaracionesPermisoEmpresaDto pObj)
        {
            //variavle resulatdo
            string iClave = string.Empty;
            iClave += pObj.CodigoEmpresa + "-";
            iClave += pObj.CodigoUsuario;
            return iClave;
        }
        public static DeclaracionesPermisoEmpresaDto EsEmpresaDeUsuario(DeclaracionesPermisoEmpresaDto pObj)
        {
            DeclaracionesPermisoEmpresaDto iPemEN = new DeclaracionesPermisoEmpresaDto();

            //si no se digito la empresa entonces es true
            if (pObj.CodigoEmpresa == string.Empty)
            {
                iPemEN.Adicionales.EsVerdad = true;
                iPemEN.Adicionales.Mensaje = string.Empty;
                return iPemEN;
            }

            //verificar que se aya escrito el usuario
            if (pObj.CodigoUsuario == string.Empty)
            {
                iPemEN.Adicionales.EsVerdad = false;
                iPemEN.Adicionales.Mensaje = "Primero debes elegir al usuario";
                return iPemEN;
            }

            //si CodigoEmpresa no esta vacio y hay usuario
            iPemEN = DeclaracionesPermisoEmpresaController.BuscarPermisoEmpresaXClave(pObj);
            if (iPemEN.CodigoEmpresa == string.Empty)
            {
                iPemEN.Adicionales.EsVerdad = false;
                iPemEN.Adicionales.Mensaje = "La empresa" + Cadena.Espacios(1) + pObj.CodigoEmpresa + Cadena.Espacios(1) + "no existe";
                return iPemEN;
            }
            else
            {
                //verificar que la empresa este desactivada
                if (iPemEN.CEstadoEmpresa == "0") //desactivada
                {
                    iPemEN = DeclaracionesPermisoEmpresaController.EnBlanco();
                    iPemEN.Adicionales.EsVerdad = false;
                    iPemEN.Adicionales.Mensaje = "La empresa" + Cadena.Espacios(1) + pObj.CodigoEmpresa + Cadena.Espacios(1) + "esta desactivada";
                    return iPemEN;
                }
                if (iPemEN.CodigoPerfil != "01")
                {
                    if (iPemEN.CPermitir == "0") //no tiene permiso
                    {
                        iPemEN = DeclaracionesPermisoEmpresaController.EnBlanco();
                        iPemEN.Adicionales.EsVerdad = false;
                        iPemEN.Adicionales.Mensaje = "La empresa" + Cadena.Espacios(1) + pObj.CodigoEmpresa + Cadena.Espacios(1) + "no esta autorizada para este usuario";
                        return iPemEN;
                    }
                }
            }
            //si llega hasta aqui entonces si tiene permiso
            iPemEN.Adicionales.EsVerdad = true;
            return iPemEN;

        }

        public static DeclaracionesPermisoEmpresaDto BuscarPermisoEmpresaXClave(DeclaracionesPermisoEmpresaDto pObj)
        {
            IDeclaracionesPermisoEmpresaRepository iDeclaracionesPermisoEmpresa = new DeclaracionesPermisoEmpresaRepository();
            return iDeclaracionesPermisoEmpresa.BuscarPermisoEmpresaXClave(pObj);
        }
        public static DeclaracionesPermisoEmpresaDto EnBlanco()
        {
            DeclaracionesPermisoEmpresaDto iPemEN = new DeclaracionesPermisoEmpresaDto();
            return iPemEN;
        }
        public List<DeclaracionesPermisoEmpresaDto> ListarPermisosEmpresaActivasXUsuarioYAutorizadas(DeclaracionesPermisoEmpresaDto pObj)
        {
            IDeclaracionesPermisoEmpresaRepository iDeclaracionesPermisoEmpresa = new DeclaracionesPermisoEmpresaRepository();
            return iDeclaracionesPermisoEmpresa.ListarPermisosEmpresaActivasXUsuarioYAutorizadas(pObj);
        }
        public static void AdicionarPermisosEmpresaXEmpresa(DeclaracionesPermisoEmpresaDto pObj)
        {
            //Traer todos los usuarios del sistema          
            DeclaracionesAccessDto iUsuEN = new DeclaracionesAccessDto();
            iUsuEN.Additionals.CampoOrden = DeclaracionesAccessDto.CodUsu;
            List<DeclaracionesAccessDto> iLisUsu = DeclaracionesAccessController.ListarUsuarios();

            //lista de los nuevos permisos para este usuario
            List<DeclaracionesPermisoEmpresaDto> iLisPerEmp = new List<DeclaracionesPermisoEmpresaDto>();

            //recorrer cada usuario
            foreach (DeclaracionesAccessDto xObj in iLisUsu)
            {
                DeclaracionesPermisoEmpresaDto iPemEN = new DeclaracionesPermisoEmpresaDto();
                iPemEN.CodigoUsuario = xObj.CodigoUsuario;
                iPemEN.CodigoEmpresa = pObj.CodigoEmpresa;//la nueva empresa del sistema
                iPemEN.ClavePermisoEmpresa = DeclaracionesPermisoEmpresaController.ObtenerClavePermisoEmpresa(iPemEN);
                iPemEN.CPermitir = "0"; //no permitir                
                iLisPerEmp.Add(iPemEN);
            }

            //grabamos la lista
            DeclaracionesPermisoEmpresaController.AdicionarPermisoEmpresaMasivo(iLisPerEmp);
        }
        public static void AdicionarPermisoEmpresaMasivo(List<DeclaracionesPermisoEmpresaDto> pLista)
        {
            IDeclaracionesPermisoEmpresaRepository iDeclaracionesPermisoEmpresa = new DeclaracionesPermisoEmpresaRepository();
            iDeclaracionesPermisoEmpresa.AdicionarPermisoEmpresaMasivo(pLista);
        }
        public static void EliminarPermisosEmpresaXEmpresa(DeclaracionesPermisoEmpresaDto pObj)
        {
            IDeclaracionesPermisoEmpresaRepository iDeclaracionesPermisoEmpresa = new DeclaracionesPermisoEmpresaRepository();
            iDeclaracionesPermisoEmpresa.EliminarPermisosEmpresaXEmpresa(pObj);
        }
    }
}
