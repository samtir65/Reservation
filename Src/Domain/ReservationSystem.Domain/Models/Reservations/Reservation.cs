using Framework.Core.Clock;
using Framework.Domain;
using System;
using Framework.Application;

namespace ReservationSystem.Domain.Models.Reservations
{
    public class Reservation:AggregateRoot<ReservationId>
    {
        public DateTime CreateOn { get; private set; }
        public long CustomerId { get; private set; }
        public long ServiceId { get; private set; }
        public long PersonelId { get; private set; }

        public Reservation(ReservationId id, IClock createOn, long customerId,long serviceId,long personelId, IClaimHelper claimHelper, IEventPublisher eventPublisher) : base(id, eventPublisher, claimHelper.GetUserId())
        {
            CreateOn = createOn.Now();
            CustomerId = customerId;
            ServiceId = serviceId;
            PersonelId = personelId;
        }

        protected Reservation(){}
    }
}