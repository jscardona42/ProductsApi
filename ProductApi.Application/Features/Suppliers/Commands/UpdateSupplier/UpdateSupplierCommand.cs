using MediatR;

namespace ProductApi.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommand : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; } = String.Empty;

        public string? Telefono { get; set; }
    }
}
