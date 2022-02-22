using NHibernate.Mapping.ByCode.Conformist;
using ReservationSystem.Domain.Models.Reservations;

namespace ReservationSystem.Persistence.NH.Mapping.Reservations
{
    public class ReservationMapping:ClassMapping<Reservation>
    {
        public ReservationMapping()
        {
            Table("__Reservation__");
            Lazy(false);
            ComponentAsId(x => x.Id, map =>
            {
                map.Property(x => x.DbId, z => z.Column("Id"));
            });
            Property(x => x.CreatOn);
            Property(x => x.CustomerId);
            Property(x => x.PersonelId);
            Property(x => x.ServiceId);
        }
        
    }
}