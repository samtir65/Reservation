namespace Reservation.Query.Model.Customers
{
    public class CustomerPhoneQuery
    {
        public string Area { get; private set; }
        public string Number { get; private set; }

        protected CustomerPhoneQuery()
        {
            
        }
    }
}