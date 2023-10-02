using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaEstudiantes.CAPAPRESENTACION;

namespace SistemaEstudiantes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCarreras formularioCarreras = new frmCarreras();
            formularioCarreras.Show();
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            frmEstudiantes formularioEstudiantes = new frmEstudiantes();
            formularioEstudiantes.Show();
        }
    }
}
