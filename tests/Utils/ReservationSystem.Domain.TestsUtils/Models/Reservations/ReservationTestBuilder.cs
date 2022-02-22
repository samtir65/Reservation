using Framework.Core.Clock;
using Framework.Domain;
using Framework.Test;
using Framework.Test.ClockStubs;
using ReservationSystem.Domain.Models.Reservations;
using System;

namespace ReservationSystem.Domain.TestsUtils.Models.Reservations
{
    public class  ReservationTestBuilder
    {
        public ReservationId Id { get;private set; }
        public IClock CreatOn { get; set; }
        public long CustomerId { get;private set; }
        public long ServiceId { get;private set; }
        public long PersonelId { get;private set; }
        public ReservationTestBuilder()
        {
            Id = new ReservationId(GenerateRandom.Number()) ;
            CreatOn = new ClockStub(DateTime.Now);
            CustomerId = GenerateRandom.Number();
            ServiceId = GenerateRandom.Number();
        }

        public Reservation Build()
        {
            return new Reservation(Id,CreatOn, CustomerId, ServiceId, PersonelId);
        
        }
    }

}
