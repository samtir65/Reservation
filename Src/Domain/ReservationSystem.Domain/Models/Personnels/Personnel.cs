using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    }

}