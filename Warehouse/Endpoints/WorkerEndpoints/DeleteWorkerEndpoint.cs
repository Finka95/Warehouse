using Contracts.Interfaces;
using Contracts.Requests.Worker;
using Contracts.Responses.Worker;
using Entities.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Warehouse.Mappers.WorkerMappers;

namespace Warehouse.Endpoints.WorkerEndpoints
{
    public class DeleteWorkerEndpoint : Endpoint<GetDeleteWorker, WorkerDTOWithDetails, WorkerDTOWithDetailsMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Delete("api/workers/{Id}");
            Description(b => b.WithTags("Worker"));
            Summary(s =>
            {
                s.Summary = "Delete worker";
                s.Params["Id"] = "Worker unique identifier";
            });
        }

        public DeleteWorkerEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(GetDeleteWorker worker, CancellationToken ct)
        {
            Logger.LogDebug($"Delete worker");
            var workerDBWithDetails = _repository.Worker.GetWorkerWithDetailsById(worker.Id);
            if (workerDBWithDetails == null)
                await SendNotFoundAsync(cancellation: ct);
            else
            {
                _repository.Worker.DeleteWorker(workerDBWithDetails);
                _repository.Save();
                var workerDTOWithDetails = Map.FromEntity(workerDBWithDetails);
                await SendAsync(workerDTOWithDetails, cancellation: ct);
            }
        }
    }
}
