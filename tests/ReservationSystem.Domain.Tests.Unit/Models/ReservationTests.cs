using FluentAssertions;
using ReservationSystem.Domain.TestsUtils.Models;
using System;
using Xunit;

namespace ReservationSystem.Domain.Tests.Unit.Models
{
    
    public class ReservationTests
    {
        private readonly ReservationTestBuilder _reservationTestBuilder;
        public ReservationTests(ReservationTestBuilder reservationTestBuilder)
        {
            _reservationTestBuilder = reservationTestBuilder;
        }
        [Fact]
        public void construct_properly()
        {
            var creatOn = DateTime.Now;
            var reservation = new ReservationTestBuilder.Build();
            reservation.Id.Should().Be(_reservationTestBuilder.Id);
            reservation.CreatOn.Should().Be(_reservationTestBuilder.CreatOn);
            reservation.CustomerId.Should().Be(_reservationTestBuilder.CustomerId);
            reservation.ServiceId.Should().Be(_reservationTestBuilder.ServiceId);
            reservation.PersonelId.Should().Be(_reservationTestBuilder.PersonelId);
        } 
    }
}