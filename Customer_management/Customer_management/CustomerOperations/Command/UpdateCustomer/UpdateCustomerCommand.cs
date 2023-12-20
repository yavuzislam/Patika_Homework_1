using Customer_management.DbOperation;

namespace Customer_management.CustomerOperations.Command.UpdateCustomer;

public class UpdateCustomerCommand
{
    private readonly CustomerManagementDbContext _context;
    public UpdateCustomerModel Model { get; set; }
    public int CustomerId { get; set; }

    public UpdateCustomerCommand(CustomerManagementDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var customer = _context.Customers.Find(CustomerId);
        if (customer is null)
        {
            throw new InvalidOperationException("Customer not found");
        }

        customer.Name = Model.Name != default ? Model.Name : customer.Name;
        customer.Surname = Model.Surname != default ? Model.Surname : customer.Surname;
        customer.Job = Model.Job != default ? Model.Job : customer.Job;
        customer.IncomeLevelId = Model.IncomeLevelId != default ? Model.IncomeLevelId : customer.IncomeLevelId;
        customer.MartialStatusId = Model.MartialStatusId != default ? Model.MartialStatusId : customer.MartialStatusId;
        _context.SaveChanges();
    }
}

public class UpdateCustomerModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Job { get; set; }
    public int IncomeLevelId { get; set; }
    public int MartialStatusId { get; set; }
}