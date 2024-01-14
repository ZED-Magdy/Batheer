using Batheer.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.AssociationsAffiliatedWithTheCouncils.Commands.CreateCouncil
{
    public class CreateCouncilCommandValidator : AbstractValidator<CreateCouncilCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateCouncilCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(6).WithMessage("Name must be more then 5 characters.")
                .MustAsync(BeUniqueUserName).WithMessage("The specified username already exists.");
        }

        private async Task<bool> BeUniqueUserName(CreateCouncilCommand command, string name, CancellationToken arg2)
        {
            return !await _context.AssociationsAffiliatedWithTheCouncils
               .AnyAsync(w => w.Name == command.Name);
        }
    }
}
