using System;
using System.Data;
using System.Data.SqlClient;
using SistemaEstudiantes.CAPANEGOCIO;

namespace SistemaEstudiantes.CAPADATOS
{
    internal class CarrerasCapaDatos
    {
        ConexionCapaDatos conexion;

        public CarrerasCapaDatos()
        {
            conexion = new ConexionCapaDatos();
        }

        public bool Agregar(CarreraCapaNegocio oCarrerasCapaNegocio)
        {
            SqlCommand SQLComando = new SqlCommand("sp_InsertarCarrera");
            SQLComando.CommandType = CommandType.StoredProcedure;
            SQLComando.Parameters.Add("@Carrera", SqlDbType.VarChar).Value = oCarrerasCapaNegocio.Carrera;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        public bool Eliminar(CarreraCapaNegocio oCarrerasCapaNegocio)
        {
            SqlCommand SQLComando = new SqlCommand("sp_EliminarCarrera");
            SQLComando.CommandType = CommandType.StoredProcedure;
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oCarrerasCapaNegocio.ID;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        public bool Modificar(CarreraCapaNegocio oCarrerasCapaNegocio)
        {
            SqlCommand SQLComando = new SqlCommand("sp_ModificarCarrera");
            SQLComando.CommandType = CommandType.StoredProcedure;
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oCarrerasCapaNegocio.ID;
            SQLComando.Parameters.Add("@Carrera", SqlDbType.VarChar).Value = oCarrerasCapaNegocio.Carrera;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        public DataSet MostrarCarreras()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Carreras");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
