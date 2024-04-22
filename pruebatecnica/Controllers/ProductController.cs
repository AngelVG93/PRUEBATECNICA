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
    public class ProductController : BaseController<Product, ProductDto>
    {
        public readonly IProductService _foodService;
        public ProductController(IMapper mapper, IProductService foodService, IBaseService<Product> service, IValidator<Product> validator) : base(mapper, service, validator)
        {
            _foodService = foodService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ResponseGenericApi<ProductDto>>> GetAll()
        {

            var listProductDto = _mapper.Map<IEnumerable<ProductDto>>(await _service.Get());

            var response = new ResponseGenericApi<IEnumerable<ProductDto>>(listProductDto);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<ResponseGenericApi<ProductDto>>> GetById([FromQuery] int idproductDto)
        {
            MapToDto();
            var foodDto = _mapper.Map<ProductDto>(await _service.Get(idproductDto));
            var response = new ResponseGenericApi<ProductDto>(foodDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto productDto)
        {
            await MapToEntityAsync(productDto);
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
        public async Task<IActionResult> Delete([FromBody] ProductDto productDto)
        {
            await MapToEntityAsync(productDto);
            return Ok(await _service.Delete(_model));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            await MapToEntityAsync(productDto);
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
