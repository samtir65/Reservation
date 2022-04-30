using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Application.Contracts.Customers.Commands;
using ReservationSystem.Application.Contracts.Customers.CommandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ReservationSystem.Application.Contracts.Customers.QueryServices;
using Framework.Core;
using Reservation.Query.Model.Customers;

namespace ReservationSystem.Gateways.RestApi.Controllers.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersQueryController : ControllerBase
    {
        private readonly ICustomerQueryFacade _customerQueryFacade;

        public CustomersQueryController(ICustomerQueryFacade customerQueryFacade)
        {
            _customerQueryFacade = customerQueryFacade;

        }

        [HttpGet]
        [AllowAnonymous]
        public PageResult<CustomerQuery> GetAll([FromQuery] PageInfo pageInfo)
        {
            return _customerQueryFacade.GetAll(pageInfo);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public CustomerQuery GetAll(long id)
        {
            return _customerQueryFacade.GetBy(id);
        }
        
    }
}
