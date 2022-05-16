using ProductApi.Application.Contracts.Persistence;
using ProductApi.Application.Exceptions;
using ProductsApi.Domain;
using ProductsApi.Infrastructure.Persistence;

namespace ProductsApi.Infrastructure.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(SupplierDbContext context) : base(context)
        {

        }
        public async Task<Supplier> GetByIdAsyncS(int id)
        {
            var supplier = await _context.Set<Supplier>().FindAsync(id);
            if (supplier == null)
            {
                throw new NotFoundException(nameof(Supplier), id);
            }
            return supplier;
        }
    }
}
