using AutoMapper;
using Core.Interfaces.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace pruebatecnica.BaseControl
{
    public class BaseController<TEntity, TEntityDto> : ControllerBase where TEntity : class
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseService<TEntity> _service;
        protected readonly IValidator<TEntity> _validator;
        protected TEntity _model;
        protected TEntityDto _dtoModel;

        public BaseController(IMapper mapper,
                             IBaseService<TEntity> service,
                             IValidator<TEntity> validator)
        {
            _validator = validator;
            _mapper = mapper;
            _service = service;
        }
        protected async Task MapToEntityAsync(TEntityDto dtoEntity)
        {
            _model = _mapper.Map<TEntity>(dtoEntity);
        }
        protected void MapToDto()
        {
            _dtoModel = _mapper.Map<TEntityDto>(_model);
        }
        protected async Task<BadRequestObjectResult> ValidateAsyncDto()
        {
            var validation = await _validator.ValidateAsync(_model);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors?.Select(e => new ValidationResult()
                {
                    Errors = validation.Errors
                }));
            }

            return null;
        }
    }
}
