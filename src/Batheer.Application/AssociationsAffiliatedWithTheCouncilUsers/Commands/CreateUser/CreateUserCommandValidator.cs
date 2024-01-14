using Batheer.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.AssociationsAffiliatedWithTheCouncilUsers.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateUserCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MinimumLength(6).WithMessage("UserName must be more then 5 characters.")
                .MustAsync(BeUniqueUserName).WithMessage("The specified username already exists.");
        }

        private async Task<bool> BeUniqueUserName(CreateUserCommand command, string userName, CancellationToken arg2)
        {
            return !await _context.Users
               .AnyAsync(w => w.UserName == command.UserName);
        }
    }
}
