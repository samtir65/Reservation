using Framework.Application;
using System;

namespace ReservationSystem.Application.Contracts.Reservations.Commands
{
    public class CreateReservationsCommand:ICommand
    {
        public DateTime CreateOn { get; private set; }
        public long CustomerId { get; private set; }
        public long ServiceId { get; private set; }
        public long PersonelId { get; private set; }

        public CreateReservationsCommand(DateTime createOn, long customerId, long serviceId, long personelId)
        {
            CreateOn = createOn;
            CustomerId = customerId;
            ServiceId = serviceId;
            PersonelId = personelId;
        }
    }
}
