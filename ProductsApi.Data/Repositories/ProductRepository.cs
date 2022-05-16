using Microsoft.EntityFrameworkCore;
using ProductApi.Application.Contracts.Persistence;
using ProductApi.Application.Exceptions;
using ProductsApi.Domain;
using ProductsApi.Infrastructure.Persistence;

namespace ProductsApi.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(SupplierDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Product>> GetAllAsyncP()
        {
            return await _context.Set<Product>().Where(q => q.Estado == "activo").Include(q => q.Supplier).ToListAsync();
        }

        public async Task<Product> GetByIdAsyncP(int id)
        {
            var product = await _context.Set<Product>().Include(q => q.Supplier).FirstOrDefaultAsync(q => q.Id == id && q.Estado == "activo");
            if (product == null)
            {
                throw new NotFoundException(nameof(Product), id);
            }
            return product;
        }

        public async Task<Product> UpdateAsyncP(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
