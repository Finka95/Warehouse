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
    public class PostWorkerEndpoint : Endpoint<PostWorker, WorkerDTOWithDetails, WorkerDTOWithDetailsMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Post("api/workers");
            Description(b => b.WithTags("Worker"));
            Summary(s =>
            {
                s.Summary = "Create a new worker.";
            });
        }

        public PostWorkerEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(PostWorker createWorker, CancellationToken ct)
        {
            Logger.LogDebug("Create an worker");
            Worker worker = Map.ToEntity(createWorker);
            _repository.Worker.CreateWorker(worker);
            _repository.Save();
            var workerDTO = Map.FromEntity(worker);
            await SendAsync(workerDTO, cancellation: ct);
        }
    }
}
