using NHibernate;
using ReservationSystem.Domain.Models.Reservations;
using ReservationSystem.Domain.TestsUtils.Models.Reservations;
using ReservationSystem.Persistence.NH.Repository.Reservations;
using Xunit;

namespace ReservationSystem.NH.Tests.Integration.Reservations
{
    public class ReservationRepositoryTest:BasePersistenceTest
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ReservationTestBuilder _reservationTestBuilder;
        public ReservationRepositoryTest()
        {
            _reservationRepository = new ReservationRepository(Session);
            _reservationTestBuilder = new ReservationTestBuilder();
        }
        [Fact]
        public void register_reservation()
        {
            Session.BeginTransaction();
            var reservation = _reservationTestBuilder.Build();
            _reservationRepository.Create(reservation);
            Session.GetCurrentTransaction().Commit();
            Session.Clear();
        }
    }
}