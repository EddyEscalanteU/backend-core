using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace BackendCore.Extensions
{
    /// <summary>
    /// Extension de métodos para el Header de los request.
    /// </summary>
    public static class HeaderExtensions
    {
        #region Methods

        /// <summary>
        /// Obtener el valor del headerKey dentro del Header del request
        /// </summary>
        /// <param name="Headers">The headers.</param>
        /// <param name="headerKey">Nombre del parámetro existente en el Header del request</param>
        /// <returns>El valor que representa el headerKey</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetHeaderValue(this IHeaderDictionary Headers, string headerKey)
        {
            if (Headers is null)
            {
                throw new ArgumentNullException($"{Headers}: No tiene un valor asignado");
            }
            Headers.TryGetValue(headerKey, out var headerValue);
            CheckHeader(headerKey, headerValue);
            return headerValue;
        }

        /// <summary>
        /// Verifica el valor del headerKey dentro del Header del request
        /// </summary>
        /// <param name="headerKey">Nombre del parámetro existente en el Header del request</param>
        /// <param name="headerValue">Valor del parámetro existente en el Header del request</param>
        /// <remarks>La excepción si no el headerKey no tuviera un valor</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        private static void CheckHeader(string headerKey, StringValues headerValue)
        {
            if (headerValue == StringValues.Empty)
            {
                throw new ArgumentNullException($"{headerKey}: No tiene un valor asignado en el Header");
            }
        }

        #endregion Methods
    }
}