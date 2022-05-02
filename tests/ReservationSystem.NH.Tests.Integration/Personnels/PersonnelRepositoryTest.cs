using FluentAssertions;
using NHibernate;
using ReservationSystem.Domain.Models.Personnels;
using ReservationSystem.Domain.TestsUtils.Models.Customers;
using ReservationSystem.Domain.TestsUtils.Models.Personnels;
using ReservationSystem.NH.Tests.Integration.Reservations;
using ReservationSystem.Persistence.NH.Repository.Customers;
using ReservationSystem.Persistence.NH.Repository.Personnels;
using Xunit;

namespace ReservationSystem.NH.Tests.Integration.Customers
{
    public class PersonnelRepositoryTest: BasePersistenceTest
    {
        private readonly IPersonnelRepository _personnelRepository;
        private readonly PersonnelTestBuilder _personnelTestBuilder;

        public PersonnelRepositoryTest()
        {
            _personnelRepository = new PersonnelRepository(Session);
            _personnelTestBuilder = new PersonnelTestBuilder();
        }

        [Fact]
        public void register_customer()
        {
            Session.BeginTransaction();
            var personnel = _personnelTestBuilder.Build();
            _personnelRepository.Create(personnel);
            Session.GetCurrentTransaction().Commit(); 
            Session.Clear();
            var expectedPersonnel = _personnelRepository.GetBy(personnel.Id);
            expectedPersonnel.Should().BeEquivalentTo(personnel);

        }
    }
}
