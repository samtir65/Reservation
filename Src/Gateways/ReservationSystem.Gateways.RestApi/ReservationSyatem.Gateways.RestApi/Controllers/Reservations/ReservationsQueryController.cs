using Microsoft.AspNetCore.Mvc;
using Reservation.Query.Model.Reservations;
using ReservationSystem.Application.Contracts.Reservations.CommandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationSystem.Application.Contracts.Reservations.QueryServices;
using Framework.Core;

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
        public PageResult<ReservationQuery> GetAll([FromQuery]PageInfo pageInfo)
        {
            return _reservationQueryFacade.GetAll(pageInfo);
        }
        public ReservationQuery GetAll(long id)
        {
           return _reservationQueryFacade.GetBy(id);
        }
    }
}
