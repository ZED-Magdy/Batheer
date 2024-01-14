using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class SupportingFamilyRequestConfiguration : IEntityTypeConfiguration<SupportingFamilyRequest>
    {
        public void Configure(EntityTypeBuilder<SupportingFamilyRequest> builder)
        {

            builder.HasOne<Family>(a => a.Family)
                 .WithOne(a => a.SupportingFamilyRequest)
                 .HasForeignKey<SupportingFamilyRequest>(a => a.FamilyId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<BankDefaultData>(a => a.BankDefaultData)
                .WithMany()
                .HasForeignKey(a => a.BankDefaultDataId)
                .OnDelete(DeleteBehavior.Restrict);

          
            builder.HasOne<FinanceData>(a => a.FinanceData)
                .WithMany()
                .HasForeignKey(a => a.FinanceDataId)
                .OnDelete(DeleteBehavior.Restrict);

          

            builder.HasOne<LoanData>(a => a.LoanData)
                .WithMany()
                .HasForeignKey(a => a.LoanDataId)
                .OnDelete(DeleteBehavior.Restrict);

           

            builder.HasOne<ProjectData>(a => a.ProjectData)
                .WithMany()
                .HasForeignKey(a => a.ProjectDataId)
                .OnDelete(DeleteBehavior.Restrict);

          

            builder.HasOne<WorkOnAProjectData>(a => a.WorkOnAProjectData)
                .WithMany()
                .HasForeignKey(a => a.WorkOnAProjectDataId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}