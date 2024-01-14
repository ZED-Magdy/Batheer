using Batheer.Application.Common.Models;
using Batheer.Application.Common.Models.RequestForms;
using Batheer.Application.Families.Commands.CreateFamily;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Batheer.DataMigration
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Do_Work();
            Do_Work_For_Mig2();
            Console.WriteLine("Hello World!");
        }

        public static List<CreateFamilyCommand> Do_Work_For_Mig2()
        {
            var result = new List<CreateFamilyCommand>();
            string currentDirectory = @"C:\Users\mdahman\source\repos\Tabuk_CouncilProject\src\Batheer.DataMigration\"; // Directory.GetCurrentDirectory();
            //                        C:\Users\mdahman\source\repos\Tabuk_CouncilProject\src\Batheer
            var file_female_avatar = File.OpenRead(@$"{currentDirectory}\images\female-avatar.png");
            byte[] file_female_avatar_bytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                file_female_avatar.CopyTo(ms);
                file_female_avatar_bytes = ms.ToArray();
            }

            var file_male_avatar = File.OpenRead(@$"{currentDirectory}\images\male-avatar.png");
            byte[] file_male_avatar_bytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                file_male_avatar.CopyTo(ms);
                file_male_avatar_bytes = ms.ToArray();
            }


            var file_identity = File.OpenRead(@$"{currentDirectory}\images\identity.png");
            byte[] file_identity_bytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                file_identity.CopyTo(ms);
                file_identity_bytes = ms.ToArray();
            }



            string contentType = "image/png";



            var dd = new DataSet1TableAdapters.Sheet02TableAdapter();
            var dt = dd.GetData();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt[i];
                Console.WriteLine(i);

                var command = new CreateFamilyCommand();

                command.AssociationAffiliatedId = (int) row.CouncilId;
                command.CouncilProjectId = 1;


                command.PersonalDataForm = new PersonalDataFormModel();
                //command.PersonalDataForm.DateOfBirth =  string.IsNullOrEmpty(row.PersonalDataForm_DateOfBirth) ?
                //    DateTime.MaxValue :
                //    ConvertDateCalendar(row.PersonalDataForm_DateOfBirth);

                DateTime DateOfBirth;
                DateTime.TryParse(row.PersonalDataForm_DateOfBirth,
                      // "yyyy-dd-MM hh:mm tt",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out DateOfBirth);

                if(DateOfBirth == null)
                {
                    DateOfBirth = DateTime.MinValue;
                }

                command.PersonalDataForm.DateOfBirth = DateOfBirth;
                command.PersonalDataForm.PlaceOfBirth = row.PersonalDataForm_PlaceOfBirth;

                command.PersonalDataForm.FamilyName = row.PersonalDataForm_FamilyName;
                command.PersonalDataForm.FatherName = row.PersonalDataForm_FatherName;
                command.PersonalDataForm.FirstName = row.PersonalDataForm_FirstName;
                //command.PersonalDataForm.GenderId = row.PersonalDataForm_GenderId == "ذكر" ? 1 : 2;
                command.PersonalDataForm.GenderId = (int) row.GenderId;
                command.PersonalDataForm.GrandFatherName = row.PersonalDataForm_GrandFatherName;



                command.PersonalDataForm.PersonalPhotoFile = new UploadedFile()
                {
                    ContentType = contentType,
                    FileName = command.PersonalDataForm.GenderId == 1 ? "male_avatar" : "female_avatar",
                    Content = command.PersonalDataForm.GenderId == 1 ? file_male_avatar_bytes : file_female_avatar_bytes,

                };

                command.PersonalDataForm.IdentityNo = row.PersonalDataForm_IdentityNo.ToString();
                //command.PersonalDataForm.NationalityId = Convert.ToInt32(row.PersonalDataForm_NationalityId);
                command.PersonalDataForm.NationalityId = (int) row.NationalityId;
                command.PersonalDataForm.IdentityFile = new UploadedFile()
                {

                    Content = file_identity_bytes,
                    FileName = "identity",
                    ContentType = contentType,
                };

                command.PersonalDataForm.PlaceOfBirth = row.PersonalDataForm_PlaceOfBirth;


                command.AccommodationData = new AccommodationDataModel();
                //command.AccommodationData.AccommodationTypeId = get_AccommodationTypeId(row.AccommodationData_AccommodationTypeId);
                command.AccommodationData.AccommodationTypeId = (int) row.AccommodationTypeId;
                command.AccommodationData.Others = row.AccommodationData_Others;


                //command.BankDefaultData = new BankDefaultDataModel();
                ////command.BankDefaultData.IsThereABankDefault = row.ba


                command.ContactInformation = new ContactInformationDataModel();
                command.ContactInformation.Email = row.ContactInformation_Email;
                command.ContactInformation.Facebook = row.ContactInformation_Facebook;
                command.ContactInformation.Instagram = row.ContactInformation_Instagram;
                command.ContactInformation.Mobile = row.ContactInformation_Mobile.ToString();
                command.ContactInformation.Others = row.ContactInformation_Others;
                command.ContactInformation.PhoneNumber = row.ContactInformation_PhoneNumber.ToString();
                command.ContactInformation.Twitter = row.ContactInformation_Twitter;



                command.EducationalData = new EducationalDataModel();
                //command.EducationalData.EducationalLevelId = get_EducationalLevelId(row.EducationalData_EducationalLevelId);
                command.EducationalData.EducationalLevelId = (int) row.EducationalLevelId;


                command.FamilyCategoryData = new FamilyCategoryDataModel();
                //command.FamilyCategoryData.FamilyCategoryId = get_FamilyCategoryId(row.FamilyCategoryData_FamilyCategoryId);
                command.FamilyCategoryData.FamilyCategoryId = (int) row.FamilyCategoryId;

                //command.FamilyNeedData = new System.Collections.Generic.List<FamilyNeedDataModel>();
                ////command.FamilyNeedData


                //command.FinanceData = new FinanceDataModel();
                ////command.FinanceData.FinanceTypeId = row.

                command.HealthStatusData = new HealthStatusDataModel();
                command.HealthStatusData.Description = row.HealthStatusData_Description;
                //command.HealthStatusData.HealthStatusId = get_HealthStatusId(row.HealthStatusData_HealthStatusId);
                command.HealthStatusData.HealthStatusId = (int) row.HealthStatusId;
                command.HealthStatusData.Others = row.HealthStatusData_Others;


                //command.LoanData = new LoanDataModel();
                ////command.LoanData.Description = row.lo

                command.MaritalStatusData = new MaritalStatusDataModel();
                //command.MaritalStatusData.MaritalStatusId = get_MaritalStatusId(row.MaritalStatusData_MaritalStatusId);
                command.MaritalStatusData.MaritalStatusId = (int) row.MaritalStatusId;
                command.MaritalStatusData.Others = "";


                command.MonthlyIncomeData = new MonthlyIncomeDataModel();
                //command.MonthlyIncomeData.MonthlyIncomeId = Convert.ToInt32(row.MonthlyIncomeData_MonthlyIncomeId);
                command.MonthlyIncomeData.MonthlyIncomeId = (int) row.MonthlyIncomeId;



                command.OccupationData = new OccupationDataModel();
                //command.OccupationData.OccupationId = Convert.ToInt32(row.OccupationData_OccupationId);
                command.OccupationData.OccupationId = (int) row.OccupationId;

                /*
                                               command.ProjectData = new ProjectDataModel();
                                               //command.ProjectData.AboutTheProject = row.abb

                */

                command.ResidencyAddressData = new ResidencyAddressDataModel();
                command.ResidencyAddressData.District = row.ResidencyAddressData_District;
                command.ResidencyAddressData.IsOutOfTabuk = row.ResidencyAddressData_IsOutOfTabuk == "نعم" ? true : false;
                command.ResidencyAddressData.LocationOnTheMap = row.ResidencyAddressData_LocationOnTheMap;
                command.ResidencyAddressData.Others = row.ResidencyAddressData_Others;
                command.ResidencyAddressData.Province = row.ResidencyAddressData_Province;
                //command.ResidencyAddressData.ProvinceId = row.ResidencyAddressData_Province
                command.ResidencyAddressData.Street = row.ResidencyAddressData_Street;


                command.SocialSecurityData = new SocialSecurityDataModel();
                command.SocialSecurityData.AreYouABeneficiaryOfSocialSecurity = row.SocialSecurityData_AreYouABeneficiaryOfSocialSecurity == "نعم" ? true : false;
                command.SocialSecurityData.Description = row.SocialSecurityData_Description;
                /*
                                               command.WorkOnAProjectData = new WorkOnAProjectDataModel();
                                               //command.WorkOnAProjectData.AreYouFreeAndReadyToWorkOnAproject = row.are


                                               */


                command.FamilyNeedData = new List<FamilyNeedDataModel>();

                if(row.FamilyNeedData_1 == 1)
                {
                    command.FamilyNeedData.Add(new FamilyNeedDataModel() { Checked = true, FamilyNeedId = 1 });
                }
                if (row.FamilyNeedData_2 == "1")
                {
                    command.FamilyNeedData.Add(new FamilyNeedDataModel() { Checked = true, FamilyNeedId = 2 });
                }
                if (row.FamilyNeedData_3 == "1")
                {
                    command.FamilyNeedData.Add(new FamilyNeedDataModel() { Checked = true, FamilyNeedId = 3 });
                }
                if (row.FamilyNeedData_4 == "1")
                {
                    command.FamilyNeedData.Add(new FamilyNeedDataModel() { Checked = true, FamilyNeedId = 4 });
                }
                if (row.FamilyNeedData_5 == "1")
                {
                    command.FamilyNeedData.Add(new FamilyNeedDataModel() { Checked = true, FamilyNeedId = 5 });
                }
                result.Add(command);
            }



            return result;
        }

        public static List<CreateFamilyCommand> Do_Work()
        {
            var result = new List<CreateFamilyCommand>();
            string currentDirectory = @"C:\Users\mdahman\source\repos\Tabuk_CouncilProject\src\Batheer.DataMigration\"; // Directory.GetCurrentDirectory();
            //                        C:\Users\mdahman\source\repos\Tabuk_CouncilProject\src\Batheer
            var file_female_avatar = File.OpenRead(@$"{currentDirectory}\images\female-avatar.png");
            byte[] file_female_avatar_bytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                file_female_avatar.CopyTo(ms);
                file_female_avatar_bytes = ms.ToArray();
            }

            var file_male_avatar = File.OpenRead(@$"{currentDirectory}\images\male-avatar.png");
            byte[] file_male_avatar_bytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                file_male_avatar.CopyTo(ms);
                file_male_avatar_bytes = ms.ToArray();
            }


            var file_identity = File.OpenRead(@$"{currentDirectory}\images\identity.png");
            byte[] file_identity_bytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                file_identity.CopyTo(ms);
                file_identity_bytes = ms.ToArray();
            }



            string contentType = "image/png";



            var dd = new DataSet1TableAdapters.View_1TableAdapter();
            var dt = dd.GetData();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt[i];
                Console.WriteLine(i);

                var command = new CreateFamilyCommand();

                command.AssociationAffiliatedId = row.CouncilId;
                command.CouncilProjectId = 1;


                command.PersonalDataForm = new PersonalDataFormModel();
                //command.PersonalDataForm.DateOfBirth =  string.IsNullOrEmpty(row.PersonalDataForm_DateOfBirth) ?
                //    DateTime.MaxValue :
                //    ConvertDateCalendar(row.PersonalDataForm_DateOfBirth);

                command.PersonalDataForm.DateOfBirth = row.PersonalDataForm_DateOfBirth;

                command.PersonalDataForm.FamilyName = row.PersonalDataForm_FamilyName;
                command.PersonalDataForm.FatherName = row.PersonalDataForm_FatherName;
                command.PersonalDataForm.FirstName = row.PersonalDataForm_FirstName;
                //command.PersonalDataForm.GenderId = row.PersonalDataForm_GenderId == "ذكر" ? 1 : 2;
                command.PersonalDataForm.GenderId = row.GenderId;
                command.PersonalDataForm.GrandFatherName = row.PersonalDataForm_GrandFatherName;



                command.PersonalDataForm.PersonalPhotoFile = new UploadedFile()
                {
                    ContentType = contentType,
                    FileName = command.PersonalDataForm.GenderId == 1 ? "male_avatar" : "female_avatar",
                    Content = command.PersonalDataForm.GenderId == 1 ? file_male_avatar_bytes : file_female_avatar_bytes,

                };

                command.PersonalDataForm.IdentityNo = row.PersonalDataForm_IdentityNo.ToString();
                //command.PersonalDataForm.NationalityId = Convert.ToInt32(row.PersonalDataForm_NationalityId);
                command.PersonalDataForm.NationalityId = row.NationalityId;
                command.PersonalDataForm.IdentityFile = new UploadedFile()
                {

                    Content = file_identity_bytes,
                    FileName = "identity",
                    ContentType = contentType,
                };

                command.PersonalDataForm.PlaceOfBirth = row.PersonalDataForm_PlaceOfBirth;


                command.AccommodationData = new AccommodationDataModel();
                //command.AccommodationData.AccommodationTypeId = get_AccommodationTypeId(row.AccommodationData_AccommodationTypeId);
                command.AccommodationData.AccommodationTypeId = row.AccommodationTypeId;
                command.AccommodationData.Others = row.AccommodationData_Others;


                //command.BankDefaultData = new BankDefaultDataModel();
                ////command.BankDefaultData.IsThereABankDefault = row.ba


                command.ContactInformation = new ContactInformationDataModel();
                command.ContactInformation.Email = row.ContactInformation_Email;
                command.ContactInformation.Facebook = row.ContactInformation_Facebook;
                command.ContactInformation.Instagram = row.ContactInformation_Instagram;
                command.ContactInformation.Mobile = row.ContactInformation_Mobile.ToString();
                command.ContactInformation.Others = row.ContactInformation_Others;
                command.ContactInformation.PhoneNumber = row.ContactInformation_PhoneNumber;
                command.ContactInformation.Twitter = row.ContactInformation_Twitter;



                command.EducationalData = new EducationalDataModel();
                //command.EducationalData.EducationalLevelId = get_EducationalLevelId(row.EducationalData_EducationalLevelId);
                command.EducationalData.EducationalLevelId = row.EducationalLevelId;


                command.FamilyCategoryData = new FamilyCategoryDataModel();
                //command.FamilyCategoryData.FamilyCategoryId = get_FamilyCategoryId(row.FamilyCategoryData_FamilyCategoryId);
                command.FamilyCategoryData.FamilyCategoryId = row.FamilyCategoryId;

                //command.FamilyNeedData = new System.Collections.Generic.List<FamilyNeedDataModel>();
                ////command.FamilyNeedData


                //command.FinanceData = new FinanceDataModel();
                ////command.FinanceData.FinanceTypeId = row.

                command.HealthStatusData = new HealthStatusDataModel();
                command.HealthStatusData.Description = row.HealthStatusData_Description;
                //command.HealthStatusData.HealthStatusId = get_HealthStatusId(row.HealthStatusData_HealthStatusId);
                command.HealthStatusData.HealthStatusId = row.HealthStatusId;
                command.HealthStatusData.Others = row.HealthStatusData_Others;


                //command.LoanData = new LoanDataModel();
                ////command.LoanData.Description = row.lo

                command.MaritalStatusData = new MaritalStatusDataModel();
                //command.MaritalStatusData.MaritalStatusId = get_MaritalStatusId(row.MaritalStatusData_MaritalStatusId);
                command.MaritalStatusData.MaritalStatusId = row.MaritalStatusId;
                command.MaritalStatusData.Others = "";


                command.MonthlyIncomeData = new MonthlyIncomeDataModel();
                //command.MonthlyIncomeData.MonthlyIncomeId = Convert.ToInt32(row.MonthlyIncomeData_MonthlyIncomeId);
                command.MonthlyIncomeData.MonthlyIncomeId = row.MonthlyIncomeId;



                command.OccupationData = new OccupationDataModel();
                //command.OccupationData.OccupationId = Convert.ToInt32(row.OccupationData_OccupationId);
                command.OccupationData.OccupationId = row.OccupationId;

                /*
                                               command.ProjectData = new ProjectDataModel();
                                               //command.ProjectData.AboutTheProject = row.abb

                */

                command.ResidencyAddressData = new ResidencyAddressDataModel();
                command.ResidencyAddressData.District = row.ResidencyAddressData_District;
                command.ResidencyAddressData.IsOutOfTabuk = row.ResidencyAddressData_IsOutOfTabuk == "نعم" ? true : false;
                command.ResidencyAddressData.LocationOnTheMap = row.ResidencyAddressData_LocationOnTheMap;
                command.ResidencyAddressData.Others = row.ResidencyAddressData_Others;
                command.ResidencyAddressData.Province = row.ResidencyAddressData_Province;
                //command.ResidencyAddressData.ProvinceId = row.ResidencyAddressData_Province
                command.ResidencyAddressData.Street = row.ResidencyAddressData_Street;


                command.SocialSecurityData = new SocialSecurityDataModel();
                command.SocialSecurityData.AreYouABeneficiaryOfSocialSecurity = row.SocialSecurityData_AreYouABeneficiaryOfSocialSecurity == "نعم" ? true : false;
                command.SocialSecurityData.Description = row.SocialSecurityData_Description;
                /*
                                               command.WorkOnAProjectData = new WorkOnAProjectDataModel();
                                               //command.WorkOnAProjectData.AreYouFreeAndReadyToWorkOnAproject = row.are


                                               */


                command.FamilyNeedData = new List<FamilyNeedDataModel>();
                result.Add(command);
            }



            return result;
        }

        public static DataSet1.sp_selectDataTable Do_Work_Step02()
        {
            var dd = new DataSet1TableAdapters.sp_selectTableAdapter();
            return dd.GetData();
        }

        public static int get_AccommodationTypeId(string AccommodationTypeId)
        {
            switch (AccommodationTypeId)
            {
                case "ملك":
                    return 1;
                case "إيجار":
                    return 2;
                case "آخر":
                    return 100;
                default:
                    return 99;
            }
        }
        public static int get_EducationalLevelId(string data)
        {
            switch (data)
            {
                case "ابتدائي فما دون":
                    return 1;
                case "متوسط":
                    return 2;
                case "ثانوي":
                    return 3;
                case "جامعي":
                    return 4;
                default:
                    return 99;
            }
        }
        public static int get_FamilyCategoryId(string data)
        {
            switch (data)
            {
                case "أرملة":
                    return 1;
                case "مطلقة":
                    return 2;
                case "فقيرة":
                    return 3;
                case "يتيم":
                    return 4;
                default:
                    return 99;
            }
        }
        public static int get_HealthStatusId(string data)
        {
            switch (data)
            {
                case "سليم":
                    return 1;
                case "مريض":
                    return 2;
                case "من ذوي الاحتياجات الخاصة":
                    return 3;
                case "آخر":
                    return 100;
                default:
                    return 99;
            }
        }

        public static int get_MaritalStatusId(string data)
        {
            switch (data)
            {
                case "أعزب / عزباء":
                    return 1;
                case "متزوج / متزوجة":
                    return 2;
                case "أرملة":
                    return 3;
                case "مطلق/ مطلقة":
                    return 4;
                case "آخر":
                    return 100;
                default:
                    return 99;
            }
        }
        public static DateTime ConvertDateCalendar(string dateString)
        {
            //CultureInfo arSA = new CultureInfo("ar-SA");
            //DateTime dateValue;

            //if (DateTime.TryParseExact(dateString, "d/M/yyyy", arSA,
            //                           DateTimeStyles.None, out dateValue))
            //    Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue,
            //                      dateValue.Kind);
            //else if (DateTime.TryParseExact(dateString, "dd/M/yyyy", arSA,
            //                           DateTimeStyles.None, out dateValue))
            //    Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue,
            //                      dateValue.Kind);
            //else if (DateTime.TryParseExact(dateString, "dd/MM/yyyy", arSA,
            //                         DateTimeStyles.None, out dateValue))
            //    Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue,
            //                      dateValue.Kind);
            //else if (DateTime.TryParseExact(dateString, "d/MM/yyyy", arSA,
            //                        DateTimeStyles.None, out dateValue))
            //    Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue,
            //                      dateValue.Kind);
            //else
            //    Console.WriteLine("'{0}' is not in an acceptable format.", dateString);

            //return dateValue;

            if (string.IsNullOrEmpty(dateString))
                return DateTime.MaxValue;

            var arSA = new System.Globalization.CultureInfo("ar-SA");
            arSA.DateTimeFormat.Calendar = new System.Globalization.UmAlQuraCalendar();

            var rr = dateString.Split('/');

            return new DateTime(Convert.ToInt32(rr[2]), Convert.ToInt32(rr[1]), Convert.ToInt32(rr[0]), arSA.DateTimeFormat.Calendar);

        }
    }
}
