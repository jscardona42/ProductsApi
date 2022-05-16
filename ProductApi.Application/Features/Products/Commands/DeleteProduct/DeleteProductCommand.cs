using MediatR;

namespace ProductApi.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
