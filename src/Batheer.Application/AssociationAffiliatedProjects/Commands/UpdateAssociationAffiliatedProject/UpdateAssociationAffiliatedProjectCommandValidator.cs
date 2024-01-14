using Batheer.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.AssociationAffiliatedProjects.Commands.UpdateAssociationAffiliatedProject
{
    public class UpdateAssociationAffiliatedProjectCommandValidator : AbstractValidator<UpdateAssociationAffiliatedProjectCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateAssociationAffiliatedProjectCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v=> v)
                .MustAsync(NotUsedBefore).WithMessage("لا يمكن التعديل لوجود بيانات مرتبطة.");
            //RuleFor(v => v.Title)
            //    .NotEmpty().WithMessage("Title is required.")
            //    .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            //    .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        }

        private async Task<bool> NotUsedBefore(UpdateAssociationAffiliatedProjectCommand command, CancellationToken cancellationToken)
        {
            return !await _context.TargetedSchedulingForProjectImplementations
                .AnyAsync(w => w.AssociationAffiliatedProjectId == command.Id);
        }
    }
}