using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using pruebatecnica.BaseControl;
using pruebatecnica.Responses;
using Microsoft.AspNetCore.Authorization;

namespace pruebatecnica.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController<Role, RoleDto>
    {
        public readonly IRoleService _roleService;
        public RoleController(IMapper mapper, IRoleService roleService, IBaseService<Role> service, IValidator<Role> validator) : base(mapper, service, validator)
        {
            _roleService = roleService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ResponseGenericApi<RoleDto>>> GetAll()
        {

            var listRoleDto = _mapper.Map<IEnumerable<RoleDto>>(await _service.Get());

            var response = new ResponseGenericApi<IEnumerable<RoleDto>>(listRoleDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<ResponseGenericApi<RoleDto>>> GetById([FromQuery] int idRoleDto)
        {
            MapToDto();
            var alimentaryGroupsDto = _mapper.Map<RoleDto>(await _service.Get(idRoleDto));
            var response = new ResponseGenericApi<RoleDto>(alimentaryGroupsDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoleDto roleDto)
        {
            await MapToEntityAsync(roleDto);
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
        public async Task<IActionResult> Delete([FromBody] RoleDto roleDto)
        {
            await MapToEntityAsync(roleDto);
            return Ok(await _service.Delete(_model));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleDto roleDto)
        {
            await MapToEntityAsync(roleDto);
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
