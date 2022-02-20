using Framework.Domain;
using System;

namespace ReservationSystem.Domain.Tests.Unit.Models
{
    public class Reservation:AggregateRoot<long>
    {
        public DateTime CreatOn { get; private set; }
        public long CustomerId { get; private set; }
        public long ServiceId { get; private set; }
        public long PersonelId { get; private set; }

        public Reservation(long id, DateTime createOn, long customerId,long serviceId,long personelId) : base(id)
        {
            CreatOn = createOn;
            CustomerId = customerId;
            ServiceId = serviceId;
            PersonelId = personelId;
        }
    }
}