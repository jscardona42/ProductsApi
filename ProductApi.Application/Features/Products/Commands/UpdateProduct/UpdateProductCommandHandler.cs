using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductApi.Application.Contracts.Persistence;
using ProductApi.Application.Exceptions;
using ProductsApi.Domain;

namespace ProductApi.Application.Features.Products.Commands.UpdateProduct
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updateProduct = await _productRepository.GetByIdAsyncP(request.Id);
            if (updateProduct == null)
            {
                _logger.LogError($"No se encontró el product id {request.Id}");
                throw new NotFoundException(nameof(Product), request.Id);
            }

            var fechaFab = request.FechaFabricacion;
            var fechaVen = request.FechaVencimiento;

            await DatesValidate(fechaFab, fechaVen, updateProduct);
            var datos = updateProduct.Description;

            _mapper.Map(request, updateProduct, typeof(UpdateProductCommand), typeof(Product));

            var dataos1 = updateProduct.Description;

            await _productRepository.UpdateAsyncP(updateProduct);
            _logger.LogInformation($"Product {updateProduct.Id} fue actualizado exitosamente");
            return Unit.Value;
        }

        public async Task DatesValidate(DateTime? fechaFab, DateTime? fechaVen, Product updateProduct)
        {
            if (fechaFab == null)
            {
                fechaFab = updateProduct.FechaFabricacion;
            }
            if (fechaVen == null)
            {
                fechaVen = updateProduct.FechaVencimiento;
            }

            if (fechaFab >= fechaVen)
            {
                throw new Exception("La fecha de vencimiento debe ser mayor a la fecha de fabricación");
            };
        }
    }
}
