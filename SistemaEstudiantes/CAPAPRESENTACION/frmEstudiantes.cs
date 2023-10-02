using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SistemaEstudiantes.CAPADATOS;
using SistemaEstudiantes.CAPANEGOCIO;

namespace SistemaEstudiantes.CAPAPRESENTACION
{
    public partial class frmEstudiantes : Form
    {
        byte[] imagenByte;  //Variable

        public frmEstudiantes()
        {
            InitializeComponent();
        }

        private void frmEstudiantes_Load(object sender, EventArgs e)
        {
            CarrerasCapaDatos objCarreras = new CarrerasCapaDatos();
            cbxCarrera.DataSource = objCarreras.MostrarCarreras().Tables[0];
            cbxCarrera.DisplayMember = "carrera";
            cbxCarrera.ValueMember = "ID";
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectorImagen = new OpenFileDialog();
            selectorImagen.Title = "Seleccionar Imagen";

            if (selectorImagen.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromStream(selectorImagen.OpenFile());
                MemoryStream memoria = new MemoryStream();
                picFoto.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Png);

                imagenByte= memoria.ToArray();
            }

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RecolectarDatos();
        }
        private void RecolectarDatos()
        {
            EstudiantesCapaNegocio objEstudiantes = new EstudiantesCapaNegocio();

            int codigoEstudiante = 1;

            int.TryParse(txtID.Text, out codigoEstudiante);

            objEstudiantes.ID = codigoEstudiante;
            objEstudiantes.NombreEstudiante =txtNombre.Text;
            objEstudiantes.PrimerApellido =txtPrimerApellido.Text;
            objEstudiantes.SegundoApellido =txtSegundoApellido.Text;
            objEstudiantes.Correo =txtCorreo.Text;

            int IDCarrera = 0;
            int.TryParse(cbxCarrera.SelectedValue.ToString(), out IDCarrera);

            objEstudiantes.Carrera = IDCarrera;

            objEstudiantes.FotoEstudiante = imagenByte;
        }
    }
}
