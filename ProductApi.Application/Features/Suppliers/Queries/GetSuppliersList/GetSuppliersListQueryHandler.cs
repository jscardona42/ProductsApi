using AutoMapper;
using MediatR;
using ProductApi.Application.Contracts.Persistence;

namespace ProductApi.Application.Features.Suppliers.Queries.GetSuppliersList
{
    public class GetSuppliersListQueryHandler : IRequestHandler<GetSuppliersListQuery, SuppliersVm>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSuppliersListQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<SuppliersVm> Handle(GetSuppliersListQuery request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsyncS(request._SupplierId);

            return _mapper.Map<SuppliersVm>(supplier);
        }


    }
}
