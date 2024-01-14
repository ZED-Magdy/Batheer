using AutoMapper;
using Batheer.Application.Common.Interfaces;
using Batheer.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.ExcludeIdentityNumbers.Commands.CreateExcludeIdentityNumber
{
    public class CreateExcludeIdentityNumberCommand : IRequest<int>
    {
        public string IdentityNo { get; set; }
        public string Notes { get; set; }
    }

    public class CreateExcludeIdentityNumberCommandHandler : IRequestHandler<CreateExcludeIdentityNumberCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreateExcludeIdentityNumberCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<CreateExcludeIdentityNumberCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateExcludeIdentityNumberCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.ExcludeIdentityNumbers.Add(new ExcludeIdentityNumber());

            entity.CurrentValues.SetValues(request);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Entity.Id;
        }

    }

}
