using Batheer.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.AssociationAffiliatedProjects.Commands.DeleteAssociationAffiliatedProject
{
    public class DeleteAssociationAffiliatedProjectCommandValidator : AbstractValidator<DeleteAssociationAffiliatedProjectCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteAssociationAffiliatedProjectCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Id)
                .MustAsync(HasRelatedData).WithMessage("لا يمكن إكمال هذا الإجراء لوجود بيانات مرتبطة في جدول : الجدولة الزمنية المستهدفة");

            //RuleFor(v => v.Title)
            //    .NotEmpty().WithMessage("Title is required.")
            //    .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            //    .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        }



        private async Task<bool> HasRelatedData(int id, CancellationToken cancellationToken)
        {
            return !await _context.TargetedSchedulingForProjectImplementations
              .AnyAsync(w => w.AssociationAffiliatedProjectId == id);
        }

    }
}