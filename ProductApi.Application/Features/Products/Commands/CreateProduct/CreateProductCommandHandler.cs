using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductApi.Application.Contracts.Persistence;
using ProductApi.Application.Exceptions;
using ProductsApi.Domain;

namespace ProductApi.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(IProductRepository productRepository, ISupplierRepository supplierRepository, IMapper mapper, ILogger<CreateProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsyncS(request.SupplierId);
            if (supplier == null)
            {
                _logger.LogError($"No se encontró el supplier id {request.SupplierId}");
                throw new NotFoundException(nameof(Product), request.SupplierId);
            }
            var fechaFab = request.FechaFabricacion;
            var fechaVen = request.FechaVencimiento;

            await DatesValidate(request.FechaFabricacion, request.FechaVencimiento);
            var ProductEntity = _mapper.Map<Product>(request);
            var newProduct = await _productRepository.AddAsync(ProductEntity);
            _logger.LogInformation($"Product {newProduct.Id} fue creado exitosamente");
            return newProduct.Id;
        }

        public async Task DatesValidate(DateTime fechaFab, DateTime fechaVen)
        {
            if (fechaFab >= fechaVen)
            {
                throw new Exception("La fecha de vencimiento debe ser mayor a la fecha de fabricación");
            };
        }
    }
}
