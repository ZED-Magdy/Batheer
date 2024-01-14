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

namespace Batheer.Application.Requests.PersonalDataForms.Queries.IsExistsIdentityNo
{
    public class IsExistsIdentityNoQuery : IRequest<IsExistsIdentityNoDto>
    {
        public IsExistsIdentityNoQuery(string identityNo)
        {
            IdentityNo = identityNo;
        }
        public string IdentityNo { get; }
    }

    public class GetIsExistsIdentityNoQueryHandler : IRequestHandler<IsExistsIdentityNoQuery, IsExistsIdentityNoDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetIsExistsIdentityNoQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<IsExistsIdentityNoQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IsExistsIdentityNoDto> Handle(IsExistsIdentityNoQuery request, CancellationToken cancellationToken)
        {
            IsExistsIdentityNoDto result;
            var result1 = await _context
                .PersonalDataForm
                .AnyAsync(w => w.IdentityNo == request.IdentityNo, cancellationToken);
            // .ProjectTo<IsExistsIdentityNoDto>(_mapper.ConfigurationProvider)
            //  .ToListAsync();


            // return result1.FirstOrDefault();


            return new IsExistsIdentityNoDto() { Result = result1 };

        }

    }
}
