namespace BackendCore.Common
{
    /// <summary>
    /// Colección de mensajes
    /// </summary>
    public static class ArrayMensaje
    {
        /// <summary>
        /// Gets the error messages.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>El texto del mensaje a un tipo array</returns>
        public static Mensaje[] GetErrorMessages(string message)
        {
            var messageList = new List<Mensaje>
            {
                Mensaje.ErrorMessage(message)
            };
            return messageList.ToArray();
        }

        /// <summary>
        /// Gets the information message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>El texto del mensaje a un tipo array</returns>
        public static Mensaje[] GetInformationMessage(string message)
        {
            var messageList = new List<Mensaje>
            {
                Mensaje.InformationMessage(message)
            };
            return messageList.ToArray();
        }

        /// <summary>
        /// Gets the success message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>El texto del mensaje a un tipo array</returns>
        public static Mensaje[] GetSuccessMessage(string message)
        {
            var messageList = new List<Mensaje>
            {
                Mensaje.SuccessMessage(message)
            };
            return messageList.ToArray();
        }

        /// <summary>
        /// Gets the warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>El texto del mensaje a un tipo array</returns>
        public static Mensaje[] GetWarningMessage(string message)
        {
            var messageList = new List<Mensaje>
            {
                Mensaje.WarningMessage(message)
            };
            return messageList.ToArray();
        }
    }
}