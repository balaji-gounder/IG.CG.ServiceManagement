using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }


        /// <summary>
        /// Retrieves all Customer Detail List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active Customer available in the database.
        /// </remarks>
        /// <returns>Returns a collection of customer objects.</returns>
        [HttpGet("GetAllCustomer")]
        public async Task<ActionResult<IEnumerable<CustomerDisplayModel>>> GetCustomer([FromQuery] CustomerFilter customerFilter)
        {
            var Customer = await _customerService.GetAllCustomerAsync(customerFilter);
            if (Customer is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Customer);
            }
        }



        /// <summary>
        /// Retrieve Customer Data by Customer Id.
        /// </summary>
        /// <remarks>
        /// Based on Customer id,this endpoint returns a matching active Customer available in the database.
        /// </remarks>
        /// <returns>Returns a single Customer objects.</returns>
        [HttpGet("GetCustomerById")]
        public async Task<ActionResult<CustomerModel>> GetCustomerById(int customerId)
        {
            var Customer = await _customerService.GetCustomerByIdAsync(customerId);
            if (Customer is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Customer);

            }

        }

        /// <summary>
        /// Insert & Update Customer Information.
        /// </summary>
        /// <remarks>
        /// Insert & Update Customer into the database.
        /// </remarks>
        /// <returns>Returns a last saved positive Customer id if insert or update successfully completed
        /// If it's 1000 then Customer name already exists 
        /// </returns>
        [HttpPost("UpsertCustomer")]
        public async Task<ActionResult> InsertCustomer(CustomerModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var customer = await _customerService.UpsertCustomerAsync(customerModel, customerModel.CustPhone);
                return Ok(customer);
            }

        }


        /// <summary>
        /// Remove Customer data.
        /// </summary>
        /// <remarks>
        /// Remove Customer from the database.
        /// </remarks>
        /// <returns>
        ///  Returns a removed Customer id.
        /// </returns>
        [Authorize]
        [HttpDelete("DeleteCustomer")]
        public async Task<ActionResult> RemoveCustomer(int customerId, int isActive)
        {
            var customer = await _customerService.DeleteCustomerAsync(customerId, User?.Identity?.Name, isActive);
            return Ok(customer);
        }

    }
}
