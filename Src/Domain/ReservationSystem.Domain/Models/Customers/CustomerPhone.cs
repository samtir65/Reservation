using Framework.Domain;

namespace ReservationSystem.Domain.Models.Customers
{
    public class CustomerPhone:ValueObjectBase
    {
        public string Area { get; private set; }
        public string Number { get; private set; }
        public CustomerPhone(string area, string number)
        {
            Area = area;
            Number = number;
        }
        protected CustomerPhone(){}
    }
}
