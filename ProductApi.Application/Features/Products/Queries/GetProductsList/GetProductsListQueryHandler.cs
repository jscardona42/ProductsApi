using AutoMapper;
using MediatR;
using ProductApi.Application.Contracts.Persistence;

namespace ProductApi.Application.Features.Products.Queries.GetProductsList
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, ProductsVm>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductsVm> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsyncP(request._ProductId);

            return _mapper.Map<ProductsVm>(product);
        }
    }
}
