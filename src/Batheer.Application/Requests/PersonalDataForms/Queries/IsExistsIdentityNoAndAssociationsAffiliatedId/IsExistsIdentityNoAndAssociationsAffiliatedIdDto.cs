using AutoMapper;
using Batheer.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Requests.PersonalDataForms.Queries.IsExistsIdentityNoAndAssociationsAffiliatedId
{
    public class IsExistsIdentityNoAndAssociationsAffiliatedIdDto : IMapFrom<Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm>
    {
        public bool Result { get; set; } 
        public int PersonalDataFormId { get; set; }
        public int BaseRequestId { get; set; }


        public void Mapping(Profile profile)
        {

            //profile.CreateMap<Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm, IsExistsIdentityNoDto>()
            //    .ForMember(d => d.Result, opt => opt.Condition(s => s == null, false ))
            //    .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.PersonalDataForm.FirstName))
            //    ));
        }
    }
}
