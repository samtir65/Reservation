using Framework.Core;

namespace Reservation.Query.Model.Customers
{
    public interface ICustomerQueryRepository
    {
        PageResult<CustomerQuery> GetAll(PageInfo pageInfo);
        CustomerQuery Get(long id);

    }
}
