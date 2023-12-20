using Customer_management.DbOperation;

namespace Customer_management.CustomerOperations.Command.DeleteCustomer;

public class DeleteCustomerCommand
{
    private readonly CustomerManagementDbContext _context;
    public int CustomerId { get; set; }

    public DeleteCustomerCommand(CustomerManagementDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerId);
        if (customer is null)
        {
            throw new InvalidOperationException("Customer not found");
        }

        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }
}