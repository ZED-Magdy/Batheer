using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Models.RequestForms
{
    public class PersonalDataFormModel : IMapFrom<Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm>
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
        //public string IdentityFilePath { get; set; }
        public UploadedFile IdentityFile { get; set; }
        //public string PersonalPhotoFilePath { get; set; }
        public UploadedFile PersonalPhotoFile { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Domain.UploadedFile, UploadedFile>()
            //    .ForMember(d => d.Content, opt => opt.MapFrom(s => s.Content))
            //    .ForMember(d => d.ContentType, opt => opt.MapFrom(s => s.ContentType))
            //    .ForMember(d => d.FileName, opt => opt.MapFrom(s => s.FileName));

           // profile.CreateMap<Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm, UploadedFile>();
           // profile.CreateMap<Domain.UploadedFile, UploadedFile>();

            profile.CreateMap<Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm, PersonalDataFormModel>()
                .ForMember(d => d.IdentityFile, opt => opt.MapFrom(s => s.IdentityFile))
                .ForMember(d => d.PersonalPhotoFile, opt => opt.MapFrom(s => s.PersonalPhotoFile));
        }

    }
}
