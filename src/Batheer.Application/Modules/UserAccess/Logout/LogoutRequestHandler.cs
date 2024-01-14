using Batheer.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Modules.UserAccess.Logout
{
    public class LogoutRequestHandler : IRequestHandler<LogoutRequest>
    {
        private readonly ILogger<LogoutRequest> _logger;
        private readonly IHttpContextService _httpContextService;

        public LogoutRequestHandler(ILogger<LogoutRequest> logger, IHttpContextService httpContextService)
        {
            _logger = logger;
            _httpContextService = httpContextService;
        }

        public async Task<Unit> Handle(LogoutRequest request, CancellationToken cancellationToken)
        {
            await _httpContextService.Logout();
            return Unit.Value;

        }



    }
}
