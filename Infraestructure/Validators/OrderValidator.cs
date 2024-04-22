using Core.Entities;
using FluentValidation;

namespace Infraestructure.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(attribute => attribute.Description).Custom((st, context) =>
            {
                if (st == null && st == "")
                {
                    context.AddFailure("EL dato Description es obligatorio");
                }

            });
        }
    }
}
