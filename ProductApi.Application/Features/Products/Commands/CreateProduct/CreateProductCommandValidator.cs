using FluentValidation;

namespace ProductApi.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Description)
               .NotEmpty().WithMessage("La {Description} no puede estar en blanco")
               .NotNull();

            RuleFor(p => p.Estado)
               .NotEmpty().WithMessage("El {Estado} no puede estar en blanco")
               .NotNull();

            RuleFor(p => p.FechaFabricacion)
                .NotEmpty().WithMessage("La {FechaFabricacion} no puede estar en blanco")
                .NotNull();

            RuleFor(p => p.FechaVencimiento)
               .NotEmpty().WithMessage("La {FechaVencimiento} no puede estar en blanco")
               .NotNull();

            //RuleFor(p => p.FechaVencimiento).GreaterThan(r => r.FechaFabricacion)
            //    .WithMessage("La fecha de vencimiento debe ser mayor a la fecha de fabricación");
        }
    }
}
