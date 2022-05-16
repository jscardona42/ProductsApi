using AutoFixture;
using ProductApi.Application.Contracts.Persistence;
using Moq;
using ProductsApi.Domain;

namespace ProductsApi.Application.UnitTests.Mocks
{
    public static class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var fixture = new Fixture();
            var products = fixture.CreateMany<Product>().ToList();

            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(x => x.GetAllAsyncP()).ReturnsAsync(products);

            return mockRepository;
        }
    }
}
