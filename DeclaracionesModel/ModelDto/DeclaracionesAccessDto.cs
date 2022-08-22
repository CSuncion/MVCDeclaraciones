using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesModel.ModelDto
{
    public class DeclaracionesAccessDto
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string CodUsu = "CodigoUsuario";
        public const string NomUsu = "NombreUsuario";
        public const string ClaUsu = "ClaveUsuario";
        public const string DirUsu = "DireccionUsuario";
        public const string FotUsu = "FotoUsuario";
        public const string CorUsu = "CorreoUsuario";
        public const string CodPer = "CodigoPerfil";
        public const string NomPer = "NombrePerfil";
        public const string CEstUsu = "CEstadoUsuario";
        public const string NEstUsu = "NEstadoUsuario";
        public const string CAccUsu = "CAccesaUsuario";
        public const string NAccUsu = "NAccesaUsuario";
        public const string TelFijUsu = "TelFijoUsuario";
        public const string TelCelUsu = "TelCelularUsuario";
        public const string CodPrs = "CodigoPersonal";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";


        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _CodigoUsuario = string.Empty;
        private string _NombreUsuario = string.Empty;
        private string _ClaveUsuario = string.Empty;
        private string _DireccionUsuario = string.Empty;
        private string _FotoUsuario = string.Empty;
        private string _CorreoUsuario = "@hotmail.com";
        private string _CodigoPerfil = "02";
        private string _NombrePerfil = string.Empty;
        private string _CEstadoUsuario = "1";
        private string _NEstadoUsuario = "ACTIVADO";
        private string _CAccesaUsuario = "1";
        private string _NAccesaUsuario = "Si";
        private string _TelFijoUsuario = string.Empty;
        private string _TelCelularUsuario = string.Empty;
        private string _CodigoPersonal = string.Empty;
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private Additional _Additionals = new Additional();

        //propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }


        public string CodigoUsuario
        {
            get { return this._CodigoUsuario; }
            set { this._CodigoUsuario = value; }
        }


        public string NombreUsuario
        {
            get { return this._NombreUsuario; }
            set { this._NombreUsuario = value; }
        }


        public string ClaveUsuario
        {
            get { return this._ClaveUsuario; }
            set { this._ClaveUsuario = value; }
        }


        public string DireccionUsuario
        {
            get { return this._DireccionUsuario; }
            set { this._DireccionUsuario = value; }
        }


        public string FotoUsuario
        {
            get { return this._FotoUsuario; }
            set { this._FotoUsuario = value; }
        }


        public string CorreoUsuario
        {
            get { return this._CorreoUsuario; }
            set { this._CorreoUsuario = value; }
        }


        public string CodigoPerfil
        {
            get { return this._CodigoPerfil; }
            set { this._CodigoPerfil = value; }
        }


        public string NombrePerfil
        {
            get { return this._NombrePerfil; }
            set { this._NombrePerfil = value; }
        }


        public string CAccesaUsuario
        {
            get { return this._CAccesaUsuario; }
            set { this._CAccesaUsuario = value; }
        }


        public string NAccesaUsuario
        {
            get { return this._NAccesaUsuario; }
            set { this._NAccesaUsuario = value; }
        }


        public string CEstadoUsuario
        {
            get { return this._CEstadoUsuario; }
            set { this._CEstadoUsuario = value; }
        }


        public string NEstadoUsuario
        {
            get { return this._NEstadoUsuario; }
            set { this._NEstadoUsuario = value; }
        }


        public string TelFijoUsuario
        {
            get { return this._TelFijoUsuario; }
            set { this._TelFijoUsuario = value; }
        }


        public string TelCelularUsuario
        {
            get { return this._TelCelularUsuario; }
            set { this._TelCelularUsuario = value; }
        }


        public string CodigoPersonal
        {
            get { return this._CodigoPersonal; }
            set { this._CodigoPersonal = value; }
        }


        public string UsuarioAgrega
        {
            get { return this._UsuarioAgrega; }
            set { this._UsuarioAgrega = value; }
        }


        public DateTime FechaAgrega
        {
            get { return this._FechaAgrega; }
            set { this._FechaAgrega = value; }
        }


        public string UsuarioModifica
        {
            get { return this._UsuarioModifica; }
            set { this._UsuarioModifica = value; }
        }


        public DateTime FechaModifica
        {
            get { return this._FechaModifica; }
            set { this._FechaModifica = value; }
        }


        public Additional Additionals
        {
            get { return this._Additionals; }
            set { this._Additionals = value; }
        }
    }
}
