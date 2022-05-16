using FluentValidation;

namespace ProductApi.Application.Features.Suppliers.Commands
{
    public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierCommandValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("La {Description} no puede estar en blanco")
                .NotNull();

            RuleFor(p => p.Telefono)
                .MaximumLength(10).WithMessage("El {Telefono} no puede exceder los 10 caracetres");
        }
    }
}
