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
        public IList<CustomerPhoneQuery> CustomerPhones { get; set; }

        protected CustomerQuery()
        {
            
        }
    }
}
