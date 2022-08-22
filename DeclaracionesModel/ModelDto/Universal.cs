using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesModel.ModelDto
{
    public class Universal
    {

        public static string gCodigoUsuario = string.Empty;
        public static string gNombreUsuario = string.Empty;
        public static string gCodigoEmpresa = string.Empty;
        public static string gNombreEmpresa = string.Empty;
        public static string gCodigoPerfil = string.Empty;
        public static string gNombrePerfil = string.Empty;
        public static string gStrPermisosAlmacen = string.Empty;

        //enumeraciones 

        public enum Opera
        {
            Adicionar = 0,
            Modificar,
            Eliminar,
            Visualizar,
            Anular,
            AgregarVarios,
            Pendiente
        }


        public enum LlenarDetalle
        {
            DeBaseDeDatos = 0,
            DeListaVirtual,
        }


        public enum EjecutaEnBaseDatos
        {
            No = 0,
            Si,
        }



        //metodos y funciones

        public static string EstadoBarra()
        {
            StringBuilder iEstado = new System.Text.StringBuilder();
            iEstado.Append("Usuario : " + Universal.gCodigoUsuario + " - " + Universal.gNombreUsuario + "   |   ");
            iEstado.Append("Perfil : " + Universal.gNombrePerfil + "   |   ");
            iEstado.Append("Empresa : " + Universal.gCodigoEmpresa + " - " + Universal.gNombreEmpresa + "   |   ");
            iEstado.Append("Hoy : " + DateTime.Today.ToShortDateString());
            return iEstado.ToString();
        }

        public static string ErrorMensaje()
        {
            return "no se puede realizar la operacion";
        }

    }
}
