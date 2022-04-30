using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using Framework.Core;
using Reservation.Query.Model.Customers;
using Reservation.Query.Model.Reservations;
using ReservationSystem.Domain.Models.Customers;

namespace ReservationSystem.Application.Contracts.Customers.QueryServices
{
    public interface ICustomerQueryFacade : IApplicationService
    {
        PageResult<CustomerQuery> GetAll(PageInfo pageInfo);
        CustomerQuery GetBy(long id);

    }
}
