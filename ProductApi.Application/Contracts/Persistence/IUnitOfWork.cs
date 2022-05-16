using ProductsApi.Domain.Common;

namespace ProductApi.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {

        ISupplierRepository SupplierRepository { get; }
        IProductRepository ProductRepository { get; }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
