using Framework.Application;
using ReservationSystem.Application.Contracts.Customers.Commands;

namespace ReservationSystem.Application.Contracts.Customers.CommandServices
{
    public interface ICustomerFacade:IApplicationService
    {
        long CreateCustomer(CreateCustomersCommand command);

    }
}