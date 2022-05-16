using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductApi.Application.Contracts.Persistence;
using ProductApi.Application.Exceptions;
using ProductsApi.Domain;

namespace ProductApi.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProductCommandHandler> _logger;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<DeleteProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var deleteProduct = await _productRepository.GetByIdAsync(request.Id);
            if (deleteProduct == null)
            {
                _logger.LogError($"No se encontró el product id {request.Id}");
                throw new NotFoundException(nameof(Product), request.Id);
            }

            _mapper.Map(request, deleteProduct, typeof(DeleteProductCommand), typeof(Product));

            await _productRepository.DeleteAsync(deleteProduct);
            _logger.LogInformation($"Product {deleteProduct.Id} fue eliminado exitosamente");
            return Unit.Value;
        }
    }
}
