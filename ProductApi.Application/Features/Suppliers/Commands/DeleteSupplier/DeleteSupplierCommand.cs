using MediatR;

namespace ProductApi.Application.Features.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommand : IRequest
    {
        public int Id { get; set; }

        public static implicit operator int(DeleteSupplierCommand v)
        {
            throw new NotImplementedException();
        }
    }
}
