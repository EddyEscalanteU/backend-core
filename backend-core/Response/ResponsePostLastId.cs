namespace BackendCore.Response
{
    /// <summary>
    /// Respuesta a detalle del servicio de tipo POST con el LastId insertado
    /// </summary>
    public class ResponsePostLastId : ResponsePostDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsePostLastId"/> class.
        /// </summary>
        /// <param name="filasAfectadas">The filas afectadas.</param>
        /// <param name="proceso">The proceso.</param>
        /// <param name="lastId"></param>
        public ResponsePostLastId(int filasAfectadas, string proceso, string lastId) : base(filasAfectadas, proceso)
        {
            LastId = lastId;
        }

        /// <summary>
        /// Gets or sets the last identifier.
        /// </summary>
        /// <value>
        /// The last identifier.
        /// </value>
        public string LastId { get; set; }
    }
}