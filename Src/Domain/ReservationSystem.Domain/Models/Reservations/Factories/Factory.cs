using Framework.Core.Clock;

namespace ReservationSystem.Domain.Models.Reservations.Factories
{
    public static class Factory
    {
        public static Reservation CreateReservation(ReservationId id, IClock createOn, long customerId, long serviceId,
            long personelId)
        {
            return new Reservation(id, createOn, customerId, serviceId, personelId);
        }
    }
}
