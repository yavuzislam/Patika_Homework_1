using AutoMapper;
using Customer_management.DbOperation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Customer_management.CustomerOperations.Command.PatchCustomer;

public class PatchCustomerCommand
{
    private readonly CustomerManagementDbContext _context;
    private readonly IMapper _mapper;
    public JsonPatchDocument<PatchCustomerModel> PatchDocument { get; set; }
    public int CustomerId { get; set; }

    public PatchCustomerCommand(CustomerManagementDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerId);
        if (customer is null)
        {
            throw new InvalidOperationException("Customer not found");
        }

        var customerModel = _mapper.Map<PatchCustomerModel>(customer);
        var jobOperation = PatchDocument.Operations.SingleOrDefault(x => x.path == "/job");
        if (jobOperation != null)
        {
            customerModel.Job = jobOperation.value.ToString();
        }
        else if (jobOperation.OperationType==OperationType.Remove)
        {
            customerModel.Job = null;
        }
        
        _mapper.Map(customerModel, customer);
        _context.SaveChanges();
    }
}

public class PatchCustomerModel
{
    public string Job { get; set; }
}