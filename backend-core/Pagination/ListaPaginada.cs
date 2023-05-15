namespace BackendCore.Pagination
{
    /// <summary>
    /// Objeto para almacenar la lista paginada
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListaPaginada<T> : List<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListaPaginada{T}"/> class.
        /// </summary>
        /// <param name="datos">The datos.</param>
        /// <param name="count">The count.</param>
        /// <param name="numeroDePagina">The numero de pagina.</param>
        /// <param name="tamanoDePagina">The tamaño de pagina.</param>
        public ListaPaginada(List<T> datos, int count, int numeroDePagina, int tamanoDePagina)
        {
            TotalRegistros = count;
            TamanoDePagina = tamanoDePagina;
            PaginaActual = numeroDePagina;
            TotalPaginas = (int)Math.Ceiling(TotalRegistros / (double)TamanoDePagina);

            AddRange(datos);
        }

        /// <summary>
        /// Gets the numero pagina anterior.
        /// </summary>
        /// <value>
        /// The numero pagina anterior.
        /// </value>
        public int? NumeroPaginaAnterior => TienePaginaAnterior ? PaginaActual - 1 : (int?)null;

        /// <summary>
        /// Gets the numero pagina siguiente.
        /// </summary>
        /// <value>
        /// The numero pagina siguiente.
        /// </value>
        public int? NumeroPaginaSiguiente => TienePaginaSiguiente ? PaginaActual + 1 : (int?)null;

        /// <summary>
        /// Gets or sets the pagina actual.
        /// </summary>
        /// <value>
        /// The pagina actual.
        /// </value>
        public int PaginaActual { get; set; }

        /// <summary>
        /// Gets or sets the tamaño de pagina.
        /// </summary>
        /// <value>
        /// The tamaño de pagina.
        /// </value>
        public int TamanoDePagina { get; set; }

        /// <summary>
        /// Gets a value indicating whether [tiene pagina anterior].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [tiene pagina anterior]; otherwise, <c>false</c>.
        /// </value>
        public bool TienePaginaAnterior => PaginaActual > 1;

        /// <summary>
        /// Gets a value indicating whether [tiene pagina siguiente].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [tiene pagina siguiente]; otherwise, <c>false</c>.
        /// </value>
        public bool TienePaginaSiguiente => PaginaActual < TotalPaginas;

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

        /// <summary>
        /// Crear the specified registros.
        /// </summary>
        /// <param name="registros">The registros.</param>
        /// <param name="numeroDePagina">The numero de pagina.</param>
        /// <param name="tamanoDePagina">The tamaño de pagina.</param>
        /// <returns></returns>
        public static ListaPaginada<T> Crear(IEnumerable<T> registros, int numeroDePagina, int tamanoDePagina)
        {
            var count = registros.Count();
            var datos = registros.Skip((numeroDePagina - 1) * tamanoDePagina).Take(tamanoDePagina).ToList();
            return new ListaPaginada<T>(datos, count, numeroDePagina, tamanoDePagina);
        }

        /// <summary>
        /// Crear the paginación.
        /// </summary>
        /// <param name="registros">The registros.</param>
        /// <param name="count">The count.</param>
        /// <param name="numeroDePagina">The numero de pagina.</param>
        /// <param name="tamanoDePagina">The tamaño de pagina.</param>
        /// <returns></returns>
        public static ListaPaginada<T> CrearPaginacion(IEnumerable<T> registros, int count, int numeroDePagina, int tamanoDePagina)
        {
            return new ListaPaginada<T>(registros.ToList(), count, numeroDePagina, tamanoDePagina);
        }
    }
}