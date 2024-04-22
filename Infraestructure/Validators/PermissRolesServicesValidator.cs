using Core.Entities;
using FluentValidation;

namespace Infraestructure.Validators
{
    public class PermissRolesServicesValidator : AbstractValidator<PermissRolesServices>
    {
        public PermissRolesServicesValidator()
        {
            RuleFor(attribute => attribute.IdPermissions).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato IdPermissions es obligatorio");
                }

            });
            RuleFor(attribute => attribute.IdRolesService).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato IdRolesService es obligatorio");
                }

            });
        }
    }
}
