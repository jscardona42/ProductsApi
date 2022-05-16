using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Application.Features.Products.Commands.CreateProduct;
using ProductApi.Application.Features.Products.Commands.DeleteProduct;
using ProductApi.Application.Features.Products.Commands.UpdateProduct;
using ProductApi.Application.Features.Products.Queries.GetProductsList;
using ProductApi.Application.Features.Products.Queries.GetProducts;
using System.Net;

namespace ProductApi.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetProducts")]
        [ProducesResponseType(typeof(IEnumerable<ProductsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductsVm>>> GetProducts()
        {
            var query = new GetProductsQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        [ProducesResponseType(typeof(IEnumerable<ProductsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductsVm>>> GetProductById(int id)
        {
            var query = new GetProductsListQuery(id);
            var product = await _mediator.Send(query);
            return Ok(product);
        }

        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateProduct([FromBody] CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdatePorduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete(Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand
            {
                Id = id,
                Estado = "inactivo"
            };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
