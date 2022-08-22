using DeclaracionesController.Controller;
using DeclaracionesModel.ModelDto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;

namespace DeclaracionesView.Generales
{
    public partial class frmEmpresas : Form
    {
        string eNombreColumnaDgvEmp = DeclaracionesEmpresaDto.CodEmp;
        string eEncabezadoColumnaDgvEmp = "Codigo";
        public string eClaveDgvEmp = string.Empty;
        Dgv.Franja eFranjaDgvEmp = Dgv.Franja.PorIndice;
        public List<DeclaracionesEmpresaDto> eLisEmp = new List<DeclaracionesEmpresaDto>();
        int eVaBD = 1;//0 : no , 1 : si

        public frmEmpresas()
        {
            InitializeComponent();
        }
        public void NuevaVentana()
        {
            this.Dock = DockStyle.Fill;
            this.Show();
            this.ActualizarVentana();
        }
        public void ActualizarVentana()
        {
            this.ActualizarListaEmpresasDeBaseDatos();
            this.ActualizarDgvEmp();
            Dgv.HabilitarDesplazadores(this.DgvEmp, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            //this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvEmp, this.sst1);
            this.AccionBuscar();
        }
        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvEmp;
            this.tstBuscar.Focus();
        }
        public void ActualizarListaEmpresasDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();
            iEmpEN.Adicionales.CampoOrden = eNombreColumnaDgvEmp;
            this.eLisEmp = DeclaracionesEmpresaController.ListarEmpresas(iEmpEN);
        }
        public void ActualizarDgvEmp()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvEmp;
            List<DeclaracionesEmpresaDto> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvEmp;
            string iClaveBusqueda = eClaveDgvEmp;
            string iColumnaPintura = eNombreColumnaDgvEmp;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvEmp();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<DeclaracionesEmpresaDto> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvEmp;
            List<DeclaracionesEmpresaDto> iListaEmpresas = eLisEmp;

            //ejecutar y retornar
            return DeclaracionesEmpresaController.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaEmpresas);
        }
        public List<DataGridViewColumn> ListarColumnasDgvEmp()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesEmpresaDto.CodEmp, "Codigo", 50));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesEmpresaDto.NomEmp, "Nombre", 240));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesEmpresaDto.RucEmp, "Ruc", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesEmpresaDto.DirEmp, "Direccion", 300));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesEmpresaDto.TelFijEmp, "Telefono", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesEmpresaDto.TelCelEmp, "Celular", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesEmpresaDto.CorEmp, "Correo", 170));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesEmpresaDto.NEstEmp, "Estado", 120));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(DeclaracionesEmpresaDto.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }
        public void AccionAdicionar()
        {
            frmEditEmpresa win = new frmEditEmpresa();
            win.wEmp = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvEmp = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesEmpresaDto iEmpEN = this.EsEmpresaExistente();
            if (iEmpEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditEmpresa win = new frmEditEmpresa();
            win.wEmp = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvEmp = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iEmpEN);
        }
        public DeclaracionesEmpresaDto EsEmpresaExistente()
        {
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();
            this.AsignarEmpresa(iEmpEN);
            iEmpEN = DeclaracionesEmpresaController.EsEmpresaExistente(iEmpEN);
            if (iEmpEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iEmpEN.Adicionales.Mensaje, "Empresa");
            }
            return iEmpEN;
        }
        public void AsignarEmpresa(DeclaracionesEmpresaDto pEmp)
        {
            pEmp.CodigoEmpresa = Dgv.ObtenerValorCelda(this.DgvEmp, DeclaracionesEmpresaDto.CodEmp);
        }
        public void Cerrar()
        {
            //obtener al wMenu
            frmMenuGenerales wMen = (frmMenuGenerales)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.tsmiEmpresas, null);
        }
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesEmpresaDto iEmpEN = this.EsActoEliminarEmpresa();
            if (iEmpEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditEmpresa win = new frmEditEmpresa();
            win.wEmp = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvEmp = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iEmpEN);

        }
        public DeclaracionesEmpresaDto EsActoEliminarEmpresa()
        {
            DeclaracionesEmpresaDto iEmpEN = new DeclaracionesEmpresaDto();
            this.AsignarEmpresa(iEmpEN);
            iEmpEN = DeclaracionesEmpresaController.EsActoEliminarEmpresa(iEmpEN);
            if (iEmpEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iEmpEN.Adicionales.Mensaje, "Empresa");
            }
            return iEmpEN;
        }
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            DeclaracionesEmpresaDto iEmpEN = this.EsEmpresaExistente();
            if (iEmpEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            frmEditEmpresa win = new frmEditEmpresa();
            win.wEmp = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iEmpEN);
        }
        public void AccionModificarAlHacerDobleClick(int pColumna, int pFila)
        {
            //no debe pasar cuando la fila o columna sea -1
            if (pColumna == -1 || pFila == -1) { return; }

            //preguntar si este usuario tiene acceso a la accion modificar
            //basta con ver si el boton modificar esta habilitado o no
            if (tsbModificar.Enabled == false)
            {
                Mensaje.OperacionDenegada("Tu usuario no tiene permiso para modificar este registro", "Modificar");
            }
            else
            {
                this.AccionModificar();
            }
        }
        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvEmp = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvEmp = this.DgvEmp.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvEmp = this.DgvEmp.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }
        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvEmp, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvEmp, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        if (this.tstBuscar.Text != string.Empty) { eVaBD = 0; }
                        this.ActualizarVentana();
                        eVaBD = 1;
                        break;
                    }
            }
        }
        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionAdicionar();
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificar();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmpresas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            this.AccionEliminar();
        }

        private void tsbVisualizar_Click(object sender, EventArgs e)
        {
            this.AccionVisualizar();
        }

        private void DgvEmp_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvEmp, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvEmp, this.sst1);
        }

        private void DgvEmp_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void DgvEmp_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvEmp, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvEmp, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvEmp, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvEmp, Dgv.Desplazar.Ultimo);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvEmp = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }
    }
}
