using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Application.Users.Queries.VerifyUser
{
    public class VerifyUserValidator: AbstractValidator<VerifyUserQuery>
    {
        public VerifyUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MaximumLength(6);
        }
    }
}
