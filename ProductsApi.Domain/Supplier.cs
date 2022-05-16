
using ProductsApi.Domain.Common;

namespace ProductsApi.Domain
{
    public class Supplier : BaseDomainModel
    {
        public string Description { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
