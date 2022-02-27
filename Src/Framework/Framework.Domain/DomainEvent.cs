using Framework.Application;
using System;

namespace Framework.Domain
{
    public class DomainEvent:IEvent
    {
        public Guid EventId { get; set; }

        public DateTime DateTimePublish { get; set; }

        protected DomainEvent()
        {
            this.EventId = Guid.NewGuid();
            this.DateTimePublish = DateTime.Now;
        }
    }
}
