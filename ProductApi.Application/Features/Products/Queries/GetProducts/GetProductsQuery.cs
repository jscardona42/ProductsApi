using MediatR;
using ProductApi.Application.Features.Products.Queries.GetProductsList;

namespace ProductApi.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<IReadOnlyList<ProductsVm>>
    {
        public GetProductsQuery()
        {

        }
    }
}
