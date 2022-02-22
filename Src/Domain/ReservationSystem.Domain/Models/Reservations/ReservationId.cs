using Framework.Domain;

namespace ReservationSystem.Domain.Models.Reservations
{
    public class ReservationId:IdBase<int>
    {
        public ReservationId(int id) : base(id)
        {

        }
        protected ReservationId() { }
    }
}