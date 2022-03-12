using Framework.NH;
using NHibernate;
using ReservationSystem.Domain.Models.Customers;
using ReservationSystem.NH.Tests.Integration.Customers;
using System.Linq;

namespace ReservationSystem.Persistence.NH.Repository.Customers
{
   
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ISession _session;

        public CustomerRepository(ISession session)
        {
            _session = session;
        }
        public void Create(Customer customer)
        {
            _session.Save(customer);
        }

        public Customer GetBy(CustomerId customerId)
        {
           return _session.Query<Customer>().FirstOrDefault(x => x.Id.DbId == customerId.DbId);
        }

        public CustomerId GetNextId()
        {
            var idValue = _session.GetNextSequence("SequenceCustomer");
            return new CustomerId(idValue);
        }
    }
}