using Microsoft.AspNetCore.Mvc;
using Reservation.Query.Model.Reservations;
using ReservationSystem.Application.Contracts.Reservations.QueryServices;
using Framework.Core;
using Microsoft.AspNetCore.Authorization;

namespace ReservationSystem.Gateways.RestApi.Controllers.Reservations
{
    [Route("Reservations/api/[controller]")]
    [ApiController]
    public class ReservationsQueryController:ControllerBase
    {
        private IReservationQueryFacade _reservationQueryFacade;
        public ReservationsQueryController(IReservationQueryFacade reservationQueryFacade)
        {
            _reservationQueryFacade = reservationQueryFacade;
        }

        [HttpGet]
        [AllowAnonymous]
        public PageResult<ReservationQuery> GetAll([FromQuery]PageInfo pageInfo)
        {
            return _reservationQueryFacade.GetAll(pageInfo);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ReservationQuery GetAll(long id)
        {
           return _reservationQueryFacade.GetBy(id);
        }
    }
}
