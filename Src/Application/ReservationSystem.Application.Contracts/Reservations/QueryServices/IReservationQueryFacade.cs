using Framework.Application;
using Framework.Core;
using Reservation.Query.Model;
using Reservation.Query.Model.Reservations;

namespace ReservationSystem.Application.Contracts.Reservations.QueryServices
{
    public interface IReservationQueryFacade:IApplicationService
    {
        PageResult<ReservationQuery> GetAll(PageInfo pageInfo);
        ReservationQuery GetBy(long id);
    }
}