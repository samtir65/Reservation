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
            Version(x => x.RowVersion, map =>
            {
                map.Generated(VersionGeneration.Never);
                map.UnsavedValue(0);
                map.Type(new NHibernate.Type.Int32Type());
            });
            Property(x => x.CreateOn);
            Property(x => x.CustomerId);
            Property(x => x.PersonelId);
            Property(x => x.ServiceId);
        }
        
    }
}