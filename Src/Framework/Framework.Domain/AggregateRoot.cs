using System.Collections.Generic;
using Framework.Application;

namespace Framework.Domain
{
    public class AggregateRoot<T> : Entity<T>,IAggregateRoot
    {
        private IEventPublisher _publisher;
        private readonly List<DomainEvent> _publishedEvents = new List<DomainEvent>();
        public long CreatorUserId { get; private set; }
        public AggregateRoot(T id, IEventPublisher publisher, long creatorUserId) 
            : base(id)
        {
            this._publisher = publisher;
            this.CreatorUserId = creatorUserId;
        }

        protected AggregateRoot(){}
        public void SetPublisher(IEventPublisher publisher) => this._publisher = publisher;

        public void Publish<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            this._publishedEvents.Add((DomainEvent)@event);
            this._publisher.Publish<TEvent>(@event);
        }

        public IReadOnlyList<DomainEvent> GetChanges() => (IReadOnlyList<DomainEvent>)this._publishedEvents;

        public void ClearChanges() => this._publishedEvents.Clear();
    }
}