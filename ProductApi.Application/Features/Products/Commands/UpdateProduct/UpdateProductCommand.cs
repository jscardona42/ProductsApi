using MediatR;

namespace ProductApi.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime? FechaFabricacion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
    }
}
