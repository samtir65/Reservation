using System;
using System.Collections.Generic;
using Framework.Application;
using Framework.Core;
using Framework.Core.Clock;
using Framework.Test;
using Framework.Test.ClockStubs;
using ReservationSystem.Domain.Models.Customers;
using ReservationSystem.Domain.TestsUtils.Models.CustomerPhones;

namespace ReservationSystem.Domain.TestsUtils.Models.Customers
{
    public class CustomerTestBuilder
    {
        public CustomerId Id { get;private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IClock CreateOn { get;private set; }
        public List<CustomerPhone> Phones { get;set; }
        public IEventPublisher EventPublisher { get; set; }
        public IClaimHelper ClaimHelper { get; set; }
        
        public CustomerTestBuilder()
        {
            Id = new CustomerId(GenerateRandom.Number()) ;
            FirstName = GenerateRandom.String();
            LastName = GenerateRandom.String();
            CreateOn = new ClockStub(DateTime.Now);
            Phones = new List<CustomerPhone>() { new CustomerPhoneTestBuilder().Build() };
            EventPublisher = new FakeEventPublisher();
            ClaimHelper = new ClaimHelperStub();
        }
        public Customer Build()
        {
            return new Customer(Id,FirstName,LastName,CreateOn,Phones,EventPublisher,ClaimHelper);
        }
    }
}