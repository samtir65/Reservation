using FluentAssertions;
using Xunit;

namespace ReservationSystem.Domain.Tests.Unit.Models
{
    public class ReservationTests
    {
        [Fact]
        public void construct_properly()
        {
            var reservation = new Reservation(10);
            reservation.Id.Should().Be(10);
            reservation.CreatOn.should().be();


        }
        
    }
}