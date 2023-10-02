using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaEstudiantes.CAPANEGOCIO
{
    internal class EstudiantesCapaNegocio
    {
        public int ID {get;set;}
        public string NombreEstudiante { get;set;}
        public string PrimerApellido { get;set;}
        public string SegundoApellido { get;set;}
        public int Carrera { get; set; }
        public string Correo { get; set; }
        public byte[] FotoEstudiante { get; set; }


    }
}
