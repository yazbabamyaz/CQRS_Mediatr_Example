using CqrsAndMediatr.CQRS.Commands.Request;
using CqrsAndMediatr.CQRS.Commands.Response;
using CqrsAndMediatr.CQRS.Queries.Request;
using CqrsAndMediatr.CQRS.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsAndMediatr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //IMediator interface'ini Constructor Injection ile aldık.

        IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
            
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest requestModel)
        {
            List<GetAllProductQueryResponse> allProducts = await _mediator.Send(requestModel);
            return Ok(allProducts);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> Get([FromQuery] GetByIdProductQueryRequest requestModel)
        {
            GetByIdProductQueryResponse product = await _mediator.Send(requestModel);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest requestModel)
        {
            CreateProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest requestModel)
        {
            UpdateProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteProductCommandRequest requestModel)
        {
            //send metoduna reauest modeli verilir.Ve Gelen Request tipine göre Handler classı çalışır.
            DeleteProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }



    }
}
