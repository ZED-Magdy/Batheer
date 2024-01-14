using AutoMapper;
using Batheer.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Requests.PersonalDataForms.Queries.GetByBaseRequestId
{
    public class PersonalDataFormDto : IMapFrom<Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }

        public string IdentityNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public int Gender { get; set; }

        public int NationalityId { get; set; }
        public Guid? IdentityFileObjectKey { get; set; }
        public Guid? PersonalPhotoFileObjectKey { get; set; }
    }
}
