using Framework.Application;
using Framework.Core;
using Framework.Core.Clock;
using ReservationSystem.Application.Contracts.Reservations.Commands;
using ReservationSystem.Domain.Models.Reservations;
using ReservationSystem.Domain.Models.Reservations.Factories;

namespace ReservationSystem.Application.Reservations
{
    public class ReservationCommandHandler : ICommandHandler<CreateReservationsCommand>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IClaimHelper _claimHelper;
        private readonly IReservationRepository _reservationRepository;
        private readonly IClock _clock;
        public ReservationCommandHandler(IReservationRepository reservationRepository,IClock clock,IEventPublisher eventPublisher,IClaimHelper claimHelper)
        {
            _reservationRepository = reservationRepository;
            _clock = clock;
            _claimHelper = claimHelper;
            _eventPublisher = eventPublisher;

        }
        public void Handle(CreateReservationsCommand command)
        {
            var id = _reservationRepository.GetNextId();
            var reservation = Factory.CreateReservation(id,_clock, command.CustomerId, command.ServiceId,
                command.PersonelId,_claimHelper,_eventPublisher);
            _reservationRepository.Create(reservation);
        }
    }
}
