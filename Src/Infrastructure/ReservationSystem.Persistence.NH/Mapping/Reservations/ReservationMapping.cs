using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ReservationSystem.Domain.Models.Reservations;

namespace ReservationSystem.Persistence.NH.Mapping.Reservations
{
    public class ReservationMapping:ClassMapping<Reservation>
    {
        public ReservationMapping()
        {
            Table("Reservations");
            Lazy(false);
            ComponentAsId(x => x.Id, map =>
            {
                map.Property(x => x.DbId, z => z.Column("Id"));
            });
            Property(x => x.CreateOn);
            Property(x => x.CustomerId);
            Property(x => x.PersonnelId);
            Property(x => x.RequiredSkills);
            Property(x => x.CreatorUserId);
           
        }
        
    }
}