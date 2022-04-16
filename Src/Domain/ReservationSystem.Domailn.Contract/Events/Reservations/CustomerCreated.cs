using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Framework.Application;
using Framework.Domain;
using ReservationSystem.Domain.Models.Customers;

namespace ReservationSystem.Domailn.Contract.Events.Reservations
{
    public class CustomerCreated : DomainEvent ,IUserInfo
    {
        public long Id { get; private set; }
        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        public DateTime CreateOn { get;private set; }
        public long ActionUserId { get; set; }
        public string UserName { get; set; }

        private readonly IList<CustomerPhone> _customerPhones;
        public IReadOnlyCollection<CustomerPhone> CustomerPhones => 
            new ReadOnlyCollection<CustomerPhone>(_customerPhones);

        protected CustomerCreated(long id,IList<CustomerPhone> customerPhones, string firstName, string lastName, DateTime createOn)
        {
            Id = id;
            _customerPhones = customerPhones;
            FirstName = firstName;
            LastName = lastName;
            CreateOn = createOn;
        }
    }
}