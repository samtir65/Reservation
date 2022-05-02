using FluentAssertions;
using ReservationSystem.Domain.TestsUtils.Models.Personnels;
using Xunit;

namespace ReservationSystem.Domain.Tests.Unit.Models.Personnels
{
    public class PersonnelTests
    {
        private readonly PersonnelTestBuilder _personnelTestBuilder;

        public PersonnelTests()
        {
            _personnelTestBuilder = new PersonnelTestBuilder();
        }

        [Fact]
        public void construct_properly()
        {
            var personnel = _personnelTestBuilder.Build();
            personnel.Id.Should().Be(_personnelTestBuilder.Id);
            personnel.FirstName.Should().Be(_personnelTestBuilder.FirstName);
            personnel.LastName.Should().Be(_personnelTestBuilder.LastName);
            personnel.Skills.Should().BeEquivalentTo(_personnelTestBuilder.Skills);

        }
    }
}