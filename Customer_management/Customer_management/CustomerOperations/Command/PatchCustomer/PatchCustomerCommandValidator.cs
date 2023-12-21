using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;

namespace Customer_management.CustomerOperations.Command.PatchCustomer;

public class PatchCustomerCommandValidator : AbstractValidator<PatchCustomerCommand>
{
    public PatchCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId).GreaterThan(0);
        RuleFor(x => x.PatchDocument).Must(ContainOnlyJobOperation)
            .WithMessage("Only 'Job' can be updated.");
    }

    private bool ContainOnlyJobOperation(JsonPatchDocument<PatchCustomerModel> patchDoc)
    {
        if (patchDoc != null && patchDoc.Operations.Count == 1)
        {
            var operation = patchDoc.Operations[0];
            return operation.path == "/job";
        }

        return false;
    }
}