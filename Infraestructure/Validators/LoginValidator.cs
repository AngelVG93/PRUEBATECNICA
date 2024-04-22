using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Validators
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(attribute => attribute.userName).Custom((st, context) =>
            {
                if (st == "")
                {
                    context.AddFailure("EL dato userName es obligatorio");
                }

            });
            RuleFor(attribute => attribute.bearerToken).Custom((st, context) =>
            {
                if (st == "")
                {
                    context.AddFailure("EL dato bearerToken es obligatorio");
                }

            });
            RuleFor(attribute => attribute.lastName).Custom((st, context) =>
            {
                if (st == "")
                {
                    context.AddFailure("EL dato lastName es obligatorio");
                }

            });
            RuleFor(attribute => attribute.idUser).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato idUser es obligatorio");
                }

            });
        }
    }
}
