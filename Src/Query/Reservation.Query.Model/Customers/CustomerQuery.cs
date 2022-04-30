using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Query.Model.Customers
{
    public class CustomerQuery
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateOn { get; set; }

        private readonly IList<CustomerPhoneQuery> CustomerPhones;

        public CustomerQuery(IList<CustomerPhoneQuery> customerPhones, long id, string firstName, string lastName, DateTime creatOn)
        {
            CustomerPhones = customerPhones;
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CreateOn = creatOn;
        }

        protected CustomerQuery()
        {
            
        }
    }
}
