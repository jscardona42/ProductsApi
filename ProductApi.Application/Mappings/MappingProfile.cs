using AutoMapper;
using ProductApi.Application.Features.Products.Commands.CreateProduct;
using ProductApi.Application.Features.Products.Commands.DeleteProduct;
using ProductApi.Application.Features.Products.Commands.UpdateProduct;
using ProductApi.Application.Features.Products.Queries.GetProducts;
using ProductApi.Application.Features.Products.Queries.GetProductsList;
using ProductApi.Application.Features.Suppliers.Commands;
using ProductApi.Application.Features.Suppliers.Queries.GetSuppliersList;
using ProductsApi.Domain;

namespace ProductApi.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductsVm>();
            CreateMap<Supplier, SuppliersVm>();
            CreateMap<CreateSupplierCommand, Supplier>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<DeleteProductCommand, Product>();
            CreateMap<GetProductsQuery, ProductsVm>();
        }
    }
}
