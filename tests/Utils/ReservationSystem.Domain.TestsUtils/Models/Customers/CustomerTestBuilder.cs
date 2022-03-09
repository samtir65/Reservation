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
        public string Name { get;private set; }
        public IClock CreateOn { get;private set; }
        private List<CustomerPhone> Phones { get;set; }
        public IClaimHelper ClaimHelper { get; set; }
        public IEventPublisher EventPublisher { get; set; }

        public CustomerTestBuilder()
        {
            Id = new CustomerId(GenerateRandom.Number()) ;
            Name = GenerateRandom.String();
            CreateOn = new ClockStub(DateTime.Now);
            Phones = new List<CustomerPhone>() { new CustomerPhoneTestBuilder().Build() };
            ClaimHelper = new ClaimHelperStub();
            EventPublisher = new FakeEventPublisher();
        }

        public Customer build()
        {
            return new Customer(Id,EventPublisher,)
        }
    }
}