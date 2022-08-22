using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesModel.ModelDto
{
    public class DeclaracionesEmpresaDto
    {
        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CorEmp = "CorreoEmpresa";
        public const string RucEmp = "RucEmpresa";
        public const string DirEmp = "DireccionEmpresa";
        public const string TelFijEmp = "TelFijoEmpresa";
        public const string TelCelEmp = "TelCelularEmpresa";
        public const string NexEmp = "NextelEmpresa";
        public const string LogEmp = "LogoEmpresa";
        public const string CEstEmp = "CEstadoEmpresa";
        public const string NEstEmp = "NEstadoEmpresa";
        public const string CTipDoc = "CTipoDocumento";
        public const string NTipDoc = "NTipoDocumento";
        public const string SerDoc = "SerieDocumento";
        public const string NumDoc = "NumeroDocumento";
        public const string ConCuoOrd = "ConceptoCuotaOrdinaria";
        public const string ConCuoLuz = "ConceptoCuotaLuz";
        public const string ConCuoAgu = "ConceptoCuotaAgua";
        public const string ConCuoMor = "ConceptoCuotaMora";
        public const string PorMor = "PorcentajeMora";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CorreoEmpresa = "hotmail.com";
        private string _RucEmpresa = string.Empty;
        private string _DireccionEmpresa = string.Empty;
        private string _TelFijoEmpresa = string.Empty;
        private string _TelCelularEmpresa = string.Empty;
        private string _NextelEmpresa = string.Empty;
        private string _LogoEmpresa = string.Empty;
        private string _CEstadoEmpresa = "1";
        private string _NEstadoEmpresa = "ACTIVADO";
        private string _CTipoDocumento = string.Empty;
        private string _NTipoDocumento = string.Empty;
        private string _SerieDocumento = string.Empty;
        private string _NumeroDocumento = string.Empty;
        private string _ConceptoCuotaOrdinaria = string.Empty;
        private string _ConceptoCuotaLuz = string.Empty;
        private string _ConceptoCuotaAgua = string.Empty;
        private string _ConceptoCuotaMora = string.Empty;
        private decimal _PorcentajeMora = 0;
        private string _UsuarioAgrega;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica;
        private DateTime _FechaModifica;
        private Additional _Adicionales = new Additional();

        //propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
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

        public string CorreoEmpresa
        {
            get { return this._CorreoEmpresa; }
            set { this._CorreoEmpresa = value; }
        }

        public string RucEmpresa
        {
            get { return this._RucEmpresa; }
            set { this._RucEmpresa = value; }
        }

        public string DireccionEmpresa
        {
            get { return this._DireccionEmpresa; }
            set { this._DireccionEmpresa = value; }
        }

        public string TelFijoEmpresa
        {
            get { return this._TelFijoEmpresa; }
            set { this._TelFijoEmpresa = value; }
        }

        public string TelCelularEmpresa
        {
            get { return this._TelCelularEmpresa; }
            set { this._TelCelularEmpresa = value; }
        }

        public string NextelEmpresa
        {
            get { return this._NextelEmpresa; }
            set { this._NextelEmpresa = value; }
        }

        public string LogoEmpresa
        {
            get { return this._LogoEmpresa; }
            set { this._LogoEmpresa = value; }
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

        public string CTipoDocumento
        {
            get { return this._CTipoDocumento; }
            set { this._CTipoDocumento = value; }
        }

        public string NTipoDocumento
        {
            get { return this._NTipoDocumento; }
            set { this._NTipoDocumento = value; }
        }

        public string SerieDocumento
        {
            get { return this._SerieDocumento; }
            set { this._SerieDocumento = value; }
        }

        public string NumeroDocumento
        {
            get { return this._NumeroDocumento; }
            set { this._NumeroDocumento = value; }
        }

        public string ConceptoCuotaOrdinaria
        {
            get { return this._ConceptoCuotaOrdinaria; }
            set { this._ConceptoCuotaOrdinaria = value; }
        }

        public string ConceptoCuotaLuz
        {
            get { return this._ConceptoCuotaLuz; }
            set { this._ConceptoCuotaLuz = value; }
        }

        public string ConceptoCuotaAgua
        {
            get { return this._ConceptoCuotaAgua; }
            set { this._ConceptoCuotaAgua = value; }
        }

        public string ConceptoCuotaMora
        {
            get { return this._ConceptoCuotaMora; }
            set { this._ConceptoCuotaMora = value; }
        }

        public decimal PorcentajeMora
        {
            get { return this._PorcentajeMora; }
            set { this._PorcentajeMora = value; }
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
