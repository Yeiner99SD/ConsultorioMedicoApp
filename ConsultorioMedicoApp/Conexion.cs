using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsultorioMedicoApp
{
    internal class Conexion
    {
        private static string servidor = "localhost";
        private static string baseDatos = "db_clinica";
        private static string usuario = "root"; 
        private static string contrasena = "Adev123.";   
        private static string cadenaConexion = $"Server={servidor};Database={baseDatos};Uid={usuario};Pwd={contrasena};";

        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                return null;
            }
        }
    }
}
