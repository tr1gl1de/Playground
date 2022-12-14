using MediatR;
using MediatrExample.Products.Commands.AddProduct;
using MediatrExample.Products.Notifications;
using MediatrExample.Products.Queries.GetProductById;
using MediatrExample.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Mvc;

namespace MediatrExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var createdProduct = await _mediator.Send(new AddProductCommand(product));
            await _mediator.Publish(new ProductAddedNotification(createdProduct));
            return CreatedAtRoute("GetProductByIdAsync", new { id = createdProduct.Id }, createdProduct);
        }

        [HttpGet("{id:long}", Name = "GetProductByIdAsync")]
        public async Task<ActionResult> GetProductById(long id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }
    }
}
