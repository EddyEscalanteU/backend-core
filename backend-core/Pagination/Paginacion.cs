using BackendCore.Response;

namespace BackendCore.Pagination
{
    /// <summary>
    /// Objeto para la paginación
    /// </summary>
    public class Paginacion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Paginacion"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public Paginacion(ResponseGetPagination result)
        {
            TotalRegistros = result.Paginacion.TotalRegistros;
            TamanoDePagina = result.Paginacion.TamanoDePagina;
            PaginaActual = result.Paginacion.PaginaActual;
            TotalPaginas = result.Paginacion.TotalPaginas;
            TienePaginaAnterior = result.Paginacion.TienePaginaAnterior;
            TienePaginaSiguiente = result.Paginacion.TienePaginaSiguiente;
        }

        /// <summary>
        /// Gets or sets the pagina actual.
        /// </summary>
        /// <value>
        /// The pagina actual.
        /// </value>
        public int PaginaActual { get; set; }

        /// <summary>
        /// Gets or sets the tamano de pagina.
        /// </summary>
        /// <value>
        /// The tamano de pagina.
        /// </value>
        public int TamanoDePagina { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [tiene pagina anterior].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [tiene pagina anterior]; otherwise, <c>false</c>.
        /// </value>
        public bool TienePaginaAnterior { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [tiene pagina siguiente].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [tiene pagina siguiente]; otherwise, <c>false</c>.
        /// </value>
        public bool TienePaginaSiguiente { get; set; }

        /// <summary>
        /// Gets or sets the total paginas.
        /// </summary>
        /// <value>
        /// The total paginas.
        /// </value>
        public int TotalPaginas { get; set; }

        /// <summary>
        /// Gets or sets the total registros.
        /// </summary>
        /// <value>
        /// The total registros.
        /// </value>
        public int TotalRegistros { get; set; }
    }
}