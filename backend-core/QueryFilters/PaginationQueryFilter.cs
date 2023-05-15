using BackendCore.Pagination;

namespace BackendCore.QueryFilters
{
    /// <summary>
    /// Paginación de un listado de objetos
    /// </summary>
    public class PaginationQueryFilter
    {
        /// <summary>
        /// Gets or sets the numero de pagina.
        /// </summary>
        /// <value>
        /// The numero de pagina.
        /// </value>
        public int NumeroDePagina { get; set; }

        /// <summary>
        /// Gets or sets the tamaño de pagina.
        /// </summary>
        /// <value>
        /// The tamaño de pagina.
        /// </value>
        public int TamanoDePagina { get; set; }

        /// <summary>
        /// Validates the pagination options.
        /// </summary>
        /// <remarks>Dando sus atributos por defecto</remarks>
        /// <param name="_paginationOptions">The pagination options.</param>
        public void ValidatePaginationOptions(PaginacionOptions _paginationOptions)
        {
            NumeroDePagina = NumeroDePagina == 0 ? _paginationOptions.InicialNumeroDePagina : NumeroDePagina;
            TamanoDePagina = TamanoDePagina == 0 ? _paginationOptions.InicialTamanoDePagina : TamanoDePagina;
        }
    }
}