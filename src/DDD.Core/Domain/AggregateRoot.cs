namespace Bieber.DDD.Core.Domain;
public abstract class AggregateRoot(Guid id) : Entity(id)
{
    private readonly List<IDomainEvent> _domainEvents = [];
    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();
    public void Raise(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();

    public void ApplyEvents(IEnumerable<IDomainEvent> events)
    {
        foreach (var @event in events)
        {
            ApplyEvent(@event);
        }
    }
    public abstract void ApplyEvent(IDomainEvent @event);

}