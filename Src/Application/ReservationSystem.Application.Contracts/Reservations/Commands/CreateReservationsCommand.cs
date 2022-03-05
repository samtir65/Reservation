using Framework.Application;
using System;

namespace ReservationSystem.Application.Contracts.Reservations.Commands
{
    public class CreateReservationsCommand:ICommand
    {
        public long CustomerId { get;  set; }
        public long ServiceId { get;  set; }
        public long PersonelId { get; set; }

        public CreateReservationsCommand(long customerId, long serviceId, long personelId)
        {
            CustomerId = customerId;
            ServiceId = serviceId;
            PersonelId = personelId;
        }
    }
}
