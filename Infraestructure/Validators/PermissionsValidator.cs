using Core.Entities;
using FluentValidation;

namespace Infraestructure.Validators
{
    public class PermissionsValidator : AbstractValidator<Permissions>
    {
        public PermissionsValidator()
        {
            RuleFor(attribute => attribute.Name).Custom((st, context) =>
            {
                if (st == "")
                {
                    context.AddFailure("EL dato Name es obligatorio");
                }

            });
        }
    }
}
