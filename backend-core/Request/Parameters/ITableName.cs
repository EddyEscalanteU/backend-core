namespace BackendCore.Request.Parameters
{
    /// <summary>
    /// Interfaz para capturar el nombre de la tabla de base de datos
    /// </summary>
    public interface ITableName
    {
        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public string TableName { get; }
    }
}