using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Services;
using Core.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pruebatecnica.BaseControl;
using pruebatecnica.Responses;

namespace pruebatecnica.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController<Order, OrderDto>
    {
        public readonly IOrderService _orderService;
        public OrderController(IMapper mapper, IOrderService orderService, IBaseService<Order> service, IValidator<Order> validator) : base(mapper, service, validator)
        {
            _orderService = orderService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ResponseGenericApi<OrderDto>>> GetAll()
        {
            var listOrderDto = _mapper.Map<IEnumerable<OrderDto>>(await _service.Get());

            var response = new ResponseGenericApi<IEnumerable<OrderDto>>(listOrderDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<ResponseGenericApi<OrderDto>>> GetById([FromQuery] int idOrderDto)
        {
            MapToDto();
            var orderDto = _mapper.Map<OrderDto>(await _service.Get(idOrderDto));
            var response = new ResponseGenericApi<OrderDto>(orderDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrderDto orderDto)
        {
            await MapToEntityAsync(orderDto);
            BadRequestObjectResult actionResult = await ValidateAsyncDto();
            if (actionResult != null)
            {
                if (actionResult.StatusCode == 400)
                {
                    return Ok(actionResult.Value);
                }
            }
            _model = await _service.Put(_model);
            MapToDto();
            return Ok(_dtoModel);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] OrderDto orderDto)
        {
            await MapToEntityAsync(orderDto);
            return Ok(await _service.Delete(_model));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDto orderDto)
        {
            await MapToEntityAsync(orderDto);
            BadRequestObjectResult actionResult = await ValidateAsyncDto();
            if (actionResult != null)
            {
                if (actionResult.StatusCode == 400)
                {
                    return Ok(actionResult.Value);
                }
            }
            _model = await _service.Post(_model);
            MapToDto();
            return Ok(_dtoModel);
        }
    }
}
