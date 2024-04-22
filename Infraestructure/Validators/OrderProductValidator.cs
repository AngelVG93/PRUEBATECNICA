using Core.Entities;
using FluentValidation;

namespace Infraestructure.Validators
{
    public class OrderProductValidator : AbstractValidator<OrderProduct>
    {
        public OrderProductValidator()
        {
            RuleFor(attribute => attribute.DateOrder).Custom((st, context) =>
            {
                if (st.Year == 0 | st.Day == 0 | st.Minute == 0)
                {
                    context.AddFailure("EL formato del campo DateOrder es incorrecto");
                }

            });
        }
    }
}
