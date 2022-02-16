using FluentAssertions;
using System;
using Xunit;

namespace ReservationSystem.Domain.Tests.Unit.Models
{
    public class ReservationTests
    {
        [Fact]
        public void construct_properly()
        {
            var creatOn = DateTime.Now;
            var reservation = new Reservation(10,creatOn,1,2,1);
            reservation.Id.Should().Be(10);
            reservation.CreatOn.Should().Be(creatOn);
            reservation.CustomerId.Should().Be(1);
            reservation.ServiceId.Should().Be(2);
            reservation.BarberId.Should().Be(1);

        }
        
    }
}