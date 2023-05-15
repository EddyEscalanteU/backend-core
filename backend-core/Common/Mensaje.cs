using BackendCore.Enums;

namespace BackendCore.Common
{
    /// <summary>
    /// Objeto para el manejo de mensajes
    /// </summary>
    public class Mensaje
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mensaje"/> class.
        /// </summary>
        /// <param name="tipo">The tipo.</param>
        /// <param name="descripcion">The descripción.</param>
        public Mensaje(string tipo, string descripcion)
        {
            Tipo = tipo;
            Descripcion = descripcion;
        }

        /// <summary>
        /// Gets or sets the descripción.
        /// </summary>
        /// <value>
        /// The descripción.
        /// </value>
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets the tipo.
        /// </summary>
        /// <value>
        /// The tipo.
        /// </value>
        public string Tipo { get; set; }

        /// <summary>
        /// Errors the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Mensaje con el valor de Errors</returns>
        public static Mensaje ErrorMessage(string message)
        {
            return new Mensaje(nameof(TypeMessage.error), message);
        }

        /// <summary>
        /// Informations the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Mensaje con el valor de Information</returns>
        public static Mensaje InformationMessage(string message)
        {
            return new Mensaje(nameof(TypeMessage.information), message);
        }

        /// <summary>
        /// Successes the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Mensaje con el valor de Success</returns>
        public static Mensaje SuccessMessage(string message)
        {
            return new Mensaje(nameof(TypeMessage.success), message);
        }

        /// <summary>
        /// Warnings the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Mensaje con el valor de Warning</returns>
        public static Mensaje WarningMessage(string message)
        {
            return new Mensaje(nameof(TypeMessage.warning), message);
        }
    }
}