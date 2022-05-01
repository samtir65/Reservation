using System;
using System.Collections.Generic;
using Framework.Application;
using Framework.Domain;

namespace ReservationSystem.Domailn.Contract.Events.Reservations
{
    public class ReservationCreated : DomainEvent,IUserInfo
    {
        public long Id { get; private set; }
        public DateTime CreateOn { get; private set; }
        public long CustomerId { get; private set; }
        public List<long> RequiredSkills { get; private set; }
        public long PersonelId { get; private set; }
        public long ActionUserId { get; set; }
        public string UserName { get; set; }

        public ReservationCreated(long id,DateTime createOn, long customerId, List<long> requiredSkills, long personelId, long actionUserId, string userName)
        {
            Id = id;
            CreateOn = createOn;
            CustomerId = customerId;
            RequiredSkills = requiredSkills;
            PersonelId = personelId;
            ActionUserId = actionUserId;
            UserName = userName;
        }
    }
}
