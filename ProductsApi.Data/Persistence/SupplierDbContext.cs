using Microsoft.EntityFrameworkCore;
using ProductsApi.Domain;
using ProductsApi.Domain.Common;

namespace ProductsApi.Infrastructure.Persistence
{
    public class SupplierDbContext : DbContext
    {
        public SupplierDbContext(DbContextOptions<SupplierDbContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=SEBASTIÁN\MSSQLSERVER01; Initial Catalog=ProductsApi;Integrated Security=true")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}
        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .HasMany(m => m.Products)
                .WithOne(m => m.Supplier)
                .HasForeignKey(m => m.SupplierId)
                .IsRequired();
        }
        public DbSet<Supplier>? Suppliers { get; set; }

        public DbSet<Product>? Products { get; set; }
    }
}
