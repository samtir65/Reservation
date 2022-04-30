using Framework.Core;
using Reservation.Query.Model.Customers;
using ReservationSystem.Application.Contracts.Customers.QueryServices;

namespace Reservations.Gateway.Facade.Query.Customers
{
    public class CustomerQueryFacade : ICustomerQueryFacade
    {
        private ICustomerQueryRepository _customerQueryRepository;

        public CustomerQueryFacade(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }

        public PageResult<CustomerQuery> GetAll(PageInfo pageInfo)
        {
          return  _customerQueryRepository.GetAll(pageInfo);
        }

        public CustomerQuery GetBy(long id)
        {
            return _customerQueryRepository.Get(id);
        }
    }
}
