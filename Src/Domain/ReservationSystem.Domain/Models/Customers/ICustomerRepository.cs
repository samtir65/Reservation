using ReservationSystem.Domain.Models.Customers;

namespace ReservationSystem.NH.Tests.Integration.Customers
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        Customer GetBy(CustomerId customerId);
        CustomerId GetNextId();
    }
}