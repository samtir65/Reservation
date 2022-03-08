using System.Linq;
using Framework.Core;
using NHibernate;
using Reservation.Query.Model.Reservations;

namespace Reservation.Query.NH.Repositories
{
    public class ReservationQueryRepository : IReservationQueryRepository
    {
        private ISession _session;

        public ReservationQueryRepository(ISession session)
        {
            _session = session;
        }
        public PageResult<ReservationQuery> GetAll(PageInfo pageInfo)
        {
            if (!pageInfo.Take.HasValue)
                pageInfo.Take = 10;
            var totalCount = _session.Query<ReservationQuery>().Count();
            var data = _session.Query<ReservationQuery>().OrderByDescending(x => x.Id)
                .Skip(pageInfo.Skip).Take(pageInfo.Take.Value).ToList();
            return new PageResult<ReservationQuery>(data, totalCount);
        }

        public ReservationQuery GetBy(long id)
        {
            return _session.Query<ReservationQuery>().FirstOrDefault(x => x.Id == id);
        }
    }
}