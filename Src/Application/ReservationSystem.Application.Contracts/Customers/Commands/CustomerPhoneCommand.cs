namespace ReservationSystem.Application.Contracts.Customers.Commands
{
    public class CustomerPhoneCommand
    {
        public string Area { get; set; }
        public string Number { get; set; }

        public CustomerPhoneCommand(string area, string number)
        {
            Area = area;
            Number = number;
        }
    }
}