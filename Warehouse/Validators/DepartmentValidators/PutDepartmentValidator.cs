using Contracts.Requests.Department;
using FastEndpoints;
using FluentValidation;

namespace Warehouse.Validators.DepartmentValidators
{
    public class PutDepartmentValidator : Validator<PutDepartment>
    {
        public PutDepartmentValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Department id can't be null.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Department identifier cannot be less than zero");
            RuleFor(x => x.Name)
                .NotNull().NotEmpty()
                .WithMessage("Name can't be null or empty.");
        }
    }
}
