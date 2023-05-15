using BackendCore.Common;
using BackendCore.Response;
using FluentValidation.Results;

namespace BackendCore.Validator
{
    /// <summary>
    /// objeto para el manejo central de las validaciones
    /// </summary>
    public static class MainValidator
    {
        /// <summary>
        /// Iterations the validation result.
        /// </summary>
        /// <param name="validationResult">The validation result.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public static ResponseModel IterationValidationResult(ValidationResult validationResult)
        {
            try
            {
                var responseModel = new ResponseModel();
                List<Mensaje> ValidationMessages = new();

                if (!validationResult.IsValid)
                {
                    responseModel.IsValid = false;
                    foreach (ValidationFailure failure in validationResult.Errors)
                    {
                        var mensaje = Mensaje.ErrorMessage(failure.ErrorMessage);
                        ValidationMessages.Add(mensaje);
                    }
                    responseModel.ValidationMessages = ValidationMessages;
                }

                return responseModel;
            }
            catch (Exception exception)
            {
                throw new NotSupportedException(exception.Message);
            }
        }
    }
}