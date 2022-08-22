using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Comun;
using WinControles.ControlesWindows;
using DeclaracionesModel.ModelDto;
using DeclaracionesController.Controller;

namespace DeclaracionesView.FuncionesGenericas
{
    public class Generico
    {
        DeclaracionesItemGController declaracionesItemGController = new DeclaracionesItemGController();

        public static void CancelarVentanaEditar(Form pVentana, Universal.Opera pOperacionVentana, Masivo pObjetoMasivo, string pTituloVentana)
        {
            if (pOperacionVentana == Universal.Opera.Visualizar || pOperacionVentana == Universal.Opera.Eliminar || pOperacionVentana == Universal.Opera.Anular)
            {
                pVentana.Close();
                return;
            }

            //solo para adicionar y modificar
            if (pObjetoMasivo.SonTextosIguales() == false)
            {
                if (Mensaje.DeseasCancelarOperacion(pTituloVentana) == false)
                {
                    return;
                }
                else
                {
                    pVentana.Close();
                }
            }
            else
            {
                pVentana.Close();
            }
        }

        public static bool EsCodigoItemGValido(string pCodigoTabla, TextBox pControlCodigoTabla, TextBox pControlNombreTabla, string pTituloTabla)
        {
            //si el control es de solo lectura entonces devuelve true
            if (pControlCodigoTabla.ReadOnly == true) { return true; }

            //ejecutar
            DeclaracionesItemGDto iIteGEN = new DeclaracionesItemGDto();
            iIteGEN.CodigoTabla = pCodigoTabla;
            iIteGEN.CodigoItemG = pControlCodigoTabla.Text.Trim();
            iIteGEN = DeclaracionesItemGController.EsItemGValido(iIteGEN);
            if (iIteGEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIteGEN.Adicionales.Mensaje, pTituloTabla);
                pControlCodigoTabla.Focus();
            }

            //mostrar datos
            pControlCodigoTabla.Text = iIteGEN.CodigoItemG;
            pControlNombreTabla.Text = iIteGEN.NombreItemG;

            //devolver
            return iIteGEN.Adicionales.EsVerdad;
        }

        public static bool EsPeriodoValido(string pPeriodo)
        {
            //esta dato aparte de ser un periodo real , puede estar vacio
            if (pPeriodo == string.Empty)
            {
                Mensaje.OperacionDenegada("Debes elegir un periodo, no se puede realizar la operacion", "Periodo");
                return false;
            }

            //ok
            return true;
        }

        public static void MostrarMensajeError(Additional pObjMenErr)
        {
            if (pObjMenErr.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(pObjMenErr.Mensaje, "Operacion Denegada");
            }
        }

        public static void MostrarMensajeError(Additional pObjMenErr, Control pControlFoco)
        {
            if (pObjMenErr.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(pObjMenErr.Mensaje, "Operacion Denegada");
                pControlFoco.Focus();
            }
        }

        public static void MostrarMensajeError(Additional pObjMenErr, TextBox pControlTxt)
        {
            if (pObjMenErr.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(pObjMenErr.Mensaje, "Operacion Denegada");
                pControlTxt.Clear();
                pControlTxt.Focus();
            }
        }

        //public static bool EsCodigoItemEValido(string pCodigoTabla, TextBox pControlCodigoTabla, TextBox pControlNombreTabla, string pTituloTabla)
        //{
        //    //si el control es de solo lectura entonces devuelve true
        //    if (pControlCodigoTabla.ReadOnly == true) { return true; }

        //    //ejecutar
        //    ItemEEN iIteEEN = new ItemEEN();
        //    iIteEEN.CodigoTabla = pCodigoTabla;
        //    iIteEEN.CodigoItemE = pControlCodigoTabla.Text.Trim();
        //    iIteEEN.ClaveItemE = ItemERN.ObtenerClaveItemE(iIteEEN);
        //    iIteEEN = ItemERN.EsItemEValido(iIteEEN);
        //    if (iIteEEN.Adicionales.EsVerdad == false)
        //    {
        //        Mensaje.OperacionDenegada(iIteEEN.Adicionales.Mensaje, pTituloTabla);
        //        pControlCodigoTabla.Focus();
        //    }

        //    //mostrar datos
        //    pControlCodigoTabla.Text = iIteEEN.CodigoItemE;
        //    pControlNombreTabla.Text = iIteEEN.NombreItemE;

        //    //devolver
        //    return iIteEEN.Adicionales.EsVerdad;
        //}

        //public static bool EsCodigoItemEActivoValido(string pCodigoTabla, TextBox pControlCodigoTabla, TextBox pControlNombreTabla, string pTituloTabla)
        //{
        //    //si el control es de solo lectura entonces devuelve true
        //    if (pControlCodigoTabla.ReadOnly == true) { return true; }

        //    //ejecutar
        //    ItemEEN iIteEEN = new ItemEEN();
        //    iIteEEN.CodigoTabla = pCodigoTabla;
        //    iIteEEN.CodigoItemE = pControlCodigoTabla.Text.Trim();
        //    iIteEEN.ClaveItemE = ItemERN.ObtenerClaveItemE(iIteEEN);
        //    iIteEEN = ItemERN.EsItemEActivoValido(iIteEEN);
        //    if (iIteEEN.Adicionales.EsVerdad == false)
        //    {
        //        Mensaje.OperacionDenegada(iIteEEN.Adicionales.Mensaje, pTituloTabla);
        //        pControlCodigoTabla.Focus();
        //    }

        //    //mostrar datos
        //    pControlCodigoTabla.Text = iIteEEN.CodigoItemE;
        //    pControlNombreTabla.Text = iIteEEN.NombreItemE;

        //    //devolver
        //    return iIteEEN.Adicionales.EsVerdad;
        //}


    }
}
