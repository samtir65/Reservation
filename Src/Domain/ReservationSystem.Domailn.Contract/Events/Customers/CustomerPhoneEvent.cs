namespace ReservationSystem.Domailn.Contract.Events.Customers
{
    public class CustomerPhoneEvent
    {
        public string Area { get; private set; }
        public string Number { get; private set; }
        public CustomerPhoneEvent(string area, string number)
        {
            Area = area;
            Number = number;
        }
        protected CustomerPhoneEvent(){}
    }
}
