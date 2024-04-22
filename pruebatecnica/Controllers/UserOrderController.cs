using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pruebatecnica.BaseControl;
using pruebatecnica.Responses;

namespace pruebatecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrderController : BaseController<UserOrder, UserOrderDto>
    {
        public readonly IUserOrderService _userOrderService;
        public UserOrderController(IMapper mapper, IUserOrderService userOrderService, IBaseService<UserOrder> service, IValidator<UserOrder> validator) : base(mapper, service, validator)
        {
            _userOrderService = userOrderService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ResponseGenericApi<UserOrderDto>>> GetAll()
        {

            var listUserOrderDto = _mapper.Map<IEnumerable<UserOrderDto>>(await _service.Get());

            var response = new ResponseGenericApi<IEnumerable<UserOrderDto>>(listUserOrderDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<ResponseGenericApi<UserOrderDto>>> GetById([FromQuery] int idUserOrderDto)
        {
            MapToDto();
            var alimentaryGroupsDto = _mapper.Map<UserOrderDto>(await _service.Get(idUserOrderDto));
            var response = new ResponseGenericApi<UserOrderDto>(alimentaryGroupsDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserOrderDto userOrderDto)
        {
            await MapToEntityAsync(userOrderDto);
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
        public async Task<IActionResult> Delete([FromBody] UserOrderDto userOrderDto)
        {
            await MapToEntityAsync(userOrderDto);
            return Ok(await _service.Delete(_model));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserOrderDto userOrderDto)
        {
            await MapToEntityAsync(userOrderDto);
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
