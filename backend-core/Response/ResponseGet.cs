using BackendCore.Common;
using Newtonsoft.Json;
using System.Net;

namespace BackendCore.Response
{
    /// <summary>
    /// objeto que se retorna para las peticiones GET
    /// </summary>
    public class ResponseGet
    {
        /// <summary>
        /// Gets or sets the datos.
        /// </summary>
        /// <value>
        /// The datos.
        /// </value>
        [JsonProperty("datos")]
        public object Datos { get; set; } = null!;

        /// <summary>
        /// Gets or sets the mensajes.
        /// </summary>
        /// <value>
        /// The mensajes.
        /// </value>
        [JsonProperty("mensajes")]
        public Mensaje[] Mensajes { get; set; } = null!;

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        [JsonIgnore]
        [JsonProperty("statusCode")]
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Tokens the error message.
        /// </summary>
        /// <returns></returns>
        public static ResponseGet TokenErrorMessage()
        {
            return new ResponseGet()
            {
                Mensajes = DefaultArrayMensaje.GetInformationErrorToken(),
                StatusCode = HttpStatusCode.Unauthorized
            };
        }

        /// <summary>
        /// Internals the server error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public static ResponseGet InternalServerErrorMessage(Exception exception)
        {
            return new ResponseGet()
            {
                Mensajes = ArrayMensaje.GetErrorMessages(exception.Message)
            };
        }

        /// <summary>
        /// Noes the content.
        /// </summary>
        /// <returns></returns>
        public static ResponseGet NoContent()
        {
            return new ResponseGet()
            {
                Mensajes = DefaultArrayMensaje.GetInformationNoContent(),
                StatusCode = HttpStatusCode.NoContent
            };
        }

        /// <summary>
        /// OK the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="mensajes">The mensajes.</param>
        /// <returns></returns>
        public static ResponseGet OK(object result, Mensaje[]? mensajes = null)
        {
            return new ResponseGet()
            {
                Datos = result,
                Mensajes = mensajes ?? DefaultArrayMensaje.GetSuccessOK(),
                StatusCode = HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Validates the content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public static ResponseGet ValidateContent<T>(IEnumerable<T> result)
        {
            if (result is object && result.Any())
            {
                return OK(result);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Validates the content.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public static ResponseGet ValidateContent(object result)
        {
            if (result is object)
            {
                return OK(result);
            }
            else
            {
                return NoContent();
            }
        }
    }
}