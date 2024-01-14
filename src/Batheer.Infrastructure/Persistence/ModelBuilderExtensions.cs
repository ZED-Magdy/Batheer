using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using System;

namespace Batheer.Infrastructure.Persistence
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssociationsAffiliatedWithTheCouncil>().HasData(
                new AssociationsAffiliatedWithTheCouncil
                {
                    AboutIt = "قوم الجمعية بتقديم المساعدات المالية والعينية على شكل مخصصات شهرية ثابتة أو مساعدات طارئة أو مؤقتة للأفراد والأسر",
                    AdministrativeRestructuring = "",
                    ContactInformation = "المنطقة الشرقية, الدمام , المملكة العربية السعودية",
                    Id = 1,
                    LocationOnTheMap = "الموقع على الخريطة",
                    Name = "الجمعية الخيرية بمحافظة أحد المسارحة"
                },
                 new AssociationsAffiliatedWithTheCouncil
                 {
                     AboutIt = "قوم الجمعية بتقديم المساعدات المالية والعينية على شكل مخصصات شهرية ثابتة أو مساعدات طارئة أو مؤقتة للأفراد والأسر",
                     AdministrativeRestructuring = "",
                     ContactInformation = "المنطقة الشرقية, الدمام , المملكة العربية السعودية",
                     Id = 2,
                     LocationOnTheMap = "الموقع على الخريطة",
                     Name = "الجمعية الخيرية بمحافظة ضرما"
                 },
                  new AssociationsAffiliatedWithTheCouncil
                  {
                      AboutIt = "قوم الجمعية بتقديم المساعدات المالية والعينية على شكل مخصصات شهرية ثابتة أو مساعدات طارئة أو مؤقتة للأفراد والأسر",
                      AdministrativeRestructuring = "",
                      ContactInformation = "المنطقة الشرقية, الدمام , المملكة العربية السعودية",
                      Id = 3,
                      LocationOnTheMap = "الموقع على الخريطة",
                      Name = "الجمعية الخيرية بمحافظة المزاحمية"
                  }
                 );

            return;

            modelBuilder.Entity<AssociationsAffiliatedWithTheCouncilUser>().HasData(
                new AssociationsAffiliatedWithTheCouncilUser()
                {
                    AssociationsAffiliatedWithTheCouncilId = 1,
                    FullName = "محمد علي",
                    Id = 1,
                    Mobile = "966500000000",
                    PhotoUrl = "",
                    UserName = "User_01"
                },
                new AssociationsAffiliatedWithTheCouncilUser()
                {
                    AssociationsAffiliatedWithTheCouncilId = 1,
                    FullName = "محمد سعيد",
                    Id = 2,
                    Mobile = "966500000000",
                    PhotoUrl = "",
                    UserName = "User_02"
                },
                new AssociationsAffiliatedWithTheCouncilUser()
                {
                    AssociationsAffiliatedWithTheCouncilId = 2,
                    FullName = "محمد عمر",
                    Id = 3,
                    Mobile = "966500000000",
                    PhotoUrl = "",
                    UserName = "User_03"
                },
                new AssociationsAffiliatedWithTheCouncilUser()
                {
                    AssociationsAffiliatedWithTheCouncilId = 3,
                    FullName = "محمد محمد",
                    Id = 4,
                    Mobile = "966500000000",
                    PhotoUrl = "",
                    UserName = "User_04"
                }
                );



            modelBuilder.Entity<CouncilProject>()
                .HasData(
                new CouncilProject()
                {
                    Id = 1,
                    Name = "كفالة أيتام"
                },
                new CouncilProject()
                {
                    Id = 2,
                    Name = "تمكين الأسر (الأسر المنتجة)"
                },
                new CouncilProject()
                {
                    Id = 3,
                    Name = "دعم الأسر"
                }
                );

            modelBuilder.Entity<AccommodationType>()
               .HasData(
                new AccommodationType() { Id = 1, Name = "ملك" },
                new AccommodationType() { Id = 2, Name = "إيجار" },
                new AccommodationType() { Id = 100, Name = "آخر" }
                );


            modelBuilder.Entity<EducationalLevel>()
               .HasData(
                new EducationalLevel() { Id = 1, Name = "ابتدائي فما دون" },
                new EducationalLevel() { Id = 2, Name = "متوسط" },
                new EducationalLevel() { Id = 3, Name = "ثانوي" },
                new EducationalLevel() { Id = 4, Name = "جامعي" }
                );

            modelBuilder.Entity<EstimatedProjectCost>()
              .HasData(
               new EstimatedProjectCost() { Id = 1, Name = "3000- 5000" },
               new EstimatedProjectCost() { Id = 2, Name = "5000- 7000" },
               new EstimatedProjectCost() { Id = 3, Name = "7000- 10000" },
               new EstimatedProjectCost() { Id = 100, Name = "آخر" }
               );


            modelBuilder.Entity<FinanceType>()
              .HasData(
               new FinanceType() { Id = 1, Name = "سيارات الأجرة" },
               new FinanceType() { Id = 2, Name = "عربات البيع" },
               new FinanceType() { Id = 3, Name = "الأكشاك" },
               new FinanceType() { Id = 4, Name = "الكورنرات" },
               new FinanceType() { Id = 5, Name = "الأسر المنتجة" },
               new FinanceType() { Id = 6, Name = "توطين المتاجر" }
               );


            modelBuilder.Entity<HealthStatus>()
              .HasData(
               new HealthStatus() { Id = 1, Name = "سليم" },
               new HealthStatus() { Id = 2, Name = "مريض" },
               new HealthStatus() { Id = 3, Name = "من ذوي الاحتياجات الخاصة" },
               new HealthStatus() { Id = 100, Name = "آخر" }
               );


            modelBuilder.Entity<LoanType>()
              .HasData(
               new LoanType() { Id = 1, Name = "شخصية" },
               new LoanType() { Id = 2, Name = "عقارية" },
               new LoanType() { Id = 3, Name = "بطاقات إئتمانية" },
               new LoanType() { Id = 4, Name = "قروض حكومية" },
               new LoanType() { Id = 100, Name = "آخر" }
               );


            modelBuilder.Entity<MaritalStatus>()
              .HasData(
               new MaritalStatus() { Id = 1, Name = "أعزب / عزباء" },
               new MaritalStatus() { Id = 2, Name = "متزوج / متزوجة" },
               new MaritalStatus() { Id = 3, Name = "أرملة" },
               new MaritalStatus() { Id = 4, Name = "مطلق/ مطلقة" },
               new MaritalStatus() { Id = 100, Name = "آخر" }
               );


            modelBuilder.Entity<MonthlyIncome>()
              .HasData(
               new MonthlyIncome() { Id = 1, Name = "لا يوجد" },
               new MonthlyIncome() { Id = 2, Name = "1000- 3000" },
               new MonthlyIncome() { Id = 3, Name = "1000- 3000" },
               new MonthlyIncome() { Id = 4, Name = "5000- 7000" },
               new MonthlyIncome() { Id = 100, Name = "أكثر من 7000" }
               );

            modelBuilder.Entity<Nationality>()
              .HasData(
               new Nationality() { Id = 1, Name = "السعودية" },
               new Nationality() { Id = 2, Name = "اليمن" },
               new Nationality() { Id = 3, Name = "مصر" },
               new Nationality() { Id = 4, Name = "الأردن" },
               new Nationality() { Id = 5, Name = "سوريا" }
               );


            modelBuilder.Entity<Occupation>()
              .HasData(
               new Occupation() { Id = 1, Name = "موظف حكومي" },
               new Occupation() { Id = 2, Name = "قطاع خاص" },
               new Occupation() { Id = 3, Name = "طالب / طالبة" },
               new Occupation() { Id = 4, Name = "متقاعد/ متقاعدة" },
               new Occupation() { Id = 5, Name = "غير موظف" }
               );


            modelBuilder.Entity<ProducedFamilyProduct>()
              .HasData(
               new ProducedFamilyProduct() { Id = 1, Name = "حلويات شعبية" },
               new ProducedFamilyProduct() { Id = 2, Name = "أكلات شعبية" },
               new ProducedFamilyProduct() { Id = 3, Name = "تصميم ملابس" },
               new ProducedFamilyProduct() { Id = 4, Name = "تنسيق حفلات" },
               new ProducedFamilyProduct() { Id = 5, Name = "صنع عطور" },
               new ProducedFamilyProduct() { Id = 6, Name = "صنع منسوجات" },
               new ProducedFamilyProduct() { Id = 7, Name = "صنع قهوة" }
               );


            modelBuilder.Entity<RequestStatus>()
             .HasData(
              new RequestStatus() { Id = 1, Name = "جديد" },
              new RequestStatus() { Id = 2, Name = "مقبول" },
              new RequestStatus() { Id = 3, Name = "مرفوض" }
              );


            /***************/

            modelBuilder.Entity<AssociationAffiliatedProject>().HasData(
             new AssociationAffiliatedProject()
             {
                 Id = 1,
                 AboutTheProject = "عن المشروع",
                 AssociationsAffiliatedWithTheCouncilId = 1,
                 CouncilProjectId = 1,
                 Notes = "",
                 ProjectName = "مشروع رقم 1",

             });

            modelBuilder.Entity<AssociationAffiliatedProject>().HasData(
               new AssociationAffiliatedProject()
               {
                   Id = 2,
                   AboutTheProject = "عن المشروع",
                   AssociationsAffiliatedWithTheCouncilId = 1,
                   CouncilProjectId = 2,
                   Notes = "",
                   ProjectName = "مشروع رقم 2",

               });

            modelBuilder.Entity<AssociationAffiliatedProject>().HasData(
               new AssociationAffiliatedProject()
               {
                   Id = 3,
                   AboutTheProject = "عن المشروع",
                   AssociationsAffiliatedWithTheCouncilId = 1,
                   CouncilProjectId = 3,
                   Notes = "",
                   ProjectName = "3",

               });

            modelBuilder.Entity<AssociationAffiliatedProject>().HasData(
               new AssociationAffiliatedProject()
               {
                   Id = 4,
                   AboutTheProject = "عن المشروع",
                   AssociationsAffiliatedWithTheCouncilId = 2,
                   CouncilProjectId = 1,
                   Notes = "",
                   ProjectName = "مشروع رقم 1",

               });

            modelBuilder.Entity<AssociationAffiliatedProject>().HasData(
               new AssociationAffiliatedProject()
               {
                   Id = 5,
                   AboutTheProject = "عن المشروع",
                   AssociationsAffiliatedWithTheCouncilId = 2,
                   CouncilProjectId = 2,
                   Notes = "",
                   ProjectName = "مشروع رقم 4",

               });

            modelBuilder.Entity<AssociationAffiliatedProject>().HasData(
               new AssociationAffiliatedProject()
               {
                   Id = 6,
                   AboutTheProject = "عن المشروع",
                   AssociationsAffiliatedWithTheCouncilId = 3,
                   CouncilProjectId = 3,
                   Notes = "",
                   ProjectName = "مشروع رقم 33",

               });


            /*************************/

            modelBuilder.Entity<TargetedSchedulingForProjectImplementationStatus>().HasData(new TargetedSchedulingForProjectImplementationStatus() { Id = 1, Name = "جديد" });
            modelBuilder.Entity<TargetedSchedulingForProjectImplementationStatus>().HasData(new TargetedSchedulingForProjectImplementationStatus() { Id = 2, Name = "جاري العمل عليه" });
            modelBuilder.Entity<TargetedSchedulingForProjectImplementationStatus>().HasData(new TargetedSchedulingForProjectImplementationStatus() { Id = 3, Name = "تم التنفيذ" });
            
            modelBuilder.Entity<TargetedSchedulingForProjectImplementation>().HasData(new TargetedSchedulingForProjectImplementation()
            {
                Id = 1,
                AssociationAffiliatedProjectId = 1,
                FromDate = DateTime.Now.AddDays(-500),
                ToDate = DateTime.Now.AddDays(-450),
                TargetedSchedulingForProjectImplementationStatusId = 2,
            });

            modelBuilder.Entity<TargetedSchedulingForProjectImplementation>().HasData(new TargetedSchedulingForProjectImplementation()
            {
                Id = 2,
                AssociationAffiliatedProjectId = 1,
                FromDate = DateTime.Now.AddDays(-400),
                ToDate = DateTime.Now.AddDays(-350),
                TargetedSchedulingForProjectImplementationStatusId = 2,
            });

            modelBuilder.Entity<TargetedSchedulingForProjectImplementation>().HasData(new TargetedSchedulingForProjectImplementation()
            {
                Id = 3,
                AssociationAffiliatedProjectId = 1,
                FromDate = DateTime.Now.AddDays(-300),
                ToDate = DateTime.Now.AddDays(-250),
                TargetedSchedulingForProjectImplementationStatusId = 2,
            });

            modelBuilder.Entity<TargetedSchedulingForProjectImplementation>().HasData(new TargetedSchedulingForProjectImplementation()
            {
                Id = 4,
                AssociationAffiliatedProjectId = 1,
                FromDate = DateTime.Now.AddDays(-200),
                ToDate = DateTime.Now.AddDays(-150),
                TargetedSchedulingForProjectImplementationStatusId = 1,
            });

        }
    }
}
