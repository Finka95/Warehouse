using Contracts.Requests.Product;
using FastEndpoints;
using FluentValidation;

namespace Warehouse.Validators.Product
{
    public class GetDeleteProductValidator : Validator<GetDeleteProduct>
    {
        public GetDeleteProductValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Product identifier cannot be less than zero.");
        }
    }
}
