using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Application.Contracts.Reservations.Commands;
using ReservationSystem.Application.Contracts.Reservations.CommandServices;

namespace ReservationSyatem.Gateways.RestApi.Controllers.Reservations
{
    [Route("Reservations/api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationFacade _reservationFacade; 

        public ReservationController(IReservationFacade reservationFacade)
        {
            _reservationFacade = reservationFacade;
        }
        [HttpPost]
        public long CreateReservation(CreateReservationsCommand command)
        {
            return _reservationFacade.CreateReservation(command);

        }

    }
}
