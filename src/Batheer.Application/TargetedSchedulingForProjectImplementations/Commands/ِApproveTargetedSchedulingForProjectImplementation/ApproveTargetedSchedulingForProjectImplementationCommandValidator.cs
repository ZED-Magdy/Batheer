using Batheer.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.TargetedSchedulingForProjectImplementations.Commands.ApproveTargetedSchedulingForProjectImplementation
{
    public class ApproveTargetedSchedulingForProjectImplementationCommandValidator : AbstractValidator<ApproveTargetedSchedulingForProjectImplementationCommand>
    {
        private readonly IApplicationDbContext _context;
        public ApproveTargetedSchedulingForProjectImplementationCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            //RuleFor(v => v.Title)
            //    .NotEmpty().WithMessage("Title is required.")
            //    .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            //    .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        }
    }
}
