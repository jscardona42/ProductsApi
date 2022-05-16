using ProductsApi.Domain;

namespace ProductApi.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<Product> GetByIdAsyncP(int Id);
        Task<IReadOnlyList<Product>> GetAllAsyncP();
        Task<Product> UpdateAsyncP(Product entity);
    }
}
