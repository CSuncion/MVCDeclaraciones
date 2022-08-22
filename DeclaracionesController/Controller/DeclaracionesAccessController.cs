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
    public class DeclaracionesAccessController
    {
        private readonly IDeclaracionesAccessRepository _iDeclaracionesAccessRepository;

        public DeclaracionesAccessController()
        {
            this._iDeclaracionesAccessRepository = new DeclaracionesAccessRepository();
        }
        public DeclaracionesAccessDto EsUsuarioValido(DeclaracionesAccessDto pObj)
        {
            DeclaracionesAccessDto iUsuEN = new DeclaracionesAccessDto();

            //si no hay codigousuario entonces es true
            if (pObj.CodigoUsuario == string.Empty)
            {
                iUsuEN.Additionals.EsVerdad = true;
                iUsuEN.Additionals.Mensaje = "";
                return iUsuEN;
            }

            //aqui CodigoUsuario no esta vacio
            iUsuEN = this._iDeclaracionesAccessRepository.BuscarUsuarioXCodigo(pObj);
            if (iUsuEN.CodigoUsuario == string.Empty)
            {
                iUsuEN.Additionals.EsVerdad = false;
                iUsuEN.Additionals.Mensaje = "No existe usuario con este codigo : " + Cadena.Espacios(1) + pObj.CodigoUsuario;
                return iUsuEN;
            }
            else
            {
                if (iUsuEN.CEstadoUsuario == "0") //desactivado
                {
                    iUsuEN = DeclaracionesAccessController.EnBlanco();
                    iUsuEN.Additionals.EsVerdad = false;
                    iUsuEN.Additionals.Mensaje = "El usuario" + Cadena.Espacios(1) + pObj.CodigoUsuario + Cadena.Espacios(1) + "esta desactivado";
                    return iUsuEN;
                }
            }
            iUsuEN.Additionals.EsVerdad = true;
            return iUsuEN;
        }
        public DeclaracionesAccessDto EsContrasenaDeUsuario(DeclaracionesAccessDto pObj)
        {
            DeclaracionesAccessDto iUsuEN = new DeclaracionesAccessDto();

            //si no se digito contraseña entonces es true
            if (pObj.ClaveUsuario == string.Empty)
            {
                iUsuEN.Additionals.EsVerdad = true;
                iUsuEN.Additionals.Mensaje = string.Empty;
                return iUsuEN;
            }

            //si CodigoUsuario no esta vacio y clave tampoco
            string xClave = pObj.ClaveUsuario;
            iUsuEN = this._iDeclaracionesAccessRepository.BuscarUsuarioXCodigo(pObj);
            if (iUsuEN.ClaveUsuario.Trim() == xClave)
            {
                iUsuEN.Additionals.EsVerdad = true;
                iUsuEN.Additionals.Mensaje = string.Empty;
                return iUsuEN;
            }
            else
            {
                iUsuEN.Additionals.EsVerdad = false;
                iUsuEN.Additionals.Mensaje = "La clave es Incorrecta";
                return iUsuEN;
            }

        }
        public static DeclaracionesAccessDto EnBlanco()
        {
            DeclaracionesAccessDto iUsuEN = new DeclaracionesAccessDto();
            return iUsuEN;
        }
        public List<DeclaracionesAccessDto> ListarUsuariosActivos(DeclaracionesAccessDto pObj)
        {
            return this._iDeclaracionesAccessRepository.ListarUsuariosXEstado(pObj);
        }
        public static List<DeclaracionesAccessDto> ListarUsuarios()
        {
            IDeclaracionesAccessRepository iUsuEN = new DeclaracionesAccessRepository();
            return iUsuEN.ListarUsuarios();
        }
    }
}
