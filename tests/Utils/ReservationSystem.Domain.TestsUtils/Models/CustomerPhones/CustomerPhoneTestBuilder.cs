using ReservationSystem.Domain.Models.Customers;

namespace ReservationSystem.Domain.TestsUtils.Models.CustomerPhones
{
    public class CustomerPhoneTestBuilder
    {
        public string Area { get;set; }
        public string Number { get;set; }

        public CustomerPhoneTestBuilder()
        {
            Area = "Tehran";
            Number = "021-8547474747";
        }

        public CustomerPhoneTestBuilder WithArea(string area)
        {
            Area = area;
            return this;
        }

        public CustomerPhoneTestBuilder WithNumber(string number)
        {
            Number = number;
            return this;
        }

        public CustomerPhone Build()
        {
            return new CustomerPhone(Area, Number);
        }
    }
}
