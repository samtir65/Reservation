using NHibernate.Mapping.ByCode.Conformist;
using Reservation.Query.Model.Reservations;

namespace Reservation.Query.NH.Mapping.Reservations
{
    public class ReservationQueryMapping:ClassMapping<ReservationQuery>
    {
        public ReservationQueryMapping()
        {
            Table("Reservations");
            Lazy(false);
            Property(x => x.Id);
            Property(x => x.CreateOn);
            Property(x => x.CustomerId);
            Property(x => x.PersonnelId);
            Property(x => x.ServiceId);
            Property(x => x.CreatorUserId);
        }
    }
}