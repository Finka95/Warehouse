using Contracts.Interfaces;
using Contracts.Requests.Worker;
using Contracts.Responses.Worker;
using FastEndpoints;
using Warehouse.Mappers.WorkerMappers;

namespace Warehouse.Endpoints.WorkerEndpoints
{
    public class DeleteDepartmentFromWorkerEndpoint : Endpoint<ChangeWorkerDepartment, WorkerDTOWithDetails, WorkerDTOWithDetailsMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Delete("api/workers/{@workerId}/{@departmentId}", x => new { x.WorkerId, x.DepartmentId });
            Description(b => b.WithTags("Worker"));
            Summary(s =>
            {
                s.Summary = "Removes worker from the department";
                s.Description = "Use this method to remove an worker from the department";
                s.Params["workerId"] = "Worker unique identifier";
                s.Params["departmentId"] = "Department unique identifier";
            });
        }

        public DeleteDepartmentFromWorkerEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(ChangeWorkerDepartment patchWorker, CancellationToken ct)
        {
            Logger.LogDebug("Remove worker from the department");
            var workerDb = _repository.Worker.GetWorkerWithDetailsById(patchWorker.WorkerId);
            var departmentDb = _repository.Department.GetDepartmentWithDetailsById(patchWorker.DepartmentId);

            if (workerDb == null)
                await SendStringAsync("No such worker in the database.", statusCode: 404, cancellation: ct);
            else if (departmentDb == null)
                await SendStringAsync("No such department in the database.", statusCode: 404, cancellation: ct);
            else if (!workerDb!.Departments!.Contains(departmentDb))
                await SendStringAsync("This worker is no longer part of this department", statusCode: 400, cancellation: ct);
            else
            {
                
                workerDb.Departments!.Remove(departmentDb);
                _repository.Worker.UpdateWorker(workerDb);
                _repository.Save();
                var workerDTOWithDetails = Map.FromEntity(workerDb);
                await SendAsync(workerDTOWithDetails, cancellation: ct);
            }
        }
    }
}
