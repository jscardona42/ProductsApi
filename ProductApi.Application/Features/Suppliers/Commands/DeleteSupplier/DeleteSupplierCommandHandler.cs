using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductApi.Application.Contracts.Persistence;
using ProductApi.Application.Exceptions;
using ProductsApi.Domain;

namespace ProductApi.Application.Features.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteSupplierCommandHandler> _logger;

        public DeleteSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper, ILogger<DeleteSupplierCommandHandler> logger)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var deleteSupplier = await _supplierRepository.GetByIdAsync(request.Id);
            if (deleteSupplier == null)
            {
                _logger.LogError($"No se encontró el supplier id {request.Id}");
                throw new NotFoundException(nameof(Supplier), request.Id);
            }

            await _supplierRepository.DeleteAsync(deleteSupplier);
            _logger.LogInformation($"Supplier {deleteSupplier.Id} fue eliminado exitosamente");
            return Unit.Value;
        }
    }
}
