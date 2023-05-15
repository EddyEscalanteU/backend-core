namespace BackendCore.Request.Parameters
{
    /// <summary>
    /// Llave de la base de datos
    /// </summary>
    public interface IDatabaseKey
    {
        /// <summary>
        /// Gets the database key.
        /// </summary>
        /// <value>
        /// The database key.
        /// </value>
        public string DatabaseKey { get; }
    }
}