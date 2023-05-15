using Backend.Core.Response;
using BackendCore.Common;
using System.Net;

namespace BackendCore.Response
{
    /// <summary>
    /// Mandar la respuesta del modelo de validación
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseModel"/> class.
        /// </summary>
        public ResponseModel()
        {
            IsValid = true;
            ValidationMessages = new List<Mensaje>();
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets the validation messages.
        /// </summary>
        /// <value>
        /// The validation messages.
        /// </value>
        public List<Mensaje> ValidationMessages { get; set; }

        /// <summary>
        /// Bads the request by get.
        /// </summary>
        /// <returns></returns>
        public ResponseGet BadRequestByGet()
        {
            return new ResponseGet()
            {
                Mensajes = ValidationMessages.ToArray(),
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        /// <summary>
        /// Bads the request by post.
        /// </summary>
        /// <returns></returns>
        public ResponsePost BadRequestByPost()
        {
            return new ResponsePost()
            {
                Mensajes = ValidationMessages.ToArray(),
                StatusCode = HttpStatusCode.BadRequest
            };
        }
    }
}