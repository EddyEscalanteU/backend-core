using BackendCore.Common;
using BackendCore.Pagination;

namespace BackendCore.Response
{
    /// <summary>
    /// Manipulación de los datos de paginación para el controlador
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        /// <param name="responseGetPagination">The response get pagination.</param>
        private ApiResponse(ResponseGetPagination responseGetPagination)
        {
            Datos = responseGetPagination.Paginacion;
            Mensajes = responseGetPagination.Mensajes;
            Paginacion = new Paginacion(responseGetPagination);
        }

        /// <summary>
        /// Gets or sets the datos.
        /// </summary>
        /// <value>
        /// The datos.
        /// </value>
        public ListaPaginada<object> Datos { get; set; }

        /// <summary>
        /// Gets or sets the mensajes.
        /// </summary>
        /// <value>
        /// The mensajes.
        /// </value>
        public Mensaje[] Mensajes { get; set; }

        /// <summary>
        /// Gets or sets the paginación.
        /// </summary>
        /// <value>
        /// The paginación.
        /// </value>
        public Paginacion Paginacion { get; set; }

        /// <summary>
        /// Loads the response get pagination.
        /// </summary>
        /// <param name="responseGetPagination">The response get pagination.</param>
        /// <returns></returns>
        public static ApiResponse LoadResponseGetPagination(ResponseGetPagination responseGetPagination)
        {
            return new ApiResponse(responseGetPagination);
        }
    }
}