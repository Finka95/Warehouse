using Contracts.Interfaces;
using Microsoft.Extensions.Logging;
using FastEndpoints;
using Microsoft.Identity.Client.Extensibility;
using Contracts.Requests.Worker;
using Microsoft.AspNetCore.Authorization;
using Warehouse.Mappers.WorkerMappers;
using Contracts.Responses.Worker;

namespace Warehouse.Endpoints.WorkerEndpoints
{
    public class PostDepartmentToWorkerEndpoint : Endpoint<ChangeWorkerDepartment, WorkerDTOWithDetails, WorkerDTOWithDetailsMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Post("api/workers/{@workerId}/{@departmentId}", x => new {x.WorkerId, x.DepartmentId});
            Description(b => b.WithTags("Worker"));
            Summary(s =>
            {
                s.Summary = "Add an worker to the department";
                s.Description = "Use this method to add an worker to the department";
                s.Params["workerId"] = "Worker unique identifier";
                s.Params["departmentId"] = "Department unique identifier";
            });
        }

        public PostDepartmentToWorkerEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(ChangeWorkerDepartment patchWorker, CancellationToken ct)
        {
            Logger.LogDebug("Add worker to the department");
            var workerDb = _repository.Worker.GetWorkerWithDetailsById(patchWorker.WorkerId);
            var departmentDb = _repository.Department.GetDepartmentWithDetailsById(patchWorker.DepartmentId);

            if (workerDb == null)
                await SendStringAsync("No such worker in the database.", statusCode: 404, cancellation: ct);
            else if (departmentDb == null)
                await SendStringAsync("No such department in the database.", statusCode: 404, cancellation: ct);
            else if (workerDb!.Departments!.Contains(departmentDb))
                await SendStringAsync("This worker is already in this department.", statusCode: 400, cancellation: ct);
            else
            {
                workerDb.Departments!.Add(departmentDb);
                _repository.Worker.UpdateWorker(workerDb);
                _repository.Save();
                var workerDTOWithDetails = Map.FromEntity(workerDb);
                await SendAsync(workerDTOWithDetails, cancellation: ct);
            }
        }
    }
}
