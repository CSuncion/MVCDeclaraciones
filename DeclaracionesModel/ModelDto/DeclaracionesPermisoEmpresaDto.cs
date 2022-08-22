using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesModel.ModelDto
{
    public class DeclaracionesPermisoEmpresaDto
    {
        //campos nombres
        public const string ClaPerEmp = "ClavePermisoEmpresa";
        public const string CodUsu = "CodigoUsuario";
        public const string NomUsu = "NombreUsuario";
        public const string CodPer = "CodigoPerfil";
        public const string NomPer = "NombrePerfil";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CEstEmp = "CEstadoEmpresa";
        public const string NEstEmp = "NEstadoEmpresa";
        public const string CPerm = "CPermitir";
        public const string NPerm = "NPermitir";
        public const string VerFal = "VerdadFalso";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";


        //atributos
        private string _ClavePermisoEmpresa = string.Empty;
        private string _CodigoUsuario = string.Empty;
        private string _NombreUsuario = string.Empty;
        private string _CodigoPerfil = "01";
        private string _NombrePerfil = "ADMINISTRADOR";
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CEstadoEmpresa = string.Empty;
        private string _NEstadoEmpresa = string.Empty;
        private string _CPermitir = string.Empty;
        private string _NPermitir = string.Empty;
        private bool _VerdadFalso = false;
        private string _UsuarioAgrega;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica;
        private DateTime _FechaModifica;
        private Additional _Adicionales = new Additional();


        //propiedades

        public string ClavePermisoEmpresa
        {
            get { return this._ClavePermisoEmpresa; }
            set { this._ClavePermisoEmpresa = value; }
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


        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
        }


        public string NombreEmpresa
        {
            get { return this._NombreEmpresa; }
            set { this._NombreEmpresa = value; }
        }


        public string CEstadoEmpresa
        {
            get { return this._CEstadoEmpresa; }
            set { this._CEstadoEmpresa = value; }
        }


        public string NEstadoEmpresa
        {
            get { return this._NEstadoEmpresa; }
            set { this._NEstadoEmpresa = value; }
        }


        public string CPermitir
        {
            get { return this._CPermitir; }
            set { this._CPermitir = value; }
        }


        public string NPermitir
        {
            get { return this._NPermitir; }
            set { this._NPermitir = value; }
        }


        public bool VerdadFalso
        {
            get { return this._VerdadFalso; }
            set { this._VerdadFalso = value; }
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



        public Additional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
}
