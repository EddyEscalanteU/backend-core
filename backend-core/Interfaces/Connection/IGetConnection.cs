using System.Data.SqlClient;

namespace BackendCore.Interfaces.Connection
{

    /// <summary>
    /// Interfaz para obtener la conexión a la base de datos
    /// </summary>
    public interface IGetConnection
    {
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <param name="databaseKey">The database key.</param>
        /// <returns>cadena de conexión</returns>
        /// <exception cref="FormatException"></exception>
        SqlConnection GetConnection(string databaseKey);
    }
}