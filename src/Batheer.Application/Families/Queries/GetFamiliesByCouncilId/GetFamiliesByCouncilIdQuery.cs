using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Mappings;
using Batheer.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Requests.BaseRequests.Queries.GetFamiliesByCouncilId
{
    /// <summary>
    /// جميع الطلبات الخاصة بالجمعية
    /// </summary>
    public class GetFamiliesByCouncilIdQuery : IRequest<PaginatedList<GetFamiliesByCouncilIdDto>>
    {
        public GetFamiliesByCouncilIdQuery(int councilId, int pageNumber, int pageSize, SortOrders sortOrder)
        {
            CouncilId = councilId;
            PageNumber = pageNumber == 0 ? 1 : pageNumber;
            PageSize = pageSize == 0 ? 10 : pageSize;
            SortOrder = sortOrder;
        }
        public int CouncilId { get; }
        public int PageNumber { get; } = 1;
        public int PageSize { get; } = 10;
        public SortOrders SortOrder { get; } = GetFamiliesByCouncilIdQuery.SortOrders.Id_Desc;


        public enum SortOrders
        {
            Id_Aesc,
            Id_Desc,
        }
    }

    public class GetFamiliesByCouncilIdQueryHandler : IRequestHandler<GetFamiliesByCouncilIdQuery, PaginatedList<GetFamiliesByCouncilIdDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetFamiliesByCouncilIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetFamiliesByCouncilIdQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PaginatedList<GetFamiliesByCouncilIdDto>> Handle(GetFamiliesByCouncilIdQuery request, CancellationToken cancellationToken)
        {

            var query = _context
                .FamilyRegistrationRequests
                .Include(f => f.Family)
                .Include(t => t.CouncilProject)
                .Include(t => t.Family.ResponsibleFamilyMember.PersonalDataForm)
                .Select(s => s);

            if (request.CouncilId != 0)
            {
                query = query.Where(w => w.AssociationsAffiliatedWithTheCouncilId == request.CouncilId);
            }

            switch (request.SortOrder)
            {
                case GetFamiliesByCouncilIdQuery.SortOrders.Id_Aesc:
                    query = query.OrderBy(o => o.Id);
                    break;
                case GetFamiliesByCouncilIdQuery.SortOrders.Id_Desc:
                    query = query.OrderByDescending(o => o.Id);
                    break;
                default:
                    break;
            }


            return await query
                .AsNoTracking()
                .ProjectTo<GetFamiliesByCouncilIdDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            /*
            if (request.CouncilId == 0)
            {
                // افتكاسة يا محمد
                return await _context
                .FamilyRegistrationRequests
                .Include(t => t.CouncilProject)
                .Include(t => t.Family.ResponsibleFamilyMember.PersonalDataForm)
                //.Include(t => t.Family.ResponsibleFamilyMember.PersonalDataForm.Nationality)
                .ProjectTo<GetFamiliesByCouncilIdDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
                //.ToListAsync(cancellationToken);

            }

            var result = await _context
                .FamilyRegistrationRequests
                .Include(t => t.CouncilProject)
                .Include(t => t.Family.ResponsibleFamilyMember.PersonalDataForm)
                //.Include(t => t.Family.ResponsibleFamilyMember.PersonalDataForm.Nationality)
                .Where(w => w.AssociationsAffiliatedWithTheCouncilId == request.CouncilId)
                .ProjectTo<GetFamiliesByCouncilIdDto>(_mapper.ConfigurationProvider)
                 .PaginatedListAsync(request.PageNumber, request.PageSize);
            //.ToListAsync(cancellationToken);

            return result;
            */
        }

    }
}
