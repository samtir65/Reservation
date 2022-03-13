using System.Collections.Generic;
using Framework.Application;

namespace ReservationSystem.Application.Contracts.Customers.Commands
{
    public class CreateCustomersCommand:ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CustomerPhoneCommand> CustomerPhones { get; set; }

        public CreateCustomersCommand(string firstName, string lastName, List<CustomerPhoneCommand> customerPhones)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerPhones = customerPhones;
        }
    }
   

}