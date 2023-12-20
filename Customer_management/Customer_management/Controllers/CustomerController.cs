using Customer_management.CustomerOperations.Command.CreateCustomer;
using Customer_management.CustomerOperations.Command.DeleteCustomer;
using Customer_management.CustomerOperations.Command.UpdateCustomer;
using Customer_management.CustomerOperations.Query.GetBooks;
using Customer_management.DbOperation;
using Customer_management.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Customer_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerManagementDbContext _context;

        public CustomerController(CustomerManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<CustomersViewModel> Get()
        {
            GetCustomersQuery query = new GetCustomersQuery(_context);
            var customerList = query.Handle();
            return customerList;
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            GetCustomersByIdQuery query = new GetCustomersByIdQuery(_context);
            try
            {
                query.CustomerId = id;
                var customer = query.Handle();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Customer
        [HttpPost]
        public IActionResult Post([FromBody] CreateCustomerModel model)
        {
            try
            {
                var command = new CreateCustomerCommand(_context)
                {
                    Model = model
                };
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCustomerModel model)
        {
            try
            {
                var command = new UpdateCustomerCommand(_context)
                {
                    Model = model,
                    CustomerId = id
                };
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var command = new DeleteCustomerCommand(_context)
                {
                    CustomerId = id
                };
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest("Customer not found");
            }

            return Ok();
        }
    }
}