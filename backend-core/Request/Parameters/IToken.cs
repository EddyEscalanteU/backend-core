namespace BackendCore.Request.Parameters
{
    /// <summary>
    /// Token de la aplicación
    /// </summary>
    public interface IToken
    {
        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; }
    }
}