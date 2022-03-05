using Framework.Application;

namespace Framework.Domain
{
    public class AggregateRoot<T> : Entity<T>
    {
        private IEventPublisher _publisher;
        public AggregateRoot(T id, IEventPublisher publisher) 
            : base(id)
        {
            this._publisher = publisher;
        }

        protected AggregateRoot(){}
    }
}