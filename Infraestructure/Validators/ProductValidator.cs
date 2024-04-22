using Core.Entities;
using FluentValidation;

namespace Infraestructure.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(attribute => attribute.Name).Custom((st, context) =>
            {
                if (st == "")
                {
                    context.AddFailure("EL dato Name es obligatorio");
                }

            });
            RuleFor(attribute => attribute.Descriptionapp).Custom((st, context) =>
            {
                if (st == "")
                {
                    context.AddFailure("EL dato Descriptionapp es obligatorio");
                }

            });
            RuleFor(attribute => attribute.Price).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato Price es obligatorio");
                }

            });
            RuleFor(attribute => attribute.numberunits).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato numberunits es obligatorio");
                }

            });
        }
    }
}
