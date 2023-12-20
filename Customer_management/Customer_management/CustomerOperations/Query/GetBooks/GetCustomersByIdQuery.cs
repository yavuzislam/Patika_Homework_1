using Customer_management.Common;
using Customer_management.DbOperation;

namespace Customer_management.CustomerOperations.Query.GetBooks;

public class GetCustomersByIdQuery
{
    private readonly CustomerManagementDbContext _context;

    public int CustomerId { get; set; }

    public GetCustomersByIdQuery(CustomerManagementDbContext context)
    {
        _context = context;
    }

    public GetCustomerViewModel Handle()
    {
        var customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerId);
        if (customer is null)
        {
            throw new InvalidOperationException("Customer not found");
        }

        var model = new GetCustomerViewModel()
        {
            FullName = customer.Name + " " + customer.Surname,
            BirthDate = customer.BirthDate.Date.ToString("dd/MM/yyyy"),
            Job = customer.Job,
            Country = customer.Country,
            IncomeLevel = ((IncomeLevelType)customer.IncomeLevelId).ToString(),
            MartialStatus = ((MartialStatusType)customer.MartialStatusId).ToString()
        };
        return model;
    }
}

public class GetCustomerViewModel
{
    public string FullName { get; set; }
    public string BirthDate { get; set; }
    public string Job { get; set; }
    public string Country { get; set; }
    public string IncomeLevel { get; set; }
    public string MartialStatus { get; set; }
}