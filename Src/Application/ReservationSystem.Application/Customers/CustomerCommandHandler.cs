using Framework.Application;
using Framework.Core;
using Framework.Core.Clock;
using ReservationSystem.Application.Contracts.Customers.Commands;
using ReservationSystem.Application.Customers.Mapper;
using ReservationSystem.Domain.Models.Customers.Factories;
using ReservationSystem.NH.Tests.Integration.Customers;

namespace ReservationSystem.Application.Customers
{
    public class CustomerCommandHandler : ICommandHandler<CreateCustomersCommand>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IClaimHelper _claimHelper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IClock _clock;

        public CustomerCommandHandler(IEventPublisher eventPublisher, IClaimHelper claimHelper, ICustomerRepository customerRepository, IClock clock)
        {
            _eventPublisher = eventPublisher;
            _claimHelper = claimHelper;
            _customerRepository = customerRepository;
            _clock = clock;
        }
        
        public void Handle(CreateCustomersCommand command)
        {
            var phones = CustomerMapper.MapToPhones(command.CustomerPhones);
            var id = _customerRepository.GetNextId();
            var customer = Factory.CreateCustomer(id,command.FirstName, command.LastName, _clock,phones, _eventPublisher,
                _claimHelper);

        }
    }
}