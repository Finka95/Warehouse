using FastEndpoints;
using Microsoft.Extensions.Logging;
using Contracts.Responses;
using Entities.Models;
using Warehouse.Mappers;
using Contracts.Interfaces;

namespace Warehouse.Endpoints.WorkerEndpoints
{
    [HttpGet("api/workers/{workerId}")]
    public class GetWorkerEndpoint : Endpoint<int, WorkerDTO, WorkerMapper>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly WorkerMapper _workerMapper;

        public GetWorkerEndpoint(IRepositoryWrapper repository, WorkerMapper workerMapper)
        {
            _workerMapper = workerMapper;
            _repository = repository;
        }

        public override async Task HandleAsync(int id, CancellationToken ct)
        {
            Logger.LogDebug("Retrivering workers");
            var worker = _repository.Worker.GetWorkerById(id);

            if (worker == null)
                await SendNotFoundAsync();
            else
            {
                var workerDTO = _workerMapper.FromEntity(worker);
                await SendAsync(workerDTO, cancellation: ct);
            }
        }
    }
}
