using Core.Entities;
using FluentValidation;

namespace Infraestructure.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(attribute => attribute.Name).Custom((st, context) =>
            {
                if (st == "")
                {
                    context.AddFailure("EL dato Name es obligatorio");
                }

            });
            RuleFor(attribute => attribute.LastName).Custom((st, context) =>
            {
                if (st == "")
                {
                    context.AddFailure("EL dato LastName es obligatorio");
                }

            });
            RuleFor(attribute => attribute.IdentityNumber).Custom((st, context) =>
            {
                if (st == "")
                {
                    context.AddFailure("EL dato IdentityNumber es obligatorio");
                }

            });
            RuleFor(attribute => attribute.Password).Custom((st, context) =>
            {
                if (st == "")
                {
                    context.AddFailure("EL dato Password es obligatorio");
                }

            });
        }
    }
}
