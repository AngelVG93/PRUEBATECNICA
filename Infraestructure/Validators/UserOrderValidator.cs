using Core.Entities;
using FluentValidation;

namespace Infraestructure.Validators
{
    public class UserOrderValidator : AbstractValidator<UserOrder>
    {
        public UserOrderValidator()
        {
            RuleFor(attribute => attribute.IdUser).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato IdUser es obligatorio");
                }

            });
            RuleFor(attribute => attribute.IdOrder).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato IdOrder es obligatorio");
                }

            });
            RuleFor(attribute => attribute.DateOrder).Custom((st, context) =>
            {
                if (st.Year == 0 | st.Day == 0 | st.Minute == 0)
                {
                    context.AddFailure("EL dato DateOrder es obligatorio");
                }

            });
        }
    }
}
