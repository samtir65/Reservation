using System.Collections.Generic;
using System.Collections.ObjectModel;
using Framework.Application;
using Framework.Domain;
using ReservationSystem.Domain.Models.AssignedServices;
using ReservationSystem.Domain.Models.Services;

namespace ReservationSystem.Domain.Models.Personnels
{
    public class Personnel:AggregateRoot<PersonnelId>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private readonly IList<AssigenedService> _skills;
        public IReadOnlyCollection<AssigenedService> Skills =>
            new ReadOnlyCollection<AssigenedService>(_skills);

        public Personnel(PersonnelId id, IEventPublisher publisher, long creatorUserId, IList<AssigenedService> skills, string firstName, string lastName) : base(id, publisher, creatorUserId)
        {
            _skills = skills;
            FirstName = firstName;
            LastName = lastName;
        }

        protected Personnel()
        {
        }
    }


}