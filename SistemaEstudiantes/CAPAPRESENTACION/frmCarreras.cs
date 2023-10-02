using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaEstudiantes.CAPADATOS;
using SistemaEstudiantes.CAPANEGOCIO;

namespace SistemaEstudiantes.CAPAPRESENTACION
{
    public partial class frmCarreras : Form
    {
        CarrerasCapaDatos oCarrerasCapaDatos;   // creacion de un objeto
        public frmCarreras()
        {
            oCarrerasCapaDatos = new CarrerasCapaDatos();  //Primero objeto ,luego interfaz grafica
            InitializeComponent();
            LlegarGrid();
            LimpiarEntradas();
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Clase CapaDatos Carreras   ...Objeto que tiene la informacion de la GUI
            oCarrerasCapaDatos.Agregar(RecuperarInformacion());
            LlegarGrid();
            LimpiarEntradas();

        }
        private CarreraCapaNegocio RecuperarInformacion ()
        {
            CarreraCapaNegocio oCarreraCapaNegocio = new CarreraCapaNegocio();
            int ID =0; int.TryParse(txtID.Text, out ID);
            
            oCarreraCapaNegocio.ID = ID;
            oCarreraCapaNegocio.Carrera=txtNombre.Text;

            return oCarreraCapaNegocio;

        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dgvCarreras.ClearSelection();

            if (indice >=0)
            { 

            txtID.Text = dgvCarreras.Rows[indice].Cells[0].Value.ToString();
            txtNombre.Text = dgvCarreras.Rows[indice].Cells[1].Value.ToString();

            btnAgregar.Enabled = false;
            btnBorrar.Enabled = true;
            btnModificar.Enabled = true;
            btnCancelar.Enabled = true;

            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oCarrerasCapaDatos.Eliminar(RecuperarInformacion());
            LlegarGrid();
            LimpiarEntradas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oCarrerasCapaDatos.Modificar(RecuperarInformacion());
            LlegarGrid();
            LimpiarEntradas();
        }

        public void LlegarGrid()
        {
            dgvCarreras.DataSource = oCarrerasCapaDatos.MostrarCarreras().Tables[0];

            dgvCarreras.Columns[0].HeaderText = "ID";
            dgvCarreras.Columns[1].HeaderText = "Nombre Carrera";
        }
        public void LimpiarEntradas()
        {
            txtID.Text = "";
            txtNombre.Text = "";

            btnAgregar.Enabled = true;
            btnBorrar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }
    }
}
