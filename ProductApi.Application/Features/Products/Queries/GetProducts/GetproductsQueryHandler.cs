using AutoMapper;
using MediatR;
using ProductApi.Application.Contracts.Persistence;
using ProductApi.Application.Features.Products.Queries.GetProductsList;

namespace ProductApi.Application.Features.Products.Queries.GetProducts
{
    public class GetproductsQueryHandler : IRequestHandler<GetProductsQuery, IReadOnlyList<ProductsVm>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetproductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductsVm>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsyncP();

            return _mapper.Map<IReadOnlyList<ProductsVm>>(products);
        }
    }
}
