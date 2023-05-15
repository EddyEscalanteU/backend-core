using Microsoft.AspNetCore.Http;

namespace BackendCore.Request
{
    /// <summary>
    /// Patron de diseño para la construcción de un objeto
    /// </summary>
    public class FluentRequest : RequestBody
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>La instancia con los valores ingresados</returns>
        public static FluentRequest Build()
        {
            return new FluentRequest();
        }

        /// <summary>
        /// Adds the body.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <returns>Registra el Body al objeto Fluent</returns>
        public FluentRequest AddBody(object body)
        {
            Body = body;
            return this;
        }

        /// <summary>
        /// Adds the headers.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <returns>Registra el Header al objeto Fluent</returns>
        public FluentRequest AddHeaders(IHeaderDictionary header)
        {
            Headers = header;
            return this;
        }

        /// <summary>
        /// Adds the detalle.
        /// </summary>
        /// <param name="detalle">The detalle.</param>
        /// <returns></returns>
        public FluentRequest AddDetalle(string detalle)
        {
            Detalle = detalle;
            return this;
        }
    }
}