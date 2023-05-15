using BackendCore.Extensions;
using BackendCore.Request.Parameters;
using Microsoft.AspNetCore.Http;

namespace BackendCore.Request
{
    /// <summary>
    /// Información de la cabecera de una solicitud
    /// </summary>
    public class RequestHeaders : IToken, IDatabaseKey, IIdUsuarioRequest, IIP
    {
        /// <summary>
        /// Obtiene el nombre del host del cliente donde se realiza la solicitud
        /// </summary>
        /// <value>
        /// The name of the host.
        /// </value>
        public string IpRequest
        {
            get
            {
                if (Headers is null)
                {
                    throw new ArgumentNullException($"{Headers}: No tiene un valor asignado");
                }
                const string headerKey = "IpRequest";
                return Headers.GetHeaderValue(headerKey);
            }
        }

        /// <summary>
        /// Obtiene el Id del usuario que esta realizando la solicitud
        /// </summary>
        /// <remarks>
        /// En caso de Graduados es el IdPersonaGraduado quien toma el valor
        /// En caso de Odontología es el IdPersona quien toma el valor
        /// </remarks>
        /// <value>
        /// The identifier usuario request.
        /// </value>
        public string IdUsuarioRequest
        {
            get
            {
                if (Headers is null)
                {
                    throw new ArgumentNullException($"{Headers}: No tiene un valor asignado");
                }
                const string headerKey = "IdUsuarioRequest";
                return Headers.GetHeaderValue(headerKey);
            }
        }

        /// <summary>
        /// Obtiene el Token único por proyecto
        /// </summary>
        /// <remarks>
        /// Este atributo es utilizado para el servicio de Authentication
        /// </remarks>
        /// <value>
        /// The token.
        /// </value>
        public string Token
        {
            get
            {
                if (Headers is null)
                {
                    throw new ArgumentNullException($"{Headers}: No tiene un valor asignado");
                }
                const string headerKey = "Token";
                return Headers.GetHeaderValue(headerKey);
            }
        }

        /// <summary>
        /// Gets the database key.
        /// </summary>
        /// <value>
        /// The database key para obtener los datos de la BD
        /// </value>
        public string DatabaseKey
        {
            get
            {
                if (Headers is null)
                {
                    throw new ArgumentNullException($"{Headers}: No tiene un valor asignado");
                }
                const string headerKey = "DatabaseKey";
                return Headers.GetHeaderValue(headerKey);
            }
        }

        /// <summary>
        /// Gets the linked server.
        /// </summary>
        /// <value>
        /// The linked server.
        /// </value>
        public string LinkedServer
        {
            get
            {
                if (Headers is null)
                {
                    throw new ArgumentNullException($"{Headers}: No tiene un valor asignado");
                }
                const string headerKey = "LinkedServer";
                if (Headers.TryGetValue(headerKey, out var headerValue))
                {
                    return headerValue;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get
            {
                if (Headers is null)
                {
                    throw new ArgumentNullException($"{Headers}: No tiene un valor asignado");
                }
                const string headerKey = "UserName";
                return Headers.GetHeaderValue(headerKey);
            }
        }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        /// <value>
        /// The headers.
        /// </value>
        protected IHeaderDictionary? Headers { get; set; }

        /// <summary>
        /// Obtiene todos los Headers del request
        /// </summary>
        /// <returns>Un objeto de tipo IHeaderDictionary que tiene todos los parámetros del Header</returns>
        public IHeaderDictionary GetHeaders()
        {
            if (Headers is null)
            {
                throw new ArgumentNullException($"{Headers}: No tiene un valor asignado");
            }
            return Headers;
        }
    }
}