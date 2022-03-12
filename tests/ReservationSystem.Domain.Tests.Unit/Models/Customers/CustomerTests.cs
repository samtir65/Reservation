using FluentAssertions;
using ReservationSystem.Domain.TestsUtils.Models.Customers;
using Xunit;

namespace ReservationSystem.Domain.Tests.Unit.Models.Customers
{
    public class CustomerTests
    {
        private readonly CustomerTestBuilder _customerTestBuilder;

        public CustomerTests()
        {
            _customerTestBuilder = new CustomerTestBuilder();
        }

        [Fact]
        public void construct_properly()
        {
            var customer = _customerTestBuilder.Build();
            customer.Id.Should().Be(_customerTestBuilder.Id);
            customer.FirstName.Should().Be(_customerTestBuilder.FirstName);
            customer.LastName.Should().Be(_customerTestBuilder.LastName);
            customer.CustomerPhones.Should().BeEquivalentTo(_customerTestBuilder.Phones);
        }
    }
}