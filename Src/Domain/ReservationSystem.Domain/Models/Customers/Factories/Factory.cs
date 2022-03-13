using System.Collections.Generic;
using Framework.Application;
using Framework.Core;
using Framework.Core.Clock;

namespace ReservationSystem.Domain.Models.Customers.Factories
{
    public static class Factory
    {
        public static Customer CreateCustomer(CustomerId id, string firstName, string lastName, IClock createOn, List<CustomerPhone> customerPhones, IEventPublisher eventPublisher, IClaimHelper claimHelper)
        {
            return new Customer(id, firstName, lastName, createOn, customerPhones, eventPublisher, claimHelper);
        }
    }
}