using Batheer.Application.Common.Interfaces;
using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Batheer.Domain.AuthenticationUsers;
using Batheer.Domain.Common;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        private readonly IDomainEventService _domainEventService;


        public ApplicationDbContext(
            DbContextOptions options,
            //IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService,
            IDateTime dateTime) : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
            _domainEventService = domainEventService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.;Database=SchoolDB2;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>().HasKey(p => p.UserName);

            //ApplicationDbContextSeed.SeedSystemDataAsync(this).Wait();
            //ApplicationDbContextSeed.SeedSampleDataAsync(this).Wait();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // System.Diagnostics.Debug.WriteLine("***********" + Assembly.GetExecutingAssembly().FullName);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Batheer.Infrastructure"));

            //modelBuilder.Seed();


            //modelBuilder.Entity<Family>().HasQueryFilter(e => e.IsDeleted == false);

            //base.OnModelCreating(modelBuilder);

        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            UpdateSoftDeleteStatuses();
            var result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents();

            return result;
        }

        private async Task DispatchEvents()
        {
            while (true)
            {
                var domainEventEntity = ChangeTracker.Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .Where(domainEvent => !domainEvent.IsPublished)
                    .FirstOrDefault();
                if (domainEventEntity == null) break;

                domainEventEntity.IsPublished = true;
                await _domainEventService.Publish(domainEventEntity);
            }
        }

        //entities
        #region MyRegion

        public IDbContextTransaction BeginTransaction()
        {
            return this.Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            this.Database.RollbackTransaction();
        }
        public DbSet<AccommodationData> AccommodationData { get; set; }
        public DbSet<BankDefaultData> BankDefaultData { get; set; }
        public DbSet<ContactInformationData> ContactInformationData { get; set; }
        public DbSet<EducationalData> EducationalData { get; set; }
        public DbSet<FinanceData> FinanceData { get; set; }
        public DbSet<HealthStatusData> HealthStatusData { get; set; }
        public DbSet<LoanData> LoanData { get; set; }
        public DbSet<MaritalStatusData> MaritalStatusData { get; set; }
        public DbSet<MonthlyIncomeData> MonthlyIncomeData { get; set; }
        public DbSet<OccupationData> OccupationData { get; set; }
        public DbSet<PersonalDataForm> PersonalDataForm { get; set; }
        public DbSet<ProjectData> ProjectData { get; set; }
        public DbSet<ResidencyAddressData> ResidencyAddressData { get; set; }
        public DbSet<SocialSecurityData> SocialSecurityData { get; set; }
        public DbSet<WorkOnAProjectData> WorkOnAProjectData { get; set; }
        public DbSet<AccommodationType> AccommodationTypes { get; set; }
        public DbSet<EducationalLevel> EducationalLevels { get; set; }
        public DbSet<EstimatedProjectCost> EstimatedProjectCosts { get; set; }
        public DbSet<FinanceType> FinanceTypes { get; set; }
        public DbSet<HealthStatus> HealthStatuses { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<MonthlyIncome> MonthlyIncomes { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<ProducedFamilyProduct> ProducedFamilyProducts { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<AssociationAffiliatedProject> AssociationAffiliatedProjects { get; set; }
        public DbSet<AssociationAffiliatedProjectFamilyNeedDetail> AssociationAffiliatedProjectFamilyNeedDetails { get; set; }
        public DbSet<AssociationsAffiliatedWithTheCouncil> AssociationsAffiliatedWithTheCouncils { get; set; }
        public DbSet<AssociationsAffiliatedWithTheCouncilUser> AssociationsAffiliatedWithTheCouncilUsers { get; set; }
        public DbSet<CouncilProject> CouncilProjects { get; set; }
        public DbSet<ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProject> ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjects { get; set; }
        public DbSet<ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectAttachment> ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectAttachments { get; set; }
        public DbSet<ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectStatus> ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectStatuses { get; set; }
        public DbSet<TargetedSchedulingForProjectImplementation> TargetedSchedulingForProjectImplementations { get; set; }
        public DbSet<TargetedSchedulingForProjectImplementationStatus> TargetedSchedulingForProjectImplementationStatuses { get; set; }
        public DbSet<TheIntendedBeneficiariesOfTheScheduledAssociationProject> TheIntendedBeneficiariesOfTheScheduledAssociationProjects { get; set; }
        public DbSet<FamilyRegistrationRequest> FamilyRegistrationRequests { get; set; }
        public DbSet<SupportingFamilyRequest> SupportingFamilyRequests { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<FamilyCategory> FamilyCategories { get; set; }
        public DbSet<ResponsibleFamilyMember> ResponsibleFamilyMembers { get; set; }
        public DbSet<FamilyNeed> FamilyNeeds { get; set; }
        public DbSet<FamilyNeedDetail> FamilyNeedDetails { get; set; }
        public DbSet<FamilyNeedData> FamilyNeedData { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<SupportingFamilyType> SupportingFamilyTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<ExcludeIdentityNumber> ExcludeIdentityNumbers { get; set; }

        public DbSet<AssociationsAffiliatedWithTheCouncilInfo> AssociationsAffiliatedWithTheCouncilInfos { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }

        public DbSet<AssociationsAffiliatedWithTheCouncilInfoActivityType> AssociationsAffiliatedWithTheCouncilInfoActivityTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Town> Towns { get; set; }

        public DbSet<VisitingFamilyResult> VisitingFamilyResults { get; set; }

        public DbSet<VisitingFamilyMemberResult> VisitingFamilyMemberResults { get; set; }

        #endregion


        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries<ISoftDeletabe>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.IsDeleted = false;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.DeletedBy = _currentUserService.UserId;
                        entry.Entity.DeletedDate = _dateTime.Now;
                        entry.Entity.IsDeleted = true;
                        break;
                }
            }
        }
    }
}


