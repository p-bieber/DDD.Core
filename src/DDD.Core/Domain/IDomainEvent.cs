using MediatR;

namespace Bieber.DDD.Core.Domain;
public interface IDomainEvent : INotification
{
    public Guid AggregateId { get; }
}
