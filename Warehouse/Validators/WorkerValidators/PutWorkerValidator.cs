using Contracts.Requests.Worker;
using FastEndpoints;
using FluentValidation;

namespace Warehouse.Validators.WorkerValidators
{
    public class PutWorkerValidator : Validator<PutWorker>
    {
        public PutWorkerValidator()
        {
            RuleFor(w => w.Id)
                .NotNull()
                .WithMessage("Worker Id can't be null.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Worker identifier cannot be less than zero");
            RuleFor(w => w.FirstName)
                .MaximumLength(50)
                .WithMessage("Worker first name must be less than 50 characters.")
                .NotEmpty()
                .WithMessage("First Name cant't be empty");
            RuleFor(w => w.LastName)
                .MaximumLength(50)
                .WithMessage("Worker last name must be less than 50 characters.")
                .NotEmpty()
                .WithMessage("Last Name cant't be empty");
        }
    }
}
