using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using NHibernate;
using Reservation.Query.Model.Customers;

namespace Reservation.Query.NH.Repositories.Customers
{
    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        private ISession _session;

        public CustomerQueryRepository(ISession session)
        {
            _session = session;
        }
        public CustomerQuery Get(long id)
        {
            return _session.Query<CustomerQuery>().FirstOrDefault(x => x.Id == id);
        }

        public PageResult<CustomerQuery> GetAll(PageInfo pageInfo)
        {
            if (!pageInfo.Take.HasValue)
                pageInfo.Take = 10;
            var totalCount = _session.Query<CustomerQuery>().Count();
            var data = _session.Query<CustomerQuery>().OrderByDescending(x => x.Id)
                .Skip(pageInfo.Skip).Take(pageInfo.Take.Value).ToList();
            return new PageResult<CustomerQuery>(data, totalCount);

        }
    }
}
