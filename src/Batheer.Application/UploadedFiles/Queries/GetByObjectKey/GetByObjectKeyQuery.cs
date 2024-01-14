using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Batheer.Application.UploadedFiles.Queries.GetByObjectKey
{
    public class GetByObjectKeyQuery : IRequest<GetByObjectKeyDto>
    {
        public GetByObjectKeyQuery(Guid objectKey)
        {
            ObjectKey = objectKey;
        }

        public Guid ObjectKey { get; }
    }
    public class GetByObjectKeyQueryHandler : IRequestHandler<GetByObjectKeyQuery, GetByObjectKeyDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetByObjectKeyQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetByObjectKeyQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetByObjectKeyDto> Handle(GetByObjectKeyQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .UploadedFiles
                .Where(w => w.ObjectKey == request.ObjectKey)
                .ProjectTo<GetByObjectKeyDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result.FirstOrDefault();
        }

    }
}
