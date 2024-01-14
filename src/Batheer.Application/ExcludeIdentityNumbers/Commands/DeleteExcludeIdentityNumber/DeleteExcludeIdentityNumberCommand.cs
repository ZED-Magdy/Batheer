using AutoMapper;
using Batheer.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.ExcludeIdentityNumbers.Commands.DeleteExcludeIdentityNumber
{
    public class DeleteExcludeIdentityNumberCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteExcludeIdentityNumberCommandHandler : IRequestHandler<DeleteExcludeIdentityNumberCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeleteExcludeIdentityNumberCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<DeleteExcludeIdentityNumberCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteExcludeIdentityNumberCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.ExcludeIdentityNumbers
                .Where(w=> w.Id == request.Id)
                .FirstOrDefault();

            _context.ExcludeIdentityNumbers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }

}
