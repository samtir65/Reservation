using Framework.Domain;

namespace ReservationSystem.Domain.Models.Reservations
{
    public class ReservationId:IdBase<long>
    {
        public ReservationId(long id) : base(id)
        {

        }
        protected ReservationId() { }
    }
}