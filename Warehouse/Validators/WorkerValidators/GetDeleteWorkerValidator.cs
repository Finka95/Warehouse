using Contracts.Requests.Worker;
using FastEndpoints;
using FluentValidation;

namespace Warehouse.Validators.WorkerValidators
{
    public class GetDeleteWorkerValidator : Validator<GetDeleteWorker>
    {
        public GetDeleteWorkerValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Worker identifier cannot be less than zero.");
        }
    }
}
