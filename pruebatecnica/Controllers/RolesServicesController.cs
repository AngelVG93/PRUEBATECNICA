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
    public class RolesServicesController : BaseController<RolesServices, RolesServicesDto>
    {
        public RolesServicesController(IMapper mapper, IBaseService<RolesServices> service, IValidator<RolesServices> validator) : base(mapper, service, validator)
        {
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RolesServicesDto rolesServicesDto)
        {
            await MapToEntityAsync(rolesServicesDto);
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
        public async Task<IActionResult> Delete([FromBody] RolesServicesDto rolesServicesDto)
        {
            await MapToEntityAsync(rolesServicesDto);
            return Ok(await _service.Delete(_model));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RolesServicesDto rolesServicesDto)
        {
            await MapToEntityAsync(rolesServicesDto);
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
