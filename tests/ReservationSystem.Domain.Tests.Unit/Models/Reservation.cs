using Framework.Domain;

namespace ReservationSystem.Domain.Tests.Unit.Models
{
    public class Reservation:AggregateRoot<long>
    {
        public Reservation(long id) : base(id)
        {

        }
    }
}