using AutoMapper;
using Batheer.Application.Common.Behaviours;
using Batheer.Application.Common.Mappings;
using Batheer.Application.Common.Models;
using Batheer.Application.Common.Models.RequestForms;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Batheer.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper((config) =>
            {
                //config.CreateMap<CreateRequestCommand, BaseRequest>()
                //        .ForMember(m => m.PersonalDataForm, opt => opt.MapFrom<PersonalDataFormModel>(o => o.PersonalDataForm));

                config.CreateMap<PersonalDataFormModel, PersonalDataForm>();
                config.CreateMap<UploadedFile, Domain.UploadedFile>();
                config.CreateMap<ContactInformationDataModel, ContactInformationData>();
                config.CreateMap<ResidencyAddressDataModel, ResidencyAddressData>();
                config.CreateMap<OccupationDataModel, OccupationData>();
                config.CreateMap<EducationalDataModel, EducationalData>();
                config.CreateMap<AccommodationDataModel, AccommodationData>();
                config.CreateMap<MaritalStatusDataModel, MaritalStatusData>();
                config.CreateMap<MonthlyIncomeDataModel, MonthlyIncomeData>();
                config.CreateMap<ProjectDataModel, ProjectData>();
                config.CreateMap<HealthStatusDataModel, HealthStatusData>();
                config.CreateMap<SocialSecurityDataModel, SocialSecurityData>();
                config.CreateMap<WorkOnAProjectDataModel, WorkOnAProjectData>();
                config.CreateMap<BankDefaultDataModel, BankDefaultData>();
                config.CreateMap<FinanceDataModel, FinanceData>();
                config.CreateMap<LoanDataModel, LoanData>();

                config.CreateMap<GoogleMapValuesDto, GoogleMapValues>();
                config.CreateMap<LatLngDto, LatLng>();
                config.CreateMap<MarkerDto, Marker>();

            }, Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

            return services;
        }
    }
}
