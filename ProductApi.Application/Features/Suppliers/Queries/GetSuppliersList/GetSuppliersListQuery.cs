using MediatR;

namespace ProductApi.Application.Features.Suppliers.Queries.GetSuppliersList
{
    public class GetSuppliersListQuery : IRequest<SuppliersVm>
    {
        public int _SupplierId { get; set; }

        public GetSuppliersListQuery(int supplierId)
        {
            _SupplierId = supplierId;
            if (_SupplierId == 0)
            {
                throw new ArgumentNullException(nameof(_SupplierId));
            }
        }
    }
}
