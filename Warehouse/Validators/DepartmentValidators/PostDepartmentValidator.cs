using Contracts.Requests.Department;
using FastEndpoints;
using FluentValidation;

namespace Warehouse.Validators.DepartmentValidators
{
    public class PostDepartmentValidator : Validator<PostDepartment>
    {
        public PostDepartmentValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty()
                .WithMessage("Departments name can't be null or empty");
        }
    }
}
