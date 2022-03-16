using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ReservationSystem.Domailn.Contract.Events.Reservations
{
    public class CustomerCreated
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateOn { get; set; }


        private readonly IList<CustomerPhone> _customerPhones;
        public IReadOnlyCollection<CustomerPhone> CustomerPhones =>
            new ReadOnlyCollection<CustomerPhone>(_customerPhones);

    }
}