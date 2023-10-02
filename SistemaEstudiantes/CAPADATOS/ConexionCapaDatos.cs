using System;
using System.Collections.Generic;
using System.Data; //Libreria para usar SQL
using System.Data.SqlClient; //Libreria para usar SQL
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudiantes.CAPADATOS
{
    internal class ConexionCapaDatos
    {
        private string CadenaConexion = "Data Source=DESKTOP-6KAJKEK\\SQLEXPRESS; Initial Catalog=db Sistema; Integrated Security =True";
        SqlConnection Conexion;

        public SqlConnection EstablecerConexion()
        {
            this.Conexion = new SqlConnection(this.CadenaConexion);
            return this.Conexion;
        }


        /* Metodo de ejecucion Insert , Delet , Update */
        public bool ejecutarComandoSinRetornoDatos(string strComando) {
            try
            {
                
                SqlCommand Comando = new SqlCommand();

                Comando.CommandText = strComando;
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();

                return true;

            }
            catch{
                return false;
            }
           

        }
        //Sobrecarga Metodo de ejecucion Insert , Delet , Update
        public bool ejecutarComandoSinRetornoDatos(SqlCommand SQLComando)
        {
            try
            {

                SqlCommand Comando = SQLComando;
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();

                return true;

            }
            catch
            {
                return false;
            }


        }


        /*SELECT (Retorno datos)*/
        public DataSet EjecutarSentencia(SqlCommand sqlComando)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();

            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlComando;
                Comando.Connection = EstablecerConexion();
                Adaptador.SelectCommand = Comando;
                Conexion.Open();
                Adaptador.Fill(DS);
                Conexion.Close();
                return DS;
            }
            catch
            {
                return DS;
            }


        }


    }
}
