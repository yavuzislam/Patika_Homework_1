using FluentValidation;

namespace Customer_management.CustomerOperations.Command.DeleteCustomer;

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId).GreaterThan(0);
    }
}