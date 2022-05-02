using Framework.Core.Clock;
using Framework.Test;
using Framework.Test.ClockStubs;
using ReservationSystem.Domain.Models.Reservations;
using System;
using Framework.Application;
using Framework.Core;
using System.Collections.Generic;
using ReservationSystem.Domain.Models.Services;
using ReservationSystem.Domain.Models.Personnels;

namespace ReservationSystem.Domain.TestsUtils.Models.Reservations
{
    public class ReservationTestBuilder
    {
        public ReservationId Id { get; private set; }
        public IClock CreateOn { get; private set; }
        public long CustomerId { get; private set; }
        public List<SkillId> RequiredSkills { get; private set; }
        public PersonnelId PersonelId { get; private set; }
        public IClaimHelper ClaimHelper { get; set; }
        public IEventPublisher EventPublisher { get; set; }

        public ReservationTestBuilder()
        {
            Id = new ReservationId(GenerateRandom.Number());
            CreateOn = new ClockStub(DateTime.Now);
            CustomerId = GenerateRandom.Number();
            RequiredSkills = new List<SkillId>();
            PersonelId = new PersonnelId(GenerateRandom.Number());
            ClaimHelper = new ClaimHelperStub();
            EventPublisher = new FakeEventPublisher();
        }
        public Reservation Build()
        {
            return new Reservation(Id,CreateOn, CustomerId,RequiredSkills,PersonelId,ClaimHelper,EventPublisher);

        }
    }
}
