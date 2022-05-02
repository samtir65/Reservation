using FluentAssertions;
using NHibernate;
using ReservationSystem.Domain.TestsUtils.Models.Customers;
using ReservationSystem.NH.Tests.Integration.Reservations;
using ReservationSystem.Persistence.NH.Repository.Customers;
using Xunit;

namespace ReservationSystem.NH.Tests.Integration.Customers
{
    public class CustomerRepositoryTest : BasePersistenceTest
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerTestBuilder _customerTestBuilder;

        public CustomerRepositoryTest()
        {
            _customerRepository = new CustomerRepository(Session);
            _customerTestBuilder = new CustomerTestBuilder();
        }

        [Fact]
        public void register_customer()
        {
            Session.BeginTransaction();
            var customer = _customerTestBuilder.Build();
            _customerRepository.Create(customer);
            Session.GetCurrentTransaction().Commit(); 
            Session.Clear();
            var expectedCustmoer = _customerRepository.GetBy(customer.Id);
            expectedCustmoer.Should().BeEquivalentTo(customer);

        }
    }
}
