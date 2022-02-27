using Framework.Application;
using Framework.Core.Clock;
using ReservationSystem.Application.Contracts.Reservations.Commands;
using ReservationSystem.Domain.Models.Reservations;
using ReservationSystem.Domain.Models.Reservations.Factories;

namespace ReservationSystem.Application.Reservations
{
    public class ReservationCommandHandler : ICommandHandler<CreateReservationsCommand>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IClock _clock;
        public ReservationCommandHandler(IReservationRepository reservationRepository,IClock clock)
        {
            _reservationRepository = reservationRepository;
            _clock = clock;

        }
        public void Handle(CreateReservationsCommand command)
        {
            var id = _reservationRepository.GetNextId();
            var reservation = Factory.CreateReservation(id,_clock, command.CustomerId, command.ServiceId,
                command.PersonelId);
            _reservationRepository.Create(reservation);
        }
    }
}
