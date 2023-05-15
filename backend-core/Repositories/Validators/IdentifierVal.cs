using BackendCore.Entities;
using BackendCore.Interfaces.Validators;
using BackendCore.Response;
using BackendCore.Validator;

namespace BackendCore.Repositories.Validators
{
    /// <summary>
    /// Implementación de los métodos de validación
    /// </summary>
    public class IdentifierVal : IIdentifierVal
    {
        /// <summary>
        /// Validates the identifier.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>
        /// ResponseModel object
        /// </returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public ResponseModel ValidateIdentifier(Identifier identifier)
        {
            try
            {
                IdentifierValidator validator = new();
                var validationResult = validator.Validate(identifier);
                return MainValidator.IterationValidationResult(validationResult);
            }
            catch (Exception exception)
            {
                throw new NotSupportedException(exception.Message);
            }
        }

        /// <summary>
        /// Validates the identifier by identifier value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// ResponseModel object
        /// </returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public ResponseModel ValidateIdentifierById(string id)
        {
            try
            {
                IdentifierValidator validator = new();
                var validationResult = validator.Validate(new Identifier() { Id = id });
                return MainValidator.IterationValidationResult(validationResult);
            }
            catch (Exception exception)
            {
                throw new NotSupportedException(exception.Message);
            }
        }
    }
}