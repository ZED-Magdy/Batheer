using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    public class Family : AuditableEntity, ISoftDeletabe
    {
        public int Id { get; set; }
        public virtual FamilyRegistrationRequest FamilyRegistrationRequest { get; set; }

        public virtual ResponsibleFamilyMember ResponsibleFamilyMember { get; set; }
        public int ResponsibleFamilyMemberId { get; set; }

        public virtual SupportingFamilyRequest SupportingFamilyRequest { get; set; }


        public virtual ICollection<FamilyMember> FamilyMembers { get; set; }


        /********/

        public int ContactInformationId { get; set; }
        public virtual Entities.ContactInformationData ContactInformationData { get; set; }

        public int ResidencyAddressDataId { get; set; }
        public virtual Entities.ResidencyAddressData ResidencyAddressData { get; set; }

        public int AccommodationDataId { get; set; }
        public virtual Entities.AccommodationData AccommodationData { get; set; }


        public int MonthlyIncomeDataId { get; set; }
        public virtual Entities.MonthlyIncomeData MonthlyIncomeData { get; set; }


        public int SocialSecurityDataId { get; set; }
        public virtual Entities.SocialSecurityData SocialSecurityData { get; set; }

        public Guid objectkey { get; set; }

        /// <summary>
        /// كرت العائلة
        /// </summary>
        public int? FamilyIdentityCardFileId { get; set; }
        public virtual UploadedFile FamilyIdentityCardFile { get; set; }


        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string DeleteNotes { get; set; }
    }
}
