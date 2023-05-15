using BackendCore.Database;

namespace BackendCore.Interfaces.Connection
{
    /// <summary>
    /// Interfaz de tipo Query para solamente la consulta de datos.
    /// </summary>
    public interface IReadConexion
    {
        /// <summary>
        /// Executes the query asynchronous.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="databaseKey">The database key.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException">Connection error</exception>
        /// <exception cref="FormatException"></exception>
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, string databaseKey);

        /// <summary>
        /// Exists the data asynchronous.
        /// </summary>
        /// <param name="parametros">The parámetros.</param>
        /// <param name="query">The query.</param>
        /// <param name="databaseKey">The database key.</param>
        /// <returns>true or false</returns>
        /// <exception cref="System.NotSupportedException"></exception>
        Task<bool> ExistDataAsync(SqlDynamicParameters parametros, string query, string databaseKey);

        /// <summary>
        /// Gets the data asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parametros">The parámetros.</param>
        /// <param name="query">The query.</param>
        /// <param name="databaseKey">The database key.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="encrypt">if set to <c>true</c> [encrypt].</param>
        /// <returns>El listado de tipo T de la consulta con parámetros</returns>
        /// <exception cref="System.NotSupportedException">Connection error</exception>
        /// <exception cref="FormatException"></exception>
        Task<IEnumerable<T>> GetDataAsync<T>(SqlDynamicParameters parametros, string query, string databaseKey, string? tableName = default, bool encrypt = true);

        /// <summary>
        /// Encriptar the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <param name="query">The query.</param>
        /// <param name="databaseKey">The database key.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>El mismo objeto encriptado</returns>
        /// <exception cref="System.NotSupportedException">Connection error</exception>
        Task<T> EncriptObject<T>(T result, string query, string databaseKey, string? tableName = default);
        /*
        /// <summary>
        /// Gets the query asynchronous.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>El listado de objetos de la consulta</returns>
        /// <exception cref="System.NotSupportedException">Connection error</exception>
        Task<IEnumerable<object>> GetQueryAsync(string query);

        /// <summary>
        /// Gets the query asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <returns>El listado de tipo T de la consulta</returns>
        /// <exception cref="System.NotSupportedException">Connection error</exception>
        Task<IEnumerable<T>> GetQueryAsync<T>(string query);
        */
    }
}