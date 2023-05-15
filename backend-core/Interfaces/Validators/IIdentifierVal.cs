using BackendCore.Entities;
using BackendCore.Response;

namespace BackendCore.Interfaces.Validators
{
    /// <summary>
    /// Interfaz para validar los identificadores
    /// </summary>
    public interface IIdentifierVal
    {
        /// <summary>
        /// Validates the identifier.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>ResponseModel object</returns>
        public ResponseModel ValidateIdentifier(Identifier identifier);

        /// <summary>
        /// Validates the identifier by identifier value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ResponseModel object</returns>
        public ResponseModel ValidateIdentifierById(string id);
    }
}