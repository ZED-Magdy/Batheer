using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    /// <summary>
    /// نموذج البيانات الشخصية 
    /// </summary>
    public class PersonalDataForm : AuditableEntity
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
        public virtual Gender Gender { get; set; }

        public int NationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }

        //public string IdentityFilePath { get; set; }
        public virtual UploadedFile IdentityFile { get; set; }
        public int? IdentityFileId { get; set; }
        //public string PersonalPhotoFilePath { get; set; }
        public virtual UploadedFile PersonalPhotoFile { get; set; }
        public int? PersonalPhotoFileId { get; set; }
    }
}
