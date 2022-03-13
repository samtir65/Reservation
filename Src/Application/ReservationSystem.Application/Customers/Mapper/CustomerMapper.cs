using System.Collections.Generic;
using ReservationSystem.Application.Contracts.Customers.Commands;
using ReservationSystem.Domain.Models.Customers;

namespace ReservationSystem.Application.Customers.Mapper
{
    public class CustomerMapper
    {
        public static List<CustomerPhone> MapToPhones(List<CustomerPhoneCommand> commandPhones)
        {
            var phones = new List<CustomerPhone>();
            foreach (var phoneCommand in commandPhones)
            {
                var addressInfo = new CustomerPhone(phoneCommand.Area, phoneCommand.Number);
                phones.Add(addressInfo);
            }
            return phones;
        }
    }
}