using Core.Entities;
using FluentValidation;

namespace Infraestructure.Validators
{
    public class RolesServicesValidator : AbstractValidator<RolesServices>
    {
        public RolesServicesValidator()
        {
            RuleFor(attribute => attribute.IdServices).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato IdServices es obligatorio");
                }

            });
            RuleFor(attribute => attribute.IdRoles).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato IdRoles es obligatorio");
                }

            });
        }
    }
}
