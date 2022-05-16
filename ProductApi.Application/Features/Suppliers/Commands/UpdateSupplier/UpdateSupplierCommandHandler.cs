using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductApi.Application.Contracts.Persistence;
using ProductApi.Application.Exceptions;
using ProductsApi.Domain;

namespace ProductApi.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateSupplierCommandHandler> _logger;

        public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper, ILogger<UpdateSupplierCommandHandler> logger)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var updateSupplier = await _supplierRepository.GetByIdAsync(request.Id);
            if (updateSupplier == null)
            {
                _logger.LogError($"No se encontró el supplier id {request.Id}");
                throw new NotFoundException(nameof(Supplier), request.Id);
            }

            _mapper.Map(request, updateSupplier, typeof(UpdateSupplierCommand), typeof(Supplier));

            await _supplierRepository.UpdateAsync(updateSupplier);
            _logger.LogInformation($"Supplier {updateSupplier.Id} fue actualizado exitosamente");
            return Unit.Value;
        }
    }
}
