using Framework.Core.Clock;
using Framework.Test;
using Framework.Test.ClockStubs;
using ReservationSystem.Domain.Models.Reservations;
using System;
using Framework.Application;
using Framework.Core;

namespace ReservationSystem.Domain.TestsUtils.Models.Reservations
{
    public class ReservationTestBuilder
    {
        public ReservationId Id { get; private set; }
        public IClock CreateOn { get; private set; }
        public long CustomerId { get; private set; }
        public long ServiceId { get; private set; }
        public long PersonelId { get; private set; }
        public IClaimHelper ClaimHelper { get; set; }
        public IEventPublisher EventPublisher { get; set; }

        public ReservationTestBuilder()
        {
            Id = new ReservationId(GenerateRandom.Number());
            CreateOn = new ClockStub(DateTime.Now);
            CustomerId = GenerateRandom.Number();
            ServiceId = GenerateRandom.Number();
            ClaimHelper = new ClaimHelperStub();
            EventPublisher = new FakeEventPublisher();
        }
        public Reservation Build()
        {
            return new Reservation(Id,CreateOn, CustomerId, ServiceId, PersonelId,ClaimHelper,EventPublisher);

        }
    }
}
