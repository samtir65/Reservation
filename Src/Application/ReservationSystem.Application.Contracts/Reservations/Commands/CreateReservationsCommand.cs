using Framework.Application;
using System;

namespace ReservationSystem.Application.Contracts.Reservations.Commands
{
    public class CreateReservationsCommand:ICommand
    {
        public DateTime CreateOn { get;  set; }
        public long CustomerId { get;  set; }
        public long ServiceId { get;  set; }
        public long PersonelId { get; set; }

        public CreateReservationsCommand(DateTime createOn, long customerId, long serviceId, long personelId)
        {
            CreateOn = createOn;
            CustomerId = customerId;
            ServiceId = serviceId;
            PersonelId = personelId;
        }
    }
}
