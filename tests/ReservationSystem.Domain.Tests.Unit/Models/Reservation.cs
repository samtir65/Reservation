using Framework.Domain;
using System;

namespace ReservationSystem.Domain.Tests.Unit.Models
{
    public class Reservation:AggregateRoot<long>
    {
        public DateTime CreatOn { get; private set; }
        public long CustomerId { get; internal set; }
        public long ServiceId { get; internal set; }
        public long BarberId { get; internal set; }

        public Reservation(long id, DateTime createOn, long customerId,long serviceId,long barberId) : base(id)
        {

        }
    }
}