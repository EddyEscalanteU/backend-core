namespace BackendCore.Response
{
    /// <summary>
    /// Respuesta a detalle del servicio de tipo POST 
    /// </summary>
    public class ResponsePostDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsePostDetail"/> class.
        /// </summary>
        /// <param name="filasAfectadas">The filas afectadas.</param>
        /// <param name="proceso">The proceso.</param>
        public ResponsePostDetail(int filasAfectadas, string proceso)
        {
            FilasAfectadas = filasAfectadas;
            Proceso = proceso;
        }

        /// <summary>
        /// Gets or sets the filas afectadas.
        /// </summary>
        /// <value>
        /// The filas afectadas.
        /// </value>
        public int FilasAfectadas { get; set; }

        /// <summary>
        /// Gets or sets the proceso.
        /// </summary>
        /// <value>
        /// The proceso.
        /// </value>
        public string Proceso { get; set; }

        /// <summary>
        /// Validates the emails.
        /// </summary>
        /// <param name="countMails">The count mails.</param>
        /// <returns></returns>
        public static ResponsePostDetail ValidateEmails(int countMails)
        {
            if (countMails > 0)
            {
                return new ResponsePostDetail(countMails, "Envió de correos electrónicos");
            }
            else
            {
                return new ResponsePostDetail(0, "No se envió ningún correo electrónico");
            }
        }
    }
}