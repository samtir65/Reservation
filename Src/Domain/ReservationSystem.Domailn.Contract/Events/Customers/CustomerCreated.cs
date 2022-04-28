using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Framework.Application;
using Framework.Domain;

namespace ReservationSystem.Domailn.Contract.Events.Customers
{
    public class CustomerCreated : DomainEvent, IUserInfo
    {
        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime CreateOn { get; private set; }
        public List<CustomerPhoneEvent> CustomerPhones { get; set; }
        public long ActionUserId { get; set; }
        public string UserName { get; set; }



        public CustomerCreated(long id, string firstName, string lastName, DateTime createOn, List<CustomerPhoneEvent> customerPhoneEvents , long actionUserId, string username)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CreateOn = createOn;
            CustomerPhones = customerPhoneEvents;
            ActionUserId = actionUserId;
            UserName = username;
        }
    }
}