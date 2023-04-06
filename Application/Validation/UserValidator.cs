using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Domain.Entities;

namespace Task.Application.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id);
            RuleFor(x => x.Name).Length(0, 10);
            RuleFor(x => x.Email).NotNull().EmailAddress();
        }
    }
}
