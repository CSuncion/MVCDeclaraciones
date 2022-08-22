using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesModel.ModelDto
{
    public class DeclaracionesItemGDto
    {

        //campo nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaIteG = "ClaveItemG";
        public const string CodTab = "CodigoTabla";
        public const string NomTab = "NombreTabla";
        public const string CodIteG = "CodigoItemG";
        public const string NomIteG = "NombreItemG";
        public const string AbrIteG = "AbreviaItemG";
        public const string VerFal = "VerdadFalso";
        public const string CEstIteG = "CEstadoItemG";
        public const string NEstIteG = "NEstadoItemG";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveItemG = string.Empty;
        private string _CodigoTabla = string.Empty;
        private string _NombreTabla = string.Empty;
        private string _CodigoItemG = string.Empty;
        private string _NombreItemG = string.Empty;
        private string _AbreviaItemG = string.Empty;
        private bool _VerdadFalso = false;
        private string _CEstadoItemG = "1";//activado
        private string _NEstadoItemG = string.Empty;
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

        public string ClaveItemG
        {
            get { return this._ClaveItemG; }
            set { this._ClaveItemG = value; }
        }

        public string CodigoTabla
        {
            get { return this._CodigoTabla; }
            set { this._CodigoTabla = value; }
        }

        public string NombreTabla
        {
            get { return this._NombreTabla; }
            set { this._NombreTabla = value; }
        }

        public string CodigoItemG
        {
            get { return this._CodigoItemG; }
            set { this._CodigoItemG = value; }
        }

        public string NombreItemG
        {
            get { return this._NombreItemG; }
            set { this._NombreItemG = value; }
        }

        public string AbreviaItemG
        {
            get { return this._AbreviaItemG; }
            set { this._AbreviaItemG = value; }
        }

        public bool VerdadFalso
        {
            get { return this._VerdadFalso; }
            set { this._VerdadFalso = value; }
        }

        public string CEstadoItemG
        {
            get { return this._CEstadoItemG; }
            set { this._CEstadoItemG = value; }
        }

        public string NEstadoItemG
        {
            get { return this._NEstadoItemG; }
            set { this._NEstadoItemG = value; }
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
