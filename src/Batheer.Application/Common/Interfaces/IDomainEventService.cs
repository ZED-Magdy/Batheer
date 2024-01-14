using Batheer.Domain.Common;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
