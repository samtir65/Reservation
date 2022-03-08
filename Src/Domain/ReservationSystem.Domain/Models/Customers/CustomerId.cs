using Framework.Domain;

namespace ReservationSystem.Domain.Models.Customers
{
    public class CustomerId:IdBase<long>
    { 
        public CustomerId(long id):base(id)
        {
            
        }
        protected CustomerId(){}
    }
}