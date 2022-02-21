﻿using Framework.Core.Clock;
using Framework.Domain;
using System;

namespace ReservationSystem.Domain.Models.Reservations
{
    public class Reservation:AggregateRoot<long>
    {
        public DateTime CreatOn { get; private set; }
        public long CustomerId { get; private set; }
        public long ServiceId { get; private set; }
        public long PersonelId { get; private set; }

        public Reservation(long id, IClock createOn, long customerId,long serviceId,long personelId) : base(id)
        {
            CreatOn = createOn.Now();
            CustomerId = customerId;
            ServiceId = serviceId;
            PersonelId = personelId;
        }
    }
}