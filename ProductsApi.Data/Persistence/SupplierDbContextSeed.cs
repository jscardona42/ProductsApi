using Microsoft.Extensions.Logging;
using ProductsApi.Infrastructure.Persistence;
using ProductsApi.Domain;

namespace ProductsApi.Infrastructure.Persistence
{
    public class SupplierDbContextSeed
    {
        public static async Task SeedAsync(SupplierDbContext context, ILogger<SupplierDbContextSeed> logger)
        {
            if (!context.Suppliers!.Any())
            {
                context.Suppliers!.AddRange(GetPreConfiguredSupplier());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos registros en la base de datos {context}", typeof(SupplierDbContext).Name);
            }
        }

        private static IEnumerable<Supplier> GetPreConfiguredSupplier()
        {
            return new List<Supplier>
            {
                new Supplier
                {
                    Description = "Xiaomi",
                    Telefono = "+577986352"
                },
                new Supplier
                {
                    Description = "Apple",
                    Telefono = "+578968652"
                },
                new Supplier
                {
                    Description = "Claro Colombia",
                    Telefono = "+578945621"
                }
            };
        }
    }
}
