using Customer_management.DbOperation;
using Customer_management.Entities;

namespace Customer_management.CustomerOperations.Command.CreateCustomer;

public class CreateCustomerCommand
{
    private readonly CustomerManagementDbContext _context;
    public CreateCustomerModel Model { get; set; }

    public CreateCustomerCommand(CustomerManagementDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var customer = _context.Customers.SingleOrDefault(x => x.Job == Model.Job);
        if (customer is not null)
        {
            throw new InvalidOperationException("Customer already exists");
        }

        customer = new Customer
        {
            Name = Model.Name,
            Surname = Model.Surname,
            BirthDate = Model.BirthDate.Date,
            Job = Model.Job,
            Country = Model.Country,
            IncomeLevelId = Model.IncomeLevelId,
            MartialStatusId = Model.MartialStatusId
        };
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }
}

public class CreateCustomerModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public string Job { get; set; }
    public string Country { get; set; }
    public int IncomeLevelId { get; set; }
    public int MartialStatusId { get; set; }
}