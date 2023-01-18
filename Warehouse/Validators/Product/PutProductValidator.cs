using Contracts.Requests.Product;
using FastEndpoints;
using FluentValidation;

namespace Warehouse.Validators.Product
{
    public class PutProductValidator : Validator<PutProduct>
    {
        public PutProductValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Product id can't be null")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Product identifier cannot be less than zero.");
            RuleFor(x => x.DepartmentId)
                .NotNull().When(x => x.Name == null)
                .WithMessage("Set Product name or departmentId")
                .GreaterThanOrEqualTo(0).When(x => x.Name == null)
                .WithMessage("DepartmentId can't be less than 0");
            RuleFor(x => x.Name)
                .NotEmpty().When(x => x.DepartmentId == null)
                .WithMessage("Set Product name or departmentId");
        }
    }
}
