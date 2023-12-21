using AutoMapper;
using Customer_management.Common;
using Customer_management.DbOperation;

namespace Customer_management.CustomerOperations.Query.GetBooks;

public class GetCustomersByIdQuery
{
    private readonly CustomerManagementDbContext _context;
    private readonly IMapper _mapper;

    public int CustomerId { get; set; }

    public GetCustomersByIdQuery(CustomerManagementDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public GetCustomerViewModel Handle()
    {
        var customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerId);
        if (customer is null)
        {
            throw new InvalidOperationException("Customer not found");
        }

        var model= _mapper.Map<GetCustomerViewModel>(customer);
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