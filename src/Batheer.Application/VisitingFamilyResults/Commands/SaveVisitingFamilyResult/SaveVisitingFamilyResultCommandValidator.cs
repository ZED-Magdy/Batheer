using Batheer.Application.Common.Interfaces;
using FluentValidation;

namespace Batheer.Application.VisitingFamilyResults.Commands.SaveVisitingFamilyResult
{
    public class SaveVisitingFamilyResultCommandValidator : AbstractValidator<SaveVisitingFamilyResultCommand>
    {
        private readonly IApplicationDbContext _context;
        public SaveVisitingFamilyResultCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            //RuleFor(v => v.Title)
            //    .NotEmpty().WithMessage("Title is required.")
            //    .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            //    .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");

        }

    }
}
