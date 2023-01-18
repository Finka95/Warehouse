using FastEndpoints;
using Microsoft.Extensions.Logging;
using Entities.Models;
using Contracts.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Contracts.Requests.Worker;
using Warehouse.Mappers.WorkerMappers;
using Contracts.Responses.Worker;

namespace Warehouse.Endpoints.WorkerEndpoints
{
    public class GetWorkerEndpoint : Endpoint<GetDeleteWorker, WorkerDTOWithDetails, WorkerDTOWithDetailsMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Get("api/workers/{Id}");
            Description(b => b.WithTags("Worker"));
            Summary(s =>
            {
                s.Summary = "Get worker with details";
                s.Params["Id"] = "Worker unique identifier";
            });
        }

        public GetWorkerEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(GetDeleteWorker getWorker, CancellationToken ct)
        {
            Logger.LogDebug("Retrivering worker");
            var worker = _repository.Worker.GetWorkerWithDetailsById(getWorker.Id);

            if (worker == null)
                await SendNotFoundAsync(cancellation: ct);
            else
            {
                var workerDTOWithDetails = Map.FromEntity(worker);
                await SendAsync(workerDTOWithDetails, cancellation: ct);
            }
        }
    }
}
