using System.Collections.Generic;
using System.Collections.ObjectModel;
using Framework.Application;
using Framework.Domain;
using ReservationSystem.Domain.Models.Services;

namespace ReservationSystem.Domain.Models.Personnels
{
    public class Personnel:AggregateRoot<PersonnelId>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private readonly IList<AssignedSkill> _skills;
        public IReadOnlyCollection<AssignedSkill> Skills =>
            new ReadOnlyCollection<AssignedSkill>(_skills);

        public Personnel(PersonnelId id, IEventPublisher publisher, long creatorUserId, IList<AssignedSkill> skills, string firstName, string lastName) : base(id, publisher, creatorUserId)
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