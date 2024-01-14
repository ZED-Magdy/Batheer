﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Batheer.Application.Reports.Queries.SearchInFamilyRegistrationRequests
{
    public class SearchInFamilyRegistrationRequestsQuery : IRequest<IEnumerable<SearchInFamilyRegistrationRequestsDto>>
    {
        public string FullName { get; set; }
        public string IdentityNo { get; set; }
        public int? GenderId { get; set; }
        public int? NationalityId { get; set; }
        public int? AccommodationTypeId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string PhoneNumber { get; set; }
        public int? MaritalStatusId { get; set; }
        public int? EducationalLevelId { get; set; }
        public int? HealthStatusId { get; set; }
        public int? OccupationId { get; set; }
        public int? MonthlyIncomeId { get; set; }
        public int? FamilyCategoryId { get; set; }
        public int? FamilyNeedId { get; set; }
        public int? AssociationsAffiliatedWithTheCouncilId { get; set; }
    }

    public class SearchInFamilyRegistrationRequestsHandler : IRequestHandler<SearchInFamilyRegistrationRequestsQuery, IEnumerable<SearchInFamilyRegistrationRequestsDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;

        public SearchInFamilyRegistrationRequestsHandler(IApplicationDbContext context, IMapper mapper, ILogger<SearchInFamilyRegistrationRequestsQuery> logger, IQueryExecuter queryExecuter)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
        }

        public async Task<IEnumerable<SearchInFamilyRegistrationRequestsDto>> Handle(SearchInFamilyRegistrationRequestsQuery request, CancellationToken cancellationToken)
        {

            var parameters = new
            {
                request.FullName,
                request.IdentityNo,
                request.GenderId,
                request.NationalityId,
                request.AccommodationTypeId,
                request.Email,
                request.Mobile,
                request.PhoneNumber,
                request.MaritalStatusId,
                request.EducationalLevelId,
                request.HealthStatusId,
                request.OccupationId,
                request.MonthlyIncomeId,
                request.AssociationsAffiliatedWithTheCouncilId,
                request.FamilyCategoryId,
                request.FamilyNeedId
            };

            var paramNames = parameters.GetType().GetProperties().Select(s => "@" + s.Name);


            return _queryExecuter.Query<SearchInFamilyRegistrationRequestsDto>(
                "EXEC [dbo].[SP_FamilyRegistrationRequestsByAdmin] " +
                string.Join(',', paramNames),
                parameters);

        }

    }
}
