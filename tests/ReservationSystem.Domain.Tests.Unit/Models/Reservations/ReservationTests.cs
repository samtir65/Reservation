using FluentAssertions;
using ReservationSystem.Domain.TestsUtils.Models.Reservations;
using Xunit;

namespace ReservationSystem.Domain.Tests.Unit.Models.Reservations
{

    public class ReservationTests
    {
        private readonly ReservationTestBuilder _reservationTestBuilder;
        public ReservationTests()
        {
            _reservationTestBuilder = new ReservationTestBuilder();
        }

        [Fact]
        public void construct_properly()
        {
            var reservation = _reservationTestBuilder.Build();
            reservation.Id.Should().Be(_reservationTestBuilder.Id);
            reservation.CreateOn.Should().Be(_reservationTestBuilder.CreateOn.Now());
            reservation.CustomerId.Should().Be(_reservationTestBuilder.CustomerId);
            reservation.RequiredSkills.Should().BeEquivalentTo(_reservationTestBuilder.RequiredSkills);
            reservation.PersonnelId.Should().Be(_reservationTestBuilder.PersonelId);
        } 
    }
}