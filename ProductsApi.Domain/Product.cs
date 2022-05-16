using ProductsApi.Domain.Common;

namespace ProductsApi.Domain
{
    public class Product : BaseDomainModel
    {
        public string? Description { get; set; }
        public string Estado { get; set; } = string.Empty;
        public DateTime? FechaFabricacion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? SupplierId { get; set; }
        public virtual Supplier? Supplier { get; set; }

    }
}
