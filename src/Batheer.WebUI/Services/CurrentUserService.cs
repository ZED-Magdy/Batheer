using Batheer.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Batheer.WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
        public string CouncilName => _httpContextAccessor.HttpContext?.User?.FindFirstValue("CouncilName");
        public Guid CouncilObjectkey => Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue("CouncilObjectkey"));
        public string User_Photo_ObjectKey => _httpContextAccessor.HttpContext?.User?.FindFirstValue("User_Photo_ObjectKey");
        public int CouncilId => Convert.ToInt32(_httpContextAccessor.HttpContext?.User?.FindFirstValue("CouncilId"));

    }
}
