using AutoMapper;
using Batheer.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Requests.PersonalDataForms.Queries.IsExistsIdentityNo 
{
    public class IsExistsIdentityNoDto : IMapFrom<Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm>
    {
        public bool Result { get; set; } 
        public string Message { get; set; }


        public void Mapping(Profile profile)
        {

            //profile.CreateMap<Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm, IsExistsIdentityNoDto>()
            //    .ForMember(d => d.Result, opt => opt.Condition(s => s == null, false ))
            //    .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.PersonalDataForm.FirstName))
            //    ));
        }
    }
}
