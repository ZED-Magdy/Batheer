using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class AssociationsAffiliatedWithTheCouncilConfiguration : IEntityTypeConfiguration<AssociationsAffiliatedWithTheCouncil>
    {
        public void Configure(EntityTypeBuilder<AssociationsAffiliatedWithTheCouncil> builder)
        {


            builder.HasData(
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "الجمعية الخيرية للرعاية الصحية",
                    Email = "chct@outlook.sa",
                    ExecutiveDirectorName = "محمد حمير البلوي ",
                    ContactNumber = "0506581135",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 100
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية التوحد بتبوك",
                    Email = "autism-ast@outlook.sa",
                    ExecutiveDirectorName = "هيفاء سالم",
                    ContactNumber = "0537374810",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 101
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية البدع الخيرية",
                    Email = "albada-kher@hotmail.com",
                    ExecutiveDirectorName = "محمود سعد العمري",
                    ContactNumber = "0507030405",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 102
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "لجمعية الخيرية للتنمية الأسرية ضباء",
                    Email = "dubamethag@gmail.com",
                    ExecutiveDirectorName = "منير حسن النجار",
                    ContactNumber = "0505375991",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 103
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية القرى الخيرية بأشواق",
                    Email = "albertayma78@hotmail.com",
                    ExecutiveDirectorName = "موسى البلوي",
                    ContactNumber = "0551439026",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 104
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية البر الخيرية بمركز الجهراء",
                    Email = "alberghra@gmail.com",
                    ExecutiveDirectorName = "صالح عايد العنزي",
                    ContactNumber = "0503553838",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 105
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية البر الخيرية في مركز بجدة",
                    Email = "societybjjdah@gmail.com",
                    ExecutiveDirectorName = "بدر عوده العطوي",
                    ContactNumber = "0500046692",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 106
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية البر الخيرية بالظلفه",
                    Email = "berdlfa.743@gmail.com",
                    ExecutiveDirectorName = "متعب مطيلة العطوي",
                    ContactNumber = "0558622247",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 107
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية التنمية الاسرية بتبوك",
                    Email = "info@osareah.org.sa",
                    ExecutiveDirectorName = "فهد عياضة العنزي",
                    ContactNumber = "0506590184",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 108
                },

                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "الجمعية الخيرية للعمل التطوعي",
                    Email = "info@tva.org.sa",
                    ExecutiveDirectorName = "مشاري المعلوي",
                    ContactNumber = "0551947967",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 109
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "الجمعية الخيرية لحفظ النعم",
                    Email = "alneam.tabuk@gmail.com",
                    ExecutiveDirectorName = "علي مسلم البلوي",
                    ContactNumber = "0560444729",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 110
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية الملك عبدالعزيز الخيرية",
                    Email = "Kaca.t1401@gmail.com",
                    ExecutiveDirectorName = "ناصر نافع العنزي",
                    ContactNumber = "0545555083",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 111
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية الملك خالد النسائية",
                    Email = "k.k.charitable.women@hotmail.com",
                    ExecutiveDirectorName = "ريم العطوي",
                    ContactNumber = "0558108126",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 112
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية فهد بن سلطان الاجتماعية الخيرية",
                    Email = "pfahadsc@hotmail.com",
                    ExecutiveDirectorName = "سحمي الشهراني",
                    ContactNumber = "0544055144",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 113
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعيه حقل الخيرية",
                    Email = "Haql-jamia@hotmail.com",
                    ExecutiveDirectorName = "إبراهيم هليل",
                    ContactNumber = "0504550690",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 114
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "الجمعية الخيرية لرعاية الايتام",
                    Email = "aytamtabouk@gmail.com",
                    ExecutiveDirectorName = "يحيى محمد العطوي",
                    ContactNumber = "0505372973",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 115
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية البر والخدمات الاجتماعية بتيماء",
                    Email = "albertayma78@hotmail.com",
                    ExecutiveDirectorName = "حماد سليم الحماد",
                    ContactNumber = "0504552847",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 116
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية البر الخيرية بالمويلح",
                    Email = "br--almowaleh@hotmail.com",
                    ExecutiveDirectorName = "عايض ضويحي الحويطي",
                    ContactNumber = "0535261992",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 117
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية الخريطة الخيرية",
                    Email = "info@alkhrita-charity.sa",
                    ExecutiveDirectorName = "حمود سلامه الشوامين",
                    ContactNumber = "0554551942",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 118
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية الخيرية بضباء",
                    Email = "khireya1437@gmail.com",
                    ExecutiveDirectorName = "محمد مزه",
                    ContactNumber = "0538100186",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 119
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية البر الخيرية بئير بن هرماس",
                    Email = "albr.1435@gmail.com",
                    ExecutiveDirectorName = "سالم سليمان العطوي",
                    ContactNumber = "0557033914",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 120
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية البر الخيرية بالخريبه",
                    Email = "br-536@hotmail.com",
                    ExecutiveDirectorName = "عبدالله دخيل الله الحويطي",
                    ContactNumber = "0583679009",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 121
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية البر الخيرية بنابع داما",
                    Email = "jb.nabie.duba@hotmail.com",
                    ExecutiveDirectorName = "ساري العطوي",
                    ContactNumber = "0507061383",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 122
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية المستقبل لرعاية الايتام",
                    Email = "foaduba2020@gmail.com",
                    ExecutiveDirectorName = "أحمد الصايغ",
                    ContactNumber = "0504556780",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 123
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية حقل لرعاية الايتام",
                    Email = "aytamhaqel@gmail.com",
                    ExecutiveDirectorName = "فرج العمراني",
                    ContactNumber = "0554551959",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 124
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "حقوق الحيوان بتبوك عطف",
                    Email = "animalrightsatf@hotmail.com",
                    ExecutiveDirectorName = "عبدالرحمن البلوب",
                    ContactNumber = "0503128440",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 125
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "المتقاعدين بمنطقة تبوك",
                    Email = "Ssm8264@gmail.com",
                    ExecutiveDirectorName = "سليمان العلوان",
                    ContactNumber = "0559885505",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 126
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية قادر لتعزيز الصحة النفسية",
                    Email = "ibrahem-2525@hotmail.com",
                    ExecutiveDirectorName = "إبراهيم العنزي",
                    ContactNumber = "0553761777",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 127
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية إحسان للاسكان",
                    Email = "hedarah2006@hotmail.com",
                    ExecutiveDirectorName = "مها قزان",
                    ContactNumber = "0540769969",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 128
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية المسؤولية الاجتماعية",
                    Email = "sa-66000@hotmail.com",
                    ExecutiveDirectorName = "سالم محمد سالم العطوي ( رئيس المجلس )",
                    ContactNumber = "0503066000",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 129
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية رواء للفتيات",
                    Email = "saam53066@gmail.com",
                    ExecutiveDirectorName = "سميره عمر عثمان قرموش ( رئيسة المجلس)",
                    ContactNumber = "0506585192",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Civil_Associations,
                    Id = 130
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "لجنة التنمية الاجتماعية الأهلية بتبوك",
                    Email = "Tabuksdcc@gmail.com",
                    ExecutiveDirectorName = "صالح محمد السهيمي",
                    ContactNumber = "0553392707",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Development_Committees,
                    Id = 131
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "لجنة التنمية الاجتماعية الاهلية بمحافظة البدع",
                    Email = "Tanmiabd@GmaiI.com",
                    ExecutiveDirectorName = "فهيد عبدالرحمن العامري",
                    ContactNumber = "0503561156",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Development_Committees,
                    Id = 132
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "لجنة التنمية الإجتماعية الأهلية بشرما",
                    Email = "maa22222@hotmail.com",
                    ExecutiveDirectorName = "محمد عليان الرقابي",
                    ContactNumber = "0543954129",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Development_Committees,
                    Id = 133
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "لجنة التنمية الاجتماعية الأهلية بضباء",
                    Email = "Tanmyae@gmail.com",
                    ExecutiveDirectorName = "إبراهيم عبد المجيد أبو مراد",
                    ContactNumber = "058743878",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Development_Committees,
                    Id = 134
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "لجنة التنمية الاجتماعية الاهلية بمحافظة حقل",
                    Email = "lajnatt415@gmail.com",
                    ExecutiveDirectorName = "نايف فريج العمراني",
                    ContactNumber = "0552720077",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Development_Committees,
                    Id = 135
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "لجنة التنمية الاجتماعية الاهلية بتيماء",
                    Email = "Tayma-SDC392@HOTMAIL.COM",
                    ExecutiveDirectorName = "محمد زراع العنزي",
                    ContactNumber = "0556552235",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Development_Committees,
                    Id = 136
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "لجنة التنمية الاجتماعية الاهلية ببئر بن هرماس",
                    Email = "lj.albeer32@gmail.com",
                    ExecutiveDirectorName = "عطالله سويلم العطوي",
                    ContactNumber = "0533510897",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Development_Committees,
                    Id = 137
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية الدعوة والارشاد وتوعية الجاليات بتبوك",
                    Email = "islamiccenter33@gmail.com",
                    ExecutiveDirectorName = "",
                    ContactNumber = "0505369724",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Memorization_Associations_and_Advocacy_Offices,
                    Id = 138
                },
                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية الدعوة والارشاد وتوعية الجاليات بضباء",
                    Email = "taawni.duba@hotmail.com",
                    ExecutiveDirectorName = "",
                    ContactNumber = "0504765583",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Memorization_Associations_and_Advocacy_Offices,
                    Id = 139
                },

                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية الدعوة والارشاد وتوعية الجاليات بتيماء",
                    Email = "Dawa7998@hotmail.com",
                    ExecutiveDirectorName = "",
                    ContactNumber = "0563915705",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Memorization_Associations_and_Advocacy_Offices,
                    Id = 140
                },

                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية الدعوة والارشاد وتوعية الجاليات بالبدع",
                    Email = "albada.invitation@gmail.com",
                    ExecutiveDirectorName = "",
                    ContactNumber = "0504223922",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Memorization_Associations_and_Advocacy_Offices,
                    Id = 141
                },

                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية الدعوة والارشاد وتوعية الجاليات بحقل",
                    Email = "zkarea10@gmail.com",
                    ExecutiveDirectorName = "",
                    ContactNumber = "0596444441",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Memorization_Associations_and_Advocacy_Offices,
                    Id = 142
                },

                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية تحفيظ القرآن الكريم بتبوك",
                    Email = "qt.abosami@gmail.com",
                    ExecutiveDirectorName = "",
                    ContactNumber = "0541737495",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Memorization_Associations_and_Advocacy_Offices,
                    Id = 143
                },

                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية تحفيظ القرآن الكريم بضباء",
                    Email = "quran.duba@gmail.com",
                    ExecutiveDirectorName = "",
                    ContactNumber = "0557196998",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Memorization_Associations_and_Advocacy_Offices,
                    Id = 144
                },

                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية تحفيظ القرآن الكريم بتيماء",
                    Email = "quran_tayma@hotmail.com",
                    ExecutiveDirectorName = "",
                    ContactNumber = "0501310939",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Memorization_Associations_and_Advocacy_Offices,
                    Id = 145
                },

                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية تحفيظ القرآن الكريم بالبدع",
                    Email = "albada345h@gmail.com",
                    ExecutiveDirectorName = "",
                    ContactNumber = "0554727789",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Memorization_Associations_and_Advocacy_Offices,
                    Id = 146
                },

                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية تحفيظ القرآن الكريم بحقل",
                    Email = "Haql.quran.t@gmail.com",
                    ExecutiveDirectorName = "",
                    ContactNumber = "0504787107",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Memorization_Associations_and_Advocacy_Offices,
                    Id = 147
                },

                new AssociationsAffiliatedWithTheCouncil()
                {
                    Name = "جمعية تحفيظ القرآن الكريم ببئر بن هرماس ",
                    Email = "galbeer1432@gmail.com",
                    ExecutiveDirectorName = "",
                    ContactNumber = "0548456222",
                    CouncilCategory = AssociationsAffiliatedWithTheCouncil.CouncilCategories.Memorization_Associations_and_Advocacy_Offices,
                    Id = 148
                }
                );


            builder.HasOne<AssociationsAffiliatedWithTheCouncilInfo>(a => a.AssociationsAffiliatedWithTheCouncilInfo)
               .WithMany()
               .HasForeignKey(a => a.AssociationsAffiliatedWithTheCouncilInfoId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}