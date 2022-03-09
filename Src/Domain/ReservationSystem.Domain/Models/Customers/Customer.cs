using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Framework.Application;

namespace ReservationSystem.Domain.Models.Customers
{
    public class Customer : AggregateRoot<CustomerId>
    {
        public string Name { get; set; }
        public DateTime CreateOn { get; set; }
        private IList<CustomerPhone> _customerPhones;

        public IReadOnlyCollection<CustomerPhone> CustomerPhones =>
            new ReadOnlyCollection<CustomerPhone>(_customerPhones);

        public Customer(CustomerId id, IEventPublisher publisher, long creatorUserId, List<CustomerPhone> customerPhones, string name, DateTime createOn) : base(id, publisher, creatorUserId)
        {
            _customerPhones = customerPhones;
            Name = name;
            CreateOn = createOn;
        }

        protected Customer()
        {
        }
    }
}