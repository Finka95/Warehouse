using FastEndpoints;
using Warehouse.Mappers.WorkerMappers;
using Contracts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Contracts.Responses.Worker;

namespace Warehouse.Endpoints.WorkerEndpoints
{
    public class GetWorkersEndpoint : EndpointWithoutRequest<WorkersDTO, WorkerDTOWithoutRequestMapper>
    {
        private readonly IRepositoryWrapper _repository;

        public override void Configure()
        {
            Get("api/workers");
            Description(b => b.WithTags("Worker"));
            Summary(s =>
            {
                s.Summary = "Use this method to get all workers.";
            });
        }

        public GetWorkersEndpoint(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            Logger.LogDebug("Retrivering workers");
            var workers = _repository.Worker.GetAllWorkers();

            var workersDto = new WorkersDTO
            {
                Workers = workers.Select(Map.FromEntity)
            };

            await SendAsync(workersDto, cancellation: ct);
        }
    }
}
