using FluentValidation;

namespace Customer_management.CustomerOperations.Query.GetBooks;

public class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomersByIdQuery>
{
    public GetCustomerByIdQueryValidator()
    {
        RuleFor(x => x.CustomerId).GreaterThan(0);
    }
}