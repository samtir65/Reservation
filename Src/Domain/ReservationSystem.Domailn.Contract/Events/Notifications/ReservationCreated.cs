using Framework.Application;
using Framework.Domain;
using System;

namespace ReservationSystem.Domailn.Contract.Events.Notifications
{
    public class ReservationCreated : DomainEvent, IUserInfo
    {
        public long Id { get; private set; }
        public DateTime CreateOn { get; private set; }
        public long CustomerId { get; private set; }
        public long ServiceId { get; private set; }
        public long PersonelId { get; private set; }
        public long ActionUserId { get; set; }
        public string UserName { get; set; }

        public ReservationCreated(long id,DateTime createOn, long customerId, long serviceId, long personelId, long actionUserId, string userName)
        {
            Id = id;
            CreateOn = createOn;
            CustomerId = customerId;
            ServiceId = serviceId;
            PersonelId = personelId;
            ActionUserId = actionUserId;
            UserName = userName;
        }
    }
}
