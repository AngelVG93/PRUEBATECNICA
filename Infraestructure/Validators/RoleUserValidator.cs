using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Validators
{
    public class RoleUserValidator : AbstractValidator<RoleUser>
    {
        public RoleUserValidator()
        {
            RuleFor(attribute => attribute.IdRole).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato IdRole es obligatorio");
                }

            });
            RuleFor(attribute => attribute.IdUser).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato IdUser es obligatorio");
                }

            });
        }
    }
}
