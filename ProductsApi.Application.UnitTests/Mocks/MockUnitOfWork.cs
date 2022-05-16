using Moq;
using ProductApi.Application.Contracts.Persistence;

namespace ProductsApi.Application.UnitTests.Mocks
{
    public class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockProductRepository = MockProductRepository.GetProductRepository();

            mockUnitOfWork.Setup(r => r.ProductRepository).Returns(mockProductRepository.Object);

            return mockUnitOfWork;
        }
    }
}
