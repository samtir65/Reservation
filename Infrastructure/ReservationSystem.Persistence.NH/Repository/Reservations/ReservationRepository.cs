using NHibernate;
using ReservationSystem.Domain.Models.Reservations;
using System.Linq;

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

        public Reservation GetBy(ReservationId reservationId)
        {
            return _session.Query<Reservation>().FirstOrDefault(x => x.Id.DbId == reservationId.DbId);

        }
    }
}