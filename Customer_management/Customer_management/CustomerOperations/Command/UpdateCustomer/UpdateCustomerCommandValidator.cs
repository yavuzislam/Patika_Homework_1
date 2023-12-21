using FluentValidation;

namespace Customer_management.CustomerOperations.Command.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId).GreaterThan(0);
        RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Model.Surname).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Model.Job).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Model.IncomeLevelId).NotEmpty().GreaterThan(0).LessThan(4);
        RuleFor(x => x.Model.MartialStatusId).NotEmpty().GreaterThan(0).LessThan(5);
    }
}