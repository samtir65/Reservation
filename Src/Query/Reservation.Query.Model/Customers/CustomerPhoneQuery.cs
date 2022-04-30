namespace Reservation.Query.Model.Customers
{
    public class CustomerPhoneQuery
    {
        public string Area { get; private set; }
        public string Number { get; private set; }

        public CustomerPhoneQuery(string area, string number)
        {
            Area = area;
            Number = number;
        }

        protected CustomerPhoneQuery()
        {
            
        }
    }
}