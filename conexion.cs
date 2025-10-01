using System.Data.SqlClient;

namespace PortafolioDiseñadores
{
    public class Conexion
    {
        // Cambia la ruta si usas un .mdf en otra carpeta
        private string cadena = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\SROLD\DESKTOP\PROYECTO_POO\PORTAFOLIO_DISENADORES\DBPORTAFOLIO.MDF;Integrated Security=True;Connect Timeout=30;";



        public SqlConnection Abrir()
        {
            SqlConnection con = new SqlConnection(cadena);
            con.Open();
            return con;
        }
    }
}