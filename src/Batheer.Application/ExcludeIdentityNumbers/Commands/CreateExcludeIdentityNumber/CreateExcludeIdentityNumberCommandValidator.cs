using Batheer.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.ExcludeIdentityNumbers.Commands.CreateExcludeIdentityNumber
{
    public class CreateExcludeIdentityNumberCommandValidator : AbstractValidator<CreateExcludeIdentityNumberCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateExcludeIdentityNumberCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            //RuleFor(v => v.Title)
            //    .NotEmpty().WithMessage("Title is required.")
            //    .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            //    .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        }
    }
}
