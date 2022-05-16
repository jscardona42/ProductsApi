using ProductsApi.Domain;

namespace ProductApi.Application.Contracts.Persistence
{
    public interface ISupplierRepository : IAsyncRepository<Supplier>
    {
        Task<Supplier> GetByIdAsyncS(int Id);
    }
}
