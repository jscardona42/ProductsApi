using MediatR;

namespace ProductApi.Application.Features.Suppliers.Commands
{
    public class CreateSupplierCommand : IRequest<int>
    {
        public string Description { get; set; } = string.Empty;
        public string? Telefono { get; set; }
    }
}
