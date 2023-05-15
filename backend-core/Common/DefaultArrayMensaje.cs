using BackendCore.Helpers;

namespace BackendCore.Common
{

    /// <summary>
    /// Valores por defecto del array
    /// </summary>
    public static class DefaultArrayMensaje
    {
        /// <summary>
        /// Gets the information error token.
        /// </summary>
        /// <returns></returns>
        public static Mensaje[] GetInformationErrorToken()
        {
            var messageList = new List<Mensaje>
            {
                Mensaje.InformationMessage(ConstantesCore.ERROR_TOKEN)
            };
            return messageList.ToArray();
        }

        /// <summary>
        /// Mensaje informativo de que no existe contenido
        /// </summary>
        /// <returns>ConstantesCore.NO_CONTENT</returns>
        public static Mensaje[] GetInformationNoContent()
        {
            var messageList = new List<Mensaje>
            {
                Mensaje.InformationMessage(ConstantesCore.NO_CONTENT)
            };
            return messageList.ToArray();
        }

        /// <summary>
        /// Successes the OK.
        /// </summary>
        /// <returns>ConstantesCore.OK</returns>
        public static Mensaje[] GetSuccessOK()
        {
            var messageList = new List<Mensaje>
            {
                Mensaje.SuccessMessage(ConstantesCore.OK)
            };
            return messageList.ToArray();
        }
    }
}