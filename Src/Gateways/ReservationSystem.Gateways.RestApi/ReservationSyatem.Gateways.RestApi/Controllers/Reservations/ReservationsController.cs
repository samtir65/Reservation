using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Application.Contracts.Reservations.Commands;
using ReservationSystem.Application.Contracts.Reservations.CommandServices;

namespace ReservationSystem.Gateways.RestApi.Controllers.Reservations
{
    [Route("Reservations/api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationFacade _reservationFacade; 

        public ReservationsController(IReservationFacade reservationFacade)
        {
            _reservationFacade = reservationFacade;
        }
        [HttpPost]
        [AllowAnonymous]
        public long CreateReservation(CreateReservationsCommand command)
        {
            return _reservationFacade.CreateReservation(command);

        }
    }
}
