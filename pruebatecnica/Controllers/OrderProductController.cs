using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pruebatecnica.BaseControl;
using pruebatecnica.Responses;

namespace pruebatecnica.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : BaseController<OrderProduct, OrderProductDto>
    {
        public readonly IOrderProductService _orderFoodService;
        public OrderProductController(IMapper mapper, IOrderProductService orderFoodService, IBaseService<OrderProduct> service, IValidator<OrderProduct> validator) : base(mapper, service, validator)
        {
            _orderFoodService = orderFoodService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ResponseGenericApi<OrderProductDto>>> GetAll()
        {

            var listOrderProductDto = _mapper.Map<IEnumerable<OrderProductDto>>(await _service.Get());

            var response = new ResponseGenericApi<IEnumerable<OrderProductDto>>(listOrderProductDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<ResponseGenericApi<OrderProductDto>>> GetById([FromQuery] int idOrderProductDto)
        {
            MapToDto();
            var orderProductDto = _mapper.Map<OrderProductDto>(await _service.Get(idOrderProductDto));
            var response = new ResponseGenericApi<OrderProductDto>(orderProductDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrderProductDto orderProductDto)
        {
            await MapToEntityAsync(orderProductDto);
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
        public async Task<IActionResult> Delete([FromBody] OrderProductDto orderProductDto)
        {
            await MapToEntityAsync(orderProductDto);
            return Ok(await _service.Delete(_model));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderProductDto orderProductDto)
        {
            await MapToEntityAsync(orderProductDto);
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
