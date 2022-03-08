using Framework.Core;

namespace Reservation.Query.Model.Reservations
{
    public interface IReservationQueryRepository
    {
        PageResult<ReservationQuery> GetAll(PageInfo pageInfo);
        ReservationQuery GetBy(long id);
    }
}
