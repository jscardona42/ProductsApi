using AutoMapper;
using Moq;
using ProductApi.Application.Contracts.Persistence;
using ProductApi.Application.Features.Products.Queries.GetProductsList;
using ProductApi.Application.Mappings;
using ProductsApi.Application.UnitTests.Mocks;
using Xunit;

namespace ProductsApi.Application.UnitTests.Features.Product.Queries
{
    public class GetProductsListQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public GetProductsListQueryHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetProductsListTest()
        {
            //var handler = new GetProductsListQueryHandler(ProductRepository,_unitOfWork.Object, _mapper);

            //var result = await handler.Han

        }
    }
}
