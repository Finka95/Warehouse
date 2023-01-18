using Contracts.Requests.Product;
using FastEndpoints;
using FluentValidation;

namespace Warehouse.Validators.Product
{
    public class PostProductValidator : Validator<PostProduct>
    {
        public PostProductValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty()
                .WithMessage("Name of product cant't be null or empty");
        }
    }
}
