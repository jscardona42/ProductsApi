using MediatR;

namespace ProductApi.Application.Features.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<ProductsVm>
    {
        public int _ProductId { get; set; }

        public GetProductsListQuery(int productId)
        {
            _ProductId = productId;
            if (_ProductId == 0)
            {
                throw new ArgumentNullException(nameof(_ProductId));
            }
        }
    }
}
