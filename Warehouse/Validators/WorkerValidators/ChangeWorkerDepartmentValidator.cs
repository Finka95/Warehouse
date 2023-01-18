using Contracts.Requests.Worker;
using FastEndpoints;
using FluentValidation;

namespace Warehouse.Validators.WorkerValidators
{
    public class ChangeWorkerDepartmentValidator : Validator<ChangeWorkerDepartment>
    {
        public ChangeWorkerDepartmentValidator()
        {
            RuleFor(x => x.WorkerId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Worker identifier cannot be less than zero.");
            RuleFor(x => x.DepartmentId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Department identifier cannot be less than zero.");
        }
    }
}
