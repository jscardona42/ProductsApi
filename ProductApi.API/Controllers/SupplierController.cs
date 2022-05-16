using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Application.Features.Suppliers.Commands;
using System.Net;

namespace ProductApi.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateSupplier")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateSupplier([FromBody] CreateSupplierCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
