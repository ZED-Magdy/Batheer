using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Persistence
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedSystemDataAsync(ApplicationDbContext context)
        {
            if (context.AssociationsAffiliatedWithTheCouncils.Any() == false)
            {

                context.AssociationsAffiliatedWithTheCouncils.AddRange(
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

                context.AssociationsAffiliatedWithTheCouncils.AddRange(
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
            }

            if (context.AssociationsAffiliatedWithTheCouncilUsers.Any() == false)
            {
                context.AssociationsAffiliatedWithTheCouncilUsers.AddRange(
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
            }

            if (context.CouncilProjects.Any() == false)
            {
                context.CouncilProjects.AddRange(
                       new CouncilProject()
                       {
                           Id = 1,
                           Name = "دعم الأسر"
                       },
                       new CouncilProject()
                       {
                           Id = 2,
                           Name = "تمكين الأسر"
                       }
                       );
            }

            if (context.Genders.Any() == false)
            {
                context.Genders.AddRange(
                       new Gender()
                       {
                           Id = 1,
                           Name = "ذكر"
                       },
                       new Gender()
                       {
                           Id = 2,
                           Name = "أنثى"
                       }
                       );
            }
            if (context.AccommodationTypes.Any() == false)
            {
                context.AccommodationTypes.AddRange(
                    new AccommodationType() { Id = 1, Name = "ملك" },
                    new AccommodationType() { Id = 2, Name = "إيجار" },
                    new AccommodationType() { Id = 100, Name = "آخر" }
                );
            }

            if (context.EducationalLevels.Any() == false)
            {
                context.EducationalLevels.AddRange(
                    new EducationalLevel() { Id = 1, Name = "ابتدائي فما دون" },
                    new EducationalLevel() { Id = 2, Name = "متوسط" },
                    new EducationalLevel() { Id = 3, Name = "ثانوي" },
                    new EducationalLevel() { Id = 4, Name = "جامعي" }
                );
            }

            if (context.EstimatedProjectCosts.Any() == false)
            {
                context.EstimatedProjectCosts.AddRange(
                   new EstimatedProjectCost() { Id = 1, Name = "3000- 5000" },
                   new EstimatedProjectCost() { Id = 2, Name = "5000- 7000" },
                   new EstimatedProjectCost() { Id = 3, Name = "7000- 10000" },
                   new EstimatedProjectCost() { Id = 100, Name = "آخر" }
               );
            }

            if (context.FinanceTypes.Any() == false)
            {
                context.FinanceTypes.AddRange(
                   new FinanceType() { Id = 1, Name = "سيارات الأجرة" },
                   new FinanceType() { Id = 2, Name = "عربات البيع" },
                   new FinanceType() { Id = 3, Name = "الأكشاك" },
                   new FinanceType() { Id = 4, Name = "الكورنرات" },
                   new FinanceType() { Id = 5, Name = "الأسر المنتجة" },
                   new FinanceType() { Id = 6, Name = "توطين المتاجر" }
               );
            }

            if (context.HealthStatuses.Any() == false)
            {
                context.HealthStatuses.AddRange(
                   new HealthStatus() { Id = 1, Name = "سليم" },
                   new HealthStatus() { Id = 2, Name = "مريض" },
                   new HealthStatus() { Id = 3, Name = "من ذوي الاحتياجات الخاصة" },
                   new HealthStatus() { Id = 100, Name = "آخر" }
               );
            }

            if (context.LoanTypes.Any() == false)
            {
                context.LoanTypes.AddRange(
                   new LoanType() { Id = 1, Name = "شخصية" },
                   new LoanType() { Id = 2, Name = "عقارية" },
                   new LoanType() { Id = 3, Name = "بطاقات إئتمانية" },
                   new LoanType() { Id = 4, Name = "قروض حكومية" },
                   new LoanType() { Id = 100, Name = "آخر" }
               );
            }

            if (context.MaritalStatuses.Any() == false)
            {
                context.MaritalStatuses.AddRange(
                   new MaritalStatus() { Id = 1, Name = "أعزب / عزباء" },
                   new MaritalStatus() { Id = 2, Name = "متزوج / متزوجة" },
                   new MaritalStatus() { Id = 3, Name = "أرملة" },
                   new MaritalStatus() { Id = 4, Name = "مطلق/ مطلقة" },
                   new MaritalStatus() { Id = 100, Name = "آخر" }
               );
            }

            if (context.FamilyNeeds.Any() == false)
            {
                context.FamilyNeeds.AddRange(
                    new FamilyNeed() { Id = 1, Name = "مأكل ومشرب" },
                    new FamilyNeed() { Id = 2, Name = "ملبس" },
                    new FamilyNeed() { Id = 3, Name = "فواتير" },
                    new FamilyNeed() { Id = 4, Name = "مسكن" },
                    new FamilyNeed() { Id = 5, Name = "سيولة نقدية" }
                    );
            }


            if (context.FamilyCategories.Any() == false)
            {
                context.FamilyCategories.AddRange(
                    new FamilyCategory() { Id = 1, Name = "أرملة" },
                    new FamilyCategory() { Id = 2, Name = "مطلقة" },
                    new FamilyCategory() { Id = 3, Name = "فقيرة" },
                    new FamilyCategory() { Id = 4, Name = "يتيم" }
                    );
            }


            if (context.SupportingFamilyTypes.Any() == false)
            {
                context.SupportingFamilyTypes.AddRange(
                    new SupportingFamilyType() { Id = 1, Name = "أسرة منتجة" }
                    );
            }


            if (context.MonthlyIncomes.Any() == false)
            {
                context.MonthlyIncomes.AddRange(
                   new MonthlyIncome() { Id = 1, Name = "لا يوجد" },
                   new MonthlyIncome() { Id = 2, Name = "1000- 3000" },
                   new MonthlyIncome() { Id = 3, Name = "1000- 3000" },
                   new MonthlyIncome() { Id = 4, Name = "5000- 7000" },
                   new MonthlyIncome() { Id = 100, Name = "أكثر من 7000" }
               );

            }


            if (context.Nationalities.Any() == false)
            {
                context.Nationalities.AddRange(
                   new Nationality() { Id = 1, Name = "السعودية", ISO_CODES = "sa" },
                   new Nationality() { Id = 2, Name = "اليمن", ISO_CODES = "ye" },
                   new Nationality() { Id = 3, Name = "مصر", ISO_CODES = "eg" },
                   new Nationality() { Id = 4, Name = "الأردن", ISO_CODES = "jo" },
                   new Nationality() { Id = 5, Name = "سوريا", ISO_CODES = "sy" }
                   );
            }

            if (context.Occupations.Any() == false)
            {
                context.Occupations.AddRange(
                   new Occupation() { Id = 1, Name = "موظف حكومي" },
                   new Occupation() { Id = 2, Name = "قطاع خاص" },
                   new Occupation() { Id = 3, Name = "طالب / طالبة" },
                   new Occupation() { Id = 4, Name = "متقاعد/ متقاعدة" },
                   new Occupation() { Id = 5, Name = "غير موظف" }
                   );
            }


            if (context.ProducedFamilyProducts.Any() == false)
            {
                context.ProducedFamilyProducts.AddRange(
                    new ProducedFamilyProduct() { Id = 1, Name = "حلويات شعبية" },
                    new ProducedFamilyProduct() { Id = 2, Name = "أكلات شعبية" },
                    new ProducedFamilyProduct() { Id = 3, Name = "تصميم ملابس" },
                    new ProducedFamilyProduct() { Id = 4, Name = "تنسيق حفلات" },
                    new ProducedFamilyProduct() { Id = 5, Name = "صنع عطور" },
                    new ProducedFamilyProduct() { Id = 6, Name = "صنع منسوجات" },
                    new ProducedFamilyProduct() { Id = 7, Name = "صنع قهوة" }
                    );
            }


            if (context.RequestStatuses.Any() == false)
            {
                context.RequestStatuses.AddRange(
                    new RequestStatus() { Id = 1, Name = "جديد" },
                    new RequestStatus() { Id = 2, Name = "مقبول" },
                    new RequestStatus() { Id = 3, Name = "مرفوض" }
                    );

            }


            context.SaveChanges();
        }
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {

            /***************/
            if (context.AssociationAffiliatedProjects.Any() == false)
            {
                context.AssociationAffiliatedProjects.Add(

                    new AssociationAffiliatedProject()
                    {
                        //Id = 1,
                        AboutTheProject = "نبذة عن كفالة الأيتام",
                        AssociationsAffiliatedWithTheCouncilId = 1,
                        CouncilProjectId = 1,
                        Notes = "",
                        ProjectName = "كفالة أيتام - حي النسيم",

                    });

                context.AssociationAffiliatedProjects.Add(
                   new AssociationAffiliatedProject()
                   {
                       //Id = 2,
                       AboutTheProject = "بنذة عن مشاريع الأسر المنتجة",
                       AssociationsAffiliatedWithTheCouncilId = 1,
                       CouncilProjectId = 2,
                       Notes = "",
                       ProjectName = "الأسر المنتجة لمشاريع الخياطة",

                   });

                context.AssociationAffiliatedProjects.Add(
                   new AssociationAffiliatedProject()
                   {
                       //Id = 3,
                       AboutTheProject = "نبذة عن دعم الأسر",
                       AssociationsAffiliatedWithTheCouncilId = 1,
                       CouncilProjectId = 1,
                       Notes = "",
                       ProjectName = "دعم الأسر في القرى",

                   });

                context.AssociationAffiliatedProjects.Add(
                   new AssociationAffiliatedProject()
                   {
                       // Id = 4,
                       AboutTheProject = "نبذة عن كفالة الأيتام",
                       AssociationsAffiliatedWithTheCouncilId = 2,
                       CouncilProjectId = 1,
                       Notes = "",
                       ProjectName = "كفالة أيتام أقل من 6 سنوات",

                   });

                context.AssociationAffiliatedProjects.Add(
                   new AssociationAffiliatedProject()
                   {
                       // Id = 5,
                       AboutTheProject = "عن المشروع",
                       AssociationsAffiliatedWithTheCouncilId = 2,
                       CouncilProjectId = 2,
                       Notes = "",
                       ProjectName = "الأسر المنتجة لمشاريع الحضانة",

                   });

                context.AssociationAffiliatedProjects.Add(
                   new AssociationAffiliatedProject()
                   {
                       // Id = 6,
                       AboutTheProject = "نبذة عن دعم الأسر",
                       AssociationsAffiliatedWithTheCouncilId = 3,
                       CouncilProjectId = 1,
                       Notes = "",
                       ProjectName = "دعم الأسر التي ليس لها عائل",

                   });

            }
            /*************************/
            if (context.TargetedSchedulingForProjectImplementationStatuses.Any() == false)
            {
                //context.TargetedSchedulingForProjectImplementationStatuses.AddRange(new TargetedSchedulingForProjectImplementationStatus() { Id = 1, Name = "جديد" });
                //context.TargetedSchedulingForProjectImplementationStatuses.AddRange(new TargetedSchedulingForProjectImplementationStatus() { Id = 2, Name = "جاري العمل عليه" });
                //context.TargetedSchedulingForProjectImplementationStatuses.AddRange(new TargetedSchedulingForProjectImplementationStatus() { Id = 3, Name = "تم التنفيذ" });
            }

            if (context.TargetedSchedulingForProjectImplementations.Any() == false)
            {
                context.TargetedSchedulingForProjectImplementations.AddRange(new TargetedSchedulingForProjectImplementation()
                {
                    //Id = 1,
                    AssociationAffiliatedProjectId = 1,
                    FromDate = DateTime.Now.AddDays(-500),
                    ToDate = DateTime.Now.AddDays(-450),
                    TargetedSchedulingForProjectImplementationStatusId = 2,
                });

                context.TargetedSchedulingForProjectImplementations.AddRange(new TargetedSchedulingForProjectImplementation()
                {
                    //Id = 2,
                    AssociationAffiliatedProjectId = 1,
                    FromDate = DateTime.Now.AddDays(-400),
                    ToDate = DateTime.Now.AddDays(-350),
                    TargetedSchedulingForProjectImplementationStatusId = 2,
                });

                context.TargetedSchedulingForProjectImplementations.AddRange(new TargetedSchedulingForProjectImplementation()
                {
                    //Id = 3,
                    AssociationAffiliatedProjectId = 1,
                    FromDate = DateTime.Now.AddDays(-300),
                    ToDate = DateTime.Now.AddDays(-250),
                    TargetedSchedulingForProjectImplementationStatusId = 2,
                });

                context.TargetedSchedulingForProjectImplementations.AddRange(new TargetedSchedulingForProjectImplementation()
                {
                    //Id = 4,
                    AssociationAffiliatedProjectId = 1,
                    FromDate = DateTime.Now.AddDays(-200),
                    ToDate = DateTime.Now.AddDays(-150),
                    TargetedSchedulingForProjectImplementationStatusId = 1,
                });
            }

            if (context.FamilyRegistrationRequests.Any() == false)
            {
                context.PersonalDataForm.AddRange(

                    new PersonalDataForm()
                    {
                        // Id = 1,
                        DateOfBirth = DateTime.Now,
                        FamilyName = "سعد",
                        FatherName = "ناصر",
                        FirstName = "محمد",
                        GenderId = 1,
                        GrandFatherName = "سعد",
                        // IdentityFilePath = "IdentityFilePath",
                        IdentityNo = "1234567891",
                        NationalityId = 2,
                        //PersonalPhotoFilePath = "PersonalPhotoFilePath",
                        PlaceOfBirth = "جدة",
                    },
                    new PersonalDataForm()
                    {
                        // Id = 2,
                        DateOfBirth = DateTime.Now,
                        FamilyName = "سعيد",
                        FatherName = "سعيد",
                        FirstName = "علي",
                        GenderId = 1,
                        GrandFatherName = "علي",
                        //IdentityFilePath = "IdentityFilePath",
                        IdentityNo = "1444567891",
                        NationalityId = 2,
                        //PersonalPhotoFilePath = "PersonalPhotoFilePath",
                        PlaceOfBirth = "جدة",
                    },
                     new PersonalDataForm()
                     {
                         //  Id = 3,
                         DateOfBirth = DateTime.Now,
                         FamilyName = "علي",
                         FatherName = "علي",
                         FirstName = "فيصل",
                         GenderId = 1,
                         GrandFatherName = "فيصل",
                         //IdentityFilePath = "IdentityFilePath",
                         IdentityNo = "1555567891",
                         NationalityId = 2,
                         //PersonalPhotoFilePath = "PersonalPhotoFilePath",
                         PlaceOfBirth = "جدة",
                     }
                     );

                var p1 = context.PersonalDataForm.Find(1);
                var p2 = context.PersonalDataForm.Find(2);
                var p3 = context.PersonalDataForm.Find(3);
                context.FamilyRegistrationRequests.Add(new FamilyRegistrationRequest()
                {
                    Family = new Family()
                    {
                        AccommodationData = new AccommodationData() { AccommodationTypeId = 1 },

                        ContactInformationData = new ContactInformationData()
                        {
                            Email = "a@a.com",
                            Facebook = "facebook",
                            Instagram = "instgram",
                            Mobile = "0555555556",
                            PhoneNumber = "",
                            Twitter = "twitter",
                        },

                        ResponsibleFamilyMember = new ResponsibleFamilyMember()
                        {
                            PersonalDataForm = p1,

                            EducationalData = new EducationalData() { EducationalLevelId = 1 },
                            HealthStatusData = new HealthStatusData() { HealthStatusId = 1 },
                            MaritalStatusData = new MaritalStatusData() { MaritalStatusId = 1 },
                            OccupationData = new OccupationData() { OccupationId = 1 },
                        },
                        MonthlyIncomeData = new MonthlyIncomeData() { MonthlyIncomeId = 1 },
                        ResidencyAddressData = new ResidencyAddressData()
                        {
                            District = "District",
                            IsOutOfTabuk = true,
                            LocationOnTheMap = "",
                            //ProvinceId = "",
                            Street = "Street",
                        },
                        SocialSecurityData = new SocialSecurityData()
                        {
                            AreYouABeneficiaryOfSocialSecurity = true,
                            Description = "Description",
                        },
                    },
                    AssociationsAffiliatedWithTheCouncilId = 1,
                    //BankDefaultData = new BankDefaultData() { IsThereABankDefault = true },
                    CouncilProjectId = 1,
                    FamilyCategoryId = 2,
                    FamilyNeedData = new List<FamilyNeedData>()
                    {
                        new FamilyNeedData() { FamilyNeedId =1 },
                        new FamilyNeedData() { FamilyNeedId =2 },
                        new FamilyNeedData() { FamilyNeedId =4 }
                    },

                    //FinanceData = new FinanceData() { FinanceTypeId = 1, ProducedFamilyProductId = 1 },


                    //LoanData = new LoanData()
                    //{
                    //    Description = "Description",
                    //    DoYouHaveLoansOrOtherObligations = true,
                    //    LoanTypeId = 1,
                    //},

                    //ProjectData = new ProjectData()
                    //{
                    //    AboutTheProject = "AboutTheProject",
                    //    EstimatedProjectCostId = 1,
                    //    WhatAreTheObstaclesFacingTheProject = "WhatAreTheObstaclesFacingTheProject"
                    //},
                    //WorkOnAProjectData = new WorkOnAProjectData() { AreYouFreeAndReadyToWorkOnAproject = true, },

                });
                //context.EnsuringOrphanRequests.Add(new EnsuringOrphanRequest()
                //{

                //    AccommodationData = new AccommodationData() { AccommodationTypeId = 1 },
                //    AssociationsAffiliatedWithTheCouncilId = 1,
                //    BankDefaultData = new BankDefaultData() { IsThereABankDefault = true },
                //    ContactInformation = new ContactInformationData()
                //    {
                //        Email = "a@a.com",
                //        Facebook = "facebook",
                //        Instagram = "instgram",
                //        Mobile = "0555555556",
                //        PhoneNumber = "",
                //        Twitter = "twitter",
                //    },
                //    CouncilProjectId = 2,
                //    EducationalData = new EducationalData() { EducationalLevelId = 1 },
                //    FinanceData = new FinanceData() { FinanceTypeId = 1, ProducedFamilyProductId = 1 },
                //    HealthStatusData = new HealthStatusData() { HealthStatusId = 1 },
                //    LoanData = new LoanData()
                //    {
                //        Description = "Description",
                //        DoYouHaveLoansOrOtherObligations = true,
                //        LoanTypeId = 1,
                //    },
                //    MaritalStatusData = new MaritalStatusData() { MaritalStatusId = 1 },
                //    MonthlyIncomeData = new MonthlyIncomeData() { MonthlyIncomeId = 1 },
                //    OccupationData = new OccupationData() { OccupationId = 1 },
                //    PersonalDataForm = p1,
                //    ProjectData = new ProjectData()
                //    {
                //        AboutTheProject = "AboutTheProject",
                //        EstimatedProjectCostId = 1,
                //        WhatAreTheObstaclesFacingTheProject = "WhatAreTheObstaclesFacingTheProject"
                //    },
                //    ResidencyAddressData = new ResidencyAddressData()
                //    {
                //        District = "District",
                //        IsOutOfTabuk = true,
                //        LocationOnTheMap = "",
                //        //ProvinceId = "",
                //        Street = "Street",
                //    },
                //    SocialSecurityData = new SocialSecurityData()
                //    {
                //        AreYouABeneficiaryOfSocialSecurity = true,
                //        Description = "Description",
                //    },
                //    WorkOnAProjectData = new WorkOnAProjectData() { AreYouFreeAndReadyToWorkOnAproject = true, },

                //});
                //context.EnsuringOrphanRequests.Add(new EnsuringOrphanRequest()
                //{

                //    AccommodationData = new AccommodationData() { AccommodationTypeId = 1 },
                //    AssociationsAffiliatedWithTheCouncilId = 1,
                //    BankDefaultData = new BankDefaultData() { IsThereABankDefault = true },
                //    ContactInformation = new ContactInformationData()
                //    {
                //        Email = "a@a.com",
                //        Facebook = "facebook",
                //        Instagram = "instgram",
                //        Mobile = "0555555556",
                //        PhoneNumber = "",
                //        Twitter = "twitter",
                //    },
                //    CouncilProjectId = 3,
                //    EducationalData = new EducationalData() { EducationalLevelId = 1 },
                //    FinanceData = new FinanceData() { FinanceTypeId = 1, ProducedFamilyProductId = 1 },
                //    HealthStatusData = new HealthStatusData() { HealthStatusId = 1 },
                //    LoanData = new LoanData()
                //    {
                //        Description = "Description",
                //        DoYouHaveLoansOrOtherObligations = true,
                //        LoanTypeId = 1,
                //    },
                //    MaritalStatusData = new MaritalStatusData() { MaritalStatusId = 1 },
                //    MonthlyIncomeData = new MonthlyIncomeData() { MonthlyIncomeId = 1 },
                //    OccupationData = new OccupationData() { OccupationId = 1 },
                //    PersonalDataForm = p1,
                //    ProjectData = new ProjectData()
                //    {
                //        AboutTheProject = "AboutTheProject",
                //        EstimatedProjectCostId = 1,
                //        WhatAreTheObstaclesFacingTheProject = "WhatAreTheObstaclesFacingTheProject"
                //    },
                //    ResidencyAddressData = new ResidencyAddressData()
                //    {
                //        District = "District",
                //        IsOutOfTabuk = true,
                //        LocationOnTheMap = "",
                //        //ProvinceId = "",
                //        Street = "Street",
                //    },
                //    SocialSecurityData = new SocialSecurityData()
                //    {
                //        AreYouABeneficiaryOfSocialSecurity = true,
                //        Description = "Description",
                //    },
                //    WorkOnAProjectData = new WorkOnAProjectData() { AreYouFreeAndReadyToWorkOnAproject = true, },

                //});

                //context.EnsuringOrphanRequests.Add(new EnsuringOrphanRequest()
                //{

                //    AccommodationData = new AccommodationData() { AccommodationTypeId = 1 },
                //    AssociationsAffiliatedWithTheCouncilId = 1,
                //    BankDefaultData = new BankDefaultData() { IsThereABankDefault = true },
                //    ContactInformation = new ContactInformationData()
                //    {
                //        Email = "a@a.com",
                //        Facebook = "facebook",
                //        Instagram = "instgram",
                //        Mobile = "0555555556",
                //        PhoneNumber = "",
                //        Twitter = "twitter",
                //    },
                //    CouncilProjectId = 3,
                //    EducationalData = new EducationalData() { EducationalLevelId = 1 },
                //    FinanceData = new FinanceData() { FinanceTypeId = 1, ProducedFamilyProductId = 1 },
                //    HealthStatusData = new HealthStatusData() { HealthStatusId = 1 },
                //    LoanData = new LoanData()
                //    {
                //        Description = "Description",
                //        DoYouHaveLoansOrOtherObligations = true,
                //        LoanTypeId = 1,
                //    },
                //    MaritalStatusData = new MaritalStatusData() { MaritalStatusId = 1 },
                //    MonthlyIncomeData = new MonthlyIncomeData() { MonthlyIncomeId = 1 },
                //    OccupationData = new OccupationData() { OccupationId = 1 },
                //    PersonalDataForm = p2,
                //    ProjectData = new ProjectData()
                //    {
                //        AboutTheProject = "AboutTheProject",
                //        EstimatedProjectCostId = 1,
                //        WhatAreTheObstaclesFacingTheProject = "WhatAreTheObstaclesFacingTheProject"
                //    },
                //    ResidencyAddressData = new ResidencyAddressData()
                //    {
                //        District = "District",
                //        IsOutOfTabuk = true,
                //        LocationOnTheMap = "",
                //        //ProvinceId = "",
                //        Street = "Street",
                //    },
                //    SocialSecurityData = new SocialSecurityData()
                //    {
                //        AreYouABeneficiaryOfSocialSecurity = true,
                //        Description = "Description",
                //    },
                //    WorkOnAProjectData = new WorkOnAProjectData() { AreYouFreeAndReadyToWorkOnAproject = true, },

                //});
                //context.EnsuringOrphanRequests.Add(new EnsuringOrphanRequest()
                //{

                //    AccommodationData = new AccommodationData() { AccommodationTypeId = 1 },
                //    AssociationsAffiliatedWithTheCouncilId = 1,
                //    BankDefaultData = new BankDefaultData() { IsThereABankDefault = true },
                //    ContactInformation = new ContactInformationData()
                //    {
                //        Email = "a@a.com",
                //        Facebook = "facebook",
                //        Instagram = "instgram",
                //        Mobile = "0555555556",
                //        PhoneNumber = "",
                //        Twitter = "twitter",
                //    },
                //    CouncilProjectId = 1,
                //    EducationalData = new EducationalData() { EducationalLevelId = 1 },
                //    FinanceData = new FinanceData() { FinanceTypeId = 1, ProducedFamilyProductId = 1 },
                //    HealthStatusData = new HealthStatusData() { HealthStatusId = 1 },
                //    LoanData = new LoanData()
                //    {
                //        Description = "Description",
                //        DoYouHaveLoansOrOtherObligations = true,
                //        LoanTypeId = 1,
                //    },
                //    MaritalStatusData = new MaritalStatusData() { MaritalStatusId = 1 },
                //    MonthlyIncomeData = new MonthlyIncomeData() { MonthlyIncomeId = 1 },
                //    OccupationData = new OccupationData() { OccupationId = 1 },
                //    PersonalDataForm = p2,
                //    ProjectData = new ProjectData()
                //    {
                //        AboutTheProject = "AboutTheProject",
                //        EstimatedProjectCostId = 1,
                //        WhatAreTheObstaclesFacingTheProject = "WhatAreTheObstaclesFacingTheProject"
                //    },
                //    ResidencyAddressData = new ResidencyAddressData()
                //    {
                //        District = "District",
                //        IsOutOfTabuk = true,
                //        LocationOnTheMap = "",
                //        //ProvinceId = "",
                //        Street = "Street",
                //    },
                //    SocialSecurityData = new SocialSecurityData()
                //    {
                //        AreYouABeneficiaryOfSocialSecurity = true,
                //        Description = "Description",
                //    },
                //    WorkOnAProjectData = new WorkOnAProjectData() { AreYouFreeAndReadyToWorkOnAproject = true, },

                //});
                //context.EnsuringOrphanRequests.Add(new EnsuringOrphanRequest()
                //{

                //    AccommodationData = new AccommodationData() { AccommodationTypeId = 1 },
                //    AssociationsAffiliatedWithTheCouncilId = 1,
                //    BankDefaultData = new BankDefaultData() { IsThereABankDefault = true },
                //    ContactInformation = new ContactInformationData()
                //    {
                //        Email = "a@a.com",
                //        Facebook = "facebook",
                //        Instagram = "instgram",
                //        Mobile = "0555555556",
                //        PhoneNumber = "",
                //        Twitter = "twitter",
                //    },
                //    CouncilProjectId = 1,
                //    EducationalData = new EducationalData() { EducationalLevelId = 1 },
                //    FinanceData = new FinanceData() { FinanceTypeId = 1, ProducedFamilyProductId = 1 },
                //    HealthStatusData = new HealthStatusData() { HealthStatusId = 1 },
                //    LoanData = new LoanData()
                //    {
                //        Description = "Description",
                //        DoYouHaveLoansOrOtherObligations = true,
                //        LoanTypeId = 1,
                //    },
                //    MaritalStatusData = new MaritalStatusData() { MaritalStatusId = 1 },
                //    MonthlyIncomeData = new MonthlyIncomeData() { MonthlyIncomeId = 1 },
                //    OccupationData = new OccupationData() { OccupationId = 1 },
                //    PersonalDataForm = p3,
                //    ProjectData = new ProjectData()
                //    {
                //        AboutTheProject = "AboutTheProject",
                //        EstimatedProjectCostId = 1,
                //        WhatAreTheObstaclesFacingTheProject = "WhatAreTheObstaclesFacingTheProject"
                //    },
                //    ResidencyAddressData = new ResidencyAddressData()
                //    {
                //        District = "District",
                //        IsOutOfTabuk = true,
                //        LocationOnTheMap = "",
                //        //ProvinceId = "",
                //        Street = "Street",
                //    },
                //    SocialSecurityData = new SocialSecurityData()
                //    {
                //        AreYouABeneficiaryOfSocialSecurity = true,
                //        Description = "Description",
                //    },
                //    WorkOnAProjectData = new WorkOnAProjectData() { AreYouFreeAndReadyToWorkOnAproject = true, },

                //});

                //context.PersonalDataForm.Add();
            }


            if (context.Users.Any() == false)
            {
                //context.Users.AddRange(
                //    new Domain.AuthenticationUsers.User() { UserName = "admin", Password = "Aa@123456", FullName = "مدير النظام", UserRole = Domain.AuthenticationUsers.User.UserRoles.AdminRole, Mobile = "", PhotoUrl = "" },
                //    new Domain.AuthenticationUsers.User() { UserName = "User_01", Password = "Aa@123456", FullName = "مستخدم 1 - الجمعية الخيرية للرعاية الصحي", UserRole = Domain.AuthenticationUsers.User.UserRoles.CouncilRole, Mobile = "", PhotoUrl = "" },
                //    new Domain.AuthenticationUsers.User() { UserName = "User_03", Password = "Aa@123456", FullName = "مستخدم 1 - جمعية البدع الخيرية", UserRole = Domain.AuthenticationUsers.User.UserRoles.CouncilRole, Mobile = "", PhotoUrl = "" }


                //    );
            }


            context.SaveChanges();

        }

    }
}
