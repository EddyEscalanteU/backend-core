namespace BackendCore.Request.Parameters
{
    /// <summary>
    /// Identificador publico
    /// </summary>
    public interface IIP
    {
        /// <summary>
        /// Gets the IP request.
        /// </summary>
        /// <value>
        /// The IP request.
        /// </value>
        public string IpRequest { get; }
    }
}