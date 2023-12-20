using Customer_management.Common;
using Customer_management.DbOperation;

namespace Customer_management.CustomerOperations.Query.GetBooks;

public class GetCustomersQuery
{
    private readonly CustomerManagementDbContext _dbContext;

    public GetCustomersQuery(CustomerManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<CustomersViewModel> Handle()
    {
        var customerList = _dbContext.Customers.ToList();

        return customerList.Select(customer => new CustomersViewModel()
            {
                FullName = customer.Name + " " + customer.Surname,
                BirthDate = customer.BirthDate.Date.ToString("dd/MM/yyyy"),
                Job = customer.Job,
                Country = customer.Country,
                IncomeLevel = ((IncomeLevelType)customer.IncomeLevelId).ToString(),
                MartialStatus = ((MartialStatusType)customer.MartialStatusId).ToString()
            })
            .ToList();
    }
}
public class CustomersViewModel
{
    public string FullName { get; set; }
    public string BirthDate { get; set; }
    public string Job { get; set; }
    public string Country { get; set; }
    public string IncomeLevel { get; set; }
    public string MartialStatus { get; set; }
}