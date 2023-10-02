using SistemaEstudiantes.CAPANEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SistemaEstudiantes.CAPADATOS
{
    internal class EstudiantesCapaDatos
    {
        ConexionCapaDatos conexion;

        public EstudiantesCapaDatos()
        {
            conexion = new ConexionCapaDatos();
        }
        public bool Agregar(EstudiantesCapaNegocio oEstudiantesCapaNegocio)
        {
            SqlCommand SQLComando = new SqlCommand("sp_InsertarEstudiante");
            SQLComando.CommandType = System.Data.CommandType.StoredProcedure;
            SQLComando.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = oEstudiantesCapaNegocio.ID;
            //SQLComando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = oEstudiantesCapaNegocio.Nombre;
            //SQLComando.Parameters.Add("@Apellido", System.Data.SqlDbType.VarChar).Value = oEstudiantesCapaNegocio.Apellido;
            SQLComando.Parameters.Add("@Carrera", System.Data.SqlDbType.Int).Value = oEstudiantesCapaNegocio.Carrera;
            //SQLComando.Parameters.Add("@Foto", System.Data.SqlDbType.Image).Value = oEstudiantesCapaNegocio.Foto;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }
    }
}
