using System;
using FluentAssertions;
using Framework.Test.ClockStubs;
using NHibernate;
using ReservationSystem.Domain.Models.Reservations;
using ReservationSystem.Domain.TestsUtils.Models.Reservations;
using ReservationSystem.Persistence.NH.Repository.Reservations;
using Xunit;
using IClock = Framework.Core.Clock.IClock;

namespace ReservationSystem.NH.Tests.Integration.Reservations                                                                                          
{
    public class ReservationRepositoryTest:BasePersistenceTest
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ReservationTestBuilder _reservationTestBuilder;
        private readonly IClock _clock;
        public ReservationRepositoryTest()
        {
            _reservationRepository = new ReservationRepository(Session);
            _reservationTestBuilder = new ReservationTestBuilder();
            _clock = new ClockStub(DateTime.Now);
        }
        [Fact]
        public void register_reservation()
        {
            Session.BeginTransaction();
            var reservation = _reservationTestBuilder.Build();
            _reservationRepository.Create(reservation);
            Session.GetCurrentTransaction().Commit();
            Session.Clear();

            var expectedReservationSystem = _reservationRepository.GetBy(reservation.Id);
            expectedReservationSystem.Should().BeEquivalentTo(reservation);

        }
    }
}