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
            var custumer = _customerTestBuilder.build();
        }
    }
}