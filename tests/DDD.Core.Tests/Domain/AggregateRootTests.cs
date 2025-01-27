using Bieber.DDD.Core.Domain;

namespace DDD.Core.Tests.Domain;

public class AggregateRootTests
{
    [Fact]
    public void Raise_DomainEvent_IsAddedToDomainEvents()
    {
        var aggregate = new DerivedAggregateRoot(Guid.NewGuid());
        var domainEvent = new TestDomainEvent();

        aggregate.Raise(domainEvent);

        Assert.Contains(domainEvent, aggregate.GetDomainEvents());
    }

    [Fact]
    public void ClearDomainEvents_DomainEventsAreCleared()
    {
        var aggregate = new DerivedAggregateRoot(Guid.NewGuid());
        var domainEvent = new TestDomainEvent();

        aggregate.Raise(domainEvent);
        aggregate.ClearDomainEvents();

        Assert.Empty(aggregate.GetDomainEvents());
    }

    [Fact]
    public void ApplyEvents_EventsAreApplied()
    {
        var aggregate = new DerivedAggregateRoot(Guid.NewGuid());
        var domainEvent = new TestDomainEvent();
        var events = new List<IDomainEvent> { domainEvent };

        aggregate.ApplyEvents(events);

        Assert.True(aggregate.EventApplied);
    }

    private class DerivedAggregateRoot : AggregateRoot
    {
        public bool EventApplied { get; private set; }

        public DerivedAggregateRoot(Guid id) : base(id) { }

        public override void ApplyEvent(IDomainEvent @event)
        {
            EventApplied = true;
        }
    }

    private class TestDomainEvent : IDomainEvent { }
}
