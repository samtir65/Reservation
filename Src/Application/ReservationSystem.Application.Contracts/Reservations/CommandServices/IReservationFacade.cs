using Framework.Application;
using ReservationSystem.Application.Contracts.Reservations.Commands;

namespace ReservationSystem.Application.Contracts.Reservations.CommandServices
{
    public interface IReservationFacade:IApplicationService
    {
        long CreateReservation(CreateReservationsCommand createReservationsCommand);

    }
}
