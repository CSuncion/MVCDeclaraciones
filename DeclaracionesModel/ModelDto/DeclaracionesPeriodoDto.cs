using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesModel.ModelDto
{
    public class DeclaracionesPeriodoDto
    {

        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string ClaPer = "ClavePeriodo";
        public const string CodPer = "CodigoPeriodo";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string AnoPer = "AnoPeriodo";
        public const string CMesPer = "CMesPeriodo";
        public const string TipCamPer = "TipoCambioPeriodo";
        public const string NMesPer = "NMesPeriodo";
        public const string CEstPer = "CEstadoPeriodo";
        public const string NEstPer = "NEstadoPeriodo";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClavePeriodo = string.Empty;
        private string _CodigoPeriodo = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _AnoPeriodo = string.Empty;
        private string _CMesPeriodo = "01";
        private string _NMesPeriodo = string.Empty;
        private decimal _TipoCambioPeriodo = 1;
        private string _CEstadoPeriodo = "1";
        private string _NEstadoPeriodo = "Activado";
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private Additional _Adicionales = new Additional();


        //propiedades
        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClavePeriodo
        {
            get { return _ClavePeriodo; }
            set { _ClavePeriodo = value; }
        }

        public string CodigoPeriodo
        {
            get { return _CodigoPeriodo; }
            set { _CodigoPeriodo = value; }
        }

        public string CodigoEmpresa
        {
            get { return _CodigoEmpresa; }
            set { _CodigoEmpresa = value; }
        }

        public string NombreEmpresa
        {
            get { return _NombreEmpresa; }
            set { _NombreEmpresa = value; }
        }

        public string AnoPeriodo
        {
            get { return _AnoPeriodo; }
            set { _AnoPeriodo = value; }
        }

        public string CMesPeriodo
        {
            get { return _CMesPeriodo; }
            set { _CMesPeriodo = value; }
        }

        public string NMesPeriodo
        {
            get { return _NMesPeriodo; }
            set { _NMesPeriodo = value; }
        }

        public decimal TipoCambioPeriodo
        {
            get { return _TipoCambioPeriodo; }
            set { _TipoCambioPeriodo = value; }
        }

        public string CEstadoPeriodo
        {
            get { return _CEstadoPeriodo; }
            set { _CEstadoPeriodo = value; }
        }

        public string NEstadoPeriodo
        {
            get { return _NEstadoPeriodo; }
            set { _NEstadoPeriodo = value; }
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
            get { return _Adicionales; }
            set { _Adicionales = value; }
        }
    }
}
