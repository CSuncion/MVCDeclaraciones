using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesModel.ModelDto
{
    public class DeclaracionesTipoCambioDto
    {

        //campo nombres
        public const string ClaObj = "ClaveObjeto";
        public const string FecTipCam = "FechaTipoCambio";
        public const string ComTipCam = "CompraTipoCambio";
        public const string VtaTipCam = "VentaTipoCambio";
        public const string PerTipCam = "PeriodoTipoCambio";
        public const string CEstTipCam = "CEstadoTipoCambio";
        public const string NEstTipCam = "NEstadoTipoCambio";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _FechaTipoCambio = string.Empty;
        private decimal _CompraTipoCambio = 0;
        private decimal _VentaTipoCambio = 0;
        private string _PeriodoTipoCambio = "";
        private string _CEstadoTipoCambio = "1";//activado
        private string _NEstadoTipoCambio = "Abierto";
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


        public string FechaTipoCambio
        {
            get { return this._FechaTipoCambio; }
            set { this._FechaTipoCambio = value; }
        }


        public decimal CompraTipoCambio
        {
            get { return this._CompraTipoCambio; }
            set { this._CompraTipoCambio = value; }
        }


        public decimal VentaTipoCambio
        {
            get { return this._VentaTipoCambio; }
            set { this._VentaTipoCambio = value; }
        }

        public string PeriodoTipoCambio
        {
            get { return this._PeriodoTipoCambio; }
            set { this._PeriodoTipoCambio = value; }
        }


        public string CEstadoTipoCambio
        {
            get { return this._CEstadoTipoCambio; }
            set { this._CEstadoTipoCambio = value; }
        }


        public string NEstadoTipoCambio
        {
            get { return this._NEstadoTipoCambio; }
            set { this._NEstadoTipoCambio = value; }
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
