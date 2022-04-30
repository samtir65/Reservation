using Framework.Core;
using Reservation.Query.Model.Reservations;
using ReservationSystem.Application.Contracts.Reservations.QueryServices;

namespace Reservations.Gateway.Facade.Query.Reservations
{
    public class ReservationQueryFacade : IReservationQueryFacade
    {
        private readonly IReservationQueryRepository _reservationQueryRepository;

        public ReservationQueryFacade(IReservationQueryRepository reservationQueryRepository)
        {
            _reservationQueryRepository = reservationQueryRepository;
        }
        public PageResult<ReservationQuery> GetAll(PageInfo pageInfo)
        {
           return _reservationQueryRepository.GetAll(pageInfo);
        }

        public ReservationQuery GetBy(long id)
        {
            return _reservationQueryRepository.GetBy(id);
        }
    }
}
