using Framework.Application;
using Framework.NH;
using ReservationSystem.Application.Contracts.Reservations.Commands;
using ReservationSystem.Application.Contracts.Reservations.CommandServices;
using ReservationSystem.Domailn.Contract.Events.Notifications;

namespace Reservations.Gateway.Facade
{
    public class ReservationFacade : IReservationFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IEventListener _eventListener;

        public ReservationFacade(ICommandBus commandBus,IEventListener eventListener)
        {
            _commandBus = commandBus;
            _eventListener = eventListener;
        }
        public long CreateReservation(CreateReservationsCommand command)
        {
            long id = 0;
            _eventListener.Subscribe(new ActionEventHandler<ReservationCreated>(x => id = x.Id));
            _commandBus.Dispatch(command);
            return id;
        }

    }
}
