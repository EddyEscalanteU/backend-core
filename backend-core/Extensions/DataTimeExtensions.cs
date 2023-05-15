using System.Globalization;

namespace BackendCore.Extensions
{
    /// <summary>
    /// Extension para los tipo de datos de fechas.
    /// </summary>
    public static class DataTimeExtensions
    {
        /// <summary>
        /// Removes the seconds.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The same date but without seconds</returns>
        public static DateTime RemoveSeconds(this DateTime date)
        {
            return date.AddSeconds(-date.Second);
        }

        /// <summary>
        /// Validates the event.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static DateTime ValidateEvent(this DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    date = date.AddDays(-2);
                    break;
                case DayOfWeek.Monday:
                    break;
                case DayOfWeek.Tuesday:
                    date = date.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    break;
                case DayOfWeek.Thursday:
                    date = date.AddDays(-1);
                    break;
                case DayOfWeek.Friday:
                    break;
                case DayOfWeek.Saturday:
                    date = date.AddDays(-1);
                    break;
            }
            return date;
        }
        /// <summary>
        /// Gets the today.
        /// </summary>
        /// <value>
        /// The today.
        /// </value>
        public static DateTime Today
        {
            get
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Gets the yesterday.
        /// </summary>
        /// <value>
        /// The yesterday.
        /// </value>
        public static DateTime Yesterday
        {
            get
            {
                return DateTime.Now.AddDays(-1);
            }
        }

        /// <summary>
        /// Eses the una fecha valida.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool EsUnaFechaValida(this string value)
        {
            return DateTime.TryParseExact(value, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        /// <summary>
        /// Determines whether [is valid date].
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        ///   <c>true</c> if [is valid date] [the specified date]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidDate(this DateTime date)
        {
            return !date.Equals(default);
        }

        /// <summary>
        /// Normals the format.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>dd/MM/y h:mm tt</returns>
        public static string NormalFormat(this DateTime value)
        {
            return value.ToString("dd/MM/yyyy HH:mm");
        }

        /// <summary>
        /// Literals the format.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>dddd, dd MMMM yyyy h:mm tt</returns>
        public static string LiteralFormat(this DateTime value)
        {
            return value.ToString("dddd, dd MMMM yyyy h:mm tt");
        }
    }
}