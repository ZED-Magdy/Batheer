using System;

namespace Batheer.DataMigration.Models
{
    public class PersonalDataFormModel 
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }

        public string IdentityNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public int GenderId { get; set; }

        public int NationalityId { get; set; }
        public UploadedFile IdentityFile { get; set; }
        //public string PersonalPhotoFilePath { get; set; }
        public UploadedFile PersonalPhotoFile { get; set; }

    }
}
