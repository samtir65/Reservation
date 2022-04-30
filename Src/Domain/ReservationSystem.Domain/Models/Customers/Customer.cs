using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Framework.Application;
using Framework.Core.Clock;
using Framework.Core;
using ReservationSystem.Domailn.Contract.Events.Customers;

namespace ReservationSystem.Domain.Models.Customers
{
    public class Customer : AggregateRoot<CustomerId>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateOn { get; set; }

        private readonly IList<CustomerPhone> _customerPhones;
        public IReadOnlyCollection<CustomerPhone> CustomerPhones =>
            new ReadOnlyCollection<CustomerPhone>(_customerPhones);

        public Customer(CustomerId id, string firstName,string lastName, IClock createOn,List<CustomerPhone> customerPhones,IEventPublisher eventPublisher,IClaimHelper claimHelper)
            : base(id, eventPublisher,claimHelper.GetUserId())
        {
            FirstName = firstName;
            LastName = lastName;
            CreateOn =  createOn.Now();
            _customerPhones = customerPhones;
            var customerPhoneEvent = MapCustomerPhoneEvent();
            Publish(new CustomerCreated(id.DbId,FirstName,LastName,CreateOn,customerPhoneEvent,claimHelper.GetUserId(),claimHelper.GetUserName()));
        }

        protected List<CustomerPhoneEvent> MapCustomerPhoneEvent()
        {
            var customerPhoneEvent = new List<CustomerPhoneEvent>();
            foreach (var item in this.CustomerPhones)
            {
                customerPhoneEvent.Add(item);
            }
            return customerPhoneEvent;
        }

        
        }
        protected Customer()
        {
        }
    }
}