using FluentValidation;

namespace ProductApi.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierCommand>
    {
        public UpdateSupplierCommandValidator()
        {
            RuleFor(p => p.Telefono)
                .MaximumLength(10).WithMessage("El {Telefono} no puede exceder los 10 caracteres");
        }
    }
}
