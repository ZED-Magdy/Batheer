using Batheer.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Families.Commands.DeleteFamily
{
    public class DeleteFamilyValidator : AbstractValidator<DeleteFamilyCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteFamilyValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Objectkey)
                .MustAsync(HasNoFamilyMembers).WithMessage("لا يمكن الحذف لوجود أفراد بالعائلة.");
                //.MustAsync(HasNoTheIntendedBeneficiariesOfTheScheduledAssociationProjects).WithMessage("لا يمكن الحذف لوجود مشاريع بالعائلة.");
        }

        private async Task<bool> HasNoFamilyMembers(DeleteFamilyCommand command, Guid objectkey, CancellationToken cancellationToken)
        {
            return !await _context.Families
                .Include(i=> i.FamilyMembers)
                .Where(w => w.objectkey == objectkey)
               .AnyAsync(w => w.FamilyMembers.Any());
        }

        private async Task<bool> HasNoTheIntendedBeneficiariesOfTheScheduledAssociationProjects(DeleteFamilyCommand command, Guid objectkey, CancellationToken cancellationToken)
        {
            return !await _context.TheIntendedBeneficiariesOfTheScheduledAssociationProjects
                .Include(i => i.Family)
                .Where(w => w.Family.objectkey == objectkey)
               .AnyAsync();
        }
    }
}
