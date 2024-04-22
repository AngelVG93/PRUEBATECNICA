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
    public class LoginController : BaseController<Login, LoginDto>
    {
        public readonly ILoginServer _iLoginServer;

        public LoginController(IMapper mapper, ILoginServer iLoginServer, IBaseService<Login> service, IValidator<Login> validator) : base(mapper, service, validator)
        {
            _iLoginServer = iLoginServer;   
        }

        [HttpPost]
        public async Task<ActionResult<ResponseGenericApi<LoginDto>>> Post([FromForm] string usernumber, [FromForm] string password)
        {
            Login loginSession = await _iLoginServer.PostLogin(usernumber, password);
            var login = _mapper.Map<LoginDto>(loginSession);
            if (login != null)
            {
                return Ok(new ResponseGenericApi<LoginDto>(login));
            }
            return BadRequest();    
        }
    }
}
