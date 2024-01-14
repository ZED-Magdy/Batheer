using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Requests.PersonalDataForms.Queries.GetByBaseRequestId
{
    public class GetByBaseRequestIdQuery : IRequest<PersonalDataFormDto>
    {
        public int BaseRequestId { get; }

        public GetByBaseRequestIdQuery(int BaseRequestId)
        {
            BaseRequestId = BaseRequestId;
        }
    }
    public class GetByBaseRequestIdQueryHandler : IRequestHandler<GetByBaseRequestIdQuery, PersonalDataFormDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetByBaseRequestIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetByBaseRequestIdQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PersonalDataFormDto> Handle(GetByBaseRequestIdQuery request, CancellationToken cancellationToken)
        {

            var result = await _context
                .PersonalDataForm
                //.Where(w => w.BaseRequests.Any(a => a.Id == request.BaseRequestId))
                .ProjectTo<PersonalDataFormDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            //var result = await _context
            //    .BaseRequests
            //    .Include(i=> i.PersonalDataForm)
            //    .Where(w => w.Id == request.BaseRequestId)
            //    .Select(s=> s.PersonalDataForm)
            //    .ProjectTo<PersonalDataFormDto>(_mapper.ConfigurationProvider)
            //    .ToListAsync(cancellationToken);

            return result.FirstOrDefault();
        }

    }
}
