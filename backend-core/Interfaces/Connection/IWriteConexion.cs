using BackendCore.Database;
using BackendCore.Request;
using BackendCore.Response;

namespace BackendCore.Interfaces.Connection
{
    /// <summary>
    /// Interfaz de tipo Command para la consulta y escritura de datos.
    /// </summary>
    public interface IWriteConexion
    {
        /// <summary>
        /// Eliminar una tupla de la base de datos lógicamente.
        /// Deletes the data asynchronous, 
        /// </summary>
        /// <param name="deleteFluentRequest">The delete fluent request.</param>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <returns>ResponsePostDetail object</returns>
        /// <exception cref="System.NotSupportedException">Connection error</exception>
        Task<ResponsePostDetail> DeleteDataAsync(DeleteFluentRequest deleteFluentRequest, string storedProcedure);

        /// <summary>
        /// Validar sus referencias de dependencia con otras tablas.
        /// </summary>
        /// <param name="deleteFluentRequest">The delete fluent request.</param>
        /// <returns>Lista de tablas con quien tiene datos de referencia</returns>
        /// <exception cref="System.NotSupportedException">Connection error</exception>
        /// <exception cref="FormatException"></exception>
        Task<string> ValidateDeleteDataAsync(DeleteFluentRequest deleteFluentRequest);

        /// <summary>
        /// Insertar o Actualizar una tupla a la base de datos
        /// </summary>
        /// <param name="fluentRequest">The fluent request.</param>
        /// <param name="sqlDynamicParameters">The SQL dynamic parameters.</param>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <returns>ResponsePostDetail object</returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.NotSupportedException">Connection error</exception>
        /// <exception cref="FormatException"></exception>
        Task<ResponsePostDetail> SetDataAsync(FluentRequest fluentRequest, SqlDynamicParameters sqlDynamicParameters, string storedProcedure);
        /*
        / <summary>
        / Inserts the data per list asynchronous.
        / </summary>
        / <param name = "fluentRequest" > The fluent request.</param>
        / <param name = "sqlDynamicParameters" > The SQL dynamic parameters.</param>
        / <param name = "storedProcedure" > The stored procedure.</param>
        / <returns></returns>
        Task<ResponsePostDetail> InsertDataPerListAsync(FluentRequest fluentRequest, SqlDynamicParameters sqlDynamicParameters, string storedProcedure);

        / <summary>
        / Updates the data per list asynchronous.
        / </summary>
        / <param name = "fluentRequest" > The fluent request.</param>
        / <param name = "sqlDynamicParameters" > The SQL dynamic parameters.</param>
        / <param name = "storedProcedure" > The stored procedure.</param>
        / <returns></returns>
        Task<ResponsePostDetail> UpdateDataPerListAsync(FluentRequest fluentRequest, SqlDynamicParameters sqlDynamicParameters, string storedProcedure);
        */
    }
}