using BackendCore.Common;
using BackendCore.Pagination;
using Newtonsoft.Json;
using System.Net;

namespace BackendCore.Response
{
    /// <summary>
    /// objeto response para los datos de tipo paginación
    /// </summary>
    public class ResponseGetPagination
    {
        /// <summary>
        /// Gets or sets the mensajes.
        /// </summary>
        /// <value>
        /// The mensajes.
        /// </value>
        public Mensaje[] Mensajes { get; set; } = new Mensaje[0];

        /// <summary>
        /// Gets or sets the paginación.
        /// </summary>
        /// <value>
        /// The paginación.
        /// </value>
        public ListaPaginada<object> Paginacion { get; set; } = null!;

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Noes the content.
        /// </summary>
        /// <returns></returns>
        public static ResponseGetPagination NoContent()
        {
            return new ResponseGetPagination()
            {
                Mensajes = DefaultArrayMensaje.GetInformationNoContent(),
                StatusCode = HttpStatusCode.NoContent
            };
        }

        /// <summary>
        /// OK the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public static ResponseGetPagination OK(ListaPaginada<object> result)
        {
            return new ResponseGetPagination()
            {
                Paginacion = result,
                StatusCode = HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Validates the content.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public static ResponseGetPagination ValidateContent(ListaPaginada<object> result)
        {
            if (result.Any())
            {
                return ResponseGetPagination.OK(result);
            }
            else
            {
                return ResponseGetPagination.NoContent();
            }
        }
    }
}