using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Application.Contracts.Customers.Commands;
using ReservationSystem.Application.Contracts.Customers.CommandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ReservationSystem.Gateways.RestApi.Controllers.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerFacade _customerFacade;

        public CustomersController(ICustomerFacade customerFacade)
        {
            _customerFacade = customerFacade;

        }

        [HttpPost]
        [AllowAnonymous]
        public long CreateCustomer(CreateCustomersCommand command)
        {
           return _customerFacade.CreateCustomer(command);
        }
    }
}
