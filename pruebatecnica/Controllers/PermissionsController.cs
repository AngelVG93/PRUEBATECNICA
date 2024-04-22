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
    public class PermissionsController : BaseController<Permissions, PermissionsDto>
    {
        public readonly IPermissionsService _permissionsService;
        public PermissionsController(IMapper mapper, IPermissionsService permissionsService, IBaseService<Permissions> service, IValidator<Permissions> validator) : base(mapper, service, validator)
        {
            _permissionsService = permissionsService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ResponseGenericApi<PermissionsDto>>> GetAll()
        {

            var listPermissionsDto = _mapper.Map<IEnumerable<PermissionsDto>>(await _service.Get());

            var response = new ResponseGenericApi<IEnumerable<PermissionsDto>>(listPermissionsDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<ResponseGenericApi<PermissionsDto>>> GetById([FromQuery] int idPermissionsDto)
        {
            MapToDto();
            var permissionsDto = _mapper.Map<PermissionsDto>(await _service.Get(idPermissionsDto));
            var response = new ResponseGenericApi<PermissionsDto>(permissionsDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PermissionsDto PermissionsDto)
        {
            await MapToEntityAsync(PermissionsDto);
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
        public async Task<IActionResult> Delete([FromBody] PermissionsDto permissionsDto)
        {
            await MapToEntityAsync(permissionsDto);
            return Ok(await _service.Delete(_model));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PermissionsDto permissionsDto)
        {
            await MapToEntityAsync(permissionsDto);
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
