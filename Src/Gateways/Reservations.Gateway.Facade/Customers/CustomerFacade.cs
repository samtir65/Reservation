using Framework.Application;
using Framework.NH;
using ReservationSystem.Application.Contracts.Customers.Commands;
using ReservationSystem.Application.Contracts.Customers.CommandServices;
using ReservationSystem.Domailn.Contract.Events.Customers;

namespace Reservations.Gateway.Facade.Customers
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IEventListener _eventListener;

        public CustomerFacade(ICommandBus commandBus,IEventListener eventListener)
        {
            _commandBus = commandBus;
            _eventListener = eventListener;
        }
        public long CreateCustomer(CreateCustomersCommand command)
        {
            long id = 0;
            _eventListener.Subscribe(new ActionEventHandler<CustomerCreated>(x => id = x.Id));
            _commandBus.Dispatch(command);
            return id;
        }
    }
}