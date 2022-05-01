using Framework.Core.Clock;
using Framework.Domain;
using System;
using Framework.Application;
using Framework.Core;
using ReservationSystem.Domailn.Contract.Events.Reservations;
using ReservationSystem.Domain.Models.Personnels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReservationSystem.Domain.Models.Services;
using System.Linq;

namespace ReservationSystem.Domain.Models.Reservations
{
    public class Reservation:AggregateRoot<ReservationId>
    {
        public DateTime CreateOn { get; private set; }
        public long CustomerId { get; private set; }
        private readonly IList<SkillId> _requiredSkills;

        public IReadOnlyCollection<SkillId> RequiredSkills =>
            new ReadOnlyCollection<SkillId>(_requiredSkills);

        public PersonnelId PersonnelId { get; private set; }


        public Reservation(ReservationId id, IClock createOn, long customerId,List<SkillId> requiredSkills, PersonnelId personnelId, IClaimHelper claimHelper, IEventPublisher eventPublisher) 
            : base(id, eventPublisher, claimHelper.GetUserId())
        {
            CreateOn = createOn.Now();
            CustomerId = customerId;
            _requiredSkills = requiredSkills;
            PersonnelId = personnelId;
            var requiredSkillsEvent = requiredSkills.Select(x => x.DbId).ToList();
            Publish(new ReservationCreated(id.DbId,CreateOn,CustomerId, requiredSkillsEvent, PersonnelId.DbId,claimHelper.GetUserId(),claimHelper.GetUserName()));
        }
        protected Reservation(){}
    }
}       