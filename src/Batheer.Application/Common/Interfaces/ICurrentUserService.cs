using System;

namespace Batheer.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        string CouncilName { get; }
        string User_Photo_ObjectKey { get; }
        int CouncilId { get; }
        Guid CouncilObjectkey { get; }
    }
}
