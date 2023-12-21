using AutoMapper;
using Customer_management.CustomerOperations.Command.CreateCustomer;
using Customer_management.CustomerOperations.Command.DeleteCustomer;
using Customer_management.CustomerOperations.Command.PatchCustomer;
using Customer_management.CustomerOperations.Command.UpdateCustomer;
using Customer_management.CustomerOperations.Query.GetBooks;
using Customer_management.DbOperation;
using Customer_management.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace Customer_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerManagementDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(CustomerManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<CustomersViewModel> Get()
        {
            GetCustomersQuery query = new GetCustomersQuery(_context, _mapper);
            var customerList = query.Handle();
            return customerList;
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            GetCustomersByIdQuery query = new GetCustomersByIdQuery(_context, _mapper);

            query.CustomerId = id;

            GetCustomerByIdQueryValidator validator = new GetCustomerByIdQueryValidator();
            validator.ValidateAndThrow(query);

            var customer = query.Handle();

            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public IActionResult Post([FromBody] CreateCustomerModel model)
        {
            var command = new CreateCustomerCommand(_context, _mapper)
            {
                Model = model
            };
            var validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCustomerModel updateCustomer)
        {
            var command = new UpdateCustomerCommand(_context, _mapper)
            {
                Model = updateCustomer,
                CustomerId = id
            };
            var validator = new UpdateCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        // PATCH: api/Customer/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<UpdateCustomerModel> patchDoc)
        {
            var command = new PatchCustomerCommand(_context, _mapper)
            {
                CustomerId = id
            };
            var validator = new PatchCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var command = new DeleteCustomerCommand(_context)
            {
                CustomerId = id
            };
            var validator = new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
    }
}