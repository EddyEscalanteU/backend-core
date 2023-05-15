using BackendCore.Entities;

namespace BackendCore.Request.Parameters
{
    /// <summary>
    /// Identificador
    /// </summary>
    public interface IIdentifier
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Identifier Id { get; }
    }
}