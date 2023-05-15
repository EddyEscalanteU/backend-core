namespace BackendCore.Exceptions
{

    /// <summary>
    /// Manejo de las excepciones de la lógica de negocio
    /// </summary>
    public class BussinesException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BussinesException"/> class.
        /// </summary>
        public BussinesException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BussinesException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BussinesException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BussinesException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public BussinesException(string message, Exception exception) :
            base(message, exception)
        {
        }
    }
}