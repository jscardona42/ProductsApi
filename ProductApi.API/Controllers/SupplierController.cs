using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Application.Features.Suppliers.Commands;
using ProductApi.Application.Features.Suppliers.Commands.DeleteSupplier;
using ProductApi.Application.Features.Suppliers.Commands.UpdateSupplier;
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

        //[HttpPost(Name = "CreateSupplier")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //public async Task<ActionResult<int>> CreateSupplier([FromBody] CreateSupplierCommand command)
        //{
        //    return await _mediator.Send(command);
        //}

        //[HttpPut(Name = "UpdateSupplier")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult<int>> UpdateSupplier([FromBody] UpdateSupplierCommand command)
        //{
        //    await _mediator.Send(command);

        //    return NoContent();
        //}
    }
}
