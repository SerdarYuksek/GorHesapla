using GörHesapla.Application.Features.ProductCQRS.Command.CreateProduct;
using GörHesapla.Application.Features.ProductCQRS.Command.DeleteProduct;
using GörHesapla.Application.Features.ProductCQRS.Command.UpdateProduct;
using GörHesapla.Application.Features.ProductCQRS.Queries.GetAllProducts;
using GörHesapla.Application.Features.ProductCQRS.Queries.GetProduct;
using GörHesapla.Application.Features.ProductCQRS.Queries.GetProductsCount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GörHesapla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(GetProductsQueryRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductCount()
        {
            var response = await mediator.Send(new GetProductsCountQueryRequest());
            return Ok(response);
        }
    }
}
