using AutoMapper;
using Customer_management.DbOperation;

namespace Customer_management.CustomerOperations.Query.GetBooks;

public class GetCustomersQuery
{
    private readonly CustomerManagementDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCustomersQuery(CustomerManagementDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<CustomersViewModel> Handle()
    {
        var customerList = _dbContext.Customers.OrderBy(x => x.Id).ToList();
        var vm = _mapper.Map<List<CustomersViewModel>>(customerList);
        return vm;
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