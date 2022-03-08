using Framework.Domain;

namespace ReservationSystem.Domain.Models.Customers
{
    public class Customer : AggregateRoot<CustomerId>
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}