using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductApi.Application.Contracts.Persistence;
using ProductsApi.Domain;

namespace ProductApi.Application.Features.Suppliers.Commands
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, int>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateSupplierCommandHandler> _logger;

        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper, ILogger<CreateSupplierCommandHandler> logger)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplierEntity = _mapper.Map<Supplier>(request);
            var newSupplier = await _supplierRepository.AddAsync(supplierEntity);
            _logger.LogInformation($"Supplier {newSupplier.Id} fue creado exitosamente");
            return newSupplier.Id;
        }
    }
}
