using System;

namespace Reservation.Query.Model.Reservations
{
    public class ReservationQuery
    {
        public long Id { get; set; }
        public DateTime CreateOn { get; private set; }
        public long CustomerId { get; private set; }
        public long ServiceId { get; private set; }
        public long PersonnelId { get; private set; }
        public long CreatorUserId { get; set; }

        protected ReservationQuery()
        {
        }
    }
}
