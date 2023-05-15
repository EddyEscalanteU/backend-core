using BackendCore.Entities;
using FluentValidation;

namespace BackendCore.Validator
{
    /// <summary>
    /// Reglas de validación para la entidad: <see cref="Identifier"/>
    /// </summary>
    public class IdentifierValidator : AbstractValidator<Identifier>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentifierValidator"/> class.
        /// </summary>
        public IdentifierValidator()
        {
            RuleFor(objeto => objeto.Id)
                .NotNull()
                .WithMessage("El valor del ID es requerido")
                .NotEmpty()
                .WithMessage("El valor del ID no debe ser vació");
        }
    }
}