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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, UserDto>
    {
        public readonly IUserService _userService;
        public UserController(IMapper mapper, IUserService userService, IBaseService<User> service, IValidator<User> validator) : base(mapper, service, validator)
        {
            _userService = userService; 
        }
        [Authorize]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ResponseGenericApi<UserDto>>> GetAll()
        {

            var listUserDto = _mapper.Map<IEnumerable<UserDto>>(await _service.Get());

            var response = new ResponseGenericApi<IEnumerable<UserDto>>(listUserDto);
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<ResponseGenericApi<UserDto>>> GetById([FromQuery] int idUserDto)
        {
            MapToDto();
            var userDto = _mapper.Map<UserDto>(await _service.Get(idUserDto));
            var response = new ResponseGenericApi<UserDto>(userDto);
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("GetInfoPermiss")]
        public async Task<ActionResult<ResponseGenericApi<UserDto>>> GetInfoPermiss([FromQuery] int idUserDto)
        {
            MapToDto();
            var userDto = _mapper.Map<UserDto>(await _userService.GetInfoServicePermiss(idUserDto));
            var response = new ResponseGenericApi<UserDto>(userDto);
            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserDto userDto)
        {
            await MapToEntityAsync(userDto);
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

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] UserDto userDto)
        {
            await MapToEntityAsync(userDto);
            return Ok(await _service.Delete(_model));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            await MapToEntityAsync(userDto);
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
