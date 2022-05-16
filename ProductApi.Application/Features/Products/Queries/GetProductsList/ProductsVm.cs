using ProductApi.Application.Features.Suppliers.Queries.GetSuppliersList;

namespace ProductApi.Application.Features.Products.Queries.GetProductsList
{
    public class ProductsVm
    {
        public string? Description { get; set; }
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public virtual SuppliersVm? Supplier { get; set; }
    }
}
