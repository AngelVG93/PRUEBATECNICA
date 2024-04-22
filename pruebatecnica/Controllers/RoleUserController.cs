using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using pruebatecnica.BaseControl;
using Microsoft.AspNetCore.Authorization;

namespace pruebatecnica.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleUserController : BaseController<RoleUser, RoleUserDto>
    {
        public readonly IRoleUserService _roleUserService;
        public RoleUserController(IMapper mapper, IRoleUserService roleUserService, IBaseService<RoleUser> service, IValidator<RoleUser> validator) : base(mapper, service, validator)
        {
            _roleUserService = roleUserService;
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoleUserDto roleUserDto)
        {
            await MapToEntityAsync(roleUserDto);
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
        public async Task<IActionResult> Delete([FromBody] RoleUserDto roleUserDto)
        {
            await MapToEntityAsync(roleUserDto);
            return Ok(await _service.Delete(_model));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleUserDto roleUserDto)
        {
            await MapToEntityAsync(roleUserDto);
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
