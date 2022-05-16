using MediatR;

namespace ProductApi.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Description { get; set; } = string.Empty;
        public string Estado { get; set; } = "activo";
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int SupplierId { get; set; }
    }
}
