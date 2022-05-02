using Framework.NH;
using NHibernate;
using ReservationSystem.Domain.Models.Personnels;
using System.Linq;

namespace ReservationSystem.Persistence.NH.Repository.Personnels
{
    public class PersonnelRepository : IPersonnelRepository
    {
        private readonly ISession _session;

        public PersonnelRepository(ISession session)
        {
            _session = session;
        }
        public void Create(Personnel personnel)
        {
            _session.Save(personnel);
        }

        public Personnel GetBy(PersonnelId personnelId)
        {
           return _session.Query<Personnel>().FirstOrDefault(x => x.Id.DbId == personnelId.DbId);
        }
        public PersonnelId GetNextId()
        {
            var idValue = _session.GetNextSequence("SequencePersonnel");
            return new PersonnelId(idValue);
        }
    }
}