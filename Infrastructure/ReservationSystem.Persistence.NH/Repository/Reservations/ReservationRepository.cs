using NHibernate;
using ReservationSystem.Domain.Models.Reservations;

namespace ReservationSystem.Persistence.NH.Repository.Reservations
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ISession _session;

        public ReservationRepository(ISession session)
        {
            _session = session;
        }
        public void Create(Reservation reservation)
        {
            _session.Save(reservation);
        }
    }
}