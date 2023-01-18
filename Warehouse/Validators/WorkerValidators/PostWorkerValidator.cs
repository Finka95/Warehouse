using Contracts.Requests.Worker;
using FastEndpoints;
using FluentValidation;

namespace Warehouse.Validators.WorkerValidators
{
    public class PostWorkerValidator : Validator<PostWorker>
    {
        public PostWorkerValidator()
        {
            RuleFor(w => w.FirstName)
                .MaximumLength(50)
                .WithMessage("Worker first name must be less than 50 characters.")
                .NotEmpty()
                .WithMessage("Worker name can't be empty.");

            RuleFor(w => w.LastName)
                .MaximumLength(50)
                .WithMessage("Worker last name must be less than 50 characters.")
                .NotEmpty()
                .WithMessage("Worker last name can't be empty.");
        }
    }
}
