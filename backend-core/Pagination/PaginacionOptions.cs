namespace BackendCore.Pagination
{
    /// <summary>
    /// Opciones de la paginación
    /// </summary>
    public class PaginacionOptions
    {
        /// <summary>
        /// Gets or sets the inicial numero de pagina.
        /// </summary>
        /// <value>
        /// The inicial numero de pagina.
        /// </value>
        public int InicialNumeroDePagina { get; set; }

        /// <summary>
        /// Gets or sets the inicial tamaño de pagina.
        /// </summary>
        /// <value>
        /// The inicial tamaño de pagina.
        /// </value>
        public int InicialTamanoDePagina { get; set; }
    }
}