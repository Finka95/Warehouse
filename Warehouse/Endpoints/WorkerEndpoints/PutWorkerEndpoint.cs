using Contracts.Interfaces;
using Contracts.Requests.Worker;
using Contracts.Responses.Worker;
using Entities.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Warehouse.Mappers.WorkerMappers;

namespace Warehouse.Endpoints.WorkerEndpoints
{
    public class PutWorkerEndpoint : Endpoint<PutWorker, WorkerDTOWithDetails, PutWorkerMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Put("api/workers");
            Description(b => b.WithTags("Worker"));
            Summary(s =>
            {
                s.Summary = "Update worker information.";
            });
        }

        public PutWorkerEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(PutWorker updateWorker, CancellationToken ct)
        {
            Logger.LogDebug($"Update an worker");
            var workerDB = _repository.Worker.GetWorkerById(updateWorker.Id);
            if (workerDB == null)
                await SendNotFoundAsync(cancellation: ct);
            else
            {
                workerDB = Map.UpdateEntity(updateWorker, workerDB);
                _repository.Worker.UpdateWorker(workerDB);
                _repository.Save();
                var workerDTO = Map.FromEntity(workerDB);
                await SendAsync(workerDTO, cancellation: ct);
            }
        }
    }
}
