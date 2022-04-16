using Framework.Core.Clock;
using Framework.Domain;
using System;
using Framework.Application;
using Framework.Core;

namespace ReservationSystem.Domain.Models.Reservations
{
    public class Reservation:AggregateRoot<ReservationId>
    {
        public DateTime CreateOn { get; private set; }
        public long CustomerId { get; private set; }
        public long ServiceId { get; private set; }
        public long PersonnelId { get; private set; }

        public Reservation(ReservationId id, IClock createOn, long customerId,long serviceId,long personnelId, IClaimHelper claimHelper, IEventPublisher eventPublisher) 
            : base(id, eventPublisher, claimHelper.GetUserId())
        {
            CreateOn = createOn.Now();
            CustomerId = customerId;
            ServiceId = serviceId;
            PersonnelId = personnelId;
            Publish(new ReservationCreated(id.DbId,CreateOn,CustomerId,ServiceId,PersonnelId,claimHelper.GetUserId(),claimHelper.GetUserName()));
        }
        protected Reservation(){}
    }
}