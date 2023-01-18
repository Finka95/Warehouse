using FastEndpoints;
using Contracts.Requests.Department;
using FluentValidation;

namespace Warehouse.Validators.DepartmentValidators
{
    public class GetDeleteDepartmentValidator : Validator<GetDeleteDepartment>
    {
        public GetDeleteDepartmentValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Department identifier cannot be less than zero.");
        }
    }
}
