using FluentValidation;

namespace Customer_management.CustomerOperations.Command.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Model.Surname).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Model.BirthDate).NotEmpty().LessThan(new DateTime(2015, 01, 01));
        RuleFor(x => x.Model.Job).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Model.Country).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Model.IncomeLevelId).NotEmpty().GreaterThan(0).LessThan(4);
        RuleFor(x => x.Model.MartialStatusId).NotEmpty().GreaterThan(0).LessThan(5);
    }
}